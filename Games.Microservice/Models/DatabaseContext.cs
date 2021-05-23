using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Microservice.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<GamesObj> Games { get; set; }

        public DbSet<GameEventsObj> GameEvents { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
