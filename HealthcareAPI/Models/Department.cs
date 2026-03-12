namespace HealthcareAPI.Models
{
    // USER STORY 1:
    // Represents clinic departments (Cardiology, Dermatology, etc.)
    public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation property (optional for API requests)
    public ICollection<Doctor>? Doctors { get; set; }
}
}