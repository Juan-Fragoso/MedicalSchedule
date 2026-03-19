using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
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

        [HttpPatch("cancel")]
        public async Task<IActionResult> Cancel([FromBody] CancelAppointmentDto request)
        {
            // El controlador ahora recibe el objeto estructurado
            var result = await _service.CancelAppointmentAsync(request.AppointmentId, request.CancelationReason);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
