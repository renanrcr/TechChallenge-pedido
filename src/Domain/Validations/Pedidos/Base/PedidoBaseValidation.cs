using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Pedidos.Base
{
    public class PedidoBaseValidation : ValidationBase<Pedido>
    {
        public PedidoBaseValidation()
        {
            ValidarId();
            ValidarCliente();
            ValidarDataCadastro();
        }

        public void ValidarCliente()
        {
            RuleFor(x => x.ClienteId).NotNull().WithMessage("Informe o cliente.");
        }
    }
}