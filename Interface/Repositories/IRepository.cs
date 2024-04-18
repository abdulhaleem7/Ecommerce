using System.Linq.Expressions;

namespace Ecommerce.Interface.Repositories;

public interface IRepository<T>
{
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> Get(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    Task<int> SaveChangesAsync();
}