using System;
using System.Reflection;

namespace Salutator
{
    public partial class Salutator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.SalutationLabel.Text = $"Hello, { this.NameTextBox.Text }!";
            this.HelloFromTheCsharpCodeLabel.Text = $"This is the cs code talking.\r\n Current assembly: { Assembly.GetExecutingAssembly().Location}.";
        }
    }
}