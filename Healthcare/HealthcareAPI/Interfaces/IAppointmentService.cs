using HealthcareAPI.Models;

namespace HealthcareAPI.Interfaces
{
    public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    Task<Appointment?> GetAppointmentByIdAsync(int id);
    Task CreateAppointmentAsync(Appointment appointment);
    Task UpdateStatusAsync(int appointmentId, AppointmentStatus newStatus);
}
}
