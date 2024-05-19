using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class CompanyDto
{
    public Guid Id { get; set; }
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

public class CompanyUpdateModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public string? Address { get; set; }
   
}

public class CompanyUpdateStatus
{
    public CompanyStatus CompanyStatus { get; set; }
    public Guid CompanyId { get; set; }
    
    
}
