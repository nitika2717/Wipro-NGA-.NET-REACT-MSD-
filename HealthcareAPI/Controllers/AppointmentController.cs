using HealthcareAPI.Interfaces;
using HealthcareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Exceptions;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        // USER STORY 1 – Retrieve all appointments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _service.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        // USER STORY 1 – Retrieve by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _service.GetAppointmentByIdAsync(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        // USER STORY 2 – Create with business validation
        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            try
            {
                await _service.CreateAppointmentAsync(appointment);
                return Ok("Appointment created successfully.");
            }
            catch (DoubleBookingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // USER STORY 2 – Update status with validation
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, AppointmentStatus status)
        {
            await _service.UpdateStatusAsync(id, status);
            return Ok("Status updated successfully.");
        }
    }
}                              