using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class AppointmentStatusRepository : IAppointmentStatus
    {
        private readonly ApplicationDbContext _context;
        public AppointmentStatusRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

        public async Task<AppointmentStatus?> GetByNameAsync(string name)
        {
            return await _context.AppointmentStatuses.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
