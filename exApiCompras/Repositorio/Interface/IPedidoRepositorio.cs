using exApiCompras.Models;

namespace exApiCompras.Repositorio.Interface
{
    public interface IPedidoRepositorio
    {
        Task<PedidoModels> Create(PedidoModels pedido);
        Task<PedidoModels> Read(int id);
        Task<PedidoModels> Update(PedidoModels pedido, int id);
        Task<bool> Delete(int id);
        Task<List<PedidoModels>> ReadAll();
    }
}
