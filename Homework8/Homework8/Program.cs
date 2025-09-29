using System.Threading.Channels;

namespace Homework8;

class Program
{
    static void Main(string[] args)
    {
       //N1
       
       Console.WriteLine(PowersIninterval(49, 71, 2));
       
       //N2
       
       Console.WriteLine(Couplesofsocks("AAABBCC"));
       
       //N3 
       
       Console.WriteLine(CommonLastText("multiplication","substraction"));
       
       //N4
       
       List<string> stringList = new List<string>() { "saba", "giorgi", "lasha"};
       GenericExample(stringList);
       List<int> intList = new List<int>() {5,7,10 };
       GenericExample(intList);
       List<bool> boolList = new List<bool>() { true, false, true, false, true, false, true, false, true };
       GenericExample(boolList);
       
       //N5

       Console.WriteLine(SymbolsInNumberByRecursion(1355));
       
       //N6

       int[] arr1 = { 1, 4, 1, 2 };
       int[] arr2 = { 1, 2, 3, 4, 5 };

       string[] arr3 = { "ab", "cd", "ab" };
       string[] arr4 = { "ab", "cd", "ef" };

       Console.WriteLine(Haveduplicates(arr1));
       Console.WriteLine(Haveduplicates(arr2));
       Console.WriteLine(Haveduplicates(arr3));
       Console.WriteLine(Haveduplicates(arr4));



    }
    
    
// for N1
    static int PowersIninterval(int a, int b, int n)
    {
        int result = 0;
        while (a <= b)
        {
            double x = Math.Pow(a, 1.0/n);
            if (IsInteger(x))
            {
                result++;
            }
            a++;
        }
        return result;
    }

    static bool IsInteger(double number)
    {
        if (number % 1 == 0) return true;
        return false;
    }
    
    //for N2
    static int Couplesofsocks(string s)
    {
        int result = 0;
        var couples = s.GroupBy(x => x);
        foreach (var couple in couples)
        {
            if (couple.Count() / 2 != 0)
            {
                result+=couple.Count()/2;
            }
        }
        return result;
        
    }
    
    // for N3

    static string CommonLastText(string s1, string s2)
    {
        string result = "";
        for (int i = s1.Length-1,j=s2.Length-1; i >= 0 && j>=0; i--,j--)
        {
            if (s1[i] == s2[j])
            {
                result += s1[i];
            }
        }
        result = ReverseString(result);

        return result;
    }

    static string ReverseString(string s)
    {
        string result = "";
        for (int i = s.Length-1; i >= 0; i--)
        {
            result += s[i];
        }
        return result;
    }
    
    // for N4

    static void GenericExample<T>(List<T> list)
    {
        
        if (typeof(T) == typeof(string))
        {
            var stringList = list.Cast<string>().ToList();
            foreach (var str in stringList)
            {
                Console.Write(str.ToUpper() + " ");
               
            }

            Console.WriteLine();
        }
        else if (typeof(T) == typeof(int))
        {
            var intList = list.Cast<int>().ToList();
            Console.WriteLine($"sum of this int list is {intList.Sum()}");
            
        }
        else
        {
            if (typeof(T) == typeof(bool))
            {
                var boolList = list.Cast<bool>().ToList();
                Console.Write($"first : {boolList[0]}  last : {boolList[boolList.Count - 1]}  middle : {boolList[boolList.Count/2]}");
                Console.WriteLine();
            }
            
        }
    }
    
    // for N5

    static string SymbolsInNumberByRecursion(int num)
    {
        if (num / 10 == 0)
        {
            return num.ToString();
        }
        
        return SymbolsInNumberByRecursion(num/10) + "-" + (num%10);

    }
    
    // for N6

    static bool Haveduplicates<T>(T[] arr)
    {
        var groupedArray = arr.GroupBy(x => x);
        foreach (var element in groupedArray)
        {
            if (element.Count() > 1)
            {
                return true;
            } 
        }

        return false;
    }
    
}