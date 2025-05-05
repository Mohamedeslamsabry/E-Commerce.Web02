using Domain_Layer.Models.OrderModule;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config
{
    public class OtrderItemConfig : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable("OrderItems");

            builder.Property(O => O.Price)
              .HasColumnType("decimal(8, 2)");

            builder.OwnsOne(O => O.Product);
        }
    }
}
