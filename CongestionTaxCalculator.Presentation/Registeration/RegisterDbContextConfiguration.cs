using Microsoft.EntityFrameworkCore;
using EFCoreSecondLevelCacheInterceptor;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;

namespace SeatReserver.Movie.Application.Registeration
{
    public static class RegisterDbContextConfiguration
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration config)
        {
            const string RedisProvider = "Redis01";
            services.AddEFSecondLevelCache(options =>
            {
                options.UseMemoryCacheProvider();

                //options.UseEasyCachingCoreProvider(RedisProvider, isHybridCache: false);
            });

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(config.GetConnectionString("SqlServer"))
                    .AddInterceptors(serviceProvider
                    .GetRequiredService<SecondLevelCacheInterceptor>());

            }, ServiceLifetime.Scoped);
        }
    }
}
