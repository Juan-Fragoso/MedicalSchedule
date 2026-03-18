using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task AddAsync(Patient patient);
        void Update(Patient patient);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
