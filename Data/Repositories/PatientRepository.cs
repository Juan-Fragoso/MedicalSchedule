using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAllAsync() => await _context.Patients.ToListAsync();

        public async Task<Patient?> GetByIdAsync(int id) => await _context.Patients.FindAsync(id);

        public async Task AddAsync(Patient patient) => await _context.Patients.AddAsync(patient);

        public void Update(Patient patient) => _context.Patients.Update(patient);

        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null) _context.Patients.Remove(patient);
        }

        public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync()) > 0;
    }
}
