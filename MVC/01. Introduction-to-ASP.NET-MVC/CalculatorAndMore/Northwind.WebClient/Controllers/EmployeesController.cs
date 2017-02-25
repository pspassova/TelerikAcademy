using Bytes2you.Validation;
using Northwind.Services.Contracts;
using Northwind.WebClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.WebClient.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
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