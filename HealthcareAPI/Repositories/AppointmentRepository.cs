using HealthcareAPI.Data;
using HealthcareAPI.Interfaces;
using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAPI.Repositories
{
    // USER STORY 1:
    // Handles ONLY database operations (Single Responsibility Principle).
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthcareDbContext _context;

        public AppointmentRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync() 
        {
            // Async improves scalability in healthcare systems
            return await _context.Appointments.ToListAsync(); // Retrieves all appointments from the database
        }

        public async Task<Appointment?> GetByIdAsync(int id) // Retrieves a specific appointment by its ID from the database
        {
            return await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task AddAsync(Appointment appointment) // Adds a new appointment to the database
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task SaveAsync() // Saves changes to the database
        {
            await _context.SaveChangesAsync();
        }
    }
}              