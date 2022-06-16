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
    public class UpdateEnderecoCommand : IRequest<Response>
    {
        public int EndId { get; set; }
        public string CEP { get; set; }
        public string NumCasa { get; set; }
        public string Apedido { get; set; }
        public string NomeRua { get; set; }
        public class UpdateEnderecoCommandHandler : IRequestHandler<UpdateEnderecoCommand, Response>
        {
            private readonly IServiceBase<EnderecoEntity> _service;
            public UpdateEnderecoCommandHandler(IServiceBase<EnderecoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(UpdateEnderecoCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = _service.CreateSpec(x => x.EndId == command.EndId);
                    var endereco = await _service.FindAsync(spec);

                    if (endereco == null) throw new Exception("Endereco não encontrado");

                    endereco.NumCasa = command.NumCasa;
                    endereco.Apedido = command.Apedido;
                    endereco.CEP = command.CEP;
                    endereco.NomeRua = command.NomeRua;

                    await _service.UpdateAsync(endereco);

                    return new Response("Endereço atualizado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao atualizar endereço", e);
                }
            }
        }
    }
}
