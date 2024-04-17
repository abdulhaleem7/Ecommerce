using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Primitives;

namespace Ecommerce.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasOne(x => x.Company).
            WithMany(x => x.Users)
            .HasForeignKey(x=>x.CompanyId);
        builder.HasOne(x => x.Profile).
            WithOne(x => x.User).
            HasForeignKey<Profile>(x => x.UserId);
        builder.HasOne(x => x.Customer)
            .WithOne(x => x.User)
            .HasForeignKey<Customer>(x => x.UserId);
    }
}