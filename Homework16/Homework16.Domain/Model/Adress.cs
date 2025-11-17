namespace Homework16.Model;

public class Adress
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int HomeNumber { get; set; }
    
    
    public Person person { get; set; }
    public int PersonId { get; set; }
}