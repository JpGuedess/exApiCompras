using exApiCompras.Models;

namespace exApiCompras.Repositorio.Interface
{
    public interface IProdutoRepositorio
    {
        Task<ProdutoModels> Create(ProdutoModels produto);
        Task<ProdutoModels> Read(int id);
        Task<ProdutoModels> Update(ProdutoModels produto, int id);
        Task<bool> Delete(int id);
        Task<List<ProdutoModels>> ReadAll();
    }
}
