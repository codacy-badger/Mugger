using Mugger.Domain.Common;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Webshop : AuditableEntity
    {        
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }   
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string IconUrl { get; set; }

        public ICollection<Seller> Sellers { get; set; }

    }
}
