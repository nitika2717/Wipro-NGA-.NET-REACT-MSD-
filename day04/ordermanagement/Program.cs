
enum OrderStatus // enum is use to create named constant values
{                // OrderStatus represents the current state of an order
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

struct Location // here we create struct that stores Latitude and Longitude
{
    public double Latitude;
    public double Longitude;
    public Location(double latitude , double longitude)  // like this new Location(18.52, 73.85)
    {
        Latitude=latitude;
         Longitude= longitude;
    }
}
interface IPayment
{
    void ProcessPayment(double amount);
    void RefundPayment(double amount);
    bool MakePayment(double amount);
}
class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; } //OrderStatus (enum) stores the current status of order
        public Location ShippingLocation { get; set; } 
        public double Amount { get; set; }

        public void DisplayOrder()
        {
            Console.WriteLine(
                "OrderId: " + OrderId +
                ", Status: " + Status +
                ", Amount: " + Amount +
                ", Location: (" + ShippingLocation.Latitude +
                ", " + ShippingLocation.Longitude + ")"
            );
        }
    }

    // STEP 5:
    // Implement Interface using a concrete class
    class UpiPayment : IPayment
    {
        public bool MakePayment(double amount)
        {
            Console.WriteLine("Making UPI payment of " + amount);
            return true;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Processing UPI payment of " + amount);
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine("Refunding " +amount + " via UPI");
        }
    }

    // Program execution starts here
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Order object
            Order order = new Order
            {
                OrderId = 101,
                Status = OrderStatus.Pending,
                Amount = 2500,
                ShippingLocation = new Location(18.52, 73.85)
            };

            order.DisplayOrder();

            // Payment through interface
            IPayment payment = new UpiPayment();

            if (payment.MakePayment(order.Amount))
            {
                payment.ProcessPayment(order.Amount);
                order.Status = OrderStatus.Processing;
            }

            order.DisplayOrder();
        }
    }
