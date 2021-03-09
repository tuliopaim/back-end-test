using Microsoft.EntityFrameworkCore;
using Styme.Data.Configuration;
using Styme.Domain.Entities;

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
