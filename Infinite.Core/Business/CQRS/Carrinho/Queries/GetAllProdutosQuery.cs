

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

namespace Infinite.Core.Business.CQRS.Carrinho.Queries
{
    public class GetAllProdutoQuery : IRequest<Response>
    {
        public int UserId { get; set; }
        public class GetAllProdutoQueryHandler : IRequestHandler<GetAllProdutoQuery, Response>
        {
            private readonly IServiceBase<CarrinhoEntity> _service;
            public GetAllProdutoQueryHandler(IServiceBase<CarrinhoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(GetAllProdutoQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = _service.CreateSpec(x => x.Cliente.UsuarioId == query.UserId && x.Status == false);
                    spec.AddInclude(x => x.Cliente)
                        .AddInclude(x => x.Produtos)
                        .AddInclude("Produtos.Produto");

                    var produtos = await _service.ListAsync(spec);

                    return new Response(produtos.Select(x => x.Produtos));
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao Listar os Produto", e);
                }
            }
        }
    }
}
