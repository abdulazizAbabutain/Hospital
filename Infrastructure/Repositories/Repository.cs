using Application.Common.Repositories;
using Domain.Common;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _context.Set<T>().AddAsync(entity, cancellationToken);

        public void Delete(T entity)
            => _context.Entry(entity).State = EntityState.Deleted;

        public IQueryable<T> Get(bool trackChanges = true)
        {
            var query = _context.Set<T>().AsQueryable<T>(); 
               
            if(!trackChanges)
                query = query.AsNoTracking();
            
            return query;
        }
        public IQueryable<T> GetByCondetion(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            var query = _context.Set<T>().AsQueryable<T>();

            if (!trackChanges)
                query = query.AsNoTracking();

            return query.Where(expression);
        }
        public void Update(T entity)
            => _context.Entry(entity).State = EntityState.Modified; 
        public async Task<bool> IsExistsAync(Expression<Func<T, bool>> expression, CancellationToken cancellation = default)
        {
           var query = await _context.Set<T>().AsQueryable<T>().AnyAsync(expression, cancellation);
            return query;
        }
    }
}
