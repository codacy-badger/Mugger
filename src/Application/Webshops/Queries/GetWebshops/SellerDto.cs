using Mugger.Application.Common.Mappings;
using Mugger.Domain.Entities;

namespace Mugger.Application.Webshops.Queries.GetWebshops
{
    public class SellerDto : IMapFrom<Seller>
    {
        public long Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Icon { get; set; }
        public long? WebshopId { get; set; }

    }
}
