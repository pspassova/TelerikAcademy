using Northwind.Models;
using Northwind.Services.Contracts;
using System.Collections.Generic;

namespace Northwind.Services
{
    public class OrderService : IGenericService<Order>
    {
        public IEnumerable<Order> GetAll()
        {
            return this.Context.Orders;
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
