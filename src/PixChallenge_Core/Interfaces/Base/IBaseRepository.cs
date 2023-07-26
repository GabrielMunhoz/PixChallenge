using System.Linq.Expressions;

namespace PixChallenge_Core.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T model);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<int> SaveAsync();
        IQueryable<T> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
