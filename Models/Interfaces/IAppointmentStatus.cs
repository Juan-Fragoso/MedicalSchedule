using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IAppointmentStatus
    {
        Task<AppointmentStatus> GetByNameAsync(string name);
    }
}
