namespace Homework14;

public class ConcretClasses
{
}

public class ArtDecoChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("sitting on art deco chair");
    }
}

public class ArtDecoSofa : ISofa
{
    public void LieOn()
    {
        Console.WriteLine("lie on art deco sofa");
    }
}

public class ArtDecoCoffeeTable : ICoffeeTable
{
    public void PutOn()
    {
        Console.WriteLine("putting on art deco coffee table");
    }
}

public class VictorianChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("sitting on victorian chair");
    }
}

public class VictorianSofa : ISofa
{
    public void LieOn()
    {
        Console.WriteLine("lie on victorian sofa");
    }
}

public class VictorianCoffeeTable : ICoffeeTable
{
    public void PutOn()
    {
        Console.WriteLine("putting on victorian coffee table");
    }
}
public class ModernChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("sitting on modern chair");
    }
}

public class ModernSofa : ISofa
{
    public void LieOn()
    {
        Console.WriteLine("lie on modern deco sofa");
    }
}

public class ModernCoffeeTable : ICoffeeTable
{
    public void PutOn()
    {
        Console.WriteLine("putting on modern coffee table");
    }
}



public class ArtDecoFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ArtDecoChair();
    }

    public ISofa CreateSofa()
    {
        return new ArtDecoSofa();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
        return new ArtDecoCoffeeTable();
    }
}

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ISofa CreateSofa()
    {
        return new VictorianSofa();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
        return new VictorianCoffeeTable();
    }
}

public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ISofa CreateSofa()
    {
        return new ModernSofa();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
       return new ModernCoffeeTable();
    }
}

public class Client
{
    private IChair _chair;
    private ISofa _sofa;
    private ICoffeeTable _table;

    public Client(IFurnitureFactory factory)
    {
        _chair = factory.CreateChair();
        _sofa = factory.CreateSofa();
        _table = factory.CreateCoffeeTable();
    }

    public void ShowRoom()
    {
        _chair.SitOn();
        _sofa.LieOn();
        _table.PutOn();
    }
}
