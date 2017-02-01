using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class Employees : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                NorthwindEntities context = new NorthwindEntities();
                IList<Employee> employees = context.Employees.ToList();

                this.EmployeesGridview.DataSource = employees;
                this.EmployeesGridview.DataBind();
            }
        }
    }
}