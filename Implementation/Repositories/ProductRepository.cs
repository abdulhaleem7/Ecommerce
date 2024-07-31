using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    public async Task<IList<Product>> GetAllProductAsync(Expression<Func<Product, bool>> expression)
    {
        return await _applicationDbContext.Products
            .Include(x => x.Category)
            .Include(x => x.Company)
            .Where(expression).ToListAsync();
    }

	public async Task<PageBaseResponse<IList<ProductDto>>> GetPaginatedProductAsync(Expression<Func<Product, bool>> expression,int page, int pageSize)
	{
		var result = await _applicationDbContext.Products
			.Include(x => x.Category)
		.Include(x => x.Company)
			.Where(expression).Skip((page - 1) * pageSize)
						   .Take(pageSize).ToListAsync();
		var totalProduct = _applicationDbContext.Products.Count();
		return new PageBaseResponse<IList<ProductDto>>
		{
			Mesaage = "successful",
			Status = true,
			Data = result.Select(x => new ProductDto()
			{
				Id = x.Id,
				DisCount = x.DisCount,
				Name = x.Name,
				CategoryName = x.Category.Name,
				CompanyName = x.Company.Name,
				Description = x.Description,
				Price = x.Price,
				QuantityAvailable = x.QuantityAvailable,
				ProductStatus = x.ProductStatus,
				Image = x.Image
			}).ToList(),
			TotalCount = totalProduct,
			TotalPage = (int)Math.Ceiling((double)totalProduct / pageSize)
	};
	}
}