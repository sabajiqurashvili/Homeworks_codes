namespace H9N3;

public class GoodStudent : Student
{
    public GoodStudent(string name) : base(name){}

    public override string Study()
    {
        return "I like studying";
    }

    public override string Read()
    {
        return "I like reading";
    }

    public override string Write()
    {
        return "I like writing";
    }

    public override string Relax()
    {
        return "i don't have time to relax";
    }
    
}