using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class CityPublicHolidays
    {
        public int IdCityPublicHolidays { get; set; }
        public int? CityFk { get; set; }
        public DateTime? Holiday { get; set; }

        public virtual City CityFkNavigation { get; set; }
    }
}
