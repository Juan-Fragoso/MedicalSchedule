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
        private readonly ILogRepository _logRepository;

        public PatientService(IPatientRepository repository, ILogRepository logRepository)
        {
            _repository = repository;
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Patient?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<(bool Success, string Message)> CreateAsync(Patient patient)
        {
            using var transaction = await _repository.BeginTransactionAsync();

            try
            {
                await _repository.AddAsync(patient);
                await _repository.SaveChangesAsync();

                await transaction.CommitAsync();

                return (true, "Paciente registrado.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _repository.ClearTracker();

                await _logRepository.AddLogAsync($"Error CreatePatient: {ex.Message}");

                return (false, "Error interno al registrar paciente.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateAsync(Patient patient)
        {
            using var transaction = await _repository.BeginTransactionAsync();
            try
            {
                var existing = await _repository.GetByIdAsync(patient.PatientId);
                if (existing == null) return (false, "Paciente no encontrado.");

                existing.FullName = patient.FullName;
                existing.BirthDate = patient.BirthDate;
                existing.PhoneNumber = patient.PhoneNumber;
                existing.Email = patient.Email;

                await _repository.SaveChangesAsync();

                await transaction.CommitAsync();

                return (true, "Paciente actualizado.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _repository.ClearTracker();

                await _logRepository.AddLogAsync($"Error UpdatePatient ID {patient.PatientId}: {ex.Message}");

                return (false, "Error interno al actualizar paciente.");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.SaveChangesAsync();
        }
    }
}
