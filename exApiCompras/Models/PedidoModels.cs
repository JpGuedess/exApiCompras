namespace exApiCompras.Models
{
    public class PedidoModels
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModels? Usuario { get; set; }
        public string EnderecoEntrega { get; set; }
    }
}
