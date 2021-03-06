﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Mugger.Application.Webshops.Commands.CreateWebshop;
using Mugger.Application.Webshops.Commands.DeleteWebshop;
using Mugger.Application.Webshops.Commands.UpdateWebshop;
using Mugger.Application.Webshops.Queries.GetWebshops;

namespace Mugger.WebAPI.Controllers
{
    public class WebshopsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<GetWebshopsVm>> Get()
        {
            return await Mediator.Send(new GetWebshopsQuery());
        }


        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateWebshopCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateWebshopCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteWebshopCommand { Id = id });
            return NoContent();
        }

    }
}