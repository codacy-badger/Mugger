using Mugger.Domain.Common;

namespace Mugger.Domain.Entities
{
    public class Review : AuditableEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
