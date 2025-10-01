namespace Homework9;

public class Employee
{
    public string name { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }
    public string position { get; set; }

    private int[] _hoursInWeek = new int[7];

    public int[] hoursInWeek
    {
        get => _hoursInWeek;
        set
        {
            if (value != null && value.Length == 7)
                _hoursInWeek = value;
            else
                throw new ArgumentException("HoursInWeek must have exactly 7 elements.");
        }
    }
   

    public Employee(string name, string lastName, int age, string position, int[] hoursInWeek)
    {
        this.name = name;
        this.lastName = lastName;
        this.age = age;
        this.position = position;
        this.hoursInWeek = hoursInWeek;
    }

    public int WeekIncome()
    {
        int overtimeBonus = 5;
        int hourlypay = 10;
        if (this.position == "manager")
        {
            hourlypay = 40;
        }
        if (this.position == "developer")
        {
            hourlypay = 30;
        }
        if (this.position == "tester")
        {
            hourlypay = 20;
        }

        int weekdaysincome = 0;
        int weekendincome = 0;

        for (int i = 0; i < 5; i++)
        {
            if (hoursInWeek[i] <= 8)
            {
                weekdaysincome += hoursInWeek[i] * hourlypay;
            }
            else
            {
                weekdaysincome += 8 * hourlypay + (overtimeBonus + hourlypay) * (hoursInWeek[i] - 8);
            }
        }

        for (int i = 5; i < 7; i++)
        {
            weekendincome += hoursInWeek[i] * hourlypay * 2;
        }

        int earned = weekdaysincome + weekendincome;
        if (hoursInWeek.Sum() >= 50)
        {
            earned += earned*20/100;
        }
        return earned;
    }

   public string EmloyeeInformation()
    {
        return $"employee name : {this.name}, lastName : {this.lastName}, age : {this.age}, position : {this.position},hoursInweek : {string.Join(",",hoursInWeek)}";
    }

 
}