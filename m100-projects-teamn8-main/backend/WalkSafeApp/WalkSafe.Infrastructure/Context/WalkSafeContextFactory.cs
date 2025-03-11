using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WalkSafe.Infrastructure.Context
{
    public class WalkSafeContextFactory : IDesignTimeDbContextFactory<WalkSafeContext>
    {
        public WalkSafeContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<WalkSafeContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WalkSafe;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new WalkSafeContext(optionsBuilder.Options);
        }
    }
}
