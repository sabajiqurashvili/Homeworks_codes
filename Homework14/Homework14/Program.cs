namespace Homework14;

class Program
{
    static void Main(string[] args)
    {
        var factory = new VictorianFurnitureFactory();
        var client = new Client(factory);
        client.ShowRoom();
        var AFactory = new ModernFurnitureFactory();
        var chair = AFactory.CreateChair();
        chair.SitOn();
    }
}