using Microsoft.AspNetCore.Mvc;
using Mugger.Application.Webshops.Commands.CreateWebshop;
using System.Threading.Tasks;

namespace Mugger.WebAPI.Controllers
{
    public class WebshopController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateWebshopCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}