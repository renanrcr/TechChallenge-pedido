using Domain.Enums;
using Domain.Validations.Pedidos;

namespace Domain.Entities
{
    public class Pedido : EntidadeBase<Guid>
    {
        public Guid ClienteId { get; private set; }
        public string? NumeroPedido { get; private set; }
        public EStatusPedido? StatusPedido { get; set; }
        public EStatusPagamentoPedido? StatusPagamentoPedido { get; set; }
        public IList<ItemPedido>? ItensPedido { get; private set; }

        public async Task<Pedido> Cadastrar(Guid clienteId)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
            NumeroPedido = RandomString(10);
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraPedidoValidation());

            return this;
        }

        public async Task<Pedido> Atualizar(string? numeroPedido)
        {
            NumeroPedido = numeroPedido;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaPedidoValidation());

            return this;
        }

        public async Task<Pedido> Deletar(Guid id)
        {
            Id = id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaPedidoValidation());

            return this;
        }

        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}