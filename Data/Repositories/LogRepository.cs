using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationDbContext _context;
        public LogRepository(ApplicationDbContext context) => _context = context;

        public async Task AddLogAsync(string message)
        {
            await _context.SystemLog.AddAsync(new SystemLog
            {
                Message = message,
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync();
        }
    }
}
