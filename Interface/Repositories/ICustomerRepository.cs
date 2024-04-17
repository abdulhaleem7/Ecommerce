using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer> GetCustomer(Expression<Func<Customer, bool>> expression);
    Task<IEnumerable<Customer>> GetAllCustomerAsync(Expression<Func<Customer, bool>> expression);
}