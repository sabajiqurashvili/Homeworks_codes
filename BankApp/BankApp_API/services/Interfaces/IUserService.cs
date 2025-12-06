using BankApp_API.services.Models;
using BankApp_Domain;

namespace BankApp_API.services;

public interface IUserService
{
    public Task<User> RegisterUser(RegisterDto registerDto);
    public LoginResponse LoginUser(LoginDto loginDto);
    public User GetUserById(int id);
    
}