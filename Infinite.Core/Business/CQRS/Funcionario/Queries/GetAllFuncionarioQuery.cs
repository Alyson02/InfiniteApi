

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

namespace Infinite.Core.Business.CQRS.Funcionario.Queries
{
    public class GetAllFuncionarioQuery : IRequest<Response>
    {
        public FuncionarioFilter filter;

        public class GetAllFuncionarioQueryHandler : IRequestHandler<GetAllFuncionarioQuery, Response>
        {
            private readonly IServiceBase<FuncionarioEntity> _service;
            public GetAllFuncionarioQueryHandler(IServiceBase<FuncionarioEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(GetAllFuncionarioQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = new Specification<FuncionarioEntity>();

                    if (!string.IsNullOrEmpty(query.filter.Nome))
                    {
                        spec = _service.CreateSpec(x => x.Nome.Contains(query.filter.Nome));
                    }
                    else
                    {
                        spec = _service.CreateSpec();
                    }

                    spec.AddInclude(x => x.Usuario);

                    var Funcionario = await this._service.ListAsync(spec);

                    var model = Funcionario.Select(x => new ListFuncionarioModel
                    {
                        FuncionarioId = x.FuncionarioId,
                        Nome = x.Nome,
                        Telefone = x.Telefone,
                        Email = x.Usuario.Email,
                    });

                    return new Response(model);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao Listar os funcionarios", e);
                }
            }
        }
    }
}
