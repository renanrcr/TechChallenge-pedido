using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder.ToTable("ItemPedido");
        }
    }
}
