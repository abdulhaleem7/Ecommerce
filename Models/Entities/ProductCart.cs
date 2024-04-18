using System;
namespace Ecommerce.Models.Entities
{
	public class ProductCart :Auditables
	{
		public Guid? ProductId { get; set; }
		public Guid? CartId { get; set; }
		public Cart? Cart { get; set; }
		public Product? Product { get; set; }
		public Guid CompanyId { get; set; }
		public Company Company { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
	}
}

