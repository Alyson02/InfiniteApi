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

namespace Infinite.Core.Business.CQRS.Cartao.Commands
{
    
        public class DeleteCartaoCommand : IRequest<Response>
        {
            //Props
            public int CardId { get; set; }

            public class UpdateCartaoCommandHandler : IRequestHandler<DeleteCartaoCommand, Response>
            {
                private readonly IServiceBase<CartaoEntity> _service;
                public UpdateCartaoCommandHandler(IServiceBase<CartaoEntity> service)
                {
                    _service = service;
                }

                public async Task<Response> Handle(DeleteCartaoCommand command, CancellationToken cancellationToken)
                {
                    try
                    {
                        var spec = this._service.CreateSpec(x => x.CardId == command.CardId);

                        var cartao = await this._service.FindAsync(spec);

                        if (cartao == null) throw new Exception("Cartão não encontrado");

                        await _service.DeleteAsync(cartao);

                        return new Response("Cartão Excluido com sucesso");
                    }
                    catch (Exception e)
                    {
                        throw new AppException("Erro ao fazer a Eliminação dos dados do cartão", e);
                    }
                }
            }
        }
}