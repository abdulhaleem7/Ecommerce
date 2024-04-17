using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasOne(x => x.Customer).
            WithMany(x => x.Carts)
            .HasForeignKey(x => x.CustomerId);
        builder.HasOne(x => x.PaymentHistory)
            .WithOne(x => x.Cart)
            .HasForeignKey<PaymentHistory>(x => x.CartId);
        builder.HasMany(x => x.ProductCarts)
            .WithOne(x => x.Cart)
            .HasForeignKey(x => x.CartId);
    }
}