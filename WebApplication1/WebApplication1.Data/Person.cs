namespace WebApplication1.Data;

public class Person
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobPosition { get; set; }
    public double Salary { get; set; }
    public double WorkExperience { get; set; }
    // one to many 
    public Adress adress;
    public int AdressId { get; set; }
    
    
}