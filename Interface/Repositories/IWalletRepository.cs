using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface IWalletRepository :IRepository<Wallet>
{
    Task<Wallet> GetWallet(Expression<Func<Wallet, bool>> expression);
    Task<IEnumerable<Wallet>> GetAllUsersAsync(Expression<Func<Wallet, bool>> expression);
}