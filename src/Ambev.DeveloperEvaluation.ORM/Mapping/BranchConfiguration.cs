using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(b => b.BranchId).IsRequired();
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);

        builder.Property(b => b.CreatedAt).IsRequired();
    }
}
