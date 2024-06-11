using congestion_tax_calculator_dataModel.Data;
using congestion_tax_calculator_dataModel.Models;
using congestion_tax_calculator_dataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static congestion_tax_calculator_dataModel.Constant.VehicleType;
using static congestion_tax_calculator_dataModel.Constant.Months;

namespace congestion_tax_calculator_bussiness
{
    public class IsTollFreeDate : IIsTollFreeDate
    {
        private readonly CongestionTaxCalContext _DbContext;
        private readonly DateTime _date;
        private readonly City _city;

        public IsTollFreeDate(DateTime date, CongestionTaxCalContext taxContext, City city)
        {
            _date = date;
            _DbContext = taxContext;
            _city = city;

        }
        public bool isTollFreeDatefunc()
        {
            try
            {
                int year = _date.Year;
                int month = _date.Month;
                int day = _date.Day;
                Boolean istollfree = false;
                Repository<CityDaysTaxNotCharged> dayNotCharged = new Repository<CityDaysTaxNotCharged>(_DbContext);

                List<byte?> days = dayNotCharged.GetAll().Where(c => c.Fkcity == _city.IdCity).Select(c => c.DayInAweek).ToList();
                istollfree = days.Contains((byte?)_date.DayOfWeek) ? true : false;
                if (istollfree)
                    return true;
                //  if (_date.DayOfWeek == DayOfWeek.Saturday || _date.DayOfWeek == DayOfWeek.Sunday) return true;

                Repository<CityPublicHolidays> HolidaysNotCharged = new Repository<CityPublicHolidays>(_DbContext);
                List<DateTime?> holidays = HolidaysNotCharged.GetAll().Where(c => c.CityFk == _city.IdCity).Select(c => c.Holiday).ToList();
                bool findDate = false;
                bool daysbeforHoliday = false;
                foreach (DateTime holiday in holidays)
                {
                    findDate = year == holiday.Year && month == holiday.Month && day == holiday.Day || holiday.Month == (int)months.Jul ? true : false;
                    if (findDate == true)
                        return true;
                    IsDaysBefroeHoliday isDaysBefroeHoliday = new IsDaysBefroeHoliday(_date, holiday);
                    daysbeforHoliday = isDaysBefroeHoliday.IsDaysBeforeHoliday();
                    if (daysbeforHoliday) return true;
                }
                //if (year == 2013)
                //{
                //    if (month == 1 && day == 1 ||
                //        month == 3 && (day == 28 || day == 29) ||
                //        month == 4 && (day == 1 || day == 30) ||
                //        month == 5 && (day == 1 || day == 8 || day == 9) ||
                //        month == 6 && (day == 5 || day == 6 || day == 21) ||
                //        month == 7 ||
                //        month == 11 && day == 1 ||
                //        month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                //    {
                //        return true;
                //    }
                //}
                return istollfree;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
    //private Boolean IsTollFreeDate(DateTime date)
    //{
    //    int year = date.Year;
    //    int month = date.Month;
    //    int day = date.Day;

    //    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

    //    if (year == 2013)
    //    {
    //        if (month == 1 && day == 1 ||
    //            month == 3 && (day == 28 || day == 29) ||
    //            month == 4 && (day == 1 || day == 30) ||
    //            month == 5 && (day == 1 || day == 8 || day == 9) ||
    //            month == 6 && (day == 5 || day == 6 || day == 21) ||
    //            month == 7 ||
    //            month == 11 && day == 1 ||
    //            month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}
