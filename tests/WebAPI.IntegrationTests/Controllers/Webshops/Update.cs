using Mugger.Application.Webshops.Commands.UpdateWebshop;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.WebAPI.IntegrationTests.Controllers.Webshops
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateWebshopCommand_ReturnsSuccessCode()
        {
            var client = _factory.GetAnonymousClient();

            var command = new UpdateWebshopCommand
            {
                Id = 1,
                Name = "Test title",
                Description = "This is a test description",
                Url = "http://test.test"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/webshops/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}