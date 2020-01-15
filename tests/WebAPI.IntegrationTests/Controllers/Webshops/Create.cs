using Mugger.Application.Webshops.Commands.CreateWebshop;
using Shouldly;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.WebAPI.IntegrationTests.Controllers.Webshop
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateWebshopCommand_ReturnsSuccessCode()
        {
            var client = _factory.GetAnonymousClient();

            var command = new CreateWebshopCommand
            {
                Slug = "bol",
                Name = "Bol.com",
                Description = "bol.com, de winkel van ons allemaal. Kies uit >15 miljoen artikelen. Snel en vanaf 20,- gratis verzonden!",
                Url = "https://www.bol.com/",
                ImageUrl = "/bol.png",
                IconUrl = "/bol-icon.pngc"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/webshops", content);
            
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateWebshopCommand_ReturnsBadRequest()
        {
            var client = _factory.GetAnonymousClient();

            // Webshop without description or imageUrl
            var command = new CreateWebshopCommand
            {
                Slug = "amazon",
                Name = "Amazon",
                ImageUrl = "/amazon.png",
                IconUrl = "/amazon-icon.png"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/webshops", content);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
    }
}