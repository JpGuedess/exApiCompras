using exApiCompras.Data;
using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Repositorio
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly SistemasComprasDBContext _dbContext;
        public PedidosProdutosRepositorio(SistemasComprasDBContext SistemasComprasDBContext)
        {
            _dbContext = SistemasComprasDBContext;
        }
        public async Task<PedidosProdutosModels> Create(PedidosProdutosModels pedidosProdutos)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidosProdutos);
            await _dbContext.SaveChangesAsync();

            return pedidosProdutos;
        }

        public async Task<PedidosProdutosModels> Read(int id)
        {
            return await _dbContext.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PedidosProdutosModels> Update(PedidosProdutosModels pedidosProdutos, int id)
        {
            PedidosProdutosModels PedidosProdutosporid = await Read(id);


            if (PedidosProdutosporid == null)
            {
                throw new Exception($"Pedido do ID: {id} não foi encontrado");
            }

            PedidosProdutosporid.produtoId = pedidosProdutos.produtoId;
            PedidosProdutosporid.categoriaId = pedidosProdutos.categoriaId;
            PedidosProdutosporid.quantidade = pedidosProdutos.quantidade;

            _dbContext.PedidosProdutos.Update(PedidosProdutosporid);
            await _dbContext.SaveChangesAsync();

            return PedidosProdutosporid;
        }

        public async Task<bool> Delete(int id)
        {
            PedidosProdutosModels PedidosProdutosporid = await Read(id);
            if (PedidosProdutosporid == null)
            {
                throw new Exception($"Pedido do Id: {id} não foi encontrado");
            }

            _dbContext.PedidosProdutos.Remove(PedidosProdutosporid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<PedidosProdutosModels>> ReadAll()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }

    }
}
