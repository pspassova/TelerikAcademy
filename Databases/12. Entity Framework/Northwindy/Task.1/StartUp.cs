using System;
using System.Linq;

namespace Task._1
{
    // Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database.
    // 
    // This should be in all of the projects' App.config files:
    // 
    //    <connectionStrings>
    //  <add name = "NorthwindEntities" connectionString="metadata=res://*/NorthwindEntities.csdl|res://*/NorthwindEntities.ssdl|res://*/NorthwindEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=Northwind;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    //</connectionStrings>

    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();

            // Test connection.
            Console.WriteLine(dbContext.Employees.Single(em => em.EmployeeID == 1).FirstName.ToString());
        }
    }
}