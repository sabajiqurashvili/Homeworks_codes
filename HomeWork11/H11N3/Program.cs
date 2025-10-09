using System.Xml.Linq;

namespace H11N3;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\Jikura\Desktop\davalebebi\Homeworks\HomeWork11\H11N3\file.xml";
        List<string> list = SplitStringEqual("programming", 2);
        var elements = list.Select((item, i) => new XElement(item, $"string {i + 1}"));

        XDocument doc = new XDocument
        (
            new XElement("strings", elements)
        ); 
        doc.Save(path);
        
    }

    static List<string> SplitStringEqual(string str, int n)
    {
        List<string> result = new List<string>();
        int quanity = (int)Math.Ceiling(str.Length / (double)n);


        for (int i = 0; i < str.Length; i += quanity)
        {
            result.Add(str.Substring(i, Math.Min(quanity, str.Length - i)));
        }

        return result;
    }
}