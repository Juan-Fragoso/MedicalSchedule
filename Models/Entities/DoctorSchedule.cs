using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class DoctorSchedule
    {
        public int DoctorScheduleId { get; set; }
        public int DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Doctor Doctor { get; set; } = null!;
    }
}
