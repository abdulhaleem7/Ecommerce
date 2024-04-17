using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class CartDto
{
    public Guid? CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public CartStatus CartStatus { get; set; }
   
}

public class CartRequestModel
{
    public Guid? CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public CartStatus CartStatus { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
}