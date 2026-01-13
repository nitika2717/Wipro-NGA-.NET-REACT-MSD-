     //- objects of this class cannot be created

    static class SystemSettings
    {
        // Static variables (shared globally)- accessed using class name
        public static string PlatformName = "Learning App";
        public static int AllowedLoginTries = 5;
        public static int RegisteredUsersCount = 0;

        // Static method
        public static void IncreaseUserCount()
        {
            RegisteredUsersCount++;
        }
    }

    class Account
    {
    
        public string AccountName { get; set; }// each object will have its own Accountname 

        // Constructor
        public Account(string accountName)
        {
            AccountName = accountName;

            // Calling static method
            SystemSettings.IncreaseUserCount();
        }
        public void ShowAccount()
        {
            Console.WriteLine("Account Name: " + AccountName);
        }
    }

    // STEP 3: Main Program Class
    internal class Application
    {
        static void Main(string[] args)
        {
            // Accessing static members (NO object needed)
            Console.WriteLine("PlatformName: " + SystemSettings.PlatformName);
            Console.WriteLine("Allowed Login Tries: " + SystemSettings.AllowedLoginTries);

            Console.WriteLine("\nRegistering Accounts...\n");

            Account acc1 = new Account("User_One");
            Account acc2 = new Account("User_Two");
            Account acc3 = new Account("User_Three");

            acc1.ShowAccount();
            acc2.ShowAccount();
            acc3.ShowAccount();

            Console.WriteLine("\nTotal Registered Users: " + SystemSettings.RegisteredUsersCount);

            Console.ReadLine();
        }
    }

