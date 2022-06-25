using FluentValidation;
using Infinite.Core.Business.CQRS.Agendamento.Commands;
using Infinite.Core.Business.Services.Base;
using Infinite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Agendamento.Validations
{
    internal class CreateAgendamentoValidator : AbstractValidator<CreateAgendamentoCommand>
    {
        public CreateAgendamentoValidator(IServiceBase<AgendamentoEntity> service)
        {
            RuleFor(x => x.UsuarioId)
                .Custom((Usuario, contexto) =>
                {
                    var spec = service.CreateSpec(x => x.Cliente.UsuarioId == Usuario)
                        .AddInclude(x => x.Cliente.Usuario);
                    var temUsuario = service.FindAsync(spec).Result;

                    if (temUsuario == null)
                    {
                        contexto.AddFailure("Usuario não cadastrado");
                    }
                });

            RuleFor(x => x.MaquinaId)
                .Custom((Maquina, contexto) =>
                {
                    var spec = service.CreateSpec(x => x.MaquinaId == Maquina)
                        .AddInclude(x => x.Maquina);
                    var temMaquina = service.FindAsync(spec).Result;

                    if (temMaquina == null)
                    {
                        contexto.AddFailure("Maquina não cadastrado");
                    }
                });

            RuleFor(x => x.JogoId)
                .Custom((Jogo, contexto) =>
                {
                    var spec = service.CreateSpec(x => x.JogoId == Jogo)
                        .AddInclude(x => x.Jogo);
                    var temJogo = service.FindAsync(spec).Result;

                    if (temJogo == null)
                    {
                        contexto.AddFailure("Jogo não cadastrado");
                    }
                });

            RuleFor(x => x.Horario)
                .NotEmpty()
                .Custom((Data, contexto) => {
                    if(Data < DateTime.Now)
                    {
                        contexto.AddFailure("Você não pode fazer agendamento com datas menores que o dia de hoje");
                    }
            });

            RuleFor(x => x.Pontos)
                .NotEmpty();

        }

    }
}
