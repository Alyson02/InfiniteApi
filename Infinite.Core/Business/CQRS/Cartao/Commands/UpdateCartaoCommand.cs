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

namespace Infinite.Core.Business.CQRS.Cartao.Commands//colocar o namespace correto Ex.: .Produto.Commands
{
    public class UpdateCartaoCommand : IRequest<Response>
    {
        //Props
        public int CardId { get; set; }
        public string NumCard { get; set; }
        public string CodigoSeg { get; set; }
        public string Badeira { get; set; }
        public string ApelidoCard { get; set; }

        public class UpdateCartaoCommandHandler : IRequestHandler<UpdateCartaoCommand, Response>
        {
            private readonly IServiceBase<CartaoEntity> _service;
            public UpdateCartaoCommandHandler(IServiceBase<CartaoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(UpdateCartaoCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = this._service.CreateSpec(x => x.CardId == command.CardId);

                    var cartao = await this._service.FindAsync(spec);

                    if (cartao == null) throw new Exception("Cartão não encontrado");

                    cartao.ApelidoCard = command.ApelidoCard;
                    cartao.NumCard = command.NumCard;
                    cartao.CodigoSeg = command.CodigoSeg;
                    cartao.Badeira = command.Badeira;

                    await _service.UpdateAsync(cartao);

                    return new Response("Cartão Atualizado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer a atualização dos dados do cartão", e);
                }
            }
        }
    }
}
