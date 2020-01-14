using MediatR;
using Mugger.Application.Common.Interfaces;
using Mugger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Webshops.Commands.CreateWebshop
{
    public class CreateWebshopCommand : IRequest<long>
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageURL { get; set; }
        public string Icon { get; set; }

        public class CreateWebshopCommandHandler : IRequestHandler<CreateWebshopCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateWebshopCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateWebshopCommand request, CancellationToken cancellationToken)
            {
                var entity = new Webshop
                {
                    Slug = request.Slug,
                    Name = request.Name,
                    Description = request.Description,
                    Url = request.Url,
                    ImageURL = request.Url,
                    Icon = request.Icon
                };

                _context.Webshops.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
