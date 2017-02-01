using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeesListView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();

            this.EmployeesListview.DataSource = context.Employees.ToList();
            this.EmployeesListview.DataBind();
        }
    }
}