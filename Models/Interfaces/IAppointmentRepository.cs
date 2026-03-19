using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        // Validacion disponibilidad del doctor
        Task<bool> ValidateAvailabilityAsync(int doctorId, DateTime start, DateTime end, int dayId);
        Task<int> GetRecentCancellationsCount(int patientId, int days);
        Task AddAsync(Appointment appointment);
        Task<Appointment?> GetByIdAsync(int appointmentId);
        Task<bool> SaveChangesAsync();
    }
}
