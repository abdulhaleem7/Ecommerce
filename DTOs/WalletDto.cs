using Ecommerce.Models.Entities;

namespace Ecommerce.DTOs;

public class WalletDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public double Amount { get; set; }
}

public class WalletRequestModel
{
    public double Amount { get; set; }
}