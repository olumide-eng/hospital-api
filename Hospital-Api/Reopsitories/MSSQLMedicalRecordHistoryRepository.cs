using Hospital_Api.Data;
using Hospital_Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Repositories
{
    public class MSSQLMedicalRecordHistoryRepository : IMedicalRecordHistoryRepository
    {
        private readonly HospitalPatientDbContext dbContext;

        public MSSQLMedicalRecordHistoryRepository(HospitalPatientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MedicalRecordHistory>> GetAllAsync()
        {
            return await dbContext.MedicalRecordHistory.ToListAsync();
        }

        public async Task<MedicalRecordHistory> GetByIdAsync(int id)
        {
            return await dbContext.MedicalRecordHistory.FindAsync(id);
        }

        public async Task<MedicalRecordHistory> GetByMedicalRecordIdAsync(int id)
        {
            return await dbContext.MedicalRecordHistory.FirstOrDefaultAsync(mrh => mrh.MedicalRecordId == id);
        }

        public async Task<MedicalRecordHistory> AddAsync(MedicalRecordHistory medicalRecordHistory)
        {
            dbContext.MedicalRecordHistory.Add(medicalRecordHistory);
            await dbContext.SaveChangesAsync();
            return medicalRecordHistory;
        }

        public async Task UpdateAsync(MedicalRecordHistory medicalRecordHistory)
        {
            dbContext.Entry(medicalRecordHistory).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medicalRecordHistory = await dbContext.MedicalRecordHistory.FindAsync(id);
            if (medicalRecordHistory != null)
            {
                dbContext.MedicalRecordHistory.Remove(medicalRecordHistory);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

