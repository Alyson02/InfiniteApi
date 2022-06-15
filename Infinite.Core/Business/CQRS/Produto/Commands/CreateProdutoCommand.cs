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

namespace Infinite.Core.Business.CQRS.Produto.Commands
{
    public class CreateProdutoCommand : IRequest<Response>
    {
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public double Preco { get; set; }
        public int Pontos { get; set; }
        public int CategoriaId { get; set; }
        public class CreateProdutoHandler : IRequestHandler<CreateProdutoCommand, Response>
        {
            private readonly IServiceBase<ProdutoEntity> _service;
            public CreateProdutoHandler(IServiceBase<ProdutoEntity> service)
            {
                _service = service; 
            }

            public async Task<Response> Handle(CreateProdutoCommand commad, CancellationToken cancellationToken)
            {
                try
                {
                    var produto = new ProdutoEntity
                    {
                        Nome = commad.Nome,
                        Estoque = commad.Estoque,
                        Preco = commad.Preco,
                        Pontos = commad.Pontos,
                        CategoriaId = commad.CategoriaId
                    };

                    await _service.InsertAsync(produto);

                    return new Response("Produto adicionado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer alguma coisa", e);
                }
            }
        }
    }
}
