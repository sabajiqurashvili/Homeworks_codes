namespace H10N2;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        bool isGoodHistory = bank.CheckUserHistory();
        Console.WriteLine(isGoodHistory);
        if (isGoodHistory) 
        {
            bank.CalculateLoanPercent(10,1000);
        }
        else
        {
            Console.WriteLine("you have bad history");
        }
        
        MicroFinance microFinance = new MicroFinance();
        Console.WriteLine(microFinance.CheckUserHistory());
        microFinance.CalculateLoanPercent(10,1000);
    }
}