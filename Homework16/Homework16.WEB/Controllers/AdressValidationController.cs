
using Homework16.Model;
using Microsoft.AspNetCore.Mvc;

namespace Homework16.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AdressValidationController : Controller
{
    [HttpPost]
    public IActionResult CreateAdress(Adress adress)
    {
        var validation = new Validations.AdressValidator();
        var result = validation.Validate(adress);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errors);
        }
        return Ok(adress);
    }
}