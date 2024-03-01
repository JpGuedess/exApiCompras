using exApiCompras.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModels>
    {
        public void Configure(EntityTypeBuilder<PedidoModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.Usuario);

        }
    }
}

