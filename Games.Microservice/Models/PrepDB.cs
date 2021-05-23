﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Microservice.Models
{
    public static class PrepDB
    {
        public static void PrePopulation(IApplicationBuilder _app)
        {
            using (var serviceScope = _app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DatabaseContext>());
            }
        }

        public static void SeedData(DatabaseContext _context)
        {
            _context.Database.Migrate();
        }
    }
}