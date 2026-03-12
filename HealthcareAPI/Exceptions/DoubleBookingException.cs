namespace HealthcareAPI.Exceptions
{
        // USER STORY 2:
    // Thrown when scheduling conflicts occur.
        public class DoubleBookingException : Exception
    {
        public DoubleBookingException(string message) : base(message) 
        {
        }
    }
}