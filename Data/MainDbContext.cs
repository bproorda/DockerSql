using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using weatherapi3.Models;

namespace weatherapi3.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext (DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<weatherapi3.Models.Colour> Colour { get; set; }
    }
}
