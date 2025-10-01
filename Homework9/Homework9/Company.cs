namespace Homework9;

public class Company
{
    public bool isLocal { get; set; }
    public List<Employee> Employees { get; set;  }
    
    

    public Company(bool isLocal)
    {
        this.isLocal = isLocal;
        this.Employees = new List<Employee>();
    }

    public int govermentTaxWeekly()
    {
        int govermentTax;
        if (isLocal)
        {
            govermentTax = TotalSalary() * 18 / 100;
        }
        else
        {
            govermentTax = TotalSalary() * 5 / 100;
        }

        return govermentTax;
    }
    private int TotalSalary()
    {
        int totalSalary = 0;
        foreach (var employee  in Employees)
        {
            totalSalary += employee.WeekIncome();
        }
        return totalSalary;
    }

    public void addEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

   public void EmployeesInformation()
    {
        foreach (var employees in Employees)
        {

            Console.WriteLine(employees.EmloyeeInformation());
        }
    }
    
    
    
    
    
}