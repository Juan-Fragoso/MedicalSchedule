using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;
        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get() => Ok(await _patientService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            return patient == null ? NotFound() : Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> Post(Patient patient)
        {
            var (success, message) = await _patientService.CreateAsync(patient);
            if (!success) return BadRequest(new { message });

            return CreatedAtAction(nameof(Get), new { id = patient.PatientId }, patient);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Patient patient)
        {
            if (patient.PatientId <= 0) return BadRequest(new { message = "ID inválido." });

            var (success, message) = await _patientService.UpdateAsync(patient);

            if (!success)
            {
                if (message.Contains("no encontrado")) return NotFound(new { message });
                return BadRequest(new { message });
            }

            return Ok(new { message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patientService.DeleteAsync(id);
            return result ? Ok(new { message = "Paciente eliminado." }) : NotFound();
        }
    }
}
