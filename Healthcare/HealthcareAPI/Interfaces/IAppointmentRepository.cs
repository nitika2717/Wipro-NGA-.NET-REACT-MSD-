using HealthcareAPI.Models;

namespace HealthcareAPI.Interfaces
{
    // USER STORY 1:
    // Repository abstraction for Appointment data access.
    // Follows Dependency Inversion Principle (SOLID).
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync(); // Retrieves all appointments from the data source.
        Task<Appointment?> GetByIdAsync(int id); // Retrieves a specific appointment by its ID from the data source.
        Task AddAsync(Appointment appointment); // Adds a new appointment to the data source.
        Task SaveAsync();
    }
}