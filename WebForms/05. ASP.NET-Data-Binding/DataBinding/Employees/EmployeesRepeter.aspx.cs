using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeesRepeter : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                NorthwindEntities context = new NorthwindEntities();

                this.RepeaterEmployees.DataSource = context.Employees.ToList();
                this.RepeaterEmployees.DataBind();
            }
        }
    }
}