using Mugger.Domain.Common;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string StoreProductId { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; } = 0;
        public int TotalOrders { get; set; } = 0;
        public string URL { get; set; }
        public string PromotionURL { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal PriceInDollars { get; set; }
        public decimal OriginalPriceInDollars { get; set; }

    
        public Store Store { get; set; }
     
        public IList<ProductTag> ProductTags { get; set; }

        public IList<Tag> Tags { get; set; }

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
