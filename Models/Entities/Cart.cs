using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Models.Enums;

namespace Ecommerce.Models.Entities
{
	public class Cart :Auditables
	{
		public Guid? CustomerId { get; set; }
		public Customer? Customer { get; set; }
		
		public decimal TotalAmount { get; set; }
		
		public CartStatus CartStatus { get; set; }
		public ICollection<ProductCart>? ProductCarts { get; set; }
		public PaymentHistory PaymentHistory { get; set; }
	}
}

