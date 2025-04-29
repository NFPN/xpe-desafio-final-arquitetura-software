using Microsoft.EntityFrameworkCore;
using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;
using VendasOnline.Infraestrutura.Contexto;

namespace VendasOnline.Infraestrutura.Repositorios
{
    public class RepositorioPedido(VendasOnlineDbContext contexto) 
        : RepositorioBase<Pedido>(contexto), IRepositorioPedido
    {
        public override async Task<IEnumerable<Pedido>> ObterPorNomeAsync(string nome)
        {
            return await dbSet
                .Include(p => p.Cliente)
                .Where(p => p.Cliente.Nome.Contains(nome))
                .ToListAsync();
        }

        public override async Task<Pedido> ObterPorIdAsync(int id)
        {
            return await dbSet
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .FirstAsync(p => p.Id == id);
        }
    }
}
