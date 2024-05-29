using Ecommerce.DTOs;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Services;

public interface ICartService
{
    Task<BaseResponse<CartDto>> CreateCart(CartRequestModel cartRequestModel);
    Task<BaseResponse<CartDto>> GetCart(string id);
    
}