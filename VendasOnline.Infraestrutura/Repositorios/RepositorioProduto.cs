using Microsoft.EntityFrameworkCore;
using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;
using VendasOnline.Infraestrutura.Contexto;

namespace VendasOnline.Infraestrutura.Repositorios
{
    public class RepositorioProduto(VendasOnlineDbContext contexto)
        : RepositorioBase<Produto>(contexto), IRepositorioProduto
    {
        public override async Task<IEnumerable<Produto>> ObterPorNomeAsync(string nome)
        {
            return await dbSet
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
