using System;
using System.Linq;
using Task1;

namespace Task._3_4
{
    // Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
    // Implement previous by using native SQL query and executing it through the DbContext.
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();
            int orderYear = 1997;
            string orderCountry = "Canada";

            ListCustomersWhoHaveMadeCertainOrders(dbContext,orderYear,orderCountry);
            ListCustomersWhoHaveMadeCertainOrdersSqlQuery(dbContext, orderYear, orderCountry);
        }

        private static void ListCustomersWhoHaveMadeCertainOrders(NorthwindEntities dbContext, int orderYear, string orderCountry)
        {
            var customers = dbContext
                .Orders
                .Where(o => o.OrderDate.Value.Year == orderYear && o.ShipCountry == orderCountry)
                //.Select(o => o.Customer.ContactName.Length > 0 ? o.Customer.ContactName : o.Customer.CompanyName)
                .Select(o => o.Customer.CompanyName)
                .ToArray();

            Console.WriteLine("-----LINQ------");
            Console.WriteLine($"Company names of customers who have orders made in {orderYear} and shipped to {orderCountry}:\n\n{string.Join("\n", customers)}\n\n");
        }

        private static void ListCustomersWhoHaveMadeCertainOrdersSqlQuery(NorthwindEntities dbContext, int orderYear, string orderCountry)
        {
            var query = $@"SELECT c.CompanyName
                          FROM Customers c
                          JOIN Orders o
                          ON o.CustomerID = c.CustomerID
                          WHERE DATEPART(YEAR, o.ShippedDate) = {orderYear}
                          AND o.ShipCountry = '{orderCountry}'";

            var customers = dbContext.Database.SqlQuery<string>(query).ToList();

            Console.WriteLine("-----SQL------");
            Console.WriteLine($"Company names of customers who have orders made in {orderYear} and shipped to {orderCountry}:\n\n{string.Join("\n", customers)}");
        }
    }
}
