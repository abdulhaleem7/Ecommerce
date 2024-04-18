using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasMany(x => x.ProductCarts)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
        builder.HasMany(x => x.Products)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
        builder.HasMany(x => x.Users)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
    }
}