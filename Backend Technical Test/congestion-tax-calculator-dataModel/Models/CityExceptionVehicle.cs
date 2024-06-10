using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class CityExceptionVehicle
    {
        public int IdCityExceptVehicle { get; set; }
        public int? CityFk { get; set; }
        public int? VehicleFk { get; set; }

        public virtual City CityFkNavigation { get; set; }
        public virtual Vehicle VehicleFkNavigation { get; set; }
    }
}
