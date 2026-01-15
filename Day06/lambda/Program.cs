// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Linq;
class Program
    {
        static void Main(string[] args)
        {
            // Lambda expression example
            
            Func<int, bool> IsEven = number => number % 2 == 0;

            
            // List collection
            
            List<int> numbers = new List<int> { 56, 9, 32, 45, 6, 19, 34};

            Console.WriteLine("All numbers in the list:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            //Find first number greater than 10
            
            int result = numbers.Find(n => n > 10);
            Console.WriteLine("\nFirst number greater than 10: " + result);

            // Find even numbers using Where
    
            var evenNumbers = numbers.Where(n => n % 2 == 0);

            Console.WriteLine("\nHere are the list of even numbers:");
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }

        }
        
        }
