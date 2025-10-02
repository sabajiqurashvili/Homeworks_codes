namespace H9N3;

public class LazyStudent : Student
{
    public LazyStudent(string name) : base(name) {}

    public override string Study()
    {
        return "i don't have time to study";
    }
    public override string Read()
    {
        return "i don't have time to read";
    }

    public override string Write()
    {
        return "i don't have time to write";
    }

    public override string Relax()
    {
        return "i always have time to relax";
    }
}