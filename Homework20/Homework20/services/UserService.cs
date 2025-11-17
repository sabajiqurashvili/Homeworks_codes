using Homework20.Controllers;
using Homework20.Data;
using Homework20.Domain;
using Homework20.Model;

namespace Homework20.services;

public interface IUserService
{
    User Login(LoginRequest model);
    User GetById(int id);
}

public class UserService : IUserService
{
    private List<User> _users = new List<User>()
    {
        new User { Id = 1, Name = "saba", LastName = "jikurashvili", UserName = "saba", Password = "saba",Role = "Admin"},
        new User { Id = 2, Name = "giorgi", LastName = "giorgadze", UserName = "giorgi", Password = "giorgi",Role = "User"}
    };
    
    public User Login(LoginRequest model)
    {
        if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password)) return null;
        var user = _users.SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
        if(user == null) return null;
        return user;

    }

    public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
}