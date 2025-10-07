namespace H11N2;

class Program
{
    static void Main(string[] args)
    {
        string basePath = @"C:\Users\Jikura\Desktop\davalebebi\Homeworks\HomeWork11\H11N2";
        Console.WriteLine("Enter path : ");
        string input = Console.ReadLine();
        string path = Path.Combine(basePath, input);
        if (File.Exists(path))
        {
            Console.WriteLine(File.ReadAllText(path));
        }
        else
        {
            Console.WriteLine("Enter number : ");
            int number = int.Parse(Console.ReadLine());
            MultiplicationTable(path,number);
            Console.WriteLine(File.ReadAllText(path));
        }
    }

    static void MultiplicationTable(string path,int n)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    sw.WriteLine($"{i} * {j} = {i * j}");
                }

                sw.WriteLine("------------");
            }
        }
    }
}