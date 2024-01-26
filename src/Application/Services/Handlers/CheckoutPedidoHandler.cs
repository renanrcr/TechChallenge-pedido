using Application.Commands;
using Application.Commands.IdentificacoesPedido;
using Application.Commands.ItensPedido;
using Application.Commands.Pedidos;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using MediatR;

namespace Application.Services.Handlers
{
    public class CheckoutPedidoHandler : BaseService,
        IRequestHandler<CheckoutPedidoCommand, CheckoutPedidoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly INotificador _notificador;

        public CheckoutPedidoHandler(INotificador notificador
            , IMapper mapper
            , IMediator mediator)
            : base(notificador)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notificador = notificador;
        }

        public async Task<CheckoutPedidoDTO> Handle(CheckoutPedidoCommand request, CancellationToken cancellationToken)
        {
            var checkoutPedido = new CheckoutPedidoDTO();

            var identificacaoPedido = await CadastraIdentificacaoCliente(request.TipodIdentificacaoCliente, request.IdentificacaoCliente);

            if (!_notificador.TemNotificacao())
            {
                var retornoPedido = await CadastraPedido(identificacaoPedido.Id);

                if (!_notificador.TemNotificacao())
                {
                    await AdicionarItens(retornoPedido.IdentificacaoPedidoId, request.ItensPedido);

                    if (!_notificador.TemNotificacao())
                        checkoutPedido.Pedido = retornoPedido;
                }
            }

            return _mapper.Map<CheckoutPedidoDTO>(checkoutPedido);
        }

        private async Task<IdentificacaoPedidoDTO> CadastraIdentificacaoCliente(int tipoIdentificacaoCliente, string? valor)
        {
            var commandIdentificacao = new CadastraIdentificacaoPedidoCommand
            {
                TipodIdentificacaoPedido = tipoIdentificacaoCliente,
                Valor = valor,
            };

            var retornoIdentificacao = await _mediator.Send(commandIdentificacao);

            return retornoIdentificacao;
        }

        private async Task<PedidoDTO> CadastraPedido(Guid idIdentificacaoPedido)
        {
            var commandPedido = new CadastraPedidoCommand { IdentificacaoClienteId = idIdentificacaoPedido, };

            var retornoPedido = await _mediator.Send(commandPedido);

            return retornoPedido;
        }

        private Task AdicionarItens(Guid identificacaoPedidoId, IList<ItemPedidoDTO>? ItensPedido)
        {
            return Task.Factory.StartNew(() =>
            {
                ItensPedido?.ToList()
                            .ForEach(async x =>
                            {
                                var commmandItemPedido = new CadastraItemPedidoCommand
                                {
                                    PedidoId = identificacaoPedidoId,
                                    ProdutoId = x.ProdutoId,
                                    Quantidade = x.Quantidade,
                                };

                                await _mediator.Send(commmandItemPedido);
                            });
            });
        }
    }
}