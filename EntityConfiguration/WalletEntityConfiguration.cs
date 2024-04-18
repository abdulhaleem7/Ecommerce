using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class WalletEntityConfiguration : IEntityTypeConfiguration<Wallet>

{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne(x => x.Wallet)
            .HasForeignKey<Wallet>(x => x.UserId);
    }
}