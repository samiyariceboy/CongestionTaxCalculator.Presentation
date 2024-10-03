using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DTO.Receiption;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Domain.Entities.Tax;

namespace CongestionTaxCalculator.Domain.Entities.Receiption.Sterategies
{
    //A single charge rule
    public class StationLimitBasedOnTimeTaxLawLimitationSterategy : ILawLimitationTaxReceipts, IScopedDependency
    {

        //A single charge rule

        /*Because to fully implement the concept of the station
         Different tax scopes should be registered for each station and 
         it should be determined how much the distance between each station is and whether 
         it is possible to travel at least two stations with the permitted speed in one hour.

         I settled for the minimal implementation part and the complexity for station,
         speed and distance between each station was not implemented*/

        public (bool IsReceiptable, TaxScope? TaxScope) ShouldTaxBeReceiptable(IEnumerable<TaxScope> taxScopes,
            IEnumerable<TaxReceipt> TaxsReceipted, TaxStation taxStation, ReceiptTheTaxDTO newTaxReceiption)
        {
            var arrivalTimeSpan = newTaxReceiption.ArrivalDateTime.TimeOfDay;
            var newTaxScopes = taxScopes.OrderBy(o => o.FromTime).ThenBy(o => o.ToTime).ToList();

            var acceptedTaxScope = newTaxScopes.Where(c => arrivalTimeSpan > c.FromTime &&
                 arrivalTimeSpan < c.ToTime).FirstOrDefault();

            var lastReceiptedTheTax = TaxsReceipted.LastOrDefault();

            if (TaxsReceipted.Any() && lastReceiptedTheTax != null &&
                TaxsReceipted.All(a => a.TaxStation.Region.RegionName == taxStation.Region.RegionName) &&
                lastReceiptedTheTax.ReceiptTime.Date == newTaxReceiption.ArrivalDateTime.Date &&
                (arrivalTimeSpan - lastReceiptedTheTax.ReceiptTime.TimeOfDay).TotalMinutes <= 60
            )
            {
                return (false, null);
            }


            return (true, acceptedTaxScope);
        }
    }
}
