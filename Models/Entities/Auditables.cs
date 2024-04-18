using System;
namespace Ecommerce.Models.Entities
{
	public class Auditables
	{
		public Guid Id { get; set; } = new Guid();
		public bool IsDeleted { get; set; } 
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public DateTime DateModified { get; set; }
		public DateTime DateDeleted { get; set; }
		public string? DeletedBy { get; set; }
		public string? ModifiedBy{ get; set; }
	}
}

