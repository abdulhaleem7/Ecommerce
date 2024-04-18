using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class RepositoryAsync<T>(ApplicationDbContext applicationDbContext) : IRepository<T>
    where T : Auditables
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<T> CreateAsync(T entity)
    {
       await _applicationDbContext.Set<T>().AddAsync(entity);
       return entity;
    }

    public Task UpdateAsync(T entity)
    {
        _applicationDbContext.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression)
    {
        var entity = _applicationDbContext.Set<T>();
        return await entity.FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        var entities = _applicationDbContext.Set<T>();
       return await entities.Where(expression).ToListAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
       return await _applicationDbContext.SaveChangesAsync();
    }
}