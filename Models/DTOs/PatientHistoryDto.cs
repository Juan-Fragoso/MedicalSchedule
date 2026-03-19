using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class PatientHistoryDto
    {
        public string PatientFullName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string SpecialityName { get; set; } = string.Empty;
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
    }
}
