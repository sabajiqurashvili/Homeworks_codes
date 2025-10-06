namespace H10N2;

public class Bank : IFInanceOperations
{
    public void CalculateLoanPercent(int month, double AmountPerMonth)
    {
        double principal = AmountPerMonth * month;
        double interest = principal * 0.05;
        double total = principal + interest;
        Console.WriteLine($"you have to pay {total} | total interest amount is {interest}");
    }

    public bool CheckUserHistory()
    {
        Random random = new Random();
        if (random.Next(0, 2) == 1) return true;
        return false;
    }
}