using Northwind.Models;
using System;
using System.Linq.Expressions;

namespace Northwind.Web.Models
{
    public class OrderViewModel
    {
        public static Expression<Func<Order, OrderViewModel>> GetOrder
        {
            get
            {
                return order => new OrderViewModel
                {
                    EmployeeFirstName = order.Employee.FirstName,
                    EmployeeLastName = order.Employee.LastName,
                    ShipCity = order.ShipCity,
                    ShipCountry = order.ShipCountry,
                    OrderDate = order.OrderDate.ToString()
                };
            }
        }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string OrderDate { get; set; }
    }
}