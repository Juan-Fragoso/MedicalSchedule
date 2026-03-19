using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class DoctorAppointmentDto
    {
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhoneNumber { get; set; } = string.Empty;
        public string AppointmentReason { get; set; } = string.Empty;
        public string AppointmentStatus { get; set; } = string.Empty;
    }
}
