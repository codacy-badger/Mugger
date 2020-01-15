using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Mugger.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mugger.Application.Webshops.Commands.UpdateWebshop
{
    public class UpdateWebshopCommandValidator : AbstractValidator<UpdateWebshopCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateWebshopCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");

            RuleFor(v => v.Url)
                .NotEmpty().WithMessage("Url is required.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.");
        }

        public async Task<bool> BeUniqueName(UpdateWebshopCommand model, string name, CancellationToken cancellationToken)
        {
            return await _context.Webshops.AllAsync(w => w.Name != name);
        }

    }
}