using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class IdentificacaoPedidoMapping : IEntityTypeConfiguration<IdentificacaoPedido>
    {
        public void Configure(EntityTypeBuilder<IdentificacaoPedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => IdentificacaoPedido : Pedido
            builder.HasOne(f => f.Pedido)
                .WithOne(e => e.IdentificacaoPedido);

            builder.ToTable("IdentificacaoPedido");
        }
    }
}