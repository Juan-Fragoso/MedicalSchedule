using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class SpecialtyService
    {
        private readonly ISpecialtyRepository _repository;

        public SpecialtyService(ISpecialtyRepository repository)
        {
            _repository = repository; 
        }

        public async Task<IEnumerable<Specialty>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Specialty?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<bool> CreateAsync(Specialty specialty)
        {
            await _repository.AddAsync(specialty);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Specialty specialty)
        {
            _repository.Update(specialty);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

            return await _repository.SaveChangesAsync();
        }
    }
}
