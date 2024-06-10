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
            Console.WriteLine("Hello World!");
            var options = new DbContextOptionsBuilder<CongestionTaxCalContext>()
              .UseSqlServer("Server=DESKTOP-IKJUHBV;Database=CongestionTaxCal;TrustServerCertificate=True;Trusted_Connection=True")
              .Options;

            using (var context = new CongestionTaxCalContext(options))
            {
                Vehicle vehicle = new Vehicle();
                Repository<Vehicle> veh = new Repository<Vehicle>(context);
                vehicle=veh.GetById(1);
                DateTime[] dates = { new DateTime(2023, 10, 15), new DateTime(2023, 10, 16) };
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
