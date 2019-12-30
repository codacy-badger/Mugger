using Mugger.Domain.Common;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Store : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }

  
        public IList<Product> Products { get; set; }
        public int TotalProducts { get; set; }

    }
}
