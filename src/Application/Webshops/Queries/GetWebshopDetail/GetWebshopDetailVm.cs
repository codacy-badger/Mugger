using System;
using System.Collections.Generic;
using System.Text;

namespace Mugger.Application.Webshops.Queries.GetWebshopDetail
{
    public class GetWebshopDetailVm
    {
        public GetWebshopDetailVm()
        {
            Sellers = new List<SellerDto>();
        }

        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string IconUrl { get; set; }

        public IList<SellerDto> Sellers { get; set; }
    }
}
