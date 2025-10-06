namespace H9N2;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int AdmissionYear { get; set; }

    private string Subject;
    
    

    public Student(string name, int age, int admissionYear)
    {
        this.Name = name;
        this.Age = age;
        this.AdmissionYear = admissionYear;
    }

    public void ChooseSubject(string subject)
    {
        Subject = subject;
    }

    public string getSubject()
    {
        return Subject;
    }

    public int TimeBeforaGraduation()
    {
        return 4 - (DateTime.Now.Year - this.AdmissionYear);
    }
}