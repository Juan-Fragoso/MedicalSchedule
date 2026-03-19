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

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _service.GetAllAppointmentsAsync();
            return Ok(appointments); 
        }
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

        // Obtener agenda del dia
        [HttpGet("agenda")]
        public async Task<IActionResult> GetAgenda([FromQuery] int doctorId, [FromQuery] DateTime date)
        {
            var agenda = await _service.GetDoctorAgendaAsync(doctorId, date);

            if (agenda == null || !agenda.Any())
            {
                return NotFound(new { message = "No hay citas programadas para este médico en la fecha seleccionada." });
            }

            return Ok(agenda);
        }

        [HttpGet("patient/{patientId}/history")]
        public async Task<IActionResult> GetPatientHistory(int patientId)
        {
            var history = await _service.GetPatientHistoryAsync(patientId);

            if (history == null || !history.Any())
            {
                return NotFound(new { message = "No se encontró historial para este paciente." });
            }

            return Ok(history);
        }
    }
}
