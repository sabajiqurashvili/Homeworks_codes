using System.Diagnostics;
using System.Threading.Channels;

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

        // var input = new Char[] { '@', '@', '@', '@', '@' };
        // var res = input.All(x => x == input[Array.IndexOf(input, x)+1]);
        // Console.WriteLine(res ? "Yes" : "No");
        //

        //N3

        // Console.WriteLine("Enter wins : ");
        // int wins = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter los : ");
        // int los = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter Draws : ");
        // int draws = int.Parse(Console.ReadLine());
        //
        // var res = wins * 3 + draws;
        // Console.WriteLine(res);

        //N4

        //     int[] arr = new int[7];
        //     string[] Weekdays = new string[]
        //     {
        //         "Monday",
        //         "Tuesday",
        //         "Wednesday",
        //         "Thursday",
        //         "Friday",
        //         "Saturday",
        //         "Sunday"
        //     };
        //
        // for (int i = 0; i < 7; i++)
        //     {
        //         Console.WriteLine($"enter hours of {Weekdays[i]} : ");
        //         int hours = int.Parse(Console.ReadLine());
        //         arr[i] = hours;
        //     }
        //
        //     int overtimeBonus = 5;
        //     int hourlypay = 10;
        //     int weekdaysincome = 0;
        //     int weekendincome = 0;
        //     
        //     for (int i = 0; i < 5; i++)
        //     {
        //         if (arr[i] <= 8)
        //         {
        //             weekdaysincome += arr[i]*hourlypay;
        //         }
        //         else
        //         {
        //             weekdaysincome += 8*hourlypay + overtimeBonus*(arr[i] - 8);
        //         }
        //     }
        //
        //     for (int i = 5; i < 7; i++)
        //     {
        //         weekendincome += arr[i]*hourlypay*2;
        //     }
        //     int earned = weekdaysincome + weekendincome;
        //     foreach (var hour in arr)
        //     {
        //         Console.Write(hour + " ");
        //     }
        //
        //     Console.WriteLine();
        //
        //     Console.WriteLine($"This week you have earned {earned}$");
            


        //N5

        // int[] arr = {5, 5, 5 ,7,4,5};
        // int count = 0;
        // for (int i = 1; i < arr.Length; i++)
        // {
        //     if (arr[i - 1] < arr[i])
        //     {
        //         count++;
        //     }
        //     
        // }
        //
        // foreach (var num in arr)
        // {
        //     Console.Write(num + " ");
        // }
        //
        // Console.WriteLine();
        // Console.WriteLine(count);


        //N6
        // string[] arr = new string[] { "Hello", "World", "Programming", "communication" };
        // Console.WriteLine("Enter lenght : ");
        // int lenght = int.Parse(Console.ReadLine());
        // var res = arr.Where(x => x.Length == lenght);
        //
        // foreach (var words in res)
        // {
        //     Console.Write(words + ", ");
        // }
    }
}