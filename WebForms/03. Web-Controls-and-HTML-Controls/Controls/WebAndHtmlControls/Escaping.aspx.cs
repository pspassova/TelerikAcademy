using System;

namespace WebAndHtmlControls
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisplayText_Click(object sender, EventArgs e)
        {
            string escapedText = Server.HtmlEncode(this.TextBox.Text);

            this.ResultLabel.Text = escapedText;
            this.ResultTextBox.Text = escapedText;
        }
    }
}