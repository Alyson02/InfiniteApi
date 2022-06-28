

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

namespace Infinite.Core.Business.CQRS.Jogo.Queries//colocar o namespace correto Ex.: .Produto.Commands
{
    public class GetAllJogoQuerry : IRequest<Response>
    {
        public JogoFilter filter;

        public class GetAllJogoQuerryHandler : IRequestHandler<GetAllJogoQuerry, Response>
        {
            private readonly IServiceBase<JogoEntity> _service;
            public GetAllJogoQuerryHandler(IServiceBase<JogoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(GetAllJogoQuerry filter, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = new Specification<JogoEntity>();

                    if (!string.IsNullOrEmpty(filter.filter.Nome))
                    {
                        spec = _service.CreateSpec(x => x.Nome.Contains(filter.filter.Nome));
                    }
                    else
                    {
                        spec = _service.CreateSpec();
                    }

                    var Jogo = await this._service.ListAsync(spec);

                    var model = Jogo.Select(x => new ListJogoModel
                    {
                        JogoId = x.JogoId,
                        Nome = x.Nome,
                        PontoPreco = x.PontoPreco,
                        Status = x.Status
                    });

                    return new Response(model);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao Listar os Jogo", e);
                }
            }
        }
    }
}
