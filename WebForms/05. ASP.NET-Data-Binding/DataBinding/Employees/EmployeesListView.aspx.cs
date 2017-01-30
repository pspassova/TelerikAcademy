using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeesListView : Page
    {
        private NorthwindEntities context = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.EmployeesListview.DataSource = this.context.Employees.ToList();
            this.EmployeesListview.DataBind();
        }
    }
}