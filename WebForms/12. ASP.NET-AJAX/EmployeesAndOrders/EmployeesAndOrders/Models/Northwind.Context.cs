namespace EmployeesAndOrders.Models
{
    using System.Data.Entity;

    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities()
            : base("NorthwindEntities")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}