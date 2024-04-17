using Ecommerce.Models.Entities;

namespace Ecommerce.DTOs;

public class ProductDto
{
    public string? Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public ICollection <Product>? products { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public string? CompanyName { get; set; }
}

public class ProductRequestModel
{
    public string? Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? CompanyId { get; set; }
   
}

public class UpdateRequestModel
{
    public string? Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? CompanyId { get; set; }
}

