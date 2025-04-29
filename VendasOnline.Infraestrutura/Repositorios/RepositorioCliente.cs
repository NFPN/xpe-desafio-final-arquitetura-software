using Microsoft.EntityFrameworkCore;
using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;
using VendasOnline.Infraestrutura.Contexto;

namespace VendasOnline.Infraestrutura.Repositorios
{
    public class RepositorioCliente(VendasOnlineDbContext contexto) 
        : RepositorioBase<Cliente>(contexto), IRepositorioCliente
    {
        public override async Task<IEnumerable<Cliente>> ObterPorNomeAsync(string nome)
        {
            return await dbSet
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }

        public override async Task<Cliente> ObterPorIdAsync(int id)
        {
            return await dbSet
                .Include(c => c.Pedidos)
                .FirstAsync(c => c.Id == id);
        }
    }
}
