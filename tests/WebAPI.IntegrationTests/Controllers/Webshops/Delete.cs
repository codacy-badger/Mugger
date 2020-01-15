using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.WebAPI.IntegrationTests.Controllers.Webshops
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = _factory.GetAnonymousClient();

            var response = await client.DeleteAsync($"/api/webshops/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFound()
        {
            var invalidId = 99;

            var client = _factory.GetAnonymousClient();

            var response = await client.DeleteAsync($"/api/webshops/{invalidId}");

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}