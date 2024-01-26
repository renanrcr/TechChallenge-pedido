using Domain.Entities;
using Domain.Validations;
using FluentValidation;

namespace Domain.Validations.Pedidos.Base
{
    public class PedidoBaseValidation : ValidationBase<Pedido>
    {
        public PedidoBaseValidation()
        {
            ValidarId();
            ValidarIdentificacaoPedido();
            ValidarDataCadastro();
        }

        public void ValidarIdentificacaoPedido()
        {
            RuleFor(x => x.IdentificacaoPedidoId).NotNull().WithMessage("Informe uma identificação.");
        }
    }
}