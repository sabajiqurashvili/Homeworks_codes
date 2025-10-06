namespace HomeWork10;

public class TextFileWorker : FileWorker
{
    public override string FileExtension { get; set; }
    public override void Write()
    {
        Console.WriteLine($"i write to : {FileExtension}  | file with max storage {FileMaxStorage}");
    }
}