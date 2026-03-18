using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;

namespace Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _contex;
        public DoctorRepository(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _contex.Doctors.Include(d => d.Specialty).ToListAsync();
        public async Task<Doctor?> GetByIdAsync(int id) => await _contex.Doctors.Include(d => d.Specialty).Include(d => d.Schedules).FirstOrDefaultAsync(d => d.DoctorId == id);

        public async Task AddAsync(Doctor doctor) => await _contex.Doctors.AddAsync(doctor);
        public void Update(Doctor doctor) => _contex.Doctors.Update(doctor);
        public async Task DeleteAsync(int id)
        {
            var result = await _contex.Doctors.FindAsync(id);
            if(result != null)
            {
                _contex.Doctors.Remove(result);
            }
        }

        public async Task<bool> SaveChangesAsync() => (await _contex.SaveChangesAsync() > 0);
    }
}
