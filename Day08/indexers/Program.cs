// See https://aka.ms/new-console-template for more information
class Employee
{
    //Properties
    public string EmployeeName {get; set;}
    public int EmployeeId {get; set;}

    // Array to store monthly attendance
    private int[] attendance = new int[12];

    // Indexer to access attendance
    public int this[int month]  // this-Refers to the current object of the class
    {
        get
        {
            return attendance[month];
        }
        set
        {
            attendance[month] = value;
        }
    }
}
class Product
{
    // Property- product details
    public string ProductName { get; set; }
    public double Price { get; set; }

    // Array to store customer ratings
    private int[] ratings = new int[5];

    // Indexers access ratings by customer index
    public int this[int customerIndex]
    {
        get {
             return ratings[customerIndex]; }
        set { 
            ratings[customerIndex] = value; }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Employee object
        Employee emp = new Employee();
        emp.EmployeeName = "Nitika"; //object.PropertyName = value;
        emp.EmployeeId = 101;
        emp[0] = 19;   // January attendance object[index] = value;
        emp[1] = 23; 
        emp[2] = 29; 

        // Product object
        Product product = new Product();
        product.ProductName = "Laptop";
        product.Price = 55000;
        product[0] = 4; // Customer rating

        // Output
        Console.WriteLine("Employee Name: " + emp.EmployeeName);
        Console.WriteLine("January Attendance: " + emp[0]);

         Console.WriteLine("Product Name: " + product.ProductName);
        Console.WriteLine("Customer Rating: " + product[0]);
    }
}

