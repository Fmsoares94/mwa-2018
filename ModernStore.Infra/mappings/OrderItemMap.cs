using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItems");
            HasKey(x => x.Id);
            Property(x => x.Price).HasColumnType("money");
            Property(x => x.Quantity);
            HasRequired(x => x.Product);
        }

    }
}
