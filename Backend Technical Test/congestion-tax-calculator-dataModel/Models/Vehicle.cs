using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            CityExceptionVehicle = new HashSet<CityExceptionVehicle>();
        }

        public int IdVehicle { get; set; }
        public int VehicleCode { get; set; }
        public string VehicleName { get; set; }

        public virtual ICollection<CityExceptionVehicle> CityExceptionVehicle { get; set; }
    }
}
