using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Homework20.Data;
using Homework20.Model;
using Homework20.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Homework20.Controllers;

[Authorize]
[ApiController]
[Route("API/[Controller]")] 

public class UserController : Controller
{
    
    private readonly IUserService _userService;
    private readonly AppSettings _settings;

    public UserController(IUserService userService,IOptions<AppSettings> settings)
    {
        _userService = userService;
        _settings = settings.Value;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginRequest model)
    {
        var user = _userService.Login(model);
        if(user == null) return BadRequest("Invalid username or password");
        var token = GenerateToken(user);
        UserWithToken userWithToken = new UserWithToken()
        {
            Id = user.Id,
            Lastname = user.LastName,
            Name = user.Name,
            Username = user.UserName,
            Token = token
        };
            
        
        return Ok(userWithToken);
    }

    [HttpGet("{id}")]
   
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        if(user == null) return NotFound();
        return Ok(user);
    }

    private string GenerateToken(User user)
    {
        var tokenhandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Secret);

        var TokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenhandler.CreateToken(TokenDescriptor);
        var tokenstring = tokenhandler.WriteToken(token);
        
        return tokenstring;
    }
}