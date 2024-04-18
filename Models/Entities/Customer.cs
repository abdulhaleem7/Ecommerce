using System;
namespace Ecommerce.Models.Entities
{
	public class Customer : Auditables
    {
		public Guid? UserId { get; set; }
		public User User { get; set; }
		public string? TagNumber { get; set; }
		public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
		public ICollection<PaymentHistory> PaymentHistories { get; set; } = new HashSet<PaymentHistory>();
    }
}

