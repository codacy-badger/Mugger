using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugger.Infrastructure.Persistence.Configurations
{  
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasMany(b => b.Products)
              .WithOne(p => p.Brand)
              .HasForeignKey(p => p.BrandId)
              .IsRequired(true);
        }
    }
}
