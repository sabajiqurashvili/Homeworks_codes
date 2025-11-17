using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;

namespace WebApplication1.Controllers;

public class PersonController : Controller
{
    private readonly PersonContext _context;

    public PersonController(PersonContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
}