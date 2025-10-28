namespace Homework14N2;

class Program
{
    static void Main(string[] args)
    {
        var actor = new ActorProxy();
        actor.Act(true);
        actor.Act(false);
    }
    
}