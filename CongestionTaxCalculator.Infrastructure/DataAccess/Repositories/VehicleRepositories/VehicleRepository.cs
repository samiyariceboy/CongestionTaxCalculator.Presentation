using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.VehicleRepositories;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;

namespace CongestionTaxCalculator.Infrastructure.DataAccess.Repositories.VehicleRepositories
{
    public class VehicleRepository(ApplicationDbContext dbContext) 
        : BaseRepository<Vehicle>(dbContext), IVehicleRepository, IScopedDependency
    {
    }
}
