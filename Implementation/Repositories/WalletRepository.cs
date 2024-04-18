using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class WalletRepository(ApplicationDbContext applicationDbContext) : RepositoryAsync<Wallet>(applicationDbContext), IWalletRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    public  async Task<Wallet> GetWallet(Expression<Func<Wallet, bool>> expression)
    {
        var entity = applicationDbContext.Wallets
            .Include(x => x.User)
            .FirstOrDefaultAsync(expression);
        return await entity;
    }

    public async Task<IEnumerable<Wallet>> GetAllUsersAsync(Expression<Func<Wallet, bool>> expression)
    {
        var entity = applicationDbContext.Wallets
            .Include(x => x.User)
            .Where(expression);
        return await entity.ToListAsync();
    }
}