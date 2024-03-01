using exApiCompras.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModels>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.produtoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.categoriaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.quantidade).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.Produto);
            builder.HasOne(x => x.Categoria);
        }
    }
}

