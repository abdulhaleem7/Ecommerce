using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class ProductRepository(ApplicationDbContext applicationDbContext) :RepositoryAsync<Product>(applicationDbContext),IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    public async Task<Product> GetProduct(Expression<Func<Product, bool>> expression)
    {
        var entity = _applicationDbContext.Products
            .Include(x => x.Category)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(expression);
        return await entity;
    }

    public async  Task<IEnumerable<Product>> GetAllProductAsync(Expression<Func<Product, bool>> expression)
    {
        var entities = _applicationDbContext.Products
            .Include(x => x.Category)
            .Include(x => x.Company)
            .Where(expression);
        return await entities.ToListAsync();
    }
}