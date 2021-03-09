using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Styme.Domain.Entities;

namespace Styme.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(m => m.Price)
                .IsRequired()
                .HasColumnType("numeric(19,2)");

            builder.Property(m => m.ImageUri)
                .HasColumnType("varchar(200)");

            builder.Property(m => m.Category)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
