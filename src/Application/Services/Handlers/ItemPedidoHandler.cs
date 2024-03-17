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

        public ItemPedidoHandler(INotificador notificador,
            IItemPedidoRepository itemPedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _mapper = mapper;
        }

        public async Task<ItemPedidoDTO> Handle(CadastraItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto().NewInstance(request.NomeProduto, request.DescricaoProduto, request.Preco);
            var itemPedido = await new ItemPedido().Cadastrar(request.PedidoId, request.Quantidade, produto);

            Notificar(itemPedido.ValidationResult);

            if (itemPedido.IsValid)
            {
                bool inseriuItemPedido = await _itemPedidoRepository.InserirItemPedido(itemPedido);
                if (!inseriuItemPedido)
                    Notificar(MensagemRetorno.ErroAoAdicionarItemPedido);
            }
                

            return _mapper.Map<ItemPedidoDTO>(itemPedido);
        }

        public async Task<ItemPedidoDTO> Handle(AtualizaItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Atualizar(request.Id, request.Quantidade);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.AtualizarQuantidadeItemPedido(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }

        public async Task<ItemPedidoDTO> Handle(DeletaItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Deletar(request.Id);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.AtualizarQuantidadeItemPedido(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }
    }
}