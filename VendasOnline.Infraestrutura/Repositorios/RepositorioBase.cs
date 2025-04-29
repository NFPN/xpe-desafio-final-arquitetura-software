using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendasOnline.Dominio.Interfaces;
using VendasOnline.Infraestrutura.Contexto;

namespace VendasOnline.Infraestrutura.Repositorios
{
    public abstract class RepositorioBase<T>(VendasOnlineDbContext contexto)
        : IRepositorioBase<T> where T : class
    {
        protected readonly VendasOnlineDbContext _contexto = contexto;
        protected readonly DbSet<T> dbSet = contexto.Set<T>();

        // Este método será sobrescrito para cada repositório específico
        public virtual async Task<IEnumerable<T>> ObterPorNomeAsync(string nome) =>
            throw new NotImplementedException();

        public virtual async Task<T> ObterPorIdAsync(int id) => await dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<T>> ObterTodosAsync() => await dbSet.ToListAsync();

        public virtual async Task<int> ContarTodosAsync() => await dbSet.CountAsync();

        public virtual async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado) => await dbSet.Where(predicado).ToListAsync();

        public virtual async Task AdicionarAsync(T entidade)
        {
            await dbSet.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(T entidade)
        {
            dbSet.Update(entidade);
            await _contexto.SaveChangesAsync();
        }

        public virtual async Task RemoverAsync(int id)
        {
            var entidade = await ObterPorIdAsync(id);
            if (entidade != null)
            {
                dbSet.Remove(entidade);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
