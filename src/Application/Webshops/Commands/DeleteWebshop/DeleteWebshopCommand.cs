using MediatR;
using Microsoft.EntityFrameworkCore;
using Mugger.Application.Common.Exceptions;
using Mugger.Application.Common.Interfaces;
using Mugger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Webshops.Commands.DeleteWebshop
{
    public class DeleteWebshopCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteWebshopCommandHandler : IRequestHandler<DeleteWebshopCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteWebshopCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteWebshopCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Webshops
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Webshop), request.Id);
                }

                _context.Webshops.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
