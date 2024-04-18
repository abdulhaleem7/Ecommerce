using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUser(Expression<Func<User, bool>> expression);
    Task<IEnumerable<User>> GetAllUsersAsync(Expression<Func<User, bool>> expression);
}