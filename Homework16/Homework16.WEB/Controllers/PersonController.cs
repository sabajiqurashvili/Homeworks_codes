using System.Reflection.PortableExecutable;
using System.Text.Json;
using Homework16.Data;
using Homework16.Model;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;


namespace Homework16.Controllers;
[ApiController]
[Route("api/[controller]")]

public class PersonController : Controller
{
    private readonly PersonContext _context;

    public PersonController(PersonContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public IActionResult AddPerson([FromBody] Person person)
    {
        var validator = new Validations.PersonValidator();
        
        var result = validator.Validate(person);
        
       
        if (!result.IsValid)
        {
           var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
           return BadRequest(errors);
        }

        var people = LoadPeople();
        people.Add(person);
        SavePeople(people);
        return Ok(people);
    }

    [HttpGet("GET")]
    public IActionResult GetPeople()
    {
        var people = LoadPeople();
        return Ok(people);
    }

    [HttpGet("GET/{id}")]
    public IActionResult GetPersonWithId(int id)
    {
        var people = LoadPeople();
        if (people.Count < id)
        {
            return BadRequest("No Person found");
        }
        return Ok(people[id]);
    }

    [HttpGet("Search")]
    public IActionResult Search([FromQuery] PersonFilter PersonFilter)
    {
        var people = LoadPeople();
        var matchedpeople = people.Where(p => p.Salary >= PersonFilter.Salary);
        return Ok(matchedpeople);
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult DeletePerson(int id)
    {
        var people = LoadPeople();
        if (people.Count < id)
        {
            return BadRequest("No Person found to delete");
        }
        people.Remove(people[id]);
        SavePeople(people);
        return Ok(people);
    }

    [HttpPut("Update/{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] Person person)
    {
        var people = LoadPeople();
        if (people.Count < id)
        {
            return BadRequest("No Person found to update");
        }
        people[id] = person;
        SavePeople(people);
        return Ok(people);
    }
    
    

    
   
    
    
    
    
    
    
    
    
    
    
    private readonly string _filePath = @"C:\Users\Jikura\Desktop\davalebebi\Homeworks\Homework16.WEB\Homework16.WEB\MyFiles\people.json";

    private List<Person> LoadPeople()
    {
        if (System.IO.File.Exists(_filePath))
        {
            var json = System.IO.File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
        }
        return new List<Person>();
    }

    private void SavePeople(List<Person> people)
    {
        var json = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(_filePath, json);
    }
    
  
}