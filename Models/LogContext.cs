using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotLog.Models
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Log> Logs { get; set; }
    }
}
