using Domain.Adapters;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.IdentificacoesPedido
{
    public class CadastraIdentificacaoPedidoValidation : ValidationBase<IdentificacaoPedido>
    {
        private IIdentificacaoPedidoRepository _identificacaoPedidoRepository;

        public CadastraIdentificacaoPedidoValidation(IIdentificacaoPedidoRepository identificacaoPedidoRepository)
        {
            _identificacaoPedidoRepository = identificacaoPedidoRepository;

            ValidarId();
            ValidarValorCliente();
            ValidarValorCPF();
            ValidarExisteIdentificacaoCadastrada();
            ValidarDataCadastro();
        }

        public void ValidarValorCliente()
        {
            RuleFor(x => x.TipoIdentificacaoPedido).Must((x, identificacaoPedido) =>
            {
                return !(identificacaoPedido == ETipoIdentificacaoPedido.CLIENTE && !string.IsNullOrEmpty(x.Valor));
            }).WithMessage("Informe um valor válido.");
        }

        public void ValidarValorCPF()
        {
            RuleFor(x => x.TipoIdentificacaoPedido).Must((x, identificacaoPedido) =>
            {
                return !(identificacaoPedido == ETipoIdentificacaoPedido.CPF && ValidarCPF(x.Valor));
            }).WithMessage("Informe um CPF válido."); ;
        }

        private bool ValidarCPF(string? valor) => new CPF(valor).IsValidado;

        private void ValidarExisteIdentificacaoCadastrada()
        {
            RuleFor(s => s.Valor)
                .MustAsync(ExisteIdentificacaoAsync).WithMessage("Identificação já cadastrada em nossa base de dados.");
        }

        private async Task<bool> ExisteIdentificacaoAsync(string? valor, CancellationToken token)
        {
            return !await _identificacaoPedidoRepository.Existe(x => !string.IsNullOrEmpty(valor) && x.Valor == valor);
        }
    }
}