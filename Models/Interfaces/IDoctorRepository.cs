using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace Models.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        void Update(Doctor doctor);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
