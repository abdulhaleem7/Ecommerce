using Ecommerce.Models.Entities;

namespace Ecommerce.DTOs;

public class ProductCartDto
{
    public Guid? ProductId { get; set; }
    public Guid? CartId { get; set; }
    public Guid CompanyId { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
}