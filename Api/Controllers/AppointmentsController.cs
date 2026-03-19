using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;
        public AppointmentsController(AppointmentService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Appointment appointment)
        {
            var result = await _service.CreateAppointmentAsync(appointment);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message, suggestions = result.Data });
            }

            return Ok(new { message = result.Message, data = result.Data });
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id, [FromBody] string reason)
        {
            // Supongamos que implementas CancelAsync en el servicio
            // Este cambiaría AppointmentStatusId a 3 y guardaría CancelationReason
            return Ok(new { message = "Cita cancelada." });
        }
    }
}
