using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _doctorService;
        public DoctorsController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Get: api/doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();

            return Ok(doctors);
        }

        // Get: api/soctors/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);

            if(doctor == null)
            {
                return NotFound(
                    new { message = $"el doctor con Id {id} no encotrada" }
                );
            }

            return Ok(doctor);
        }

        // Post: api/doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            var (success, message) = await _doctorService.CreateAsync(doctor);

            if(!success)
            {
                return BadRequest(new { message });
            }

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorId }, doctor);
        }

        // Put: api/doctors
        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            if (doctor.DoctorId <= 0)
            {
                return BadRequest(new { message = "Se requiere un ID de doctor válido en el cuerpo de la solicitud." });
            }

            var (success, message) = await _doctorService.UpdateAsync(doctor);

            if (!success)
            {
                if (message.Contains("no existe")) return NotFound(new { message });

                return BadRequest(new { message });
            }

            return Ok(new { message });
        }

        //Delete: api/doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.DeleteAsync(id);
            if(!result)
            {
                return NotFound(new { message = "El doctor no existe" });
            }

            return Ok(new { message = "Doctor eliminado exitosamente" });
        }
    }
}
