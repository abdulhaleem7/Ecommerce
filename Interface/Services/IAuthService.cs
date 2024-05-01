using Ecommerce.DTOs;

namespace Ecommerce.Interface.Services;

public interface IAuthService
{
    public Task<BaseResponse<LoginDto>> Login(LoginRequestModel requestModel);
}