using CleanCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCommerce.Infrastructure.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.StockQuantity)
            .IsRequired();
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
    }
}