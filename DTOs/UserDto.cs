using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class UserDto 
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }
    public Role Role { get; set; }
    public string CompanyName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Image { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
}

public class UserRequestModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }
    public Guid? CompanyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Image { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
    public Role Role { get; set; }
}

public class UserUpdateModel
{
    public string? UserName { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? Image { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Address { get; set; }
    
    

}

public class ChangePassword
{
    public string Password { get; set; }
}