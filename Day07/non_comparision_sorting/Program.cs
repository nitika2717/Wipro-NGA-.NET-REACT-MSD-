// See https://aka.ms/new-console-template for more information
using System;

class SortingCaseStudy
{
    static void Main()
    {
        // Student Marks (Counting Sort)
        int[] marks = { 78, 95, 45, 62, 78, 90, 45 };
        Console.WriteLine("Original Marks:");
        PrintArray(marks);
        // Call Counting Sort
        // 100 is the maximum possible value of marks
        CountingSort(marks, 100);

        Console.WriteLine("\nSorted Marks (Counting Sort):");
        PrintArray(marks);

        // Registration Numbers (Radix Sort)
        int[] regNumbers = { 102345, 984321, 345678, 123456, 567890 };
        Console.WriteLine("\nOriginal Registration Numbers:");
        PrintArray(regNumbers);

        RadixSort(regNumbers);

        Console.WriteLine("\nSorted Registration Numbers (Radix Sort):");
        PrintArray(regNumbers);
    }

    // ---------------- COUNTING SORT ----------------
    static void CountingSort(int[] arr, int maxValue)
    {
        // Create count array to store frequency of each number
        int[] count = new int[maxValue + 1];

        // Count how many times each number appears

        foreach (int num in arr)
            count[num]++;

        int index = 0;
        for (int i = 0; i <= maxValue; i++)
        {
            // Place the number i into original array
            // as many times as it appears
            while (count[i] > 0)
            {
                arr[index++] = i;
                count[i]--;
            }
        }
    }

    // ---------------- RADIX SORT ----------------
    static void RadixSort(int[] arr)
    {
        // Find the maximum number in array
        int max = arr[0];
        foreach (int num in arr)
            if (num > max) max = num;

        // Perform counting sort for each digit
        // exp = 1 → units place
        // exp = 10 → tens place
        // exp = 100 → hundreds place

//         Input:

// arr = {170, 45, 75, 90}

// Pass 1: Units digit
// 170 → 0
// 45  → 5
// 75  → 5
// 90  → 0


// Stable counting sort → {170, 90, 45, 75}

// Pass 2: Tens digit
// 170 → 7
// 90  → 9
// 45  → 4
// 75  → 7
// Stable counting sort → {45, 170, 75, 90}

// Pass 3: Hundreds digit
// 45  → 0
// 170 → 1
// 75  → 0
// 90  → 0


// Stable counting sort → {45, 75, 90, 170}

// ✅ Sorted array!

        for (int exp = 1; max / exp > 0; exp *= 10)
            CountSortByDigit(arr, exp);
    }

    static void CountSortByDigit(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];  // Output array to store sorted numbers
        int[] count = new int[10]; // Count array for digits 0–9

        for (int i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (arr[i] / exp) % 10;
            output[count[digit] - 1] = arr[i];
            count[digit]--;
        }

        for (int i = 0; i < n; i++)
            arr[i] = output[i];
    }

    // ---------------- PRINT ARRAY ----------------
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }
}
