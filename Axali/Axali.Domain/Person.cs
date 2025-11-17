namespace Homework16.Model;

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
    public List<Adress> adresses { get; set; } = new List<Adress>();
    
    
}