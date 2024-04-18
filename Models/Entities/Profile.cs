using System;
using Ecommerce.Models.Enums;

namespace Ecommerce.Models.Entities
{
	public class Profile :Auditables
	{
		public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }	
        public Gender Gender { get; set; }

    }
}

