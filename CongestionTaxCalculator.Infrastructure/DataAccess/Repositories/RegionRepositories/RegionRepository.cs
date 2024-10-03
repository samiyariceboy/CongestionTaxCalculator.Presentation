using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.RegionRepositories;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;

namespace CongestionTaxCalculator.Infrastructure.DataAccess.Repositories.RegionRepositories
{
    public class RegionRepository(ApplicationDbContext dbContext)
        : BaseRepository<Region>(dbContext), IRegionRepository, IScopedDependency
    {

    }
}
