using MediatR;
using Mugger.Application.Common.Interfaces;
using Mugger.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        public string WebshopProductId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


        public class CreateTodoItemCommandHandler : IRequestHandler<CreateProductCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateTodoItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var entity = new Product
                {
                    WebshopProductId = request.WebshopProductId,
                    Name = request.Name,
                    Slug = request.Slug,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl
                };

                _context.Products.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}