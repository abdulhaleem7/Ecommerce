using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class PaymentHistoryEntityConfiguration :IEntityTypeConfiguration<PaymentHistory>
{
    public void Configure(EntityTypeBuilder<PaymentHistory> builder)
    {
        builder.HasOne(x => x.Cart)
            .WithOne(x => x.PaymentHistory)
            .HasForeignKey<PaymentHistory>(x => x.CartId);
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.PaymentHistories)
            .HasForeignKey(x => x.CustomerId);
    }
}