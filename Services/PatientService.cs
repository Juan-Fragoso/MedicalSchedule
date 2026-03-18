using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Patient?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<bool> CreateAsync(Patient patient)
        {
            await _repository.AddAsync(patient);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
            _repository.Update(patient);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.SaveChangesAsync();
        }
    }
}
