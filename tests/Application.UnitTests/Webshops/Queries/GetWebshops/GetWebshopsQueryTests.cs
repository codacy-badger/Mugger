using AutoMapper;
using Mugger.Application.Webshops.Queries.GetWebshops;
using Mugger.Infrastructure.Persistence;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.Application.UnitTests.Webshops.Queries
{
    [Collection("QueryTests")]
    public class GetWebshopsQueryTests

    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWebshopsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetWebshopsQuery();

            var handler = new GetWebshopsQuery.GetWebshopsQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<GetWebshopsVm>();
            result.Webshops.Count.ShouldBe(4);

            var webshops = result.Webshops.First();

            webshops.Sellers.Count.ShouldBe(0);
        }
    }
}
