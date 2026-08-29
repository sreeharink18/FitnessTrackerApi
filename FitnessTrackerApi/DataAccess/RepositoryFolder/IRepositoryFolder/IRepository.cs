using System.Linq.Expressions;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task RemoveAsync(T entity);
        Task AddAsync(T entity);
    }

}
