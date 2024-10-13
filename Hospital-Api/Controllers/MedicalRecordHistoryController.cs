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
    public class MedicalRecordHistoryController : ControllerBase
    {
        private readonly IMedicalRecordHistoryRepository medicalRecordHistoryRepository;
        private readonly IMedicalRecordRepository medicalRecordRepository;

        public MedicalRecordHistoryController(IMedicalRecordHistoryRepository medicalRecordHistoryRepository, IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordHistoryRepository = medicalRecordHistoryRepository;
            this.medicalRecordRepository = medicalRecordRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalRecordHistory>>> GetAll()
        {
            var medicalRecordHistories = await medicalRecordHistoryRepository.GetAllAsync();
            return Ok(medicalRecordHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalRecordHistory>> GetById(int id)
        {
            var medicalRecordHistory = await medicalRecordHistoryRepository.GetByIdAsync(id);
            if (medicalRecordHistory == null)
            {
                return NotFound();
            }
            return Ok(medicalRecordHistory);
        }

        [HttpGet("/medicalRecord/{id}")]
        public async Task<ActionResult<MedicalRecordHistory>> GetByMedicalId(int id)
        {
            var medicalRecordHistory = await medicalRecordHistoryRepository.GetByIdAsync(id);
            if (medicalRecordHistory == null)
            {
                return NotFound();
            }
            return Ok(medicalRecordHistory);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalRecordHistory>> Add(AddMedicalRecordRequestHistoryDTO medicalRecordHistoryRequestDto)
        {
            var relatedMedicalRecord = await medicalRecordRepository.GetByIdAsync(medicalRecordHistoryRequestDto.MedicalRecordId);

            var medicalHistory = new MedicalRecordHistory()
            {
                Id = 0,
                Notes = medicalRecordHistoryRequestDto.notes,
                Version = 1,
                CreatedByUserId = 1,
                MedicalRecord = relatedMedicalRecord,
            };

            if (relatedMedicalRecord == null) {
                var createdMedicalRecordHistory = await medicalRecordHistoryRepository.AddAsync(medicalHistory);
                return CreatedAtAction(nameof(GetById), new { id = createdMedicalRecordHistory.Id }, createdMedicalRecordHistory);
            }

            var prevVersionNumber = await medicalRecordHistoryRepository.GetByMedicalRecordIdAsync(relatedMedicalRecord.Id);
            if (prevVersionNumber is not null)
            {
                medicalHistory.Version = prevVersionNumber.Version++;
            }


            var newMedicalRecordHistory = await medicalRecordHistoryRepository.AddAsync(medicalHistory);
            return CreatedAtAction(nameof(GetById), new { id = newMedicalRecordHistory.Id }, newMedicalRecordHistory);


        }
    
            

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicalRecordHistory medicalRecordHistory)
        {
            if (id != medicalRecordHistory.Id)
            {
                return BadRequest();
            }
            await medicalRecordHistoryRepository.UpdateAsync(medicalRecordHistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await medicalRecordHistoryRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
