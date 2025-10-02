namespace H9N3;

class Program
{
    static void Main(string[] args)
    {
        GoodStudent goodStudent = new GoodStudent("saba");
        LazyStudent lazyStudent = new LazyStudent("luka");
        ClassRoom classRoom = new ClassRoom(goodStudent,lazyStudent);

        Console.WriteLine(classRoom.ClassInfo());
       
    }
}