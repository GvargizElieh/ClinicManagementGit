using System.Linq.Expressions;

namespace Domain.Utilities.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task<T?> GetAsync(long id);
        Task<T?> GetTrackingAsync(long id);
        Task<long> SaveAsync();
        void UpdateAsync(T entity);
    }
}
