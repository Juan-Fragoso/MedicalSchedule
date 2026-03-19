using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        public Specialty? Specialty { get; set; } = null!;
        public ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();

        [JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
