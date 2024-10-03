using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.TaxRepositories;
using CongestionTaxCalculator.Domain.Entities.Tax;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;

namespace CongestionTaxCalculator.Infrastructure.DataAccess.Repositories.TaxRepositories
{
    public class TaxRepository(ApplicationDbContext dbContext) 
        : BaseRepository<TaxRole>(dbContext), ITaxRepository, IScopedDependency
    {

    }
}
