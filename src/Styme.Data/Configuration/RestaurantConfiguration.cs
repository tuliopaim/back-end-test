using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Styme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Data.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(r => r.Address)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(r => r.Category)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(r => r.Location)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(r => r.ImageUri)
                .HasColumnType("varchar(200)");

            builder.HasMany(r => r.Menus)
                .WithOne(m => m.Restaurant)
                .HasForeignKey(m => m.RestaurantId);
        }
    }
}
