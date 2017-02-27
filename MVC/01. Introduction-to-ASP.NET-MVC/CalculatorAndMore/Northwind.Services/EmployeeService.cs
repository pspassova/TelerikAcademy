using Northwind.Services.Contracts;
using System.Collections.Generic;
using Northwind.Models;

namespace Northwind.Services
{
    public class EmployeeService : IGenericService<Employee>
    {
        public IEnumerable<Employee> GetAll()
        {
            return this.Context.Employees;
        }

        public NorthwindEntities Context
        {
            get
            {
                return new NorthwindEntities();
            }
        }
    }
}
