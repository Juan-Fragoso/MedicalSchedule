using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class AppointmentStatus
    {
        public int AppointmentStatusId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
