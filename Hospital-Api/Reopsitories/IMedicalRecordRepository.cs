using Hospital_Api.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<List<MedicalRecord>> GetAllAsync();
        Task<MedicalRecord> GetByIdAsync(int id);
        Task<MedicalRecord> AddAsync(MedicalRecord medicalRecord);
        Task UpdateAsync(MedicalRecord medicalRecord);
        Task DeleteAsync(int id);
    }
}
