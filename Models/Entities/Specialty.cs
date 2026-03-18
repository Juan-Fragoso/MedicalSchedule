using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace Models.Entities
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Una especialidad tiene muchos doctores
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
