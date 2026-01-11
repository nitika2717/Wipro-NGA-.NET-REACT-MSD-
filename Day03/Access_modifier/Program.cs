// See https://aka.ms/new-console-template for more information
// BANK ACCOUNT SYSTEM
public class BankAccount
{
    // private:
    // PIN is sensitive data
    // Accessible ONLY inside this class
    private int pin = 1234;

    // public:
    // Account number should be accessible
    // by external applications, users, APIs
    public string AccountNumber = "ACC1001";

    // protected:
    // Interest calculation logic
    // Can be used ONLY by child (derived) account classes
    // Example: SavingAccount, CurrentAccount
    protected double CalculateInterest(double balance)
    {
        return balance * 0.05;
    }

    // internal:
    // Audit logic should work only
    // inside the same bank project (assembly)
    // Not accessible to outside applications
    internal void AuditTransaction()
    {
        Console.WriteLine("Transaction audited");
    }

    // protected internal:
    // Can be accessed:
    // 1. Anywhere inside same project
    // 2. Derived classes from another project (partner banks)
    protected internal void PartnerBankFeature()
    {
        Console.WriteLine("Partner bank feature accessed");
    }
}
class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Console.WriteLine(account.AccountNumber); //  public
        account.AuditTransaction();               //  internal
        account.PartnerBankFeature();             //  protected internal

        // account.pin  NOT accessible (private)
        // account.CalculateInterest(1000) NOT accessible (protected)
    }
}

