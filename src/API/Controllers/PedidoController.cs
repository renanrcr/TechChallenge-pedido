using API.Controllers.Base;
using Application.Commands.Pedidos;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IMediator _mediator;

        public PedidoController(INotificador notificador,
            IMediator mediator)
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(new ListaPedidoCommand());

            return Ok(entidade);
        }

        [HttpPost("criar-pedido")]
        public async Task<IActionResult?> Post(CadastraPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPost("confirmar-pedido")]
        public async Task<IActionResult?> CriarPedido(CriarPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}