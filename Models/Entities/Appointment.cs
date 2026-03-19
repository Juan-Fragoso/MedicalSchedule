using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Reason { get; set; }
        public int AppointmentStatusId { get; set; }
        public string? CancelationReason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Doctor? Doctor { get; set; } = null!;
        public Patient? Patient { get; set; } = null!;
    }
}
