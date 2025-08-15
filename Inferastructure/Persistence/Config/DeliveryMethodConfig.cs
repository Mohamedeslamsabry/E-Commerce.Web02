using Domain_Layer.Models.OrderModule;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config
{
    public class DeliveryMethodConfig : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");

            builder.Property(D => D.Cost)
                .HasColumnType("decimal(8, 2)");

            builder.Property(D => D.ShortName)
                .HasColumnType("varchar(50)");

            builder.Property(D => D.Description)
                  .HasColumnType("varchar(50)");

            builder.Property(D => D.DeliveryTime)
                  .HasColumnType("varchar(50)");
        }
    }
}
