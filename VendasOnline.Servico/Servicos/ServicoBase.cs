using System.Linq.Expressions;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.Servico.Servicos
{
    public abstract class ServicoBase<T>(IRepositorioBase<T> repositorio)
        : IServicoBase<T> where T : class
    {
        public virtual async Task<T> ObterPorIdAsync(int id)
            => await repositorio.ObterPorIdAsync(id);

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
            => await repositorio.ObterTodosAsync();

        public virtual async Task<IEnumerable<T>> ObterPorNomeAsync(string nome)
            => await repositorio.ObterPorNomeAsync(nome);

        public virtual async Task<int> ContarTodosAsync()
            => await repositorio.ContarTodosAsync();

        public virtual async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado)
            => await repositorio.BuscarAsync(predicado);

        public virtual async Task AdicionarAsync(T entidade)
            => await repositorio.AdicionarAsync(entidade);

        public virtual async Task AtualizarAsync(T entidade)
            => await repositorio.AtualizarAsync(entidade);

        public virtual async Task RemoverAsync(int id)
            => await repositorio.RemoverAsync(id);
    }
}
