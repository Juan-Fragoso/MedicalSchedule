using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SpecialtiesController : ControllerBase
    {
        private readonly SpecialtyService _specialtyService;

        public SpecialtiesController(SpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        // Get: api/Specialties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetSpecialties()
        {
            var specialties = await _specialtyService.GetAllAsync();

            return Ok(specialties);
        }

        // Get: api/Specialties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialty>> GetSpecialty(int id)
        {
            var specialty = await _specialtyService.GetByIdAsync(id);

            if (specialty == null)
            {
                return NotFound(
                    new
                    {
                        message = $"Especialidad con Id {id} no encontrada"
                    });
            }

            return Ok(specialty);
        }

        // POST: api/Specialties
        [HttpPost]
        public async Task<ActionResult<Specialty>> PostSpecialty(Specialty specialty)
        {
            var result = await _specialtyService.CreateAsync(specialty);

            if(!result)
            {
                return BadRequest(new { message = "No se pudo crear la especialidad"});
            }

            return CreatedAtAction(nameof(GetSpecialty), new { id = specialty.SpecialtyId }, specialty);
        }

        // PUT: api/Specialties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialty(int id, Specialty specialty)
        {
            if(id != specialty.SpecialtyId)
            {
                return BadRequest(new { message = "El Id no coicide con una especialidad" });
            }

            var result = await _specialtyService.UpdateAsync(specialty);

            if(!result)
            {
                return NotFound();
            }

            return Ok(new { message = "Especialidad actualizada"});
        }

        // DELETE: api/Specialties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            var resul = await _specialtyService.DeleteAsync(id);

            if(!resul)
            {
                return NotFound(new { message = "la especialidad no existe"});
            }

            return Ok(new {message = "Especialidad eliminada correctamente" });
        }

    }
}
