using CongestionTaxCalculator.Domain.Common.Exceptions;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.RegionRepositories;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.TaxRepositories;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.VehicleRepositories;
using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.DTO.Tax;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Domain.Entities.Tax;
using CongestionTaxCalculator.Domain.FilterSpecifications.Region;
using CongestionTaxCalculator.Domain.FilterSpecifications.Tax;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle;

namespace CongestionTaxCalculator.Domain.Services.TaxDomainServices
{
    public class TaxDomainService(ITaxRepository taxRepository,
        IRegionRepository regionRepository, IVehicleRepository vehicleRepository) : ITaxDomainService, IScopedDependency
    {
        private readonly ITaxRepository _taxRepository = taxRepository;
        private readonly IRegionRepository _regionRepository = regionRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        public async Task<IEnumerable<RegionSelectedDto?>?> GetRegionByDynamicFilter(GetRegionByDynamicFilterDTO filter, CancellationToken cancellationToken)
        {
            var result = await _regionRepository.ListAsync
                (new GetRegionByDanamicFilterSpecification(filter), cancellationToken);

            if (result == null || result.Count == 0) return null;

            return result.Select(s => s.Clone(filter.CustomDateFormat) as RegionSelectedDto);
        }
        public async Task<List<TaxRoleSelectedDTO>> GetTaxRoleByDynamicFilter(GetTaxRoleByDynamicFilterDTO filter, CancellationToken cancellationToken)
        {
            var result = await _taxRepository.ListAsync
                (new GetTaxByDynamicFilterSpecification(filter,
                TaxRoleNavigationProperty.TaxRoleRegions), cancellationToken);

            return result.Select(s => s.Clone() as TaxRoleSelectedDTO).ToList();
        }

        public async Task<TaxRoleSelectedDTO> CreateNewTaxRole(CreateNewTaxRoleDTO createNewTaxRoleDTO, CancellationToken cancellationToken)
        {
            var newTaxRole = new TaxRole(createNewTaxRoleDTO.TaxOn,
                            createNewTaxRoleDTO.TaxDescription,
                            createNewTaxRoleDTO.MinimumAmount,
                            createNewTaxRoleDTO.MaximumAmount);

            var result = await _taxRepository.AddAsync(newTaxRole, cancellationToken);

            return new TaxRoleSelectedDTO 
            {
                TaxOn = result.TaxOn,
                MinimumAmount = result.MinimumAmount,
                MaximumAmount = result.MaximumAmount,
                TaxDescription = result.TaxDescription,

                RegionsIncludingTheTaxRole = result.TaxRoleRegions.Where(c => c != null)
                .Select(s => s.Region.Clone() as RegionSelectedDto).ToList() ?? null
            };
        }

        public async Task AssignTaxRoleToTheRegion(Guid taxRoleId, Guid regionId, CancellationToken cancellationToken)
        {
            var taxRole =  await _taxRepository.FirstOrDefaultAsync
                (new GetTaxByDynamicFilterSpecification(new GetTaxRoleByDynamicFilterDTO
                {
                    TaxRoleId = taxRoleId
                }, TaxRoleNavigationProperty.TaxRoleRegions), cancellationToken) 
                ?? throw new NotFoundException();

            var region = await _regionRepository.FirstOrDefaultAsync
             (new GetRegionByDanamicFilterSpecification(new GetRegionByDynamicFilterDTO
             {
                 RegionId = regionId,
             }), cancellationToken) ?? throw new NotFoundException();

            taxRole.AssignTaxRoleToNewRegion(region);
            await _taxRepository.UpdateAsync(taxRole, cancellationToken);
        }

        public async Task AssignTaxRoleToTheVehicle(Guid taxRoleId, Guid vehicleId, CancellationToken cancellationToken)
        {
            var taxRole = await _taxRepository.FirstOrDefaultAsync
                (new GetTaxByDynamicFilterSpecification(new GetTaxRoleByDynamicFilterDTO
                {
                    TaxRoleId = taxRoleId
                }, TaxRoleNavigationProperty.TaxRoleRegions), cancellationToken)
                ?? throw new NotFoundException();

            var vehicle = await _vehicleRepository.FirstOrDefaultAsync
             (new GetVehiclesByDynamicFilterSpecification(new GetVehiclesByDynamicFilterDTO
             {
                 VehicleId = vehicleId,
             }), cancellationToken) ?? throw new NotFoundException();

            taxRole.AssignTaxRoleToNewVehicle(vehicle);
            await _taxRepository.UpdateAsync(taxRole, cancellationToken);
        }

        public async Task CreaateNewRegion(CreateNewRegionDTO createNewRegionDTO, CancellationToken cancellationToken)
        {
            var region = new Region(createNewRegionDTO.RegionName);
            await _regionRepository.AddAsync(region, cancellationToken);
        }
    }
}
