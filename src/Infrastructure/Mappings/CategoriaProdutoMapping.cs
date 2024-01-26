using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CategoriaProdutoMapping : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("CategoriaProduto");
        }
    }
}