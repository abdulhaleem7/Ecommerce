using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.DTOs;

public class PaymentHistoryDto
{
    public Guid CartId { get; set; }
    public Guid? CustomerId { get; set; }
    public string ReferenceNumber { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public bool IsPaid { get; set; } = false;
}

public class PaymentHistoryRequestModel
{
    public Guid CartId { get; set; }
    public string ReferenceNumber { get; set; }
    public Guid? CustomerId { get; set; }
    public decimal CartTotalAmount { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public bool IsPaid { get; set; } = false;
}