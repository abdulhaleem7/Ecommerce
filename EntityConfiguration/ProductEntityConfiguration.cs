using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityConfiguration;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.HasOne(x => x.Category).
            WithMany(x => x.products).
            HasForeignKey(x => x.CategoryId);
        builder.HasOne(x=>x.Company).
            WithMany(x=>x.Products).
            HasForeignKey(x=>x.CompanyId);
        builder.HasMany(x => x.ProductCarts).
            WithOne(x => x.Product).
            HasForeignKey(x => x.ProductId);
    }
}
