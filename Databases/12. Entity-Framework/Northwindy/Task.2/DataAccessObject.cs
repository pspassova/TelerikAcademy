using System;
using System.Linq;
using System.Data.Entity.Migrations;
using Task._1;

namespace Task._2
{
    // Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.    
    internal class DataAccessObject
    {
        internal static void InsertCustomer(NorthwindEntities dbContext, Customer customer)
        {
            if (CheckIfCustomerAlreadyExists(dbContext, customer))
            {
                Console.WriteLine("Customer you're trying to insert already exists!");
                return;
            }

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            // I'm using the CompanyName, because it's not nullable.
            var company = customer.CompanyName;
            Console.WriteLine($"Customer from {company} is successfully added!");
        }

        internal static void ModifyCustomer(NorthwindEntities dbContext, Customer customer)
        {
            if (!CheckIfCustomerAlreadyExists(dbContext, customer))
            {
                Console.WriteLine("Customer you're trying to modify does not exist!");
                return;
            }

            dbContext.Customers.AddOrUpdate(customer);
            dbContext.SaveChanges();

            var company = customer.CompanyName;
            Console.WriteLine($"Customer from {company} was successfully modified!");
        }

        internal static void DeleteCustomer(NorthwindEntities dbContext, Customer customer)
        {
            if (!CheckIfCustomerAlreadyExists(dbContext,customer))
            {
                Console.WriteLine("Customer you're trying to delete does not exist!");
                return;
            }

            var company = customer.CompanyName;

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();

            Console.WriteLine($"Customer from {company} was successfully deleted!");
        }

        private static bool CheckIfCustomerAlreadyExists(NorthwindEntities dbContext, Customer customer)
        {
            return dbContext.Customers.Any(c => c.CustomerID == customer.CustomerID);
        }
    }
}
