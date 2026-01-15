using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create NON-GENERIC stack 
         Stack stack = new Stack();

        // Step 2: Push values
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Step 3: Pop value
        object poppedValue = stack.Pop();
        Console.WriteLine("Popped Value: " + poppedValue);

        // Step 4: Peek top value
        object topValue = stack.Peek();
        Console.WriteLine("Top Value: " + topValue);

        // Step 5: Contains
        bool contains20 = stack.Contains(20);
        Console.WriteLine("Stack contains 20: " + contains20);

        // Step 6: Count (PROPERTY, not method)
        int count = stack.Count;
        Console.WriteLine("Current Count: " + count);

        // Step 7: Clear stack
        stack.Clear();
        Console.WriteLine("Stack cleared. Count after clearing: " + stack.Count);
    }
}