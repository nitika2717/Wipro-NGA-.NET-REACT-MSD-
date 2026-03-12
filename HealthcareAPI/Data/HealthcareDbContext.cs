using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Data
{
    public class HealthcareDbContext : DbContext
    {
        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        
    }
}