using Northwind.Models;
using System;
using System.Linq.Expressions;

namespace Northwind.Web.Models
{
    public class EmployeeViewModel
    {
        public static Expression<Func<Employee, EmployeeViewModel>> GetEmployee
        {
            get
            {
                return employee => new EmployeeViewModel
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    City = employee.City,
                    Country = employee.Country,
                    TitleOfCourtesy = employee.TitleOfCourtesy,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate,
                    Address = employee.Address,
                    HomePhone = employee.HomePhone
                };
            }
        }

        public int EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Title { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string TitleOfCourtesy { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }

        public Nullable<DateTime> HireDate { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }
    }
}