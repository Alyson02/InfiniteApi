using Infinite.Core.Business.CQRS.Produto.Commands;
using Infinite.Core.Business.CQRS.Produto.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProdutoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
