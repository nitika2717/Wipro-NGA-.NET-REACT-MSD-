// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] numbers= new int[5];
numbers[0]=45;
numbers[1]=20;
numbers[2]=30;
numbers[3]=25;
numbers[4]=50;
for(int i=0; i<numbers.Length; i++)
{
    Console.WriteLine("Element of index "+i+":"+numbers[i]);
}
Array.Sort(numbers);
Console.WriteLine(" Sorted Array");
for(int i=0; i<numbers.Length; i++)
{
    Console.WriteLine("Element of index "+i+":"+numbers[i]);
}
