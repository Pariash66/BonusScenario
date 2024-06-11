using congestion_tax_calculator_bussiness;
using congestion_tax_calculator_dataModel;
using congestion_tax_calculator_dataModel.Data;
using congestion_tax_calculator_dataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace congestion_tax_calculator_service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("in city Gothenburg and vehicle type car with the datetime below :" +
               " \"2013-01-14 21:00:00\"\r\n\r\n\"2013-01-15 21:00:00\"\r\n\r\n\"2013-02-07 06:23:27\"\r\n\r\n\"2013-02-07 15:27:00\"\r\n\r\n\"2013-02-08 06:27:00\"\r\n\r\n\"2013-02-08 06:20:27\"\r\n\r\n\"2013-02-08 14:35:00\"\r\n\r\n\"2013-02-08 15:29:00\"\r\n\r\n\"2013-02-08 15:47:00\"\r\n\r\n\"2013-02-08 16:01:00\"\r\n\r\n\"2013-02-08 16:48:00\"\r\n\r\n\"2013-02-08 17:49:00\"\r\n\r\n\"2013-02-08 18:29:00\"\r\n\r\n\"2013-02-08 18:35:00\"\r\n\r\n\"2013-03-26 14:25:00\"\r\n\r\n\"2013-03-28 14:07:27\"");


            var options = new DbContextOptionsBuilder<CongestionTaxCalContext>()
              .UseSqlServer("Server=DESKTOP-IKJUHBV;Database=CongestionTaxCal;TrustServerCertificate=True;Trusted_Connection=True")
              .Options;

            using (var context = new CongestionTaxCalContext(options))
            {
                Vehicle vehicle = new Vehicle();
                Repository<Vehicle> veh = new Repository<Vehicle>(context);
                vehicle=veh.GetById(1);
                DateTime[] dates = { new DateTime(2013, 01, 14,21,0,0), new DateTime(2013, 01, 15,21,0,0),
                new DateTime(2013, 02, 07,06,23,27),new DateTime(2013, 02, 07,15,27,0), new DateTime(2013, 02, 08,06,27,0)
                ,new DateTime(2013, 02, 08,06,20,27),new DateTime(2013, 02, 08,14,35,0), new DateTime(2013, 02, 08,15,29,0)
                , new DateTime(2013, 02, 08,15,47,0),new DateTime(2013, 02, 08,16,01,0),new DateTime(2013, 02, 08,16,48,0)
                ,new DateTime(2013, 02, 08,17,49,0),new DateTime(2013, 02, 08,18,29,0),new DateTime(2013, 02, 08,18,35,0)
                ,new DateTime(2013, 03, 26,14,25,0),new DateTime(2013, 03, 28,14,07,27)};
                City city = new City();
                Repository<City> cit = new Repository<City>(context);
                city = cit.GetById(1);
                // Create an instance of the TaxCalculation class by passing in the dependencies
                TaxCalculation taxCalculation = new TaxCalculation(vehicle, dates, city, context);

                // Call the GetTax() function and store the result
                int tax = taxCalculation.GetTax();

                // Display the calculated tax
                Console.WriteLine($"The calculated tax is: {tax}");
            }
        }
    }
}
