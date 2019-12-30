
using Microsoft.EntityFrameworkCore;
using Mugger.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductTag> ProductTags { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Tag> Tags { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
