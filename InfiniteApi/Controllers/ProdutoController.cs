using Infinite.Core.Business.CQRS.Produto.Commands;
using Infinite.Core.Business.CQRS.Produto.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Infinite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProdutoQuery()));
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> GetAll([FromRoute] int produtoId)
        {
            return Ok(await _mediator.Send(new GetByIdProdutoQuerry { ProdutoId = produtoId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProdutoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{produtoId}")]
        public async Task<IActionResult> Update([FromBody] UpdateProdutoCommand command, [FromRoute] int produtoId)
        {
            if (produtoId != command.ProdutoId) throw new Exception("O id deve ser o mesmo do objeto enviado");
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> Delete([FromRoute] int produtoId)
        {
            return Ok(await _mediator.Send(new DeleteProdutoCommand { ProdutoId = produtoId}));
        }
    }
}
