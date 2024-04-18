using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class ProductCartEntityConfiguration : IEntityTypeConfiguration<ProductCart>
{
    public void Configure(EntityTypeBuilder<ProductCart> builder)
    {
        builder.HasOne(x => x.Cart)
            .WithMany(x => x.ProductCarts)
            .HasForeignKey(x => x.CartId);
        builder.HasOne(x => x.Company)
            .WithMany(x => x.ProductCarts)
            .HasForeignKey(x => x.CompanyId);
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductCarts)
            .HasForeignKey(x => x.ProductId);
    }
}