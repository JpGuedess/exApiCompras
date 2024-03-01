using exApiCompras.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModels>
    {
        public void Configure(EntityTypeBuilder<CategoriaModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(255);

        }
    }
}

