using Infinite.Core.Business.CQRS.Endereco.Commands;
using Infinite.Core.Business.CQRS.Endereco.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Infinite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private IMediator _mediator;

        public EnderecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEnderecoQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnderecoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{enderecoId}")]
        public async Task<IActionResult> Create([FromRoute] int enderecoId, [FromBody] UpdateEnderecoCommand command)
        {
            if (enderecoId != command.EndId) throw new Exception("O id enviado deve ser o mesmo do objeto");
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{enderecoId}")]
        public async Task<IActionResult> Create([FromRoute] int enderecoId)
        {
            return Ok(await _mediator.Send(new DeleteEnderecoCommand { EndId = enderecoId}));
        }
    }
}
