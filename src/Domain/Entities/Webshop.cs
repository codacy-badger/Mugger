﻿using Mugger.Domain.Common;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Webshop : AuditableEntity
    {        
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }   
        public string Url { get; set; }
        public string ImageURL { get; set; }
        public string Icon { get; set; }

        public ICollection<Seller> Sellers { get; set; }

    }
}
