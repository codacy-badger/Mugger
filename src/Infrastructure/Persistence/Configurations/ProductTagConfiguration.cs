using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugger.Domain.Entities;

namespace Mugger.Infrastructure.Persistence.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.HasKey(pt => new { pt.ProductId, pt.TagId });

            builder.HasOne(pt => pt.Tag)
                 .WithMany(t => t.ProductTags)
                 .HasForeignKey(pt => pt.TagId);

            builder.HasOne(pt => pt.Product)
                 .WithMany(p => p.ProductTags)
                 .HasForeignKey(pt => pt.ProductId);
        }
    }
}
