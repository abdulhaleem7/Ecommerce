using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class fgCompanyDto
{
    public string? Name { get; set; }
    public string? CacRegNumber { get; set; }
    public string? Logo { get; set; }
    public string? CompanyEmail { get; set; }
    public string? Address { get; set; }
    public CompanyStatus CompanyStatus { get; set; }
}

public class CompanyRequestModel
{
    public string? Name { get; set; }
    public string? CacRegNumber { get; set; }
    public string? Logo { get; set; }
    public string? CompanyEmail { get; set; }
    public string? Address { get; set; }
}