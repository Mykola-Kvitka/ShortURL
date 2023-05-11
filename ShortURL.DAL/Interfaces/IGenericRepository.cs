using System.Linq.Expressions;

namespace ShortURL.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetPagedAsync(int page = 1, int pageSize = 15);
        Task<T> GetAsync(int id);
        Task<List<T>> FindAsync(Expression<Func<T, Boolean>> predicate);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<int> GetCountAsync();
    }
}
