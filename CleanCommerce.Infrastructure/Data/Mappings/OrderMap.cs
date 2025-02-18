using CleanCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCommerce.Infrastructure.Data.Mappings;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OrderDate).
            IsRequired();
        builder.Property(x => x.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(x => x.Quantity)
            .IsRequired();
        
        // Relacionamento com Product
        builder.HasOne(e => e.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}