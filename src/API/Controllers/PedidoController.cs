using API.Pedido.Controllers.Base;
using Application.Commands.Pedidos;
using Domain.Adapters;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Pedido.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(INotificador notificador,
            IMediator mediator,
            IPedidoRepository pedidoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(new ListaPedidoCommand());

            return Ok(entidade);
        }

        [HttpGet("StatusPagamentoPedido")]
        public async Task<IActionResult?> GetStatusPagamentoPedido(string numeroDoPedido)
        {
            if (!ModelState.IsValid) return null;

            var status = (await _pedidoRepository.Buscar(x => x.NumeroPedido == numeroDoPedido)).FirstOrDefault()?.StatusPedido.ToString();

            return Ok(new { StatusDoPagamento = status });
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPost("AtualizaStatusPedido")]
        public async Task<IActionResult?> PostStatusPedido(string numeroDoPedido, int idStatusPedido)
        {
            if (!ModelState.IsValid) return null;

            var pedido = (await _pedidoRepository.Buscar(x => x.NumeroPedido == numeroDoPedido)).FirstOrDefault();

            if (pedido == null) return BadRequest("Pedido não enconntrado.");

            pedido.StatusPedido = (EStatusPedido)idStatusPedido;

            var status = _pedidoRepository.Atualizar(pedido);

            return Ok(pedido);
        }
    }
}