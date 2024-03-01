using exApiCompras.Data;
using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly SistemasComprasDBContext _dbContext;
        public PedidoRepositorio(SistemasComprasDBContext SistemasComprasDBContext)
        {
            _dbContext = SistemasComprasDBContext;
        }
        public async Task<PedidoModels> Create(PedidoModels pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<PedidoModels> Read(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PedidoModels> Update(PedidoModels pedido, int id)
        {
            PedidoModels pedidoporid = await Read(id);


            if (pedidoporid == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");
            }

            pedidoporid.UsuarioId = pedido.UsuarioId;
            pedidoporid.EnderecoEntrega = pedido.EnderecoEntrega;

            _dbContext.Pedidos.Update(pedidoporid);
            await _dbContext.SaveChangesAsync();

            return pedidoporid;
        }

        public async Task<bool> Delete(int id)
        {
            PedidoModels pedidoporid = await Read(id);
            if (pedidoporid == null)
            {
                throw new Exception($"Pedido do Id: {id} não foi encontrado");
            }

            _dbContext.Pedidos.Remove(pedidoporid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<PedidoModels>> ReadAll()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

    }
}
