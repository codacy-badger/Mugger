using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mugger.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Webshops.Queries.GetWebshops
{
    public class GetWebshopsQuery : IRequest<GetWebshopsVm>
    {
        public class GetWebshopsQueryHandler : IRequestHandler<GetWebshopsQuery, GetWebshopsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetWebshopsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetWebshopsVm> Handle(GetWebshopsQuery request, CancellationToken cancellationToken)
            {                
                var webshops  = await _context.Webshops
                    .ProjectTo<WebshopDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);

                var vm = new GetWebshopsVm
                {
                    Webshops = webshops,
                    Count = webshops.Count
                };

                return vm;
            }
        }
    }
}