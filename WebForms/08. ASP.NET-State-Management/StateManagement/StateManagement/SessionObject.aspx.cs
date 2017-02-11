using System;
using System.Collections.Generic;
using System.Web.UI;

namespace StateManagement
{
    public partial class SessionObject : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["values"] == null)
            {
                this.Session.Add("values", new List<string>());
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            IList<string> sessionValues = this.Session["values"] as IList<string>;

            sessionValues.Add(this.InputTextBox.Text);
            this.ResutLabel.Text = string.Join(", ", sessionValues);
            this.InputTextBox.Text = string.Empty;
        }
    }
}