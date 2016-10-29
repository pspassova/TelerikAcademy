using System;
using System.Linq;
using Task._1;

namespace Task._5
{
    // Write a method that finds all the sales by specified region and period (start / end dates).
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();
            string region = "ID";
            DateTime startDate = new DateTime(1995, 3, 12);
            DateTime endDate = new DateTime(2016, 10, 29);

            ListSalesByRegionAndPeriod(dbContext, region, startDate, endDate);
        }

        private static void ListSalesByRegionAndPeriod(NorthwindEntities dbContext, string region, DateTime startDate, DateTime endDate)
        {
            var salesInRange = dbContext.Orders.Where(o => o.ShipRegion == region && o.ShippedDate > startDate && o.ShippedDate < endDate).Select(s => new
            {
                s.ShipAddress,
                s.ShipCountry
            }).ToList();

            Console.WriteLine($"Sales from {region} region in range {startDate}-{endDate}:\n\n{string.Join("\n", salesInRange)}");
        }
    }
}
