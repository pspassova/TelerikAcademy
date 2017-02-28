using Bytes2you.Validation;
using Northwind.Models;
using Northwind.Services.Contracts;
using Northwind.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericService<Employee> employeeService;

        public EmployeeController(IGenericService<Employee> employeeService)
        {
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();

            this.employeeService = employeeService;
        }

        public ActionResult All()
        {
            IEnumerable<EmployeeViewModel> employees = employeeService
                .GetAll()
                .AsQueryable()
                .Select(EmployeeViewModel.GetEmployee);

            return View(employees);
        }
    }
}