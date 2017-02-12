using EmployeesAndOrders.Models;
using System;
using System.Linq;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesAndOrders
{
    public partial class EmployeesAndOrders : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmployeesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);

            GridView grid = sender as GridView;
            int selectedEmployeeId = Convert.ToInt32(grid.SelectedValue);

            NorthwindEntities context = new NorthwindEntities();
            this.OrdersGridView.DataSource = context.Orders.Where(emp => emp.EmployeeID == selectedEmployeeId).ToList();
            this.OrdersGridView.DataBind();
        }
    }
}