namespace H9N3;

public class Student
{
    public string Name { get; set; }

    public Student(string name)
    {
        this.Name = name;
    }

    public virtual string Study()
    {
        return "Study";
    }

    public virtual string Read()
    {
        return "Read";
    }

    public virtual string Write()
    {
        return "Write";
    }

    public virtual string Relax()
    {
        return "Relax";
    }

    public virtual string StudentInfo()
    {
        return $"my name is {this.Name} \n" +
               $"{this.Study()} \n" +
               $"{this.Read()} \n" +
               $"{this.Write()} \n" +
               $"{this.Relax()} \n";
    }
}