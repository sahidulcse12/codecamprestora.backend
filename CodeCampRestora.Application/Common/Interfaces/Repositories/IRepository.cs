using System.Linq.Expressions;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories;
public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TKey id, TEntity entity);
    Task DeleteAsync(TKey id);
    IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
    Task<bool> DoesExist(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> IncludeProps(params Expression<Func<TEntity, object>>[] navigationProperties);
}
