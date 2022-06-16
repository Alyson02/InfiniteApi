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

namespace Infinite.Core.Business.CQRS.Cartao.Queries
{ //colocar o namespace correto Ex.: .Produto.Commands

    public class GetAllCartaoQuerry : IRequest<Response>
    {
        public class GetAllCartaoQuerryHandler : IRequestHandler<GetAllCartaoQuerry, Response>
        {
            private readonly IServiceBase<CartaoEntity> _service;
            public GetAllCartaoQuerryHandler(IServiceBase<CartaoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(GetAllCartaoQuerry querry, CancellationToken cancellationToken)
            {
                try
                {
                    var cartoes = await this._service.ListAsync();

                    var model = cartoes.Select(x => new ListCartaoModel
                    {
                        ApelidoCard = x.ApelidoCard,
                        Badeira = x.Badeira,
                        CardId = x.CardId,
                        NumCard = x.NumCard
                    }); ;

                    return new Response(model);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao Listar Cartões", e);
                }
            }
        }
    }
}