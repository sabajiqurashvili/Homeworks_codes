namespace Homework6;

class Program
{
    static void Main(string[] args)
    {
        // N1

        Console.Write("Enter array length : ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter array element : ");
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("your array : ");

        foreach (var num in array)
        {
            Console.Write(num + " ");
        }

        int countForEvens = 0;
        int countForOdds = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                countForEvens++;
            }
            else
            {
                countForOdds++;
            }
        }
        var evensArray = new int[countForEvens];
        var oddsArray = new int[countForOdds];
        int e = 0;
        int o = 0;

        for (int i = 0; i < array.Length; i++)
        {
           
            if (array[i] % 2 == 0)
            {
                evensArray[e] = array[i];
                e++;
            }
            else
            {
                oddsArray[o] = array[i];
                o++;
            }
        }

        Console.WriteLine("\neven array : ");
        foreach (var evenNums in evensArray)
        {
            Console.Write(evenNums + " ");
        }

        Console.WriteLine("\nodd array : ");
        foreach (var oddNums in oddsArray)
        {
            Console.Write(oddNums + " ");
        }

    }
}
