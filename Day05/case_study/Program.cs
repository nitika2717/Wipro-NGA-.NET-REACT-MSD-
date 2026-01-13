// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        OrderService service = new OrderService();

        try
        {
            // Change values to test different scenarios
            // service.PlaceOrder(0, false);     // Validation error (NO LOG)
            // service.PlaceOrder(150, false);   // Business rule error (LOG)
            service.PlaceOrder(10, true);       // External service failure (LOG)
        }
        catch (Exception ex) when (LogIfRequired(ex) == false)
        {
            Console.WriteLine("Validation error handled without logging");
        }
        catch (Exception ex)
        {
            Logger.Log(ex);
            Console.WriteLine("Critical exception handled and logged");
        }
    }

    static bool LogIfRequired(Exception ex)//Should I log this exception or not?
    {
        if (ex is ValidationException)//Is this exception a ValidationException
        {
            return false;   // Do not log validation errors
        }

        return true;        // Log all other exceptions
    }
}

// ---------------- CUSTOM EXCEPTIONS ----------------

// Quantity <= 0
class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }
}

// Quantity > 100
class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message)
    {
    }
}

// Payment service down
class ExternalServiceException : Exception
{
    public ExternalServiceException(string message) : base(message)
    {
    }
}

// ---------------- LOGGER CLASS ----------------

class Logger
{
    public static void Log(Exception ex)
    {
        Console.WriteLine("----- LOG START -----");
        Console.WriteLine("Date and Time : " + DateTime.Now);
        Console.WriteLine("Exception Type : " + ex.GetType().Name);
        Console.WriteLine("Message : " + ex.Message);
        Console.WriteLine("----- LOG END -----");
    }
}

// ---------------- BUSINESS LOGIC ----------------

class OrderService
{
    public void PlaceOrder(int quantity, bool paymentServiceDown)
    {
        if (quantity <= 0)
        {
            throw new ValidationException("Quantity must be greater than zero");
        }

        if (quantity > 100)
        {
            throw new BusinessRuleException("Quantity cannot exceed 100");
        }

        if (paymentServiceDown)
        {
            throw new ExternalServiceException("Payment gateway is unavailable");
        }

        Console.WriteLine("Order placed successfully");
    }
}

