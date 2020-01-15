using Mugger.Application.Webshops.Commands.CreateWebshop;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.Application.UnitTests.Webshops.Commands.CreateWebshop
{
    public class CreateWebshopCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistTodoItem()
        {
            var command = new CreateWebshopCommand
            {
                Slug = "amazon",
                Name = "Amazon",
                Description = "Amazon: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more",
                Url = "https://www.amazon.com/",
                ImageURL = "/amazon.png",
                Icon = "/amazon-icon.png"

            };

            var handler = new CreateWebshopCommand.CreateWebshopCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Webshops.Find(result);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
        }
    }
}
