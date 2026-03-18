using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required, StringLength(200)]
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [StringLength(150)]
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
