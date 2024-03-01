using exApiCompras.Data.Map;
using exApiCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Data
{
    public class SistemasComprasDBContext : DbContext
    {
        public SistemasComprasDBContext(DbContextOptions<SistemasComprasDBContext> options) : base(options) { }
        public DbSet<UsuarioModels> Usuarios { get; set; }
        public DbSet<PedidoModels> Pedidos { get; set; }
        public DbSet<CategoriaModels> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
