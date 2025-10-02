namespace H9N3;

public class ClassRoom
{
    private List<Student> students;

    public ClassRoom(Student student,params List<Student> students)
    {
        this.students = new List<Student>();
        this.students.Add(student);
        this.students.AddRange(students);
    }

    public string ClassInfo()
    {
        string classInfo = "";
        foreach (var student in students)
        {
            classInfo += student.StudentInfo() + "\n---------\n";
        }
        return classInfo;
    }

}