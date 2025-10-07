namespace HomeWork11;

class Program
{
    static void Main(string[] args)
    {
        string basePath = @"C:\Users\Jikura\Desktop\davalebebi\Homeworks\HomeWork11\HomeWork11";
        Console.WriteLine("Enter path : ");
        string input = Console.ReadLine();
        string path = Path.Combine(basePath, input);
        if (File.Exists(path))
        {
            OutputTofile(path);
        }
        else
        {
            Console.WriteLine("Enter Length : ");
            int inputLength = int.Parse(Console.ReadLine());
            InputTofile(path, inputLength);
            OutputTofile(path);
        }
       
        
        
    }

    static void InputTofile(string inputPath, int n)
    {
        if (!File.Exists(inputPath))
        {
            using (StreamWriter sw = new StreamWriter(inputPath))
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Input Line {i} : ");
                    sw.WriteLine(Console.ReadLine());
                }
            }
        }
    }

    static void OutputTofile(string outputPath)
    {
        if (File.Exists(outputPath))
        {
            using (StreamReader sr = new StreamReader(outputPath))
            {
                string[] line = File.ReadAllLines(outputPath);
                int length = line.Length;
                Console.WriteLine(line[length - 1]);
                
            }
        }
    }
}