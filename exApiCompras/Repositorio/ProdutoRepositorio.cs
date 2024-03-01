using exApiCompras.Data;
using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SistemasComprasDBContext _dbContext;
        public ProdutoRepositorio(SistemasComprasDBContext SistemasComprasDBContext)
        {
            _dbContext = SistemasComprasDBContext;
        }
        public async Task<ProdutoModels> Create(ProdutoModels produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<ProdutoModels> Read(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProdutoModels> Update(ProdutoModels produto, int id)
        {
            ProdutoModels produtoPorId = await Read(id);


            if (produtoPorId == null)
            {
                throw new Exception($"Produto do ID: {id} não foi encontrado");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;

            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Delete(int id)
        {
            ProdutoModels produtoporid = await Read(id);
            if (produtoporid == null)
            {
                throw new Exception($"produto do Id: {id} não foi encontrado");
            }

            _dbContext.Produtos.Remove(produtoporid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProdutoModels>> ReadAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

    }
}
