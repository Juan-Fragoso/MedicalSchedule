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
        private readonly ILogRepository _logRepository;
        public DoctorService(IDoctorRepository repository, ISpecialtyRepository specialtyRepository, ILogRepository logRepository)
        {
            _repository = repository;
            _specialtyRepository = specialtyRepository;
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Doctor?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<(bool Success, string Message)> CreateAsync(Doctor doctor)
        {
            // Iniciamos una transacción
            using var transaction = await _repository.BeginTransactionAsync();

            try
            {
                var specialty = await _specialtyRepository.GetByIdAsync(doctor.SpecialtyId);
                if (specialty == null)
                {
                    return (false, "La especialidad proporcionada no existe.");
                }

                // 1. Validar que los DayId sean únicos
                var uniqueDaysCount = doctor.Schedules.Select(s => s.DayId).Distinct().Count();

                if (uniqueDaysCount != doctor.Schedules.Count())
                {
                    return (false, "No puedes asignar múltiples horarios al mismo día de la semana.");
                }

                // 2. Validar Horarios
                foreach (var schedule in doctor.Schedules)
                {
                    if (schedule.StartTime >= schedule.EndTime)
                    {
                        return (false, $"El horario del día {schedule.DayId} es inválido: la hora de inicio debe ser menor a la de fin.");
                    }
                }

                await _repository.AddAsync(doctor);

                var saved = await _repository.SaveChangesAsync();

                if (!saved) return (false, "Ocurrió un error inesperado al guardar en la base de datos.");

                await transaction.CommitAsync();

                return (true, "Doctor registrado exitosamente.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                // Registramos el error en tu tabla SystemLog
                string errorMessage = $"Error al crear Doctor: {ex.Message} | StackTrace: {ex.StackTrace}";
                await _logRepository.AddLogAsync(errorMessage);

                return (false, "Ocurrió un error interno. El incidente ha sido reportado.");
            }
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
                // 1. Validar que los DayId sean únicos
                var uniqueDaysCount = doctor.Schedules.Select(s => s.DayId).Distinct().Count();

                if (uniqueDaysCount != doctor.Schedules.Count())
                {
                    return false;
                }

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
