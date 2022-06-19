using Infinite.Core.Business.Services.Base;
using Infinite.Core.Domain.Models;
using Infinite.Core.Domain.Entities;
using Infinite.Core.Infrastructure.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Agendamento.Commands
{ //colocar o namespace correto Ex.: .Produto.Commands

    public class CreateAgendamentoCommand : IRequest<Response>
    {
        //Props
        public int AgendamentoId { get; set; }
        public DateTime Horario { get; set; }
        public int Pontos { get; set; }

        // Chave entrangeira
        public int ClienteId { get; set; }
        public int JogoId { get; set; }
        public int MaquinaId { get; set; }
        
        public class CreateAgendamentoCommandHandler : IRequestHandler<CreateAgendamentoCommand, Response>
        {
            private readonly IServiceBase<AgendamentoEntity> _service;
            public CreateAgendamentoCommandHandler(IServiceBase<AgendamentoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(CreateAgendamentoCommand command, CancellationToken cancellationToken)
            {

                try
                {
                    var Agendamento = new AgendamentoEntity
                    {
                        AgendamentoId = command.AgendamentoId,
                        Horario = command.Horario,
                        Pontos = command.Pontos, //Validar com o Alyson
                        ClienteId = command.ClienteId,
                        JogoId = command.JogoId,
                        MaquinaId = command.MaquinaId,
                    };

                    await _service.InsertAsync(Agendamento);

                    return new Response("Agendamento adicionado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer o cadastro do novo Agendamento", e);
                }
            }
        }
    }
}
