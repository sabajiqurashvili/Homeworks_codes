namespace Homework14N2;

public class Acting
{
}

public interface IActor
{
    void Act(bool isDengerous);
}

public class MainActor : IActor
{
    public void Act(bool isDengerous)
    {
        Console.WriteLine("Main character Acting in simple scene");
    }
}

public class StuntDouble : IActor
{
    public void Act(bool isDengerous)
    {
        if (isDengerous)
        {
            Console.WriteLine("Stunt double performing in dangerous scene");
        }
        else
        {
            Console.WriteLine("Stunt double acting in simple scene");
        }
    }
}

public class ActorProxy : IActor
{
    MainActor mainActor;
    StuntDouble stuntDouble;
    public void Act(bool isDengerous)
    {
        if (isDengerous)
        {
            if (stuntDouble == null)
            {
                stuntDouble = new StuntDouble();
                stuntDouble.Act(true);
                Console.WriteLine("Proxy : dangerous scene| actor : stuntDouble");
            }
        }
        else
        {
            if (mainActor == null)
            {
                mainActor = new MainActor();
                mainActor.Act(true);
                Console.WriteLine("Proxy : Easy scene | actor : MainActor");
            }
        }
    }
}

