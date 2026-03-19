using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class CancelAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string CancelationReason { get; set; } = string.Empty;
    }
}
