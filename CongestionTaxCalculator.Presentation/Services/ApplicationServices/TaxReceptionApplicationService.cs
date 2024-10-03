using CongestionTaxCalculator.Domain.Common.Exceptions;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.TaxRepositories;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.VehicleRepositories;
using CongestionTaxCalculator.Domain.DTO.Receiption;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using CongestionTaxCalculator.Domain.Entities.Receiption;
using CongestionTaxCalculator.Domain.FilterSpecifications.Tax;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle;

namespace CongestionTaxCalculator.Application.Services.ApplicationServices
{
    public class TaxReceptionApplicationService(ILicensePlateRepository licensePlateRepository,
        ITaxRepository taxRepository, ILawLimitationTaxReceiptsSterategyHandler lawLimitationTaxReceiptsSterategyHandler)
        : ITaxReceptionApplicationService, IScopedDependency
    {
        private readonly ILicensePlateRepository _licensePlateRepository = licensePlateRepository;
        private readonly ITaxRepository _taxRepository = taxRepository;
        private readonly ILawLimitationTaxReceiptsSterategyHandler _lawLimitationTaxReceiptsSterategyHandler = lawLimitationTaxReceiptsSterategyHandler;


        public async Task ReceiptTheTax(ReceiptTheTaxDTO receiptTheTaxDTO, CancellationToken cancellationToken)
        {
            //Find TaxRole
            var tacRole = await _taxRepository.FirstOrDefaultAsync
                (new GetTaxByDynamicFilterSpecification(new Domain.DTO.Tax.GetTaxRoleByDynamicFilterDTO
                {
                    TaxRoleId = receiptTheTaxDTO.TaxRoleId
                }, TaxRoleNavigationProperty.TaxRoleRegions, TaxRoleNavigationProperty.TaxScopes), cancellationToken) ??
                throw new NotFoundException();

            //Find licence plate
            var licencePlate = await _licensePlateRepository.FirstOrDefaultAsync
                (new GetLicensePlateByDynamicFilterSpecification(new GetLicensePlateByDynamicFilterDTO
                {
                    LicensePlateNumber = receiptTheTaxDTO.LicensePlateNumber
                }, LicensePlateNavigationProperty.TaxReceipts, LicensePlateNavigationProperty.Vehicle), cancellationToken) ??
                throw new NotFoundException();

            //Find station
            var taxStation = tacRole.TaxRoleRegions.Where(a => a.Region.TaxStations.Any(b => b.StationName == receiptTheTaxDTO.TaxStationName))
                .Select(s => s.Region.TaxStations.Where(c => c.StationName == receiptTheTaxDTO.TaxStationName).FirstOrDefault())
                .FirstOrDefault() ?? throw new NotFoundException();

            var (IsReceiptable, TaxScope) = _lawLimitationTaxReceiptsSterategyHandler
                .ShouldTaxBeReceiptable(tacRole.TaxScopes, [.. licencePlate.TaxReceipts], receiptTheTaxDTO);

            if (IsReceiptable && TaxScope != null)
            {
                var taxReceipt = licencePlate.ReceiptTheTax(taxStation, TaxScope, receiptTheTaxDTO.ArrivalDateTime);
                await _licensePlateRepository.UpdateAsync(licencePlate, cancellationToken);
            }
            else
            {
                throw new BadRequestException();
            }
        }
    }
}
