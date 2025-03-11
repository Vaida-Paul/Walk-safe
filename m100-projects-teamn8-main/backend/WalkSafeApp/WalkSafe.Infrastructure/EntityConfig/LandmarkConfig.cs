using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalkSafe.Core.Entities.LandmarkAggregate;

namespace WalkSafe.Infrastructure.EntityConfig
{
    public class LandmarkConfig : IEntityTypeConfiguration<Landmark>
    {
        public void Configure(EntityTypeBuilder<Landmark> builder)
        {
            builder.ToTable("Landmark");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Longitude);
            builder.Property(x => x.Latitude);
        }
    }
}
