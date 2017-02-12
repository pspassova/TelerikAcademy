using EmployeesAndOrders.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesAndOrders
{
    public class EmployeesProvider
    {
        NorthwindEntities context = new NorthwindEntities();

        public IList<Employee> SelectEmployees()
        {
            return this.context.Employees.ToList();
        }
    }
}