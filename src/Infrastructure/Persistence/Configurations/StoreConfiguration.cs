using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugger.Domain.Entities;


namespace Mugger.Infrastructure.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasAlternateKey(s => s.Slug);

            builder.HasData(
                new Store { Id = 1, Name = "AliExpress", Slug = "aliexpress", URL = "https://aliexpress.com/?lan=nl" },
                new Store { Id = 2, Name = "Amazon", Slug = "amazon", URL = "https://www.amazon.nl/" },
                new Store { Id = 3, Name = "Banggood", Slug = "banggood", URL = "https://www.banggood.com/" }
            );
        }
    }
}
