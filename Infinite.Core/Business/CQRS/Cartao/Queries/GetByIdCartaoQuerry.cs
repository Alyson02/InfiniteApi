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

namespace Infinite.Core.Business.CQRS.Cartao.Queries//colocar o namespace correto Ex.: .Produto.Commands
{
    public class GetByIdCartaoQuerry : IRequest<Response>
    {
        //Props
        public int CardId { get; set; }
        public class GetByIdCartaoQuerryHandler : IRequestHandler<GetByIdCartaoQuerry, Response>
        {
            private readonly IServiceBase<CartaoEntity> _service;
            public GetByIdCartaoQuerryHandler(IServiceBase<CartaoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(GetByIdCartaoQuerry command, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = this._service.CreateSpec(x => x.CardId == command.CardId);

                    var cartao = await this._service.FindAsync(spec);

                    if (cartao == null) throw new Exception("Cartão não encontrado");

                    return new Response(cartao);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer a consulta do cartão", e);
                }
            }
        }
    }
}
