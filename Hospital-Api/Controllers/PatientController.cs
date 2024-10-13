using Hospital_Api.Models.Domain;
using Hospital_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Hospital_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/Patient/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            var createdPatient = await _patientRepository.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
        }

        // PUT: api/Patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (patient == null || patient.Id != id)
            {
                return BadRequest();
            }

            var existingPatient = await _patientRepository.GetByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            await _patientRepository.UpdateAsync(patient);
            return NoContent();
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var existingPatient = await _patientRepository.GetByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            await _patientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
