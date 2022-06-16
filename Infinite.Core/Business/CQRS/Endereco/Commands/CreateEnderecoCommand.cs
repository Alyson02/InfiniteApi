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

namespace Infinite.Core.Business.CQRS.Endereco.Commands
{
    public class CreateEnderecoCommand : IRequest<Response>
    {
        public string CEP { get; set; }
        public string NumCasa { get; set; }
        public string Apedido { get; set; }
        public string NomeRua { get; set; }
        public class CreateEnderecoCommandHandler : IRequestHandler<CreateEnderecoCommand, Response>
        {
            private readonly IServiceBase<EnderecoEntity> _service;
            public CreateEnderecoCommandHandler(IServiceBase<EnderecoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(CreateEnderecoCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var endereco = new EnderecoEntity
                    {
                        Apedido = command.Apedido,
                        NomeRua = command.NomeRua,
                        NumCasa = command.NumCasa,
                        CEP = command.CEP,
                    };

                    await _service.InsertAsync(endereco);

                    return new Response("Endereco adicionado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer alguma coisa", e);
                }
            }
        }
    }
}
