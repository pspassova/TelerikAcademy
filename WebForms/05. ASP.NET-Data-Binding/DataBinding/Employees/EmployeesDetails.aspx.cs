﻿using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Employees
{
    public partial class EmployeesDetails : Page
    {
        private const string EmployeesUrl = "Employees.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeId;
            if (!int.TryParse(this.Request.Params["id"], out employeeId))
            {
                this.Response.Redirect(EmployeesUrl);
            }

            NorthwindEntities context = new NorthwindEntities();
            Employee employee = context.Employees.Find(employeeId);
            if (employee == null)
            {
                this.Response.Redirect(EmployeesUrl);
            }

            this.EmployeesDetailsView.DataSource = new List<Employee>() { employee };
            this.EmployeesDetailsView.DataBind();
        }

        protected void ButtonBack_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect(EmployeesUrl);
        }
    }
}