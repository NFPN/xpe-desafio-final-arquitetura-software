using System.ComponentModel.DataAnnotations;
using VendasOnline.Dominio.Enums;

namespace VendasOnline.Dominio.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        public StatusPedido Status { get; set; } = StatusPedido.Pendente;

        [Required(ErrorMessage = "O ID do cliente é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O pedido deve ter pelo menos um item")]
        public List<ItemPedidoDto>? Itens { get; set; }
    }
}
