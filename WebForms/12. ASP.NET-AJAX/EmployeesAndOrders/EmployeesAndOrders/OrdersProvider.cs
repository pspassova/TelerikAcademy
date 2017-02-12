using EmployeesAndOrders.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesAndOrders
{
    public class OrdersProvider
    {
        NorthwindEntities context = new NorthwindEntities();

        public IList<Order> SelectOrders()
        {
            return this.context.Orders.ToList();
        }
    }
}