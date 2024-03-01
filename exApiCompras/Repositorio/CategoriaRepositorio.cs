using exApiCompras.Data;
using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly SistemasComprasDBContext _dbContext;
        public CategoriaRepositorio(SistemasComprasDBContext SistemasComprasDBContext)
        {
            _dbContext = SistemasComprasDBContext;
        }
        public async Task<CategoriaModels> Create(CategoriaModels categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<CategoriaModels> Read(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CategoriaModels> Update(CategoriaModels categoria, int id)
        {
            CategoriaModels categoriaporid = await Read(id);


            if (categoriaporid == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");
            }

            categoriaporid.Nome = categoria.Nome;
            categoriaporid.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaporid);
            await _dbContext.SaveChangesAsync();

            return categoriaporid;
        }

        public async Task<bool> Delete(int id)
        {
            CategoriaModels categoriaporid = await Read(id);
            if (categoriaporid == null)
            {
                throw new Exception($"categoria do Id: {id} não foi encontrado");
            }

            _dbContext.Categorias.Remove(categoriaporid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoriaModels>> ReadAll()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

    }
}
