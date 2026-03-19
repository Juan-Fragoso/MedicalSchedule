using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Doctor)     
                .ToListAsync();
        }

        public async Task<bool> ValidateAvailabilityAsync(int doctorId, DateTime start, DateTime end, int dayId)
        {
            // Ejecutamos el SP y obtenemos el resultado del SELECT @result
            var result = await _context.Database
                .SqlQueryRaw<bool>
                ("EXEC [dbo].[ValidateDoctorAvailability] @doctorID={0}, @startDateTime={1}, @endDateTime={2}, @dayId={3}", doctorId, start, end, dayId)
                .ToListAsync();

            return result.FirstOrDefault();
        }

        // Buscamos si hay cancelaciones de un paciente
        public async Task<int> GetRecentCancellationsCount(int patientId, int days)
        {
            // Buscamos el estatus 'Cancelada' o 'Cancelado'
            var status = await _context.AppointmentStatuses
                .FirstOrDefaultAsync(s => s.Name == "Cancelada" || s.Name == "Cancelado");
            var appointmentStatusId = (status?.AppointmentStatusId ?? 6);

            var limitDate = DateTime.Now.AddDays(-days);
            return await _context.Appointments
                .CountAsync(a => a.PatientId == patientId
                            && a.AppointmentStatusId == appointmentStatusId
                            && a.CreatedAt >= limitDate);
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task AddAsync(Appointment appointment) => await _context.Appointments.AddAsync(appointment);
        public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync()) > 0;
    }
}
