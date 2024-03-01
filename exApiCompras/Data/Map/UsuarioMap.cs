using exApiCompras.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModels>
    {
        public void Configure(EntityTypeBuilder<UsuarioModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNascimento).IsRequired().HasMaxLength(255);

        }
    }
}

