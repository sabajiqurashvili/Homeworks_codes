namespace H9N2;

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("saba", 21, 2022);
        Student student2 = new Student("luka", 19, 2024);
        Teacher teacher = new Teacher("Giorgi", true);
        
        student1.ChooseSubject("English");
        Console.WriteLine(teacher.Answer(student1));
        student2.ChooseSubject("Math");
        Console.WriteLine(teacher.Answer(student2));
        
    }
}