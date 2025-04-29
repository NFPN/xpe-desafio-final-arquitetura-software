using VendasOnline.Dominio.Enums;

namespace VendasOnline.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public StatusPedido Status { get; set; }
        public decimal ValorTotal { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItemPedido> Itens { get; set; }
    }
}
