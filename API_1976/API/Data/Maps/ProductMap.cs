using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x=>x.ID);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
            builder.HasOne(x => x.Category).WithMany(x => x.Products);
        }
    }
}
