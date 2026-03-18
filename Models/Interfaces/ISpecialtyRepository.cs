using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty>> GetAllAsync();
        Task<Specialty?> GetByIdAsync(int id);
        Task AddAsync(Specialty specialty);
        void Update(Specialty specialty);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
