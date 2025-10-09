using System.Text.Json;
using System.Xml;

namespace H11N4;

class Program
{
    static void Main(string[] args)
    {
        string jsonstring =
            File.ReadAllText(@"C:\Users\Jikura\Desktop\davalebebi\Homeworks\HomeWork11\H11N4\Birthday.json");
        Person person = JsonSerializer.Deserialize<Person>(jsonstring);
        DateTime currentDate = DateTime.Parse(person.CurrentDate);
        DateTime birthday = DateTime.Parse(person.Birthday);
        Console.WriteLine((birthday-currentDate).Days);

       
    }
}