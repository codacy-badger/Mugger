using Mugger.Application.Common.Exceptions;
using Mugger.Application.Webshops.Commands.UpdateWebshop;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.Application.UnitTests.Webshops.Commands.UpdateWebshop
{
    public class UpdateWebshopCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedWebshop()
        {
            var command = new UpdateWebshopCommand
            {
                Id = 1,
                Name = "Test title",
                Description = "This is a test description",
                Url = "http://test.test"
            };

            var handler = new UpdateWebshopCommand.UpdateWebshopCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Webshops.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateWebshopCommand
            {
                Id = 99,
                Name = "Test title",
                Description = "This is a test description",
                Url = "http://test.test"
            };

            var sut = new UpdateWebshopCommand.UpdateWebshopCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                sut.Handle(command, CancellationToken.None));
        }
    }
}