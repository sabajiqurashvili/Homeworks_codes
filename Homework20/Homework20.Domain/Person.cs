namespace Homework20.Domain;

public class Person
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobPosition { get; set; }
    public Double Salary { get; set; }
    public Double WorkExperience { get; set; }
    
    public Adress Adress { get; set; }
    public int AdressId { get; set; }
    
}