using BankApp_API.services;
using BankApp_API.services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp_API.Controllers;

[ApiController]
[Route("API/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
    {
        try
        {
            var validation = new Validations.RegisterDtoValidator();
            var validationResults = validation.Validate(registerDto);
            if (!validationResults.IsValid)
            {
                var errors = validationResults.Errors.Select(error => error.ErrorMessage);
                return BadRequest(errors);
            }
            var result = await _userService.RegisterUser(registerDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var validataion = new Validations.LoginDtoValidator();
            var validationResult = validataion.Validate(loginDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(errors);
            }
            var result = _userService.LoginUser(loginDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        try
        {
            var result = _userService.GetUserById(id);
            if(result == null) return NotFound("User not found");
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}