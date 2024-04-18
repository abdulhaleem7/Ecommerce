using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class CustomerEntityConfiguration :IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(x => x.Carts)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);
        builder.HasMany(x => x.PaymentHistories)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);
        builder.HasOne(x => x.User)
            .WithOne(x => x.Customer)
            .HasForeignKey<Customer>(x => x.UserId);
    }
}