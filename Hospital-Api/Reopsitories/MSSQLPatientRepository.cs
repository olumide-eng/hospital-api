using Hospital_Api.Data;
using Hospital_Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Repositories
{
    public class MSSQLPatientRepository : IPatientRepository
    {
        public HospitalPatientDbContext dbContext { get; }

        public MSSQLPatientRepository(HospitalPatientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await this.dbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await this.dbContext.Patients.FindAsync(id);
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            dbContext.Patients.Add(patient);
            await dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task UpdateAsync(Patient patient)
        {
            this.dbContext.Entry(patient).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await this.dbContext.Patients.FindAsync(id);
            if (patient != null)
            {
                this.dbContext.Patients.Remove(patient);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
