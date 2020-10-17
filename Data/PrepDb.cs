using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherapi3.Models;

namespace weatherapi3.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MainDbContext>());
            }
        }

        public static void SeedData(MainDbContext context)
        {
            System.Console.WriteLine("Applying Migrations... ");

            context.Database.Migrate();

            if (!context.Colour.Any())
            {
                System.Console.WriteLine("Seeding Data... ");

                context.Colour.AddRange(
                    new Colour() { ColourName = "Red" },
                    new Colour() { ColourName = "Blue" },
                    new Colour() { ColourName = "Green" }
                );

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data, seeding canceled.");
            }
        }

    }
}
