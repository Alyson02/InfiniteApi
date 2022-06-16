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
    public class DeleteEnderecoCommand : IRequest<Response>
    {
        public int EndId { get; set; }
        public class DeleteEnderecoCommandHandler : IRequestHandler<DeleteEnderecoCommand, Response>
        {
            private readonly IServiceBase<EnderecoEntity> _service;
            public DeleteEnderecoCommandHandler(IServiceBase<EnderecoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(DeleteEnderecoCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = _service.CreateSpec(x => x.EndId == command.EndId);
                    var endereco = await _service.FindAsync(spec);

                    if (endereco == null) throw new Exception("Endereco não encontrado");

                    await _service.DeleteAsync(endereco);

                    return new Response("Endereço deletado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao deletar endereço", e);
                }
            }
        }
    }
}
