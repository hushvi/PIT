using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Subscriptions.Microservice.Models
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
            System.Console.WriteLine("Starting!");

            _context.Database.Migrate();

            if (!_context.Subscriptions.Any())
            {
                System.Console.WriteLine("Adding default sebscription!");
                _context.Subscriptions.AddRange(
                    new SubscriptionObj() { SubscriptionEmail = "baseemail@gmail.com"}                   
                );
                _context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Not adding default subscription!");
            }
        }
    }
}
