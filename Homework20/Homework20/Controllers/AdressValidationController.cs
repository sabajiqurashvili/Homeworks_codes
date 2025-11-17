using Homework20.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Homework20.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdressValidationController : Controller
{
    [HttpPost]
    public IActionResult CreateAdress(Adress adress)
    {
        var validation = new Validations.AdressValidations();
        var result = validation.Validate(adress);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errors);
        }

        return Ok(adress);
    }
}