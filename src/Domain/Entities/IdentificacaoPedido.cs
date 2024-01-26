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
            Id = Guid.NewGuid();
            Valor = valor;
            TipoIdentificacaoPedido = (ETipoIdentificacaoPedido)tipoIdentificacaoPedido;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraIdentificacaoPedidoValidation(identificacaoPedidoRepository));

            return this;
        }
    }
}