using HealthcareAPI.Exceptions;
using HealthcareAPI.Interfaces;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        // Get all appointments
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Get appointment by ID
        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Create new appointment
        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            var existingAppointments = await _repository.GetAllAsync();

            bool conflict = existingAppointments.Any(a =>
                a.DoctorId == appointment.DoctorId &&
                a.AppointmentDate == appointment.AppointmentDate &&
                a.Status == AppointmentStatus.Scheduled);

            if (conflict)
                throw new DoubleBookingException("Doctor already booked at this time.");

            appointment.Status = AppointmentStatus.Scheduled;

            await _repository.AddAsync(appointment);
            await _repository.SaveAsync();
        }

        // Update status with validation
        public async Task UpdateStatusAsync(int appointmentId, AppointmentStatus newStatus)
        {
            var appointment = await _repository.GetByIdAsync(appointmentId);

            if (appointment == null)
                throw new Exception("Appointment not found.");

            if (appointment.Status == AppointmentStatus.Completed ||
                appointment.Status == AppointmentStatus.Cancelled)
            {
                throw new InvalidStatusTransitionException(
                    "Cannot modify completed or cancelled appointments.");
            }

            // Only allow Scheduled → Completed or Cancelled
            if (appointment.Status == AppointmentStatus.Scheduled &&
                (newStatus == AppointmentStatus.Completed || newStatus == AppointmentStatus.Cancelled))
            {
                appointment.Status = newStatus;
            }
            else
            {
                throw new InvalidStatusTransitionException("Invalid status transition.");
            }

            await _repository.SaveAsync();
        }
    }
}