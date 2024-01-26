using API.Pedido.Controllers.Base;
using Application.Commands;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Pedido.Controllers
{
    public class CheckoutPedidoController : BaseController
    {
        private readonly IMediator _mediator;

        public CheckoutPedidoController(INotificador notificador,
            IMediator mediator)
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CheckoutPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}