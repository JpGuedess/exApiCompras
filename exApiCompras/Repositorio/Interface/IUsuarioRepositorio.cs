using exApiCompras.Models;

namespace exApiCompras.Repositorio.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<UsuarioModels> Create(UsuarioModels usuario);
        Task<UsuarioModels> Read(int id);
        Task<UsuarioModels> Update(UsuarioModels usuario, int id);
        Task<bool> Delete(int id);
        Task<List<UsuarioModels>> ReadAll();
    }
}
