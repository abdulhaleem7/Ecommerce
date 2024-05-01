using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class LoginDto
{
    public string Email { get; set; }
    public Role Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid  UserId { get; set; }
    
    public string UserName { get; set; }
}

public class LoginRequestModel
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
}