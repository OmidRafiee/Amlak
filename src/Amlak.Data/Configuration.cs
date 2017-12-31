using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amlak.Data
{
    public static class Configuration
    {
        public static void Initialize(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                // Applies any pending migrations for the context to the database.
                // Will create the database if it does not already exist.
                context.Database.Migrate();
            }
        }
        public static void SeedData(this IServiceScopeFactory scopeFactory)
        {
            /*
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (context.Users.Any()) return;
                var persons = new List<User>
                {
                    new User
                    {
                        FullName = "Admin",
                        Password = "123456"
                    }
                };
                context.AddRange(persons);
                context.SaveChanges();
            }
            */
        }

    }
}
