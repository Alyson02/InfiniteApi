using Infinite.Core.Business.CQRS.Cartao.Commands;
using Infinite.Core.Business.CQRS.Cartao.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Infinite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {

        private IMediator _mediator;

        public CartaoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _mediator.Send(new GetAllCartaoQuerry()));
        }
        [HttpGet("{idCartao}")]
        public async Task<IActionResult> GetAll([FromRoute] int idCartao)
        {
            return Ok(await _mediator.Send(new GetByIdCartaoQuerry { CardId = idCartao}));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCartaoCommand command)
        {

            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{cardId}")]
        public async Task<IActionResult> Update([FromRoute] int cardId, UpdateCartaoCommand command)
        {
            if(cardId != command.CardId) throw new Exception("O ID informado deve ser o mesmo do Objeto");
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{cardId}")]
        public async Task<IActionResult> Delete([FromRoute] int cardId)
        {
            
            return Ok(await _mediator.Send(new DeleteCartaoCommand {CardId = cardId }));
        }
    }
}
