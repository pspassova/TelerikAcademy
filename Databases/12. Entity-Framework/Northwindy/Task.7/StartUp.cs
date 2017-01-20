using System;
using System.Linq;
using Task._1;

namespace Task._7
{
    // Try to open two different data contexts and perform concurrent changes on the same records.
    // What will happen at SaveChanges()?
    // How to deal with it?
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();
            var dbContextSec = new NorthwindEntities();

            var originalCustomer = dbContext.Customers.Single(c => c.CustomerID == "BOLID").ContactName;
            Console.WriteLine($"Original customer's contact name: {originalCustomer}.");

            var changedCustomerName = dbContext.Customers.Single(c => c.CustomerID == "BOLID").ContactName;
            changedCustomerName = "Changed";
            Console.WriteLine($"Changed customer's contact name: {changedCustomerName}.");

            var changedCustomerNameSec = dbContextSec.Customers.Single(c => c.CustomerID == "BOLID").ContactName;
            Console.WriteLine($"Second change of customer's contact name: {changedCustomerNameSec}.");

            dbContext.SaveChanges();
            dbContextSec.SaveChanges();
            Console.WriteLine("\nSaving changes...\n");

            // Seems like only the last "SaveChanges()" command matters. :)
            var customerNameAfter = dbContext.Customers.Single(c => c.CustomerID == "BOLID").ContactName;
            Console.WriteLine($"Name after we've saved changes (first context): {customerNameAfter}.");

            var customerNameAfterSec = dbContextSec.Customers.Single(c => c.CustomerID == "BOLID").ContactName;
            Console.WriteLine($"Name after we've saved changes (second context): {customerNameAfterSec}.");
        }
    }
}
