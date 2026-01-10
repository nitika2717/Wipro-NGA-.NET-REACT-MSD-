// See https://aka.ms/new-console-template for more informationdotnet new console Collec
// Creating a non-generic collection (ArrayList)
    // using System.Collections;
    //     Console.WriteLine("Non Generic Collection Implementation");

    //     ArrayList orderCollection = new ArrayList();//Array list is non generic * it can store many datatypes and data is stored as object

    //     // Adding different types of items
    //     orderCollection.Add("Laptop");                   // string
    //     orderCollection.Add(12345);                      // int
    //     orderCollection.Add(99.99);                      // double
    //     orderCollection.Add(new DateTime(2024, 6, 1));   // DateTime

    //     // Displaying the items in the collection
    //     Console.WriteLine("Items in the Order Collection:");

    //     foreach (var item in orderCollection)   // foreach loops through all elements and var compiler decides types at runtime
    //     {
    //         Console.WriteLine(item);
    //     }


// GENERIC COLLECTION
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.WriteLine("Generic Collection Implementation");

        // Creating a generic collection
        // List<string> means it can store ONLY string values
        List<string> orderCollection = new List<string>();

        // Adding items to the collection
        orderCollection.Add("Laptop");     // string
        orderCollection.Add("Mouse");      // string
        orderCollection.Add("Keyboard");   // string

        // Displaying the items in the collection
        Console.WriteLine("Items in the Order Collection:");

        foreach (string item in orderCollection)
        {
            Console.WriteLine(item);
        }
    }
}

    