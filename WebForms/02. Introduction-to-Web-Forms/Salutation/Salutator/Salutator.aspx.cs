using System;

namespace Salutator
{
    public partial class Salutator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.SalutationLabel.Text = $"Hello, {this.NameTextBox.Text}!";
        }
    }
}