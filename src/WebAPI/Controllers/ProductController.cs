using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mugger.Application.Products.Commands.CreateProduct;

namespace Mugger.WebAPI.Controllers
{
    public class ProductController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}