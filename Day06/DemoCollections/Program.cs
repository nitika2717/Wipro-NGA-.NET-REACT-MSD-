// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Ordered data - List<T>
        List<int> numbers = new List<int>(); // created list to store order ids
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);

        Console.WriteLine("List<T> (Ordered Data):");
        for (int i = 0; i < numbers.Count; i++)
        {
           Console.WriteLine(numbers[i]);
        }

        Console.WriteLine();

       // 2. Fast lookup - Dictionary<TKey, TValue>
        Dictionary<int, string> students = new Dictionary<int, string>();
        students.Add(1, "Amit");
        students.Add(2, "Neha");

        Console.WriteLine("Dictionary<TKey, TValue> (Fast Lookup):");
        Console.WriteLine("Student with ID 1: " + students[1]);

        Console.WriteLine();

        // 3. Uniqueness - HashSet<T>
        HashSet<string> food = new HashSet<string>();
        food.Add("Burger");
        food.Add("Pizza");
        food.Add("Burger"); // duplicate will not be added

    Console.WriteLine("HashSet<T> (Unique Values):");
        foreach (string f in food)
        {
            Console.WriteLine(f);
        }

        Console.WriteLine();

        //6. Queue<T> – FIFO (First In First Out)
        Queue<string> queue = new Queue<string>();

       //Enqueue() adds elements to the end.
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

      //Dequeue() removes elements in the order they were added.

        Console.WriteLine(queue.Dequeue()); 
        Console.WriteLine(queue.Dequeue()); 
        Console.WriteLine();


        //7. Stack<T> – LIFO (Last In First Out)

        Stack<string> stack = new Stack<string>();
        //Push() adds elements to the top.
        stack.Push("Step 1");
        stack.Push("Step 2");
        stack.Push("Step 3");

        //Pop() removes the most recent item first.

        Console.WriteLine(stack.Pop()); 
        Console.WriteLine(stack.Pop()); 
        Console.WriteLine();


        //8. SortedList<TKey, TValue> – Auto Sorted
        //stores key-value pairs sorted by key automatically.
        SortedList<int, string> sortedList = new SortedList<int, string>();
        sortedList.Add(3, "Three");
        sortedList.Add(1, "One");
        sortedList.Add(2, "Two");
        foreach (var item in sortedList)
        {
           Console.WriteLine(item.Key + " : " + item.Value);
}
    }       
}