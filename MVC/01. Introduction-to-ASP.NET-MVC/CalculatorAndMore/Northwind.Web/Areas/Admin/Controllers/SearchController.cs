using Bytes2you.Validation;
using Northwind.Models;
using Northwind.Services.Contracts;
using Northwind.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.Web.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        private readonly IGenericService<Employee> employeeService;

        public SearchController(IGenericService<Employee> employeeService)
        {
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();

            this.employeeService = employeeService;
        }

        public ActionResult SearchForAddresses(string query)
        {
            IEnumerable<EmployeeViewModel> addresses = this.employeeService
                .GetAll()
                .AsQueryable()
                .Where(employee => employee.FirstName.ToLower().Contains(query.ToLower()) || employee.LastName.ToLower().Contains(query.ToLower()))
                .Select(EmployeeViewModel.GetEmployee);

            return this.PartialView("_AdditionalDetails", addresses);
        }

        public ActionResult AllEmployeesNames()
        {
            IEnumerable<EmployeeViewModel> employees = this.employeeService
                .GetAll()
                .AsQueryable()
                .Select(EmployeeViewModel.GetEmployee);

            return this.View(employees);
        }
    }
}