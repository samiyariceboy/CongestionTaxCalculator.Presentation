using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.DTO.Tax;

namespace CongestionTaxCalculator.Domain.Services.TaxDomainServices
{
    public interface ITaxDomainService
    {
        Task AssignTaxRoleToTheVehicle(Guid taxRoleId, Guid vehicleId, CancellationToken cancellationToken);
        Task AssignTaxRoleToTheRegion(Guid taxRoleId, Guid regionId, CancellationToken cancellationToken);
        Task CreaateNewRegion(CreateNewRegionDTO createNewRegionDTO, CancellationToken cancellationToken);
        Task<IEnumerable<RegionSelectedDto?>?> GetRegionByDynamicFilter(GetRegionByDynamicFilterDTO filter, CancellationToken cancellationToken);
        Task<List<TaxRoleSelectedDTO>> GetTaxRoleByDynamicFilter(GetTaxRoleByDynamicFilterDTO filter, CancellationToken cancellationToken);
        Task<TaxRoleSelectedDTO> CreateNewTaxRole(CreateNewTaxRoleDTO createNewTaxRoleDTO, CancellationToken cancellationToken);
    }
}