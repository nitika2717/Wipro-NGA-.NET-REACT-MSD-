using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Data;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public DoctorController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Doctors.ToList());
        }
    }
}