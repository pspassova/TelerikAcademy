using System;
using Task1;

namespace Task._6
{
    // Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
    // Find for the API for schema generation in MSDN or in Google.
    // 
    // New connection string this time!
    // 
    //    <connectionStrings>
    //  <add name = "NorthwindEntities" connectionString="metadata=res://*/NorthwindModel.csdl|res://*/NorthwindModel.ssdl|res://*/NorthwindModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=NorthwindTwin;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    // </connectionStrings>
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new NorthwindEntities();

            dbContext.Database.CreateIfNotExists();
            Console.WriteLine("Refresh SSMS and check for a NorthwindTwin DB :)");
        }
    }
}
