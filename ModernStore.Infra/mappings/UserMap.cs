using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(x => x.Id);
            Property(x => x.Username).IsRequired().HasMaxLength(20);
            Property(x => x.PassWord).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.Active);

        }
    }
}