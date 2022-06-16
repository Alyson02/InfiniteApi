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

namespace Infinite.Core.Business.CQRS.Endereco.Queries
{
    public class GetAllEnderecoQuery : IRequest<Response>
    {
        public class GetAllEnderecoQueryHandler : IRequestHandler<GetAllEnderecoQuery, Response>
        {
            private readonly IServiceBase<EnderecoEntity> _service;
            public GetAllEnderecoQueryHandler(IServiceBase<EnderecoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(GetAllEnderecoQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var enderecos = await _service.ListAsync();

                    var model = enderecos.Select(endereco => new ListEnderecoModel
                    {
                        Apedido = endereco.Apedido,
                        CEP = endereco.CEP,
                        EndId = endereco.EndId,
                        NomeRua = endereco.NomeRua,
                        NumCasa = endereco.NumCasa,
                    });

                    return new Response(model);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao listar endereços", e);
                }
            }
        }
    }
}
