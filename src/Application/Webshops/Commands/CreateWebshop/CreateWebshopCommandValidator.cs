using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Mugger.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Webshops.Commands.CreateWebshop
{
    public class CreateWebshopCommandValidator : AbstractValidator<CreateWebshopCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateWebshopCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");

            RuleFor(v => v.Url)
                .NotEmpty();

            RuleFor(v => v.Description)
                .NotEmpty();
        }

        public async Task<bool> BeUniqueName(CreateWebshopCommand model, string name, CancellationToken cancellationToken)
        {
            return await _context.Webshops.AllAsync(w => w.Name != name);
        }

    }
}
