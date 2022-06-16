using FluentValidation;
using Infinite.Core.Business.CQRS.Usuario.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Usuario.Validations
{
    public class UsuarioLoginCommandValidation : AbstractValidator<UsuarioLoginCommand>
    {
        public UsuarioLoginCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha é obrigatório");
        }

    }
}
