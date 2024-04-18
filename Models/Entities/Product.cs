using System;
namespace Ecommerce.Models.Entities
{
	public class Product : Auditables
	{
		public string? Name { get; set; }
		public int QuantityAvailable { get; set; }
		public decimal Price { get; set; }
		public string Image { get; set; }
		public Guid? CategoryId { get; set; }
		public Category? Category { get; set; }
		public Guid? CompanyId { get; set; }
		public Company Company { get; set; }
		public ICollection<ProductCart>? ProductCarts { get; set; }
	}
}

