using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class Employees : Page
    {
        private NorthwindEntities context = new NorthwindEntities();
        private IList<Employee> employees;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.employees = context.Employees.ToList();

                this.EmployeesGridview.DataSource = employees;
                this.EmployeesGridview.DataBind();
            }
        }
    }
}