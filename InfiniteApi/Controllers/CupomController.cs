using Infinite.Core.Business.CQRS.Cupom.Commands;
using Infinite.Core.Business.CQRS.Cupom.Queries;
using Infinite.Core.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Infinite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private IMediator _mediator;

        public CupomController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCupomQuery() { UsuarioId = HttpContext.User.GetUserId()}));
        }

        [HttpGet("{cupomId}")]
        public async Task<IActionResult> Get([FromRoute] int cupomId)
        {
            return Ok(await _mediator.Send(new GetCupomByIdQuery {CupomId = cupomId}));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCupomCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{cupomId}")]
        public async Task<IActionResult> Update([FromRoute] int cupomId ,[FromBody] UpdateCupomCommand command)
        {
            if (cupomId != command.CupomId) throw new Exception("Id do cupom deve ser o mesmo do objeto enviado");
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int cupomId)
        {
            return Ok(await _mediator.Send(new DeleteCupomCommand { CupomId = cupomId}));
        }

    }
}
