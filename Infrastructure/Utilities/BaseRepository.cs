using Domain.Utilities;
using Domain.Utilities.Repository;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Utilities
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ClinicContext context;

        public BaseRepository(ClinicContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await context.Set<TEntity>().AnyAsync(expression);
        }

        public async Task<TEntity?> GetAsync(long id)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<TEntity?> GetTrackingAsync(long id)
        {
            return await context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<long> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public  void UpdateAsync(TEntity entity)
        {
            context.Update(entity);
        }
    }
}
