using Hospital_Api.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Api.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }
}
