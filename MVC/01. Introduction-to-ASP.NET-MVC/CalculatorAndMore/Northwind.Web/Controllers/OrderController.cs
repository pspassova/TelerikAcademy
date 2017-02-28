using Bytes2you.Validation;
using Northwind.Models;
using Northwind.Services.Contracts;
using Northwind.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericService<Order> orderService;

        public OrderController(IGenericService<Order> orderService)
        {
            Guard.WhenArgument(orderService, "orderService").IsNull().Throw();

            this.orderService = orderService;
        }

        public ActionResult AllChronologicallyArranged()
        {
            IEnumerable<OrderViewModel> arrangedOrders = orderService
                .GetAll()
                .AsQueryable()
                .OrderByDescending(order => order.OrderDate)
                .Select(OrderViewModel.GetOrder);

            return View(arrangedOrders);
        }
    }
}