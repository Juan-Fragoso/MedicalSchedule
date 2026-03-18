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

            // 2. Validar Horarios (Lógica de Negocio Senior)
            foreach (var schedule in doctor.Schedules)
            {
                if (schedule.StartTime >= schedule.EndTime)
                {
                    return false;
                }
            }

            await _repository.AddAsync(doctor);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            var existingDoctor = await _repository.GetByIdAsync(doctor.DoctorId);

            if (existingDoctor == null) return false;

            // Actualizar datos Doctor
            existingDoctor.FullName = doctor.FullName;
            existingDoctor.SpecialtyId = doctor.SpecialtyId;

            // Lógica Condicional para Horarios
            if (doctor.Schedules != null && doctor.Schedules.Any())
            {
                // Limpiar los horarios actuales 
                existingDoctor.Schedules.Clear();

                // Agregar los nuevos horarios del JSON
                foreach (var newSchedule in doctor.Schedules)
                {
                    if (newSchedule.StartTime < newSchedule.EndTime)
                    {
                        existingDoctor.Schedules.Add(newSchedule);
                    }
                }
            }

            // ejecutar los DELETE de los viejos y los INSERT de los nuevos en una sola transacción
            _repository.Update(existingDoctor);
            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

            return await _repository.SaveChangesAsync();
        }
    }
}
