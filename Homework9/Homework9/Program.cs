namespace Homework9;

class Program
{
    static void Main(string[] args)
    {
        Employee employee1 = new Employee(
            "saba", "jikurashvili", 21, "manager", new int[] { 8, 8, 8, 8, 8, 0, 0 }
            );
        Employee employee2 = new Employee(
            "bidzina", "tabagari", 62, "oper", new int[] { 12, 12, 12, 12, 12, 12, 5 }
        );
        // Console.WriteLine(employee1.WeekIncome());
        // Console.WriteLine(employee1.EmloyeeInformation());

        Company company = new Company(true);
        company.addEmployee(employee1);
        company.addEmployee(employee2);
        company.EmployeesInformation();
        Console.WriteLine(company.govermentTaxWeekly());
        

    }
}