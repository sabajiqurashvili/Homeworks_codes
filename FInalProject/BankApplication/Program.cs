using Serilog;
using Serilog.Formatting.Json;

namespace BankApplication;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                new JsonFormatter(),
                @"C:\Users\Jikura\Desktop\davalebebi\Homeworks\FInalProject\BankApplication\logs.json",
                rollingInterval: RollingInterval.Day, // optional
                shared: false // safer than true for single process
            )
            .CreateLogger();


        Card card = new Card();
        Console.WriteLine("Enter Name :");
        string name = Console.ReadLine();
        card.FirstName = name;
        Console.WriteLine("Enter lastName :");
        string lastName = Console.ReadLine();
        card.LastName = lastName;
        Console.WriteLine("Enter card number: ");
        string cardNumber = Console.ReadLine();
        try
        {
            card.CardNumber = cardNumber;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message} | {e.StackTrace}");
            throw;
        }
        catch (Exception e)
        {
            throw new Exception("Unecpected exception: " + e.Message);
        }

        Console.WriteLine("Enter expiration date : ");
        string expirationDate = Console.ReadLine();
        try
        {
            card.ExpirationDate = expirationDate;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message} | {e.StackTrace}");
            throw;
        }
        catch (Exception e)
        {
            throw new Exception("Unecpected exception: " + e.Message);
        }

        Console.WriteLine("Enter cvc: ");
        string cvc = Console.ReadLine();
        try
        {
            card.Cvc = cvc;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message} | {e.StackTrace}");
            throw;
        }
        catch (Exception e)
        {
            throw new Exception("Unecpected exception: " + e.Message);
        }

        Console.WriteLine("Enter pin code: ");
        int pincode = int.Parse(Console.ReadLine());
        if (pincode == card.GetPinCode())
        {
            Console.WriteLine(card.CardDetails());
            Log.Information("card details {@card}", card);
        }
        else
        {
            Console.WriteLine("Invalid pin code");
            Log.Information("invalid pin code");
        }

        Log.CloseAndFlush();
    }
}