using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Data;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public PatientController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Patients.ToList());
        }
    }
}
