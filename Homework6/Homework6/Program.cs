using System.Globalization;

namespace Homework6;

class Program
{
    static void Main(string[] args)
    {
        // N1

        // Console.Write("Enter array length : ");
        // int length = int.Parse(Console.ReadLine());
        // int[] array = new int[length];
        // for (int i = 0; i < length; i++)
        // {
        //     Console.Write("Enter array element : ");
        //     array[i] = int.Parse(Console.ReadLine());
        // }
        //
        // Console.WriteLine("your array : ");
        //
        // foreach (var num in array)
        // {
        //     Console.Write(num + " ");
        // }
        //
        // int countForEvens = 0;
        // int countForOdds = 0;
        //
        // for (int i = 0; i < array.Length; i++)
        // {
        //     if (array[i] % 2 == 0)
        //     {
        //         countForEvens++;
        //     }
        //     else
        //     {
        //         countForOdds++;
        //     }
        // }
        // var evensArray = new int[countForEvens];
        // var oddsArray = new int[countForOdds];
        // int e = 0;
        // int o = 0;
        //
        // for (int i = 0; i < array.Length; i++)
        // {
        //    
        //     if (array[i] % 2 == 0)
        //     {
        //         evensArray[e] = array[i];
        //         e++;
        //     }
        //     else
        //     {
        //         oddsArray[o] = array[i];
        //         o++;
        //     }
        // }
        //
        // Console.WriteLine("\neven array : ");
        // foreach (var evenNums in evensArray)
        // {
        //     Console.Write(evenNums + " ");
        // }
        //
        // Console.WriteLine("\nodd array : ");
        // foreach (var oddNums in oddsArray)
        // {
        //     Console.Write(oddNums + " ");
        // }
        
        
        
        //N2
        
        // Dictionary<string,string> contacts = new Dictionary<string,string>();
        // while (true)
        // {
        //     Console.WriteLine("enter what you want to do: add | remove | allcontacts | exit ");
        //     string input = Console.ReadLine();
        //     if (input == "exit")
        //     {
        //         break;
        //     }
        //     if (input.ToLower() == "add" )
        //     {
        //         Console.Write("Enter first name: ");
        //         string name = Console.ReadLine();
        //         Console.Write("Enter number : ");
        //         string number = Console.ReadLine();
        //
        //         contacts.Add(name, number);
        //         Console.WriteLine($"Added contact {name} with number {number}");
        //     }
        //     else if (input.ToLower() == "remove")
        //     {
        //         Console.Write("Enter name what you want to remove: ");
        //         string name = Console.ReadLine();
        //         if (contacts.ContainsKey(name))
        //         {
        //             contacts.Remove(name);
        //             Console.WriteLine($"Removed contact {name}");
        //         }
        //         else
        //         {
        //             Console.WriteLine("There is no such contact");
        //         }
        //         
        //     }
        //     else if (input.ToLower() == "allcontacts")
        //     {
        //         foreach (var pair in contacts)
        //         {
        //             Console.WriteLine($"{pair.Key} : {pair.Value}");
        //         }
        //     }
        // }
        
        //N3

       //  Console.Write("Enter length of array: ");
       //  int length = int.Parse(Console.ReadLine());
       //  int[] array = new int[length];
       //  for (int i = 0; i < length; i++)
       //  {
       //      Console.WriteLine("Enter element: ");
       //      array[i] = int.Parse(Console.ReadLine());   
       //  }
       //
       //
       //  foreach (var num in array)
       //  {
       //      Console.Write(num + " ");
       //      
       //  }
       //
       //  Console.WriteLine();
       //  
       //
       // var groups = array.GroupBy(x => x);
       // foreach (var x in groups)
       // {
       //     Console.WriteLine($"{x.Key} appears {x.Count()} times in the array sum {x.Sum()}"); 
       // }
       
       
       //N4
       
       Console.Write("Enter length of array: ");
       int length = int.Parse(Console.ReadLine());
       int[] array = new int[length];
       for (int i = 0; i < length; i++)
       {
           Console.WriteLine("Enter element: ");
           array[i] = int.Parse(Console.ReadLine());   
       }
       
       var sortedArray = array.OrderBy(x => x).ToArray();
       Console.WriteLine("Enter n : ");
       int n = int.Parse(Console.ReadLine());
       var lastElements = sortedArray.TakeLast(n);
       foreach (var elements in lastElements)
       {
           Console.Write(elements + " ");
       }
    }
}
