using FluentValidation;
using Infinite.Core.Business.CQRS.Cupom.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Cupom.Validations
{
    public class CreateCupomValidator : AbstractValidator<CreateCupomCommand>
    {
        public CreateCupomValidator()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                .WithMessage("Tipo não pode ser vazio")
                .MaximumLength(20)
                .WithMessage("Tipo não pode passar de 20 caracteres");

            RuleFor(x => x.Quantidade)
                .NotEqual(0)
                .WithMessage("Quantidade não pode estar vazia");
        }
    }
}
