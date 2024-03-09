using Application.Commands.ItensPedido;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Services.Handlers
{
    public class ItemPedidoHandler : BaseService,
        IRequestHandler<CadastraItemPedidoCommand, ItemPedidoDTO>,
        IRequestHandler<AtualizaItemPedidoCommand, ItemPedidoDTO>,
        IRequestHandler<DeletaItemPedidoCommand, ItemPedidoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ItemPedidoHandler(INotificador notificador,
            IItemPedidoRepository itemPedidoRepository,
            IMapper mapper,
            IProdutoRepository produtoRepository)
            : base(notificador)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<ItemPedidoDTO> Handle(CadastraItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Cadastrar(_produtoRepository, request.PedidoId, request.ProdutoId, request.Quantidade);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
            {
                bool inseriuItemPedido = await _itemPedidoRepository.InserirItemPedido(entidade);
                if (!inseriuItemPedido)
                    Notificar(MensagemRetorno.ErroAoAdicionarItemPedido);
            }
                

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }

        public async Task<ItemPedidoDTO> Handle(AtualizaItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Atualizar(_produtoRepository, request.Id, request.Quantidade);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.AtualizarQuantidadeItemPedido(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }

        public async Task<ItemPedidoDTO> Handle(DeletaItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Deletar(_produtoRepository, request.Id);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.AtualizarQuantidadeItemPedido(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }
    }
}