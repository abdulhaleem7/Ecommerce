using System.Linq.Expressions;
using Ecommerce.DTOs;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> GetProduct(Expression<Func<Product, bool>> expression);
    Task<IList<Product>> GetAllProductAsync(Expression<Func<Product, bool>> expression);
	Task<PageBaseResponse<IList<ProductDto>>> GetPaginatedProductAsync(Expression<Func<Product, bool>> expression, int page, int pageSize);
}