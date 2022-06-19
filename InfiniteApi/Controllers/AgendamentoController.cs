using Infinite.Core.Business.CQRS.Agendamento.Commands;
using Infinite.Core.Business.CQRS.Agendamento.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Infinite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        private IMediator _mediator;
        public AgendamentoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // Bloco de consulta
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllAgendamentoQuerry()));
        }
        [HttpGet("{idAgendamento}")]
        public async Task<IActionResult> GetById([FromRoute] int idAgendamento)
        {

            return Ok(await _mediator.Send(new GetByIdAgendamentoQuerry { AgendamentoId = idAgendamento }));
        }


        // Bloco de consulta

        // Bloco de inserção
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAgendamentoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        // Bloco de inserção

        // Bloco de Atualização
        [HttpPut("{AgendamentoId}")]
        public async Task<IActionResult> Update([FromRoute] int AgendamentoId, UpdateAgendamentoCommand command)
        {
            if (AgendamentoId != command.AgendamentoId) throw new Exception("O ID informado deve ser o mesmo do Objeto");
            return Ok(await _mediator.Send(command));
        }
        // Bloco de Atualização

        // Bloco de Deletação
        [HttpDelete("{AgendamentoId}")]
        public async Task<IActionResult> Delete([FromRoute] int AgendamentoId)
        {

            return Ok(await _mediator.Send(new DeleteAgendamentoCommand { AgendamentoId = AgendamentoId }));
        }
        // Bloco de Deletação

    }
}
