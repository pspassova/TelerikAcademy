using Northwind.Services.Contracts;
using System.Collections.Generic;
using Northwind.Models;

namespace Northwind.Services
{
    public class EmployeeService : IEmployeeService
    {
        private NorthwindEntities context = new NorthwindEntities();

        public IEnumerable<Employee> GetAll()
        {
            return this.context.Employees;
        }
    }
}
