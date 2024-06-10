using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class CityDaysTaxNotCharged
    {
        public int IdCityDaysTaxNotCharged { get; set; }
        public int? Fkcity { get; set; }
        public byte? DayInAweek { get; set; }

        public virtual City FkcityNavigation { get; set; }
    }
}
