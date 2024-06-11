using System;
using System.Collections.Generic;
using System.Text;

namespace congestion_tax_calculator_bussiness
{
    public class IsDaysBefroeHoliday: IIsDaysBefroeHoliday
    {
        public DateTime _date;
        public DateTime _holidayDate;
        public IsDaysBefroeHoliday(DateTime date, DateTime holidayDate)
        {
           _date = date;
            _holidayDate = holidayDate;
        }

        public Boolean IsDaysBeforeHoliday()
        {
            try
            {
                for (DateTime date = _holidayDate.AddDays(-(int)_holidayDate.DayOfWeek); date <= _holidayDate; date = date.AddDays(1))

                {
                    if (date == _date)
                    {
                        return true;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }
    }
}
