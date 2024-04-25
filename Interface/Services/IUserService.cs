using Ecommerce.DTOs;

namespace Ecommerce.Interface.Services;

public interface IUserService
{
    Task<BaseResponse<UserDto>> CreateUser(UserRequestModel userRequest);
    Task<BaseResponse<UserDto>> GetUser(string name);
    Task<BaseResponse<IEnumerable<UserDto>>> GetAllUser(string filter = null);
    
    Task<BaseResponse<UserDto>> UpdateUser(UserUpdateModel updateRequestModel, string userName);
}