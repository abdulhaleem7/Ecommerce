using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart> GetCart(Expression<Func<Cart, bool>> expression);
    Task<IEnumerable<Cart>> GetAllCartsAsync(Expression<Func<Cart, bool>> expression);
}