using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeesRepeter : Page
    {
        private NorthwindEntities context = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.RepeaterEmployees.DataSource = this.context.Employees.ToList();
                this.RepeaterEmployees.DataBind();
            }
        }
    }
}