using System;
namespace Ecommerce.Models.Entities
{
	public class Category : Auditables
    {
		public ICollection <Product>? products { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

	}
}

