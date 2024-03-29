﻿using Application.Commands.Pedidos;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Services.Handlers
{
    public class PedidoHandler : BaseService,
        IRequestHandler<CadastraPedidoCommand, PedidoDTO>,
        IRequestHandler<AtualizaPedidoCommand, PedidoDTO>,
        IRequestHandler<DeletaPedidoCommand, PedidoDTO>,
        IRequestHandler<ListaPedidoCommand, IList<PedidosDTO>>,
        IRequestHandler<CriarPedidoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IMessageServiceRepository _messageService;

        public PedidoHandler(INotificador notificador,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository,
            IMapper mapper,
            IMessageServiceRepository messageService)
            : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _itemPedidoRepository = itemPedidoRepository;
            _messageService = messageService;
        }

        public async Task<PedidoDTO> Handle(CadastraPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Cadastrar(request.ClienteId);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
            {
                bool inseriuPedido = await _pedidoRepository.InserirPedido(entidade);
                if(!inseriuPedido)
                    Notificar(MensagemRetorno.ErroAoCadastrarPedido);
            }

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<PedidoDTO> Handle(AtualizaPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Atualizar(request.NumeroPedido);

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
            {
                bool deletouPedido = await _pedidoRepository.DeletarPedido(entidade.Id);
                if (!deletouPedido)
                    Notificar(MensagemRetorno.ErroAoDeletarPedido);
            }

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<IList<PedidosDTO>> Handle(ListaPedidoCommand request, CancellationToken cancellationToken)
        {
            var retorno = new List<PedidosDTO>();

            var pedidos = await _pedidoRepository.ObterPedido();

            pedidos
                .Where(x => x.StatusPedido != EStatusPedido.FINALIZADO)
                .OrderBy(x => x.StatusPedido)
                .ToList()
                .ForEach(async x =>
                {
                    var pedido = new PedidosDTO
                    {
                        NumeroPedido = x.NumeroPedido,
                        StatusPedido = x.StatusPedido.ToString(),
                    };

                    var itensPedido = await _itemPedidoRepository.ObterItensDoPedido(x.Id);

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

        public async Task<bool> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = (await _pedidoRepository.Buscar(x => x.NumeroPedido == request.NumeroPedido)).FirstOrDefault();
            if (pedido == null)
            {
                Notificar(MensagemRetorno.PedidoNaoEncontrado);
                return await Task.FromResult(false);
            }

            var itensPedido = await _itemPedidoRepository.ObterItensDoPedido(pedido.Id);
            if (itensPedido == null)
            {
                Notificar(MensagemRetorno.ItensPedidoNaoEncontrado);
                return await Task.FromResult(false);
            }

            var itensPedidoDTO = new List<ItensDTO>();
            itensPedido.ToList().ForEach(y =>
            {
                var itemPedido = new ItensDTO()
                {
                    Nome = y.Produto.Nome,
                    Quantidade = y.Quantidade,
                    Valor = y.Produto.TabelaPreco.IsValid ? y.Produto.TabelaPreco.Preco : 0,
                };

                itensPedidoDTO.Add(itemPedido);
            });

            var payload = new PedidosDTO 
            { 
                NumeroPedido = request.NumeroPedido,
                ItensPedido = itensPedidoDTO,
            };

            _messageService.Enqueue(payload);

            return await Task.FromResult(false);
        }
    }
}