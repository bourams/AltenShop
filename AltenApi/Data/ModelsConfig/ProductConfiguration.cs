using Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.ModelsConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Primary key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.Image)
                .HasMaxLength(500);

            builder.Property(p => p.Category)
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.InternalReference)
                .HasMaxLength(100);

            builder.Property(p => p.ShellId)
                .IsRequired();

            builder.Property(p => p.InventoryStatus)
                   .HasConversion<string>()
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.Rating)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .IsRequired();
        }
    }
}
