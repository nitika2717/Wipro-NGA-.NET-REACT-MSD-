namespace HealthcareAPI.Exceptions
{
    // USER STORY 2:
    // Ensures valid appointment lifecycle transitions.
    public class InvalidStatusTransitionException : Exception
    {
        public InvalidStatusTransitionException(string message) : base(message)
        {
        }
    }
}