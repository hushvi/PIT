using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subscriptions.Microservice.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SubscriptionObj> Subscriptions { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
