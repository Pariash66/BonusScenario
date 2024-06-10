using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class CityHourTaxChargedAmount
    {
        public int IdHourTaxCharged { get; set; }
        public TimeSpan? FromHour { get; set; }
        public int? CityFk { get; set; }
        public int? Amount { get; set; }
        public TimeSpan? ToHour { get; set; }

        public virtual City CityFkNavigation { get; set; }
    }
}
