using System;
namespace Ecommerce.Models.Entities
{
	public class Wallet: Auditables
	{
		public Guid? UserId { get; set; }
		public User User { get; set; }
		public double Amount { get; set; }
	}
}

