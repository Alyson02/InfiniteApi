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

namespace Infinite.Core.Business.CQRS.Carrinho.Commands
{

    public class DeleteCarrinhoCommand : IRequest<Response>
    {
        //Props
        public int CarrinhoId { get; set; }

        public class UpdateCarrinhoCommandHandler : IRequestHandler<DeleteCarrinhoCommand, Response>
        {
            private readonly IServiceBase<CarrinhoEntity> _service;
            public UpdateCarrinhoCommandHandler(IServiceBase<CarrinhoEntity> service)
            {
                this._service = service;
            }

            public async Task<Response> Handle(DeleteCarrinhoCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = this._service.CreateSpec(x => x.CarrinhoId == command.CarrinhoId);

                    var Carrinho = await this._service.FindAsync(spec);

                    if (Carrinho == null) throw new Exception("Carrinho não encontrado");

                    await _service.DeleteAsync(Carrinho);

                    return new Response("Carrinho Excluido com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer a Eliminação dos dados do Carrinho", e);
                }
            }
        }
    }
}