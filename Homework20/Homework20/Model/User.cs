namespace Homework20.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public string Role { get; set; }
    
}

public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
}