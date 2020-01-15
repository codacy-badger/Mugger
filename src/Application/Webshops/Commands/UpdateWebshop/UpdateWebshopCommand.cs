using MediatR;
using Mugger.Application.Common.Exceptions;
using Mugger.Application.Common.Interfaces;
using Mugger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Webshops.Commands.UpdateWebshop
{
    public partial class UpdateWebshopCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string IconUrl { get; set; }

        public class UpdateWebshopCommandHandler : IRequestHandler<UpdateWebshopCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateWebshopCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateWebshopCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Webshops.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Webshop), request.Id);
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Url = request.Url;
                entity.ImageUrl = request.ImageUrl;
                entity.IconUrl = request.IconUrl;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}