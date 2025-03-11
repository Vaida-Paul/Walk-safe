using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalkSafe.Core.Entities.GreenSpaceAggregate;

namespace WalkSafe.Infrastructure.EntityConfig
{
    public class GreenSpaceConfig : IEntityTypeConfiguration<GreenSpace>
    {
        public void Configure(EntityTypeBuilder<GreenSpace> builder)
        {
            builder.ToTable("GreenSpace");
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Name);
            builder.Property(x => x.Longitude);
            builder.Property(x => x.Latitude);
            builder.Property(x => x.Description);
        }
    }
}
