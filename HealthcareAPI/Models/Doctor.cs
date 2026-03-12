namespace HealthcareAPI.Models
{
    // USER STORY 1:
    // Represents doctors linked to departments.
    public class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public int DepartmentId { get; set; }

    // Navigation properties (optional for API input)
    public Department? Department { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
}