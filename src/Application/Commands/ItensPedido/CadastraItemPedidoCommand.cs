using Application.DTOs;
using MediatR;

namespace Application.Commands.ItensPedido
{
    public class CadastraItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public string? NomeProduto { get; set; }
        public string? DescricaoProduto { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}
