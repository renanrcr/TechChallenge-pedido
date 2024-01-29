using API.Controllers.Base;
using Application.Commands.ItensPedido;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ItemPedidoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            IItemPedidoRepository itemPedidoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ItemPedidoDTO>>(await _itemPedidoRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraItemPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}