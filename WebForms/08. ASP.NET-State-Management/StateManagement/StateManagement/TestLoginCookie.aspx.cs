using System;
using System.Web.UI;

namespace StateManagement
{
    public partial class TestLoginCookie : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Cookies["username"] == null)
            {
                this.Response.Redirect("LoginCookie.aspx");
            }

            this.LoggedInLabel.Text = "You are logged in, therefore you can be in this page.";
        }
    }
}