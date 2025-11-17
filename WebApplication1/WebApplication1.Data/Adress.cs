namespace WebApplication1.Data;

public class Adress
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int HomeNumber { get; set; }
    
    
  public List<Person> Persons { get; set; } = new List<Person>();
}