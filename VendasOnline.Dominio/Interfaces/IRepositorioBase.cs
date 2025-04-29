using System.Linq.Expressions;

namespace VendasOnline.Dominio.Interfaces
{
    /// <summary>
    /// Interface genérica para repositórios
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> ObterPorIdAsync(int id);

        Task<IEnumerable<T>> ObterTodosAsync();

        Task<IEnumerable<T>> ObterPorNomeAsync(string nome);

        Task<int> ContarTodosAsync();

        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado);

        Task AdicionarAsync(T entidade);

        Task AtualizarAsync(T entidade);

        Task RemoverAsync(int id);
    }
}
