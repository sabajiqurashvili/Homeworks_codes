using Axali.Data;
using Microsoft.AspNetCore.Mvc;

namespace Axali.Controllers;

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