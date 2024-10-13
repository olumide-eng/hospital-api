using Hospital_Api.Models.Domain;
using Hospital_Api.Models.DTO;
using Hospital_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordRepository medicalRecordRepository;
        private readonly IPatientRepository patientRepository;

        public MedicalRecordController(IMedicalRecordRepository medicalRecordRepository, IPatientRepository patientRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
            this.patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetAll()
        {
            var medicalRecords = await medicalRecordRepository.GetAllAsync();
            return Ok(medicalRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalRecord>> GetById(int id)
        {
            var medicalRecord = await medicalRecordRepository.GetByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return Ok(medicalRecord);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalRecord>> Add(AddMedicalRecordRequestDto medicalRecordRequest)

        {
            var relatedPatient = await patientRepository.GetByIdAsync(medicalRecordRequest.PatientId);
            var medicalRecord = new MedicalRecord
            {
                Id = 0,
                PatientId = relatedPatient.Id,
                Patient = relatedPatient,
            };
            var createdMedicalRecord = await medicalRecordRepository.AddAsync(medicalRecord);
            return CreatedAtAction(nameof(GetById), new { id = createdMedicalRecord.Id }, createdMedicalRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.Id)
            {
                return BadRequest();
            }
            await medicalRecordRepository.UpdateAsync(medicalRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await medicalRecordRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
