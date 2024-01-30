using Domain.Adapters;
using Domain.Enums;
using Domain.Validations.IdentificacoesPedido;

namespace Domain.Entities
{
    public class IdentificacaoPedido : EntidadeBase<Guid>
    {
        public string? Valor { get; private set; }
        public ETipoIdentificacaoPedido TipoIdentificacaoPedido { get; private set; }
        public Pedido? Pedido { get; private set; }

        public async Task<IdentificacaoPedido> Cadastrar(IIdentificacaoPedidoRepository identificacaoPedidoRepository, string? valor, int tipoIdentificacaoPedido)
        {
            NewInstance(valor, tipoIdentificacaoPedido);

            await Validate(this, new CadastraIdentificacaoPedidoValidation(identificacaoPedidoRepository));

            return this;
        }

        public IdentificacaoPedido NewInstance(string? valor, int tipoIdentificacaoPedido)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            TipoIdentificacaoPedido = (ETipoIdentificacaoPedido)tipoIdentificacaoPedido;
            DataCadastro = DateTime.Now;
            Pedido = new();

            return this;
        }

        public void AtualizarIdentificacaoPedido(ETipoIdentificacaoPedido eTipoIdentificacaoPedido)
        {
            TipoIdentificacaoPedido = eTipoIdentificacaoPedido;
        }
    }
}