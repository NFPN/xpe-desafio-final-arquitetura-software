using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.Servico.Servicos
{
    public class ServicoCliente(IRepositorioCliente repositorio)
        : ServicoBase<Cliente>(repositorio), IServicoCliente
    {
    }
}
