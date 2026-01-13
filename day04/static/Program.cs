using System.Diagnostics.Metrics;

class Counter
{
    public static int count=10; //static means the variable belongs to class itself and does not belong to any obeject so memory is created for count when class is loaded ,so no need to create object
    public Counter()// constructor of counter class
    {
        count++; //this line executes every time  when an OBJECT IS CREATED 
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("static variable count:"+Counter.count);
        Counter c1= new Counter();// constructor runs so count adds 
        Counter c2= new Counter();
        Counter c3= new Counter();
        Console.WriteLine("Value of static variable count after creating three objects:"+Counter.count);
        Console.ReadLine();
    }
}

