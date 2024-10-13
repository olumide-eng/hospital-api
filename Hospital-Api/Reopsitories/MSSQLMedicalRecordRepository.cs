using Hospital_Api.Data;
using Hospital_Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Repositories
{
    public class MSSQLMedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly HospitalPatientDbContext dbContext;

        public MSSQLMedicalRecordRepository(HospitalPatientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MedicalRecord>> GetAllAsync()
        {
            return await dbContext.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord> GetByIdAsync(int id)
        {
            return await dbContext.MedicalRecords.FindAsync(id);
        }

        public async Task<MedicalRecord> AddAsync(MedicalRecord medicalRecord)
        {
            dbContext.MedicalRecords.Add(medicalRecord);
            await dbContext.SaveChangesAsync();
            return medicalRecord;
        }

        public async Task UpdateAsync(MedicalRecord medicalRecord)
        {
            dbContext.Entry(medicalRecord).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medicalRecord = await dbContext.MedicalRecords.FindAsync(id);
            if (medicalRecord != null)
            {
                dbContext.MedicalRecords.Remove(medicalRecord);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

