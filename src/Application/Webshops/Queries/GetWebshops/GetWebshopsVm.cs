using System;
using System.Collections.Generic;
using System.Text;

namespace Mugger.Application.Webshops.Queries.GetWebshops
{
    public class GetWebshopsVm
    {
        public IList<WebshopDto> Webshops { get; set; }

        public int Count { get; set; }
    }
}
