using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class SystemLog
    {
        public int SystemLogId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
