using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext) : RepositoryAsync<User>(applicationDbContext), IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    public async Task<User> GetUser(Expression<Func<User, bool>> expression)
    {
        var entity = _applicationDbContext.Users.
            Include(x=>x.Profile)
            .Include(x=>x.Customer)
            .Include(x=>x.Wallet)
            .Include(x=>x.Company)
            .FirstOrDefaultAsync(expression);
    return await entity;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(Expression<Func<User, bool>> expression)
    {
        var entities = _applicationDbContext.Users.
            Include(x=>x.Profile)
            .Include(x=>x.Customer)
            .Include(x=>x.Wallet)
            .Include(x=>x.Company)
            .Where(expression);
        return await entities.ToListAsync();
    }
}