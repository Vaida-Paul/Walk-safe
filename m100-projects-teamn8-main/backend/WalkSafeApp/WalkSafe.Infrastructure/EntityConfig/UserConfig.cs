using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Infrastructure.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("UserAccount");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.Property(t => t.Email);
            builder.Property(t => t.Password);
            builder.Property(t => t.Role);
            //builder.Property(t => t.Preferences);
            //builder.HasMany(t => t.Bookmarks);
        }
    }
}
