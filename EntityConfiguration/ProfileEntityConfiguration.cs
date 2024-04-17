using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne(x => x.Profile)
            .HasForeignKey<Profile>(x => x.UserId);
    }
}