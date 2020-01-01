using Mugger.Domain.Common;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public long BrandId { get; set; }
        public Brand Brand { get; set; }

        public double Rating { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }
       
    }

    public class ProductTag
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }

        public ProductTag(long productId, long tagId)
        {
            ProductId = productId;
            TagId = tagId;
        }

        public ProductTag(Product product, Tag tag)
        {
            Product = product;
            Tag = tag;
        }
    }


}
