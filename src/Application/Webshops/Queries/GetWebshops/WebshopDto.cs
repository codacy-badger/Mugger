using Mugger.Application.Common.Mappings;
using Mugger.Domain.Entities;
using System.Collections.Generic;

namespace Mugger.Application.Webshops.Queries.GetWebshops
{
    public class WebshopDto : IMapFrom<Webshop>
    {
        public long Id { get; set; }
        public WebshopDto()
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