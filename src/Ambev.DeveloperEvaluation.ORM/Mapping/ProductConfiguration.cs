using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.Category).HasMaxLength(100);
        builder.Property(p => p.Image).HasMaxLength(500);
        builder.OwnsOne(p => p.Rating, rating =>
        {
            rating.Property(r => r.Rate).HasColumnName("Rate");
            rating.Property(r => r.Count).HasColumnName("Count");
        });
    }
}