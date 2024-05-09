using Ecommerce.Models.Entities;

namespace Ecommerce.DTOs;

public class CategoryDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class CategoryRequestModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
}
public class UpdateCategoryRequestModel
{
    public string OldValue { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    
}
