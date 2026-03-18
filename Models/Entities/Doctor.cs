using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required, StringLength(200)]
        public string FullName { get; set; } = string.Empty;
        public int SpecialtyId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public Specialty Specialty { get; set; } = null!;
        public ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
