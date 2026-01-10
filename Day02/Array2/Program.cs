// See https://aka.ms/new-console-template for more information

//Getting started with 2D Arrays in C#
//Step 1: Declare a 2D array of type int syntax : dataType[,] arrayName = new dataType[rows, columns];
//Step 2: Initialize the 2D array with values
int[,] matrix = new int[3, 3] //3 rows and 3 columns
{
    {1, 2, 3}, //Row 0
    {4, 5, 6}, //Row 1
    {7, 8, 9}  //Row 2
};
for (int i =0;i<3; i++)// iterate through rows
{
    for(int j = 0; j < 3; j++)// interate through columns
    {
        Console.Write(matrix[i, j] + " ");// for sameline
    }
   Console.WriteLine();//for next line
}
//Jagged Array
int[][] numbers=new int[3][]; // declare jagged aray with 3 rows
//intialise first row with 3 elements
numbers[0]=new int[]{1,2,3};
//intialise second row with 2 elements
numbers[1]=new int[]{4,5};
//intialise third row with 4 elements
numbers[2]=new int[]{1,2,3,7};
for (int i =0;i<numbers.Length; i++)// iterate through rows
{
    for(int j = 0; j < numbers[i].Length; j++)// interate through columns
    {
        Console.Write(numbers[i][j] + " ");// print each element in each row
    }
    Console.WriteLine();//for next line
}
// int[][] jagged -array
// numbers.Length - 