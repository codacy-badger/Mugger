using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugger.Domain.Entities;


namespace Mugger.Infrastructure.Persistence.Configurations
{
    public class WebshopConfiguration : IEntityTypeConfiguration<Webshop>
    {
        public void Configure(EntityTypeBuilder<Webshop> builder)
        {
            builder.HasAlternateKey(s => s.Slug);

            builder.HasData(
                new Webshop { Id = 1, Name = "AliExpress", Slug = "aliexpress", Url = "https://aliexpress.com/?lan=nl" },
                new Webshop { Id = 2, Name = "Amazon", Slug = "amazon", Url = "https://www.amazon.nl/" },
                new Webshop { Id = 3, Name = "Banggood", Slug = "banggood", Url = "https://www.banggood.com/" }
            );
        }
    }
}
