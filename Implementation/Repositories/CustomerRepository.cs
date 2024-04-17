using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class CustomerRepository(ApplicationDbContext applicationDbContext)
    : RepositoryAsync<Customer>(applicationDbContext), ICustomerRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<Customer> GetCustomer(Expression<Func<Customer, bool>> expression)
    {
        var entity = _applicationDbContext.Customers.Include(x => x.User).FirstOrDefaultAsync(expression);
        return await entity;

    }

    public  async Task<IEnumerable<Customer>> GetAllCustomerAsync(Expression<Func<Customer, bool>> expression)
    {
        var entities = _applicationDbContext.Customers.Include(x => x.User).Where(expression);
        return await entities. ToListAsync();
    }
}