using System;
using System.Linq;
using Task._1;

namespace Task._8
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();
            var employeeTerritories = dbContext.Employees.Single(e => e.EmployeeID == 1).Territories.ToArray();

            Console.WriteLine("First employee's territories:\n");

            foreach (var territory in employeeTerritories)
            {
                Console.WriteLine($"Desctiption: {territory.TerritoryDescription}");
            }
        }
    }
}
