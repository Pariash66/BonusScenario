using congestion_tax_calculator_dataModel.Data;
using congestion_tax_calculator_dataModel.Models;
using congestion_tax_calculator_dataModel;
using System;
using System.Collections.Generic;
using System.Text;
using static congestion_tax_calculator_bussiness.TaxCalculation;

namespace congestion_tax_calculator_bussiness
{

    public class GetTollFee : IGetTollFee
    {
        private readonly City _city;
        private readonly CongestionTaxCalContext _Context;
        private readonly Vehicle _vehicle;
        private readonly DateTime _datetime;
        public GetTollFee(City city, CongestionTaxCalContext context, Vehicle vehicle, DateTime datetime)
        {
            _city = city;
            _Context = context;
            _vehicle = vehicle;
            _datetime = datetime;
        }

        public int IsTollFeeFunc()
        {
            try
            {
                IsTollFreeDate freeDate = new IsTollFreeDate(_datetime, _Context, _city);
                IsTollFreeVehicle freeVehice = new IsTollFreeVehicle(_city, _vehicle, _Context);
                if (freeDate.isTollFreeDatefunc() || freeVehice.IsTollFreeVehicleFunc()) return 0;

                int hour = _datetime.Hour;
                int minute = _datetime.Minute;
                int? amount = 0;

                Repository<CityHourTaxChargedAmount> HourTaxCharged = new Repository<CityHourTaxChargedAmount>(_Context);

                HourTaxCharged.GetAll().ForEach(h =>
                {
                    amount += _datetime.TimeOfDay >= h.FromHour && _datetime.TimeOfDay <= h.ToHour ? h.Amount : 0;
                    
                });
                return Convert.ToInt32(amount);
            }
            catch(Exception ex)
            {
                throw;
            }
            //if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            //else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            //else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
            //else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
            //else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
            //else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
            //else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
            //else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
            //else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
            //else return 0;
        }
    }




}
