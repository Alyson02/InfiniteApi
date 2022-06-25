using FluentValidation;
using Infinite.Core.Business.CQRS.Funcionario.Commands;
using Infinite.Core.Business.Services.Base;
using Infinite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Funcionario.Validations
{
    internal class UpdateFuncionarioValidator : AbstractValidator<UpdateFuncionarioCommand>
    {
        public UpdateFuncionarioValidator(IServiceBase<FuncionarioEntity> service)
        {   
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(x => x.Senha)
                .MinimumLength(8)
                .WithMessage("A senha tem que ter no minimo 8 caracteres")
                .MaximumLength(20)
                .WithMessage("A senha pode ter no maximo 20 caracteres")
                .NotEmpty()
                .WithMessage("A senha é obrigatória");

            RuleFor(x => x.Nome)
                .MinimumLength(10)
                .WithMessage("O nome tem que ter pelo menos 10 caracteres")
                .MaximumLength(150)
                .WithMessage("O nome tem que ter no maximo 150 caracteres");

            RuleFor(x => x.Telefone)
                .MinimumLength(9)
                .WithMessage("O telefone tem que ter pelo menos 9 caracteres")
                .MaximumLength(100)
                .WithMessage("O telefone tem que ter no maximo 14 caracteres");
        }

    }
}
