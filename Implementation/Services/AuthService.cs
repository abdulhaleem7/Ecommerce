using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;

namespace Ecommerce.Implementation.Services;

public class AuthService (IUserRepository userRepository): IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<BaseResponse<LoginDto>> Login(LoginRequestModel requestModel)
    {
        var getUser = await _userRepository.GetUser(x => x.UserName == requestModel.UserName);
        // if (getUser is null)
        // {
        //     return new BaseResponse<LoginDto>
        //     {
        //         Mesaage = "incorrect password or username",
        //         Status = false
        //     };
        // }

        var verifyPassword = BCrypt.Net.BCrypt.Verify(requestModel.PassWord, getUser.Password);
        if (!verifyPassword || getUser.Equals(null))
        {
            return new BaseResponse<LoginDto>
            {
                Mesaage = "incorrect password or username",
                Status = false
            };
        }

        return new BaseResponse<LoginDto>
        {
            Mesaage = "Successfully logged in",
            Status = true,
            Data = new LoginDto
            {
                Email = getUser.Email,
                FirstName = getUser.Profile.FirstName,
                LastName = getUser.Profile.LastName,
                UserId = getUser.Id,
                Role = getUser.Role,
                UserName = getUser.UserName
            }
        };

    }
}