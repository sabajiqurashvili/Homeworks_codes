using System.Security.Cryptography;
using System.Text.Json;
using Serilog;

namespace BankApplication;

public class Card
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    private string cardNumber;
    private string expirationDate;
    private string cvc;

    private int pinCode = 1234;
    private double GELAmount = 0;
    private double EURAmount = 0;
    private double USDAmount = 0;
    private List<string> Transactions = new List<string>();


    public string CardNumber
    {
        get { return cardNumber; }
        set
        {
            if (value.Length == 16 && long.TryParse(value, out _))
                cardNumber = value;
            else
            {
                Log.Error("Invalid card number | number size must be 16 characters");
                throw new ArgumentException("Invalid card number | number size must be 16 characters");
            }
        }
    }

    public string ExpirationDate
    {
        get { return expirationDate; }
        set
        {
            DateTime dt = DateTime.ParseExact(value, "MM/yy", null);
            if (value.Length == 5 && value[2] == '/' && int.TryParse(value[..2], out _) &&
                int.TryParse(value[3..], out _) && DateTime.Now <= dt)
                expirationDate = value;
            else
            {
                Log.Error("Invalid Expiration Date");
                throw new ArgumentException("Invalid Expiration Date. Use format 'MM/YY'");
            }
        }
    }

    public string Cvc
    {
        get { return cvc; }
        set
        {
            if (value.Length == 3 && int.TryParse(value, out _))
                cvc = value;
            else
            {
                Log.Error("Invalid CVC number");
                throw new ArgumentException("Invalid CVC number | numbers length must be 3 characters");
                throw new ArgumentException("Invalid CVC number | numbers length must be 3 characters");
            }
        }
    }


    public string CardDetails()
    {
        return $"FirstName : {FirstName}\n" +
               $"LastName : {LastName}\n" +
               $"CardDetails\n" +
               $"CardNumber : {CardNumber}\n" +
               $"ExpirationDate : {ExpirationDate}\n" +
               $"Cvc : {Cvc}";
    }

    public int GetPinCode()
    {
        return pinCode;
    }

    public string CheckBalance()
    {
        Log.Information("{FirstName} {LastName} Checked balance", FirstName, LastName);
        Log.Information($"balance : " +
                        $"GEL : {GELAmount}" +
                        $"EUR : {EURAmount}" +
                        $"USD : {USDAmount}");
        Transactions.Add($"{FirstName} {LastName} Checked balance");
        return $"Balance :\n" +
               $" GEL : {GELAmount}\n" +
               $" EUR : {EURAmount}\n" +
               $" USD : {USDAmount}\n";
    }

    public void Withdraw(double amount)
    {
        if (amount <= GELAmount)
        {
            Log.Information("{FirstName} {LastName} Withdrawn {Amount} GEL ", FirstName, LastName, amount);
            GELAmount = GELAmount - amount;
            Transactions.Add($"{FirstName} {LastName} Withdrawn {amount} GEL");
        }
        else
        {
            Log.Error("You dont have enough gel amount");
            Console.WriteLine("You dont have enough gel amount");
        }
    }

    public void AddGELAmount(double amount)
    {
        GELAmount += amount;
        Log.Information("{FirstName} {LastName} added {Amount} GEl amount", FirstName, LastName, amount);
        Console.WriteLine($"{FirstName} {LastName} added {amount} GEl amount");
        Transactions.Add($"{FirstName} {LastName} added {amount} GEl amount");
    }

    public void ChangePinCode(int newpinCode)
    {
        if (pinCode.ToString().Length == 4)
        {
            pinCode = newpinCode;
            Log.Information("{FirstName} {LastName} changed pin code to {PinCode}", FirstName, LastName, pinCode);
            Console.WriteLine($"Pin code changed to {pinCode}");
            Transactions.Add($"{FirstName} {LastName} changed pin code to {pinCode}");
        }
        else
        {
            Console.WriteLine("pin code must be 4 digits");
            Log.Error("pin code must be 4 digits");
        }
    }

    public void ChangeAmount(string from, string to, double amountInGEL)
    {
        double eur = 0.32;
        double usd = 0.37;
        switch (from, to)
        {
            case ("GEL", "EUR"):
                GELAmount -= amountInGEL;
                EURAmount += amountInGEL * eur;
                Log.Information("{FirstName} {LastName} converted from GEL to EUR | {AmountInGEL} GEL", FirstName,
                    LastName, amountInGEL);
                Console.WriteLine($"{FirstName} {LastName} converted from GEL to EUR | {amountInGEL} GEL");
                Transactions.Add($"{FirstName} {LastName} converted from GEL to EUR | {amountInGEL} GEL");
                break;
            case ("GEL", "USD"):
                GELAmount -= amountInGEL;
                USDAmount += amountInGEL * usd;
                Log.Information("{FirstName} {LastName} converted from GEL to USD | {AmountInGEL} GEL", FirstName,
                    LastName, amountInGEL);
                Console.WriteLine($"{FirstName} {LastName} converted from GEL to USD | {amountInGEL} GEL");
                Transactions.Add($"{FirstName} {LastName} converted from GEL to USD | {amountInGEL} GEL");
                break;
            case ("EUR", "GEL"):
                EURAmount -= amountInGEL * eur;
                GELAmount += amountInGEL / eur;
                Log.Information("{FirstName} {LastName} converted from EUR to GEL | {AmountInGEL} GEL", FirstName,
                    LastName, amountInGEL);
                Console.WriteLine($"{FirstName} {LastName} converted from EUR to GEL | {amountInGEL} GEL");
                Transactions.Add($"{FirstName} {LastName} converted from EUR to GEL | {amountInGEL} GEL");
                break;
            case ("USD", "GEL"):
                USDAmount -= amountInGEL * usd;
                GELAmount += amountInGEL / usd;
                Log.Information("{FirstName} {LastName} converted from USD to GEL | {AmountInGEL} GEL", FirstName,
                    LastName, amountInGEL);
                Console.WriteLine($"{FirstName} {LastName} converted from USD to GEL | {amountInGEL} GEL");
                Transactions.Add($"{FirstName} {LastName} converted from USD to GEL | {amountInGEL} GEL");
                break;
            default:
                Console.WriteLine("Invalid input");
                Log.Error("Invalid input for converting");
                break;
        }
    }

    public List<string> Last5Transactions()
    {
        List<string> lastTransactions = Transactions.TakeLast(5).ToList();
        Log.Information("{FirstName} {LastName} checked last 5 transaction", FirstName, LastName);
        Log.Information("Last 5 transactions of : {FirstName} {LastName} is {@Lasttransactions} ", FirstName, LastName,
            lastTransactions);
        return lastTransactions;
    }
}