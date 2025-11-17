using System.Text.Json.Serialization;

namespace Homework20.Domain;

public class Adress
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int HomeNumber { get; set; }
    
    
    public List<Person> persons { get; set; } = new List<Person>();
}