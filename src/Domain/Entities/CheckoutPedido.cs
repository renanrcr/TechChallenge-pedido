namespace Domain.Entities
{
    public class CheckoutPedido : EntidadeBase<Guid>
    {
        public Pedido? Pedido { get; set; }
    }
}
