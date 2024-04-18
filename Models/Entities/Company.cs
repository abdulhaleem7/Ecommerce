using System;
using Ecommerce.Models.Enums;

namespace Ecommerce.Models.Entities
{
	public class Company : Auditables
    {
		public string? Name { get; set; }
		public string? CacRegNumber { get; set; }
		public string? Logo { get; set; }
		public string? CompanyEmail { get; set; }
		public string? Address { get; set; }
		public CompanyStatus CompanyStatus { get; set; }
		public ICollection<User> Users { get; set; } = new HashSet<User>();
		public ICollection<Product>? Products { get; set; } = new HashSet<Product>();
		public ICollection<ProductCart>? ProductCarts { get; set; } = new HashSet<ProductCart>();
		public string? PaymentKey { get; set; }

	}
}

