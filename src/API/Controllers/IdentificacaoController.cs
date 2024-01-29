using API.Controllers.Base;
using Application.Commands.IdentificacoesPedido;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IdentificacaoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;

        public IdentificacaoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            IIdentificacaoPedidoRepository identificacaoPedidoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _identificacaoPedidoRepository = identificacaoPedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<IdentificacaoPedidoDTO>>(await _identificacaoPedidoRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraIdentificacaoPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}