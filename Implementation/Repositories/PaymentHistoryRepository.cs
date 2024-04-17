using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class PaymentHistoryRepository(ApplicationDbContext applicationDbContext)
    : RepositoryAsync<PaymentHistory>(applicationDbContext), IPaymentHistoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<PaymentHistory> GetPaymentHistory(Expression<Func<PaymentHistory, bool>> expression)
    {
        var entity = _applicationDbContext.PaymentHistories
            .Include(x => x.Customer)
            .Include(x => x.Cart)
            .FirstOrDefaultAsync(expression);
        return await entity;
    }

    public  async Task<IEnumerable<PaymentHistory>> GetAllPaymentHistoryAsync(Expression<Func<PaymentHistory, bool>> expression)
    {
        var entities = applicationDbContext.PaymentHistories
            .Include(x => x.Customer)
            .Include(x => x.Cart)
            .Where(expression);
        return await entities. ToListAsync();
            
    }
}