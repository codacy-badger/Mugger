using Mugger.Domain.Common;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Tag : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public IList<ProductTag> Products { get; set; }
        public int TotalProducts { get; set; }
    }
}
