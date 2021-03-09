using Microsoft.EntityFrameworkCore;
using Styme.Data.Configuration;
using Styme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Data
{
    public class StymeContext : DbContext
    {
        public StymeContext(DbContextOptions<StymeContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>(new RestaurantConfiguration().Configure);
            modelBuilder.Entity<Menu>(new MenuConfiguration().Configure);
        }
    }
}
