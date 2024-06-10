using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class CityMonthNotCharged
    {
        public int IdCityMonthTaxNotCharged { get; set; }
        public int? Fkcity { get; set; }
        public byte? MonthTaxNotCharged { get; set; }

        public virtual City FkcityNavigation { get; set; }
    }
}
