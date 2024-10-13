using Hospital_Api.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Repositories
{
    public interface IMedicalRecordHistoryRepository
    {
        Task<List<MedicalRecordHistory>> GetAllAsync();
        Task<MedicalRecordHistory> GetByIdAsync(int id);

        Task<MedicalRecordHistory> GetByMedicalRecordIdAsync(int id);
        Task<MedicalRecordHistory> AddAsync(MedicalRecordHistory medicalRecordHistory);
        Task UpdateAsync(MedicalRecordHistory medicalRecordHistory);
        Task DeleteAsync(int id);
    }
}
