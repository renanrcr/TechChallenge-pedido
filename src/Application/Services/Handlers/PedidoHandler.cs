﻿using Application.Commands.Pedidos;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Services.Handlers
{
    public class PedidoHandler : BaseService,
        IRequestHandler<CadastraPedidoCommand, PedidoDTO>,
        IRequestHandler<AtualizaPedidoCommand, PedidoDTO>,
        IRequestHandler<DeletaPedidoCommand, PedidoDTO>,
        IRequestHandler<ListaPedidoCommand, IList<PedidosDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoHandler(INotificador notificador,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public async Task<PedidoDTO> Handle(CadastraPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Cadastrar(request.IdentificacaoClienteId);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _pedidoRepository.Adicionar(entidade);

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<PedidoDTO> Handle(AtualizaPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Atualizar(request.NumeroPedido, request.IdentificacaoPedidoId);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _pedidoRepository.Atualizar(entidade);

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<PedidoDTO> Handle(DeletaPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Deletar(request.Id);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _pedidoRepository.Atualizar(entidade);

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<IList<PedidosDTO>> Handle(ListaPedidoCommand request, CancellationToken cancellationToken)
        {
            var retorno = new List<PedidosDTO>();

            var pedidos = (await _pedidoRepository.ObterTodos()).Where(x => x.StatusPedido != EStatusPedido.FINALIZADO);

            pedidos
                .OrderBy(x => x.StatusPedido)
                .ToList()
                .ForEach(async x =>
                {
                    var pedido = new PedidosDTO
                    {
                        NumeroPedido = x.NumeroPedido,
                        StatusPedido = x.StatusPedido.ToString(),
                    };

                    var itensPedido = await _itemPedidoRepository.Buscar(x => x.PedidoId == x.Id);

                    itensPedido.ToList().ForEach(y =>
                    {
                        var itemPedido = new ItensDTO()
                        {
                            Nome = y.Produto.Nome,
                            Quantidade = y.Quantidade,
                            Valor = y.Produto.TabelaPreco.IsValid ? y.Produto.TabelaPreco.Preco : 0,
                        };

                        pedido.ItensPedido.Add(itemPedido);
                    });

                    pedido.QuantidadeItens = pedido.ItensPedido.Sum(x => x.Quantidade);
                    pedido.TotalDoPedido = pedido.ItensPedido.Sum(x => x.Valor);

                    retorno.Add(pedido);
                });

            return retorno;
        }
    }
}