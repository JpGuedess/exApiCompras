namespace exApiCompras.Models
{
    public class PedidosProdutosModels
    {
        public int Id { get; set; }
        public int? produtoId { get; set; }
        public virtual ProdutoModels? Produto { get; set; }
        public int? categoriaId { get; set; }
        public virtual CategoriaModels? Categoria { get; set; }
        public string quantidade { get; set; }
    }
}
