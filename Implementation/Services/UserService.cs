using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;

namespace Ecommerce.Implementation.Services;

public class UserService (IUserRepository userRepository, ICompanyRepository companyRepository, IProfileRepository profileRepository):IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IProfileRepository _profileRepository = profileRepository;
    public async Task<BaseResponse<UserDto>> CreateUser(UserRequestModel userRequest)
    {
        
        var getUser = await _userRepository.GetUser(x => x.Email == userRequest.Email);
        if (getUser is not null)
        {
            return new BaseResponse<UserDto>
            {
                Mesaage = "user already exist ",
                Status = false,
            };
        }

        if (userRequest.CompanyId is not null && userRequest.CompanyId != Guid.Empty)
        {
            var getCompany = await _companyRepository.Get(x => x.Id == userRequest.CompanyId);
            if (getCompany == null)
            {
                return new BaseResponse<UserDto>
                {
                    Mesaage = "selected company does not  exist ",
                    Status = false,
                };
            }
        }
        
        var user = new User
        {
            Email = userRequest.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
            UserName = userRequest.UserName,
            Role = userRequest.Role,
            CompanyId = userRequest?.CompanyId,
            
        };
        await _userRepository.CreateAsync(user);
        var profile = new Profile
        {
            Address = userRequest.Address,
            FirstName = userRequest.FirstName,
            Gender = userRequest.Gender,
            LastName = userRequest.LastName,
            Image = userRequest.Image,
            UserId = user.Id,
            PhoneNumber = userRequest.PhoneNumber,
        };
        await _profileRepository.CreateAsync(profile);
        await _userRepository.SaveChangesAsync();
        return new BaseResponse<UserDto>
        {
            Mesaage = "Successfully created",
            Status = true,
        };
    }
    

    public async  Task<BaseResponse<UserDto>> GetUser(string name)
    {
        var getUser = await _userRepository.GetUser(x => x.UserName == name);
        if (getUser is  null)
        {
            return new BaseResponse<UserDto>
            {
                Mesaage = "user does not exist",
                Status = false
            };
        }

        return new BaseResponse<UserDto>
        {
            Mesaage = "successful",
            Status = true,
            Data = new UserDto()
            {
                Address = getUser.Profile.Address,
                Email = getUser.Email,
                FirstName = getUser.Profile.FirstName,
                LastName = getUser.Profile.LastName,
                Image = getUser.Profile.Image,
                Gender = getUser.Profile.Gender,
                CompanyName = getUser.Company?.Name,
                PhoneNumber = getUser.Profile.PhoneNumber,
                Role = getUser.Role,
                UserName = getUser.UserName,

            }
        };


    }

    public  async Task<BaseResponse<IEnumerable<UserDto>>> GetAllUser(string filter = null)
    
    {
        var getAllUsers = await _userRepository.GetAllUsersAsync(x => x.UserName.Contains(filter) || x.Profile.FirstName.Contains(filter) || filter == null);
        return new BaseResponse<IEnumerable<UserDto>>
        {
            Mesaage = "Successful",
            Status = true,
            Data = getAllUsers.Select(x => new UserDto()
            {
                Address = x.Profile.Address,
                Email = x.Email,
                FirstName = x.Profile.FirstName,
                LastName = x.Profile.LastName,
                Image = x.Profile.Image,
                Gender = x.Profile.Gender,
                CompanyName = x.Company?.Name == null ? "null" : x.Company?.Name,
                PhoneNumber = x.Profile.PhoneNumber,
                Role = x.Role,
                UserName = x.UserName,
            }).ToList(),

        };
    }

    public async Task<BaseResponse<UserDto>> UpdateUser(UserUpdateModel updateRequestModel, string userName)
    {
        var getUser =  await _userRepository.GetUser(x => x.UserName == userName);
        if (getUser is  null)
        {
            return new BaseResponse<UserDto>
            {
                Mesaage = "User dose not exist",
                Status = false,
            };
        }

        if (getUser.UserName != updateRequestModel.UserName)
        {
            var checkUserName =  await _userRepository.GetUser(x => x.UserName == updateRequestModel.UserName);
            if (checkUserName is not null)
            {
                return new BaseResponse<UserDto>
                {
                    Mesaage = "Username already exist, try using another username",
                    Status = false,
                };
            }

        }
       
        getUser.UserName = updateRequestModel.UserName ?? getUser.UserName;
        await _userRepository.UpdateAsync(getUser);

        var getProfile = await _profileRepository.GetProfile(x => x.UserId == getUser.Id);

        getProfile.Address = updateRequestModel.Address ?? getProfile.Address;
        getProfile.FirstName = updateRequestModel.FirstName ?? getProfile.FirstName;
        getProfile.LastName = updateRequestModel.LastName ?? getProfile.LastName;
        getProfile.Image = updateRequestModel.Image  ?? getProfile.Image;
        getProfile.PhoneNumber = updateRequestModel.PhoneNumber  ?? getProfile.PhoneNumber;
        
        await _profileRepository.UpdateAsync(getProfile);
        await _userRepository.SaveChangesAsync();

        return new BaseResponse<UserDto>
        {
            Mesaage = "Successful",
            Status = true,

        };

    }


    
}