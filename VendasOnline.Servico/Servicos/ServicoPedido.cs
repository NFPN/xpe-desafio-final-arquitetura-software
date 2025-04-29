using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.Servico.Servicos
{
    public class ServicoPedido(IRepositorioPedido repositorio)
        : ServicoBase<Pedido>(repositorio), IServicoPedido
    {
    }
}
