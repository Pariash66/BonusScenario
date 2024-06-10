using congestion_tax_calculator_dataModel;
using congestion_tax_calculator_dataModel.Data;
using congestion_tax_calculator_dataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static congestion_tax_calculator_dataModel.Constant.OtherRules;

namespace congestion_tax_calculator_bussiness
{
    public class TaxCalculation: ITaxCalculation
    {
        private Vehicle _Vehicle;
        private DateTime[] _Date;
        private City _City;
        public CongestionTaxCalContext _DbContext;

        public TaxCalculation(Vehicle vehicle, DateTime[] dates, City city, CongestionTaxCalContext context)
        {
            _Vehicle = vehicle;
            _Date = dates;
            _City = city;
            _DbContext = context;

        }
        public int GetTax()
        {
            DateTime intervalStart = _Date[0];
            int totalFee = 0;
            int tempFee = 0;
            Repository<CityOtherRule> cityotherRule = new Repository<CityOtherRule>(_DbContext);
            List<CityOtherRule> rules = cityotherRule.GetAll().Where(c => c.CityFk == _City.IdCity).ToList();
            int singleCharge = (int)rules.Where(c => c.RuleCode == (int)otherRules.SingleChargeDuration).FirstOrDefault().Amount;
            int MaxCharge = (int)rules.Where(c => c.RuleCode == (int)otherRules.MaxTaxPerDay).FirstOrDefault().Amount;
            foreach (DateTime date in _Date)
            {
                //int nextFee = GetTollFee(date, vehicle);
                GetTollFee getTollFee = new GetTollFee(_City, _DbContext, _Vehicle, date);

                TimeSpan diffInMillies = date - intervalStart;
                double minutes = diffInMillies.TotalMinutes;

                if (minutes <= singleCharge)
                {
                    int Fee = getTollFee.IsTollFeeFunc();
                    tempFee = Math.Max(Fee, tempFee);
                }
                else
                {

                    intervalStart = date;

                    totalFee += tempFee;
                    tempFee = 0;
                }
            }
            totalFee += tempFee;

            return Math.Max(totalFee, MaxCharge); ;
        }

       
       


      
      
    }
}
