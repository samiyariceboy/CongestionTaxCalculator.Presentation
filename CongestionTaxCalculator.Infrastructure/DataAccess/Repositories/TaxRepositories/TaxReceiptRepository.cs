using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.ReceiptionRepositories;
using CongestionTaxCalculator.Domain.Entities.Receiption;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;

namespace CongestionTaxCalculator.Infrastructure.DataAccess.Repositories.TaxRepositories
{
    public class TaxReceiptRepository(ApplicationDbContext dbContext) : BaseRepository<TaxReceipt>(dbContext),
        ITaxReceiptRepository, IScopedDependency
    {
    }
}
