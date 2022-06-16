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
{ //colocar o namespace correto Ex.: .Produto.Commands

    public class CreateCartaoCommand : IRequest<Response>
    {
        //Props
        public string NumCard { get; set; }
        public string CodigoSeg { get; set; }
        public string Badeira { get; set; }
        public string ApelidoCard { get; set; }
        public class CreateCartaoCommandHandler : IRequestHandler<CreateCartaoCommand, Response>
        {
            private readonly IServiceBase<CartaoEntity> _service;
            public CreateCartaoCommandHandler(IServiceBase<CartaoEntity> service)
            {
                _service = service;
            }

            public async Task<Response> Handle(CreateCartaoCommand command, CancellationToken cancellationToken)
            {

                try
                {
                    var cartao = new CartaoEntity
                    {
                        ApelidoCard = command.ApelidoCard,
                        NumCard = command.NumCard,
                        Badeira = command.Badeira,
                        CodigoSeg = command.CodigoSeg
                    };

                    await _service.InsertAsync(cartao);

                    return new Response("Cartão adicionado com sucesso");
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer o cadastro do novo cartão", e);
                }
            }
        }
    }
}
