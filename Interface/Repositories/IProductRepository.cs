using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> GetProduct(Expression<Func<Product, bool>> expression);
    Task<IEnumerable<Product>> GetAllProductAsync(Expression<Func<Product, bool>> expression);
}