using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class City
    {
        public City()
        {
            CityDaysTaxNotCharged = new HashSet<CityDaysTaxNotCharged>();
            CityExceptionVehicle = new HashSet<CityExceptionVehicle>();
            CityHourTaxChargedAmount = new HashSet<CityHourTaxChargedAmount>();
            CityMonthNotCharged = new HashSet<CityMonthNotCharged>();
            CityOtherRule = new HashSet<CityOtherRule>();
            CityPublicHolidays = new HashSet<CityPublicHolidays>();
        }

        public int IdCity { get; set; }
        public int? CityCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<CityDaysTaxNotCharged> CityDaysTaxNotCharged { get; set; }
        public virtual ICollection<CityExceptionVehicle> CityExceptionVehicle { get; set; }
        public virtual ICollection<CityHourTaxChargedAmount> CityHourTaxChargedAmount { get; set; }
        public virtual ICollection<CityMonthNotCharged> CityMonthNotCharged { get; set; }
        public virtual ICollection<CityOtherRule> CityOtherRule { get; set; }
        public virtual ICollection<CityPublicHolidays> CityPublicHolidays { get; set; }
    }
}
