namespace HealthcareAPI.Models
{
    // USER STORY 2:
    // Strongly typed status to prevent invalid transitions.
    // Replaces unsafe string usage.
    public enum AppointmentStatus
    {
        Scheduled = 0,
        Completed = 1,
        Cancelled = 2,
        CheckedIn = 3,
        NoShow = 4
    }
}