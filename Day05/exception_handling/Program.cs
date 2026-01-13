// See https://aka.ms/new-console-template for more information
using System;

// Your custom exception class
public class DailyLimitExceededException : Exception
{
    public DailyLimitExceededException(string message) : base(message)
    {
    }
}

// Your business logic class
class BankAccount
{
    private decimal dailyLimit = 1000;
    private decimal totalTransactionsToday = 0;

    public void MakeTransaction(decimal amount)
    {
        if (totalTransactionsToday + amount > dailyLimit)
        {
            throw new DailyLimitExceededException("Daily transaction limit exceeded.");
        }
        totalTransactionsToday += amount;
        Console.WriteLine("Transaction of " + amount + " completed successfully.");
    }
}

// Main block
class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        try
        {
            account.MakeTransaction(300);//accepted as amount would be 300
            account.MakeTransaction(200);// accepted as total amount would be 500
            account.MakeTransaction(700); //total would be 1200 that exceeds so it will throw an exception
        }
        catch (DailyLimitExceededException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction processing finished for today.");
        }


        Console.ReadLine();
    }
}

