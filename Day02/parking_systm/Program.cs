// See https://aka.ms/new-console-template for more information

        // Function to calculate total marks
    int CalculateTotal(int m1, int m2, int m3)
{
    return m1 + m2 + m3;
}

// Function to calculate average
double CalculateAverage(int total)
{
    return total / 3.0;
}

// Function to calculate result
string CalculateResult(int m1, int m2, int m3)
{
    return (m1 >= 35 && m2 >= 35 && m3 >= 35) ? "PASS" : "FAIL";
}

Console.Write("Enter marks of Subject 1: ");
int.TryParse(Console.ReadLine(), out int m1);

Console.Write("Enter marks of Subject 2: ");
int.TryParse(Console.ReadLine(), out int m2);

Console.Write("Enter marks of Subject 3: ");
int.TryParse(Console.ReadLine(), out int m3);

int total = CalculateTotal(m1, m2, m3);
double avg = CalculateAverage(total);
string result = CalculateResult(m1, m2, m3);

Console.WriteLine("\n--- RESULT ---");
Console.WriteLine("Total   : " + total);
Console.WriteLine("Average : " + avg);
Console.WriteLine("Result  : " + result);