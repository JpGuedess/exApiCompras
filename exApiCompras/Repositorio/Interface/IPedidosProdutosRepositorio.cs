using exApiCompras.Models;

namespace exApiCompras.Repositorio.Interface
{
    public interface IPedidosProdutosRepositorio
    {
        Task<PedidosProdutosModels> Create(PedidosProdutosModels pedidosProdutos);
        Task<PedidosProdutosModels> Read(int id);
        Task<PedidosProdutosModels> Update(PedidosProdutosModels pedidosProdutos, int id);
        Task<bool> Delete(int id);
        Task<List<PedidosProdutosModels>> ReadAll();
    }
}
