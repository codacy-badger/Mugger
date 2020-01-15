using Mugger.Application.Common.Exceptions;
using Mugger.Application.Webshops.Commands.DeleteWebshop;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mugger.Application.UnitTests.Webshops.Commands.DeleteWebshop
{
    public class DeleteWebshopCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedWebshop()
        {
            var command = new DeleteWebshopCommand
            {
                Id = 10
            };

            var handler = new DeleteWebshopCommand.DeleteWebshopCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Webshops.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteWebshopCommand
            {
                Id = 99
            };

            var handler = new DeleteWebshopCommand.DeleteWebshopCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
