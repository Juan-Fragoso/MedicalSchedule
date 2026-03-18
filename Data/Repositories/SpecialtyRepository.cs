using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Specialty>> GetAllAsync() => await _context.Specialties.ToListAsync();

        public async Task<Specialty?> GetByIdAsync(int id) => await _context.Specialties.FindAsync(id);

        public async Task AddAsync(Specialty specialty) => await _context.Specialties.AddAsync(specialty);

        public void Update(Specialty specialty) => _context.Specialties.Update(specialty);

        public async Task DeleteAsync(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty != null)
            {
                _context.Specialties.Remove(specialty);
            }
        }

        public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync() > 0);
    }
}
