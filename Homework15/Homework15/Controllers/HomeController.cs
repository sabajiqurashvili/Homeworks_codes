using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Homework15.Models;

namespace Homework15.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("appointment")]
    [HttpGet]
    public IActionResult createPerson()
    {
        return View();
    }

    [Route("appointment")]
    [HttpPost]
    public IActionResult createPerson(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View(person);
        }
        var jsonpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/AppointedPersons.json");
        List<Person> persons = new List<Person>();
        if (System.IO.File.Exists(jsonpath))
        {
            var existingjson = System.IO.File.ReadAllText(jsonpath);
            if (!string.IsNullOrEmpty(existingjson))
            {
                persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(existingjson);
            }
        }
        persons.Add(person);
        var json = System.Text.Json.JsonSerializer.Serialize(persons,new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(jsonpath, json);
        
        return RedirectToAction("Success");
    }
    
    
   
    public IActionResult Success()
    {
        return View();
    }

    [Route("appointment/show")]
    public IActionResult ShowAppointment()
    {
        var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data");
        var filepath = Path.Combine(folderpath, "AppointedPersons.json");
        if (!System.IO.File.Exists(filepath)) return View("ShowAppointment", new List<Person>());
        var json = System.IO.File.ReadAllText(filepath);
        var persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(json);
        
        return View("ShowAppointment", persons);
    }
}