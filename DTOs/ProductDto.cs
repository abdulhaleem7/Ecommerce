using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Image { get; set; }
    public string? Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public ICollection <Product>? products { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public string? CompanyName { get; set; }
    public int DisCount { get; set; }
    public ProductStatus ProductStatus { get; set; }
}

public class ProductRequestModel
{
    public int DisCount { get; set; }
    public string? Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Description { get; set; }
    public Guid? CompanyId { get; set; }
    public string? Image { get; set; }
    public ProductStatus ProductStatus { get; set; }
   
}

public class UpdateRequestModel
{
    public int DisCount { get; set; }
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? CompanyId { get; set; }
    public string? Description { get; set; }
    public ProductStatus ProductStatus { get; set; }
}

