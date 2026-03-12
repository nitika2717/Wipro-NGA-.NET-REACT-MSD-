namespace HealthcareAPI.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        // Foreign Keys
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        // USER STORY 2:
        // Strongly typed status for lifecycle management
        public AppointmentStatus Status { get; set; }

        // Navigation Properties (User Story 3 – Relational Data Design)

        // Links appointment to Patient entity
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}   