using System;
using System.Collections.Generic;
using System.Web.UI;

namespace StateManagement
{
    public partial class DeletingViewState : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ViewState["values"] == null)
            {
                this.ViewState.Add("values", new List<string>());
            }
        }

        protected void ViewStateWriteButton_Click(object sender, EventArgs e)
        {
            IList<string> viewStateValues = ViewState["values"] as IList<string>;

            viewStateValues.Add(this.ViewStateWriteTextBox.Text);
            this.ViewStateResultLabel.Text = $"ViewState values: {string.Join(", ", viewStateValues)}";
            this.ViewStateWriteTextBox.Text = string.Empty;
        }
    }
}