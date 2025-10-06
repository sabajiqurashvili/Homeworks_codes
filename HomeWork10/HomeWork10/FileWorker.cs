namespace HomeWork10;

public abstract class FileWorker
{
    public int FileMaxStorage { get; set; }
    public abstract string FileExtension { get; set; }

    public virtual void Read()
    {
        Console.WriteLine($"i can read from {FileExtension} file with max storage {FileMaxStorage}");
    }
    public virtual void Write()
    {
        Console.WriteLine($"i can write to {FileExtension} file with max storage {FileMaxStorage}");
    }
    public virtual void Edit()
    {
        Console.WriteLine($"i can edit {FileExtension} file with max storage {FileMaxStorage}");
    }
    public virtual void Delete()
    {
        Console.WriteLine($"i can delete from {FileExtension} file with max storage {FileMaxStorage}");
    }
    
    
}