using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeesFormView : Page
    {
        private NorthwindEntities context = new NorthwindEntities();
        private IList<Employee> employees;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                employees = context.Employees.ToList();

                this.EmployeesGridview.DataSource = employees;
                this.DataBind();
            }
        }

        protected void EmployeesGridview_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int employeeId = int.Parse(this.EmployeesGridview.SelectedRow.Cells[0].Text);
            var employee = this.context.Employees.Find(employeeId);

            this.EmployeesFormview.DataSource = new List<Employee>() { employee };
            this.EmployeesFormview.DataBind();
        }
    }
}