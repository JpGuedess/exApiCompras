using exApiCompras.Models;

namespace exApiCompras.Repositorio.Interface
{
    public interface ICategoriaRepositorio
    {
        Task<CategoriaModels> Create(CategoriaModels categoria);
        Task<CategoriaModels> Read(int id);
        Task<CategoriaModels> Update(CategoriaModels categoria, int id);
        Task<bool> Delete(int id);
        Task<List<CategoriaModels>> ReadAll();
    }
}
