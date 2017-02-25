using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}
