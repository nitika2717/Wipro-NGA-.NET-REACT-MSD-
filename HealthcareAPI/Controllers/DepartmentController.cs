using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Data;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public DepartmentController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Departments.ToList());
        }
    }
}