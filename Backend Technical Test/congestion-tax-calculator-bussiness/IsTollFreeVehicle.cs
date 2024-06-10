using congestion_tax_calculator_dataModel.Data;
using congestion_tax_calculator_dataModel.Models;
using congestion_tax_calculator_dataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace congestion_tax_calculator_bussiness
{
    public class IsTollFreeVehicle : IIsTollFreeVehicle
    {
        private readonly City _city;
        private readonly CongestionTaxCalContext _DbContext;
        private readonly Vehicle _vehicle;
        public IsTollFreeVehicle(City city, Vehicle vehicle, CongestionTaxCalContext DbContext)
        {
            _city = city;
            _vehicle = vehicle;
            _DbContext = DbContext;

        }
        public bool IsTollFreeVehicleFunc()
        {
            if (_vehicle == null) return false;

            IRepository<CityExceptionVehicle> r = new Repository<CityExceptionVehicle>(_DbContext);
            return r.GetAll().Where(c => c.CityFk == _city.IdCity && c.VehicleFk == _vehicle.IdVehicle).Count() > 0 ? true : false;
            //String vehicleType = vehicle.GetVehicleType();
            //return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Military.ToString());

        }

    }

}
