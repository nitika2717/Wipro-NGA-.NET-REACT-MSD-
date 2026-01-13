internal class Program
{
    static void Main(string[] args)
    {
        string filePath= "demo.txt";
        using(FileStream fs=File.Create(filePath))
        {
            //file created successfully
            if (File.Exists(filePath))
            {
                Console.WriteLine("File Created: "+filePath);
            }
        }
        //writing to the file using streamwriter
        using(StreamWriter sw= new StreamWriter(filePath))//StreamWriter:used to write into file

        {
            sw.WriteLine("Hello");
            sw.WriteLine("This is demo file i have created today.");
        }
        //Reading from the file using StreamReader class
        using(StreamReader sr =new StreamReader(filePath))
        {
            string content =sr.ReadToEnd();
            Console.WriteLine("Here is the file content");
            Console.WriteLine(content);
        }
        //Deleting the file using file.delete() method
        File.Delete(filePath);
        if (!File.Exists(filePath))
        {
            Console.WriteLine("file deleted successfullyy: "+filePath);  }
    }
}
