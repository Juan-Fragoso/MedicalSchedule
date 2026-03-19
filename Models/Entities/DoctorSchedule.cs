using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class DoctorSchedule
    {
        public int DoctorScheduleId { get; set; }
        public int DoctorId { get; set; }
        public int DayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore] // Evita que el JSON intente subir del Horario al Doctor
        public Doctor? Doctor { get; set; } = null!;
    }
}
