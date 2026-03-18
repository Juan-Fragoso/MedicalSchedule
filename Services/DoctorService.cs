using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public DoctorService(IDoctorRepository repository, ISpecialtyRepository specialtyRepository)
        {
            _repository = repository;
            _specialtyRepository = specialtyRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Doctor?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<bool> CreateAsync(Doctor doctor)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(doctor.SpecialtyId);
            if (specialty == null)
            {
                return false;
            }

            await _repository.AddAsync(doctor);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            _repository.Update(doctor);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

            return await _repository.SaveChangesAsync();
        }
    }
}
