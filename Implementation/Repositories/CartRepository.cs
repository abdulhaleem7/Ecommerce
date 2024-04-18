using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class CartRepository(ApplicationDbContext applicationDbContext) : RepositoryAsync<Cart>(applicationDbContext), ICartRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    public  async Task<Cart> GetCart(Expression<Func<Cart, bool>> expression)
    {
        var entity = _applicationDbContext.Carts
            .Include(x => x.Customer)
            .Include(x => x.PaymentHistory)
            .FirstOrDefaultAsync(expression);
        return await entity;
    }

    public async Task<IEnumerable<Cart>> GetAllCartsAsync(Expression<Func<Cart, bool>> expression)
    {
        var entities = _applicationDbContext.Carts
            .Include(x => x.Customer)
            .Include(x => x.PaymentHistory)
            .Where(expression);
        return await entities.ToListAsync();
    }
}