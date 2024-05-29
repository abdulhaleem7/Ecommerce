using Ecommerce.Models.Entities;

namespace Ecommerce.DTOs;

public class CustomerDto
{
    public Guid? UserId { get; set; }

    public string? TagNumber { get; set; }
}