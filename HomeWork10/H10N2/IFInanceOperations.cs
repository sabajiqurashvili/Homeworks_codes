namespace H10N2;

public interface IFInanceOperations
{
    void CalculateLoanPercent(int month, double AmountPerMonth);
    bool CheckUserHistory();

}