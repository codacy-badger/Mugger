using Mugger.Domain.Common;
using System;
using System.Collections.Generic;

namespace Mugger.Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public string SellerProductId { get; set; }
        public int TotalOrders { get; set; }
        public string Url { get; set; }
        public string PromotionUrl { get; set; }

        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }        

        public long SellerId { get; set; }
        public Seller Seller { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }

}
