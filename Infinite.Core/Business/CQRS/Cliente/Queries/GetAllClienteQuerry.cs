

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
using Infinite.Core.Infrastructure.Repository;
using Infinite.Core.Domain.Filter;

namespace Infinite.Core.Business.CQRS.Cliente.Queries//colocar o namespace correto Ex.: .Produto.Commands
{
    public class GetAllClienteQuerry : IRequest<Response>
    {
        
        public ClienteFilter filter;
        public class GetAllClienteQuerryHandler : IRequestHandler<GetAllClienteQuerry, Response>
        {
            private readonly IServiceBase<ClienteEntity> _service;
            public GetAllClienteQuerryHandler(IServiceBase<ClienteEntity> service)
            {
                _service = service;
            }
            public async Task<Response> Handle(GetAllClienteQuerry query, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = _service.CreateSpec().AddInclude(x => x.Usuario);

                    if (!string.IsNullOrEmpty(query.filter.Nome))
                    {
                        spec = _service.CreateSpec(x => x.Nome.Contains(query.filter.Nome));
                    }
                    else
                    {
                        spec = _service.CreateSpec();
                    }

                    spec.AddInclude(x => x.Usuario);

                    var Cliente = await this._service.ListAsync(spec);

                    var model = Cliente.Select(x => new ListClienteModel
                    {
                        ClienteId = x.ClienteId,
                        Nome = x.Nome,
                        Tell = x.Tell,
                        Email = x.Usuario.Email
                    });

                    return new Response(model);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao Listar os Cliente", e);
                }
            }
        }
    }
}
