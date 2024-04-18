using System;
using Ecommerce.Models.Enums;

namespace Ecommerce.Models.Entities
{
	public class User :Auditables
	{
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public Role Role { get; set; }
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
        public Profile? Profile { get; set; }
        public Wallet Wallet { get; set; }
        public Customer Customer { get; set; }
    }
}

