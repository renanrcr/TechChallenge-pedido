using Application.Commands.IdentificacoesPedido;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Domain.Entities;
using MediatR;

namespace Application.Services.Handlers
{
    public class IdentificacaoPedidoHandler : BaseService,
        IRequestHandler<CadastraIdentificacaoPedidoCommand, IdentificacaoPedidoDTO>
    {
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;
        private readonly IMapper _mapper;

        public IdentificacaoPedidoHandler(INotificador notificador,
            IIdentificacaoPedidoRepository identificacaoPedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _identificacaoPedidoRepository = identificacaoPedidoRepository;
            _mapper = mapper;
        }

        public async Task<IdentificacaoPedidoDTO> Handle(CadastraIdentificacaoPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new IdentificacaoPedido().Cadastrar(_identificacaoPedidoRepository, request.Valor, request.TipodIdentificacaoPedido);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _identificacaoPedidoRepository.Adicionar(entidade);

            return _mapper.Map<IdentificacaoPedidoDTO>(entidade);
        }
    }
}