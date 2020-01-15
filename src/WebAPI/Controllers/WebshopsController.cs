using Microsoft.AspNetCore.Mvc;
using Mugger.Application.Webshops.Commands.CreateWebshop;
using Mugger.Application.Webshops.Commands.DeleteWebshop;
using System.Threading.Tasks;

namespace Mugger.WebAPI.Controllers
{
    public class WebshopsController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateWebshopCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteWebshopCommand { Id = id });
            return NoContent();
        }

    }
}