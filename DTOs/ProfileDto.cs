using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class ProfileDto 
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Image { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
}

public class ProfileUpdateRequestModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Image { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

}