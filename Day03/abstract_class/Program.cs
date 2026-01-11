// See https://aka.ms/new-console-template for more information

using System;

abstract class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;

    // Abstract method (NO BODY)
    public abstract void DisplayProductNameDetail();

    // Must be PUBLIC
    public void DisplayProductDetail()
    {
        Console.WriteLine("Product Name: " + ProductName);
        Console.WriteLine("Product ID: " + ProductID);
    }
}

class ElectronicProduct : Product  // derived class ElectronicProduct inherits Product

// Gains:

// ProductID

// ProductName

// DisplayProductDetail()
/{
    public string Brand { get; set; } = string.Empty;

    public override void DisplayProductNameDetail() //Because this method is abstract in parent
    {
        Console.WriteLine("Electronic Product Name: " + ProductName);
        Console.WriteLine("Brand: " + Brand);
    }
}

class Program
{
    static void Main()
    {
        ElectronicProduct ep = new ElectronicProduct();
        ep.ProductID = 101;
        ep.ProductName = "Laptop";
        ep.Brand = "Dell";

        ep.DisplayProductDetail();
        ep.DisplayProductNameDetail();
    }
}
