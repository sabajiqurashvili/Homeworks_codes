using System.Runtime.ConstrainedExecution;
using Serilog;
using Serilog.Formatting.Json;
using Newtonsoft.Json;

namespace BankApplication;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                new JsonFormatter(closingDelimiter: Environment.NewLine),
                @"C:\Users\Jikura\Desktop\davalebebi\Homeworks\FInalProject\BankApplication\logs.json",
                rollingInterval: RollingInterval.Day,
                shared: true
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
            while (true)
            {
                Console.WriteLine("Choose your option | write (1, 2, 3, 4 or 5)");
                Console.WriteLine("1 Check balance \n" +
                                  "2 Add balance \n" +
                                  "3 Withdraw \n" +
                                  "4 Change Amount \n" +
                                  "5 Last 5 transactions \n" +
                                  "6 Change Pincode");
                string done = Console.ReadLine();
                if (done == "exit")
                {
                    break;
                }

                if (int.TryParse(done, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(card.CheckBalance());
                            break;
                        case 2:
                            Console.WriteLine("Enter amount to add balance : ");
                            double amounttoAdd = double.TryParse(Console.ReadLine(), out double amount) ? amount : 0;
                            if (amounttoAdd > 0)
                            {
                                card.AddGELAmount(amounttoAdd);
                            }
                            else
                            {
                                Log.Error("Invalid input to add balance");
                                Console.WriteLine("you entered incorrect input to add amount on balance");
                            }

                            break;
                        case 3:
                            Console.WriteLine("Enter amount to withdraw : ");
                            double amountToWithdraw = double.TryParse(Console.ReadLine(), out double withdrawamount)
                                ? withdrawamount
                                : 0;
                            if (amountToWithdraw > 0) card.Withdraw(amountToWithdraw);
                            else
                            {
                                Log.Error("Invalid input to withdraw from balance");
                                Console.WriteLine("you entered incorrect input to withdraw from balance");
                            }

                            break;
                        case 4:
                            Console.WriteLine("(GEL,EUR,USD) from : ");
                            string from = Console.ReadLine().ToUpper();
                            Console.WriteLine("(GEL,EUR,USD) to : ");
                            string to = Console.ReadLine().ToUpper();
                            Console.WriteLine("Enter amount to convert in GEL: ");
                            double amountToconvert = double.TryParse(Console.ReadLine(), out double Convertamount)
                                ? Convertamount
                                : 0;
                            card.ChangeAmount(from, to, amountToconvert);
                            break;
                        case 5:
                            Console.WriteLine(string.Join(",", card.Last5Transactions()));
                            break;
                        case 6:
                            int newPinCode = int.TryParse(Console.ReadLine(), out int code) ? code : 0;
                            if (newPinCode > 0) card.ChangePinCode(newPinCode);
                            else
                            {
                                Console.WriteLine("You entered incorrect input to change PIN code");
                                Log.Information("You entered incorrect input to change PIN code");
                            }

                            break;
                        default:
                            Console.WriteLine($"Invalid input | tou cant choose {choice}| you must enter 1 2 3 4 or 5");
                            Log.Error($"Invalid input | tou cant choose {choice}| you must enter 1 2 3 4 or 5");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number | write (1, 2, 3, 4 or 5)");
                    Log.Error("Please enter a valid number | write (1, 2, 3, 4 or 5)");
                }
            }
        }
    }
}