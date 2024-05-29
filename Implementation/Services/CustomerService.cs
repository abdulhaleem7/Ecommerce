using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;

namespace Ecommerce.Implementation.Services;

public class CustomerService(ICustomerRepository customerRepository) :ICustomerservice
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public Task<BaseResponse<CustomerDto>> CreateCustomer(CustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public  async Task<BaseResponse<CustomerDto>> GetCustomer(Guid id)
    {
        var getCustomer =  await _customerRepository.GetCustomer(x => x.Id == id);
        if (getCustomer is  null)
        {
            return new BaseResponse<CustomerDto>
            {
                Mesaage = "customer has not being registered",
                Status = false,
            };
        }

        return new BaseResponse<CustomerDto>
        {
            Mesaage = "successful",
            Status = true,
            Data = new CustomerDto
            {
                TagNumber = getCustomer.TagNumber,
                UserId = getCustomer.UserId,
            }
        };
    }

    public Task<BaseResponse<IEnumerable<CustomerDto>>> GetAllCustomers(string filter = null)
    {
        throw new NotImplementedException();
    }
}