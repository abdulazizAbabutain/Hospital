using Domain.Common;
using System.Linq.Expressions;

namespace Application.Common.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Get(bool trackChanges = true);
        IQueryable<T> GetByCondetion(Expression<Func<T, bool>> expression, bool trackChanges = true);
        Task<bool> IsExistsAync(Expression<Func<T, bool>> expression, CancellationToken cancellation = default);
    }
}
