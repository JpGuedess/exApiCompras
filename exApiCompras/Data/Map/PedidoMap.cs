using exApiCompras.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModels>
    {
        public void Configure(EntityTypeBuilder<ProdutoModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Preco).IsRequired().HasMaxLength(255);

        }
    }
}

