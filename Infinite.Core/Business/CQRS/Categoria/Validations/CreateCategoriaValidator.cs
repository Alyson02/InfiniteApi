using FluentValidation;
using Infinite.Core.Business.CQRS.Categoria.Commands;
using Infinite.Core.Business.Services.Base;
using Infinite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Categoria.Validations
{
    internal class CreateCategoriaValidator : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaValidator(IServiceBase<CategoriaEntity> service)
        {
            RuleFor(x => x.Categoria)
                .MaximumLength(50)
                .WithMessage("O nome da categoria pode ter até no maxímo 50 caracteres")
                .NotEmpty();
        }

    }
}
