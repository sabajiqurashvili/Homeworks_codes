using Homework20.Data;
using Homework20.Domain;
using Homework20.Filters;
using Homework20.interfaces;
using Homework20.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework20.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PersonController : Controller, IPerson<Person>
{
    private readonly PersonContext _context;

    public PersonController(PersonContext context)
    {
        _context = context;
    }

    [HttpPost("AddPerson")]
    public IActionResult Add([FromBody] Person person)
    {
        var validator = new Validations.PersonValidations();
        var result = validator.Validate(person);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage);
            return BadRequest(errors);
        }

        _context.Persons.Add(person);
        _context.SaveChanges();
        return Ok(person);
    }

    [HttpGet("GetAllPerson")]
    public IActionResult GetAll()
    {
        List<Person> persons = _context.Persons.ToList();
        return Ok(persons);
    }

    [HttpGet("GetPersonById/{id}")]
    public IActionResult GetById(int id)
    {
        if (id <= 0) return BadRequest("Invalid Id");
        var person = _context.Persons.FirstOrDefault(x => x.Id == id);
        if (person == null) return NotFound("Person not found with this Id");
        return Ok(person);
    }

    [HttpGet("FilterPerson")]
    public IActionResult Filter([FromQuery] PersonFilter filter)
    {
        var people = _context.Persons.ToList();
        var matchedpeople = people.Where(person => person.Salary >= filter.Salary);
        return Ok(matchedpeople);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut("UpdatePerson/{id}")]
    public IActionResult Update(int id, [FromBody] Person newPerson)
    {
        var people = _context.Persons.ToList();
        var person = people.FirstOrDefault(p => p.Id == id);
        if (id <= 0) return BadRequest("Invalid Id");
        if (person == null) return NotFound("Person not found with this Id");
        person.Salary = newPerson.Salary;
        person.Adress = newPerson.Adress;
        person.FirstName = newPerson.FirstName;
        person.LastName = newPerson.LastName;
        person.JobPosition = newPerson.JobPosition;
        person.CreateDate = newPerson.CreateDate;
        person.Adress = newPerson.Adress;
        person.AdressId = newPerson.AdressId;
        _context.SaveChanges();

        return Ok(person);
    }

    [Authorize(Roles=Roles.Admin)]
    [HttpDelete("DeletePerson/{id}")]
    public IActionResult Delete(int id)
    {
        var people = _context.Persons.ToList();
        if (id < 0) return BadRequest("Invalid Id");
        var person = people.FirstOrDefault(p => p.Id == id);
        if (person == null) return NotFound("Person not found with this Id");
        _context.Persons.Remove(person);
        _context.SaveChanges();
        return Ok(_context.Persons.ToList());
    }

    [HttpDelete("DeleteAll")]
    public IActionResult DeleteAll()
    {
// Detach all tracked entities first
        foreach (var entry in _context.ChangeTracker.Entries())
        {
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

// Remove all persons
        _context.Persons.RemoveRange(_context.Persons);
        _context.SaveChanges();

// Remove all addresses
        _context.Adresses.RemoveRange(_context.Adresses);
        _context.SaveChanges();

        return Ok("everything deleted");
    }
}