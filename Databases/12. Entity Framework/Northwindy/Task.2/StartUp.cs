using System.Linq;
using Task1;

namespace Task._2
{
    // Write a testing class.
    // Check NorthwindDB for results.
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();
            var customer = new Customer
            {
                CustomerID = "2",
                CompanyName = "Bon app'",
                ContactTitle = "Philipe Cramero",
                Address = "Streto fo'Testo",
                City = "Versailles",
                Region = "LA",
                PostalCode = null,
                Country = "Mexico",
                Phone = "(100) 555-3612",
                Fax = null,
                CityId = 1
            };
            var modifiedCustomer = new Customer
            {
                CustomerID = "2",
                CompanyName = "CompanyName CHANGED",
                ContactTitle = "Philipe Cramero",
                Address = "Streto fo'Testo",
                City = "Versailles",
                Region = "LA",
                PostalCode = null,
                Country = "Mexico",
                Phone = "(100) 555-3612",
                Fax = null,
                CityId = 1
            };

            DataAccessObject.InsertCustomer(dbContext, customer);
            DataAccessObject.ModifyCustomer(dbContext, modifiedCustomer);
            DataAccessObject.DeleteCustomer(dbContext, dbContext.Customers.Single(c => c.CustomerID == "2"));
        }
    }
}
