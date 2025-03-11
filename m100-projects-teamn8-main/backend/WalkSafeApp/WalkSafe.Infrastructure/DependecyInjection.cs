using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Context;
using WalkSafe.Infrastructure.Repositories;

namespace WalkSafe.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connetionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=WalkSafe;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";
            //services.AddSqlServer<WalkSafeContext>(connetionString);
            services.AddDbContext<WalkSafeContext>(opttions => opttions.UseSqlServer(connetionString));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILandmarkRepository, LandmarkRepoistory>();
            services.AddTransient<IGreenSpaceRepository, GreenSpaceRepository>();
            return services;
        }
    }
}
