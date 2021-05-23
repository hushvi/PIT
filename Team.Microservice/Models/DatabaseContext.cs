using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team.Microservice.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TeamObj> Teams { get; set; }

        public DbSet<PlayerObj> Players { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        
        }
    }
}
