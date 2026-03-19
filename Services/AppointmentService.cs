using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentStatus _appointmentStatus;

        public AppointmentService(IAppointmentRepository repository, IDoctorRepository doctorRepository, IAppointmentStatus appointmentStatus)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _appointmentStatus = appointmentStatus;
        }

        // Agendar Cita
        public async Task<(bool Success, string Message, object? Data)> CreateAppointmentAsync(Appointment appointment)
        {
            // Validación: No agendar en el pasado
            if (appointment.StartDateTime <= DateTime.Now)
                return (false, "No se pueden agendar citas en el pasado.", null);

            // Obtener Doctor para Duración
            var doctor = await _doctorRepository.GetByIdAsync(appointment.DoctorId);
            if (doctor == null) return (false, "El médico no existe.", null);

            // Preparar datos para el SP
            int duration = doctor.Specialty.DurationMinutes;
            appointment.EndDateTime = appointment.StartDateTime.AddMinutes(duration);

            // Convertir el día de la semana de .NET (0=Domingo) al estándar del catálogo (7=Domingo)
            int dayId = (int)appointment.StartDateTime.DayOfWeek;
            if (dayId == 0) dayId = 7;

            // LLAMAR AL SP (Validación de Horario y Traslapes)
            bool isAvailable = await _repository.ValidateAvailabilityAsync(
                appointment.DoctorId,
                appointment.StartDateTime,
                appointment.EndDateTime,
                dayId
            );

            // Si no hay -> usamos el método de sugerencias
            if (!isAvailable)
            {
                var suggestions = await GetSuggestions(doctor, appointment.StartDateTime, duration);

                return (false, "El horario no está disponible.", new { suggestedDates = suggestions });
            }

            // Alerta de Cancelaciones
            int cancellations = await _repository.GetRecentCancellationsCount(appointment.PatientId, 30);
            string alert = cancellations >= 3 ? "ALERTA: Paciente con 3+ cancelaciones recientes." : "";

            var scheduledStatus = await _appointmentStatus.GetByNameAsync("Confirmada");
            appointment.AppointmentStatusId = (scheduledStatus != null) ? scheduledStatus.AppointmentStatusId : 1;

            await _repository.AddAsync(appointment);
            await _repository.SaveChangesAsync();

            return (true, "Cita agendada correctamente. " + alert, new { appointment, alert });
        }

        // Funcion de sugerencias de dias disponibles
        private async Task<List<DateTime>> GetSuggestions(Doctor doctor, DateTime start, int duration)
        {
            var suggestions = new List<DateTime>();
            var currentCheck = start;

            // Buscamos máximo 7 días adelante
            var limitDate = start.AddDays(7);

            while (suggestions.Count < 5 && currentCheck < limitDate)
            {
                currentCheck = currentCheck.AddMinutes(duration);

                int checkDayId = (int)currentCheck.DayOfWeek;
                if (checkDayId == 0) checkDayId = 7;

                // Calculamos el fin de la posible sugerencia
                var currentEnd = currentCheck.AddMinutes(duration);

                // Reutilizamos ValidateAvailabilityAsync para asegurar que el SP dé el visto bueno
                bool isAvailable = await _repository.ValidateAvailabilityAsync(
                    doctor.DoctorId,
                    currentCheck,
                    currentEnd,
                    checkDayId
                );

                if (isAvailable)
                {
                    suggestions.Add(currentCheck);
                }
            }

            return suggestions;
        }

    }
}
