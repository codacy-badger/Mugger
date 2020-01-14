using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugger.Domain.Entities;


namespace Mugger.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasAlternateKey(t => t.WebshopProductId);

            builder.HasAlternateKey(t => t.Slug);

            builder.HasOne(p => p.Brand)
              .WithMany(t => t.Products)
              .HasForeignKey(p => p.BrandId)
              .IsRequired(false);
        }
    }
}
