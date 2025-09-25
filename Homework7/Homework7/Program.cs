namespace Homework7;

class Program
{
    static void Main(string[] args)
    {
        //N1
        // Console.WriteLine("Enter Radius : ");
        // var radius = int.Parse(Console.ReadLine());
        // var s1 = (2 * radius) * (2 * radius);
        // var s2 = 2 * radius * radius;
        // var dif = s1 - s2;
        // Console.WriteLine($"dif = {dif} while radius = {radius}");
        
        //N2
        
        var input = new Char[] { '@', '@', '@', '@', '@' };
        var res = input.All(x => x == input[Array.IndexOf(input, x)+1]);
        Console.WriteLine(res ? "Yes" : "No");
       

    }
}
