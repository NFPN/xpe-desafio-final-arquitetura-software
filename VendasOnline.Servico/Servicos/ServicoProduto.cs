using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.Servico.Servicos
{
    public class ServicoProduto(IRepositorioProduto repositorio) 
        : ServicoBase<Produto>(repositorio), IServicoProduto
    {
    }
}
