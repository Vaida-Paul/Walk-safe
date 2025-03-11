using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WalkSafe.Core.Entities.GreenSpaceAggregate;
using WalkSafe.Core.Entities.LandmarkAggregate;
using WalkSafe.Core.Entities.UserAggregate;
using WalkSafe.Infrastructure.EntityConfig;

namespace WalkSafe.Infrastructure.Context
{
    public class WalkSafeContext(DbContextOptions<WalkSafeContext> options) : DbContext(options)
    {
        public DbSet<Landmark> Landmarks { get; set; }
        public DbSet<GreenSpace> GreenSpaces { get; set; }
        public DbSet<UserAccount> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LandmarkConfig());
            modelBuilder.ApplyConfiguration(new GreenSpaceConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));*/
        }


    }

}
