namespace BankApp_Domain;

public class Loan
{
    public int Id { get; set; }
    public LoanType LoanType { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
    public int LoanPeriodInMonths { get; set; }
    public Status Status { get; set; }
    
    
    // many to one [loan has one owner(User)]
    public User User { get; set; }
    public int UserId { get; set; }
    
    
}

public enum LoanType
{
    QuickLoan = 1,
    AutoLoan = 2,
    Installment = 3
}

public enum Currency
{
   GEL = 1,
   USD = 2,
   EUR = 3
}

public enum Status
{
    Proccesing = 1,
    Approved = 2,
    Rejected = 3
}