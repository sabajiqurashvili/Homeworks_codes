namespace Homework14_N3;

class Program
{
    static void Main(string[] args)
    {
        var report = new ReportFacade();
        Console.WriteLine(report.GenerateReport("html"));
    }
}