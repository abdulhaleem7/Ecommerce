using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface IPaymentHistoryRepository :IRepository<PaymentHistory>
{
    Task<PaymentHistory> GetPaymentHistory(Expression<Func<PaymentHistory, bool>> expression);
    Task<IEnumerable<PaymentHistory>> GetAllPaymentHistoryAsync(Expression<Func<PaymentHistory, bool>> expression);
}