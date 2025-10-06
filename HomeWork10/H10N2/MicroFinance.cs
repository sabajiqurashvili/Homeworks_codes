namespace H10N2;

public class MicroFinance : IFInanceOperations
{
    public void CalculateLoanPercent(int month, double AmountPerMonth)
    {
        double principal = AmountPerMonth * month;
        double interest = principal * 0.10 + month*4;
        double total = principal + interest;
        Console.WriteLine($"you have to pay {total} | total interest amount is {interest}");
    }

    public bool CheckUserHistory()
    {
        return true;
    }
}