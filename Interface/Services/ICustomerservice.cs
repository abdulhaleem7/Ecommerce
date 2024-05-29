using Ecommerce.DTOs;

namespace Ecommerce.Interface.Services;

public interface ICustomerservice
{
    Task<BaseResponse<CustomerDto>> CreateCustomer(CustomerDto customer);
    Task<BaseResponse<CustomerDto>> GetCustomer(Guid id);
    Task<BaseResponse<IEnumerable<CustomerDto>>> GetAllCustomers(string filter = null);
    
}