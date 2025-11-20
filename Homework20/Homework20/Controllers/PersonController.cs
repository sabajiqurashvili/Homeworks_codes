using Homework20.Data;
using Homework20.Domain;
using Homework20.Filters;
using Homework20.interfaces;
using Homework20.Model;
using Homework20.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework20.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PersonController : Controller

{
    
    private readonly IPerson<Person> _service;

    public PersonController(IPerson<Person> service)
    {
        _service = service;
    }
    

    [HttpPost("AddPerson")]
    public IActionResult Add([FromBody] Person person)
    {
        return Ok(_service.Add(person));
    }

    [HttpGet("GetAllPerson")]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("GetPersonById/{id}")]
    public IActionResult GetById(int id)
    {
        if(id <= 0) return BadRequest("id cant't be less than 0");
        var person = _service.GetById(id);
        if(person == null) return NotFound("Person not found");
        return Ok(person);
    }

    [HttpGet("FilterPerson")]
    public IActionResult Filter([FromQuery] PersonFilter filter)
    {
        
        return Ok(_service.Filter(filter));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut("UpdatePerson/{id}")]
    public IActionResult Update(int id, [FromBody] Person newPerson)
    {
        if (id <= 0)
            return BadRequest("Invalid Id");

        if (newPerson == null)
            return BadRequest("No data provided");

        // Call service to update
        var updatedPerson = _service.Update(id, newPerson);

        if (updatedPerson == null)
            return NotFound("Person not found");

        return Ok(updatedPerson);
    }

    [Authorize(Roles=Roles.Admin)]
    [HttpDelete("DeletePerson/{id}")]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid Id");

        bool deleted = _service.Delete(id);

        if (!deleted)
            return NotFound("Person not found");

        return Ok("Deleted successfully");
    }

  
  
}