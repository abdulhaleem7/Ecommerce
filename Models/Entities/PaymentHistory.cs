using Ecommerce.Models.Enums;

namespace Ecommerce.Models.Entities;

public class PaymentHistory : Auditables
{
    public Guid? CustomerId { get; set; }
    public Customer Customer { get; set; }
    public string ReferenceNumber { get; set; }
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public bool IsPaid { get; set; } = false;
}