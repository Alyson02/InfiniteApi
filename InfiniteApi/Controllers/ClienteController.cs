using Infinite.Core.Business.CQRS.Cliente.Commands;
using Infinite.Core.Business.CQRS.Cliente.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Infinite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // Bloco de consulta
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllClienteQuerry()));
        }
        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetAll([FromRoute] int idCliente)
        {
            return Ok(await _mediator.Send(new GetAllClienteQuerry()));
        }


        // Bloco de consulta

        // Bloco de inserção
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        // Bloco de inserção

        // Bloco de Atualização
        [HttpPut("{clienteId}")]
        public async Task<IActionResult> Update([FromRoute] int clienteId, UpdateClienteCommand command)
        {
            if (clienteId != command.ClienteId) throw new Exception("O ID informado deve ser o mesmo do Objeto");
            return Ok(await _mediator.Send(command));
        }
        // Bloco de Atualização

        // Bloco de Deletação
        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> Delete([FromRoute] int clienteId)
        {

            return Ok(await _mediator.Send(new DeleteClienteCommand { ClienteId = clienteId }));
        }
        // Bloco de Deletação

    }
}
