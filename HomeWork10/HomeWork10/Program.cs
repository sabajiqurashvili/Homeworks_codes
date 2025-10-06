namespace HomeWork10;

class Program
{
    static void Main(string[] args)
    {
        TextFileWorker textFileWorker = new TextFileWorker();
        textFileWorker.FileExtension = ".txt";
        textFileWorker.FileMaxStorage = 1000;
        textFileWorker.Read();
        textFileWorker.Write();
        textFileWorker.Edit();
        textFileWorker.Delete();
    }
}