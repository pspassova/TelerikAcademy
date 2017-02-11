using System;
using System.Web;
using System.Web.UI;

namespace StateManagement
{
    public partial class LoginCookie : Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            HttpCookie cookie = this.Request.Cookies["username"];
            if (cookie != null)
            {
                this.NotLoggedLabel.Text = cookie.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("username", "You are now logged in, honey-bunny :)");

            cookie.Expires = DateTime.Now.AddMinutes(1);
            this.Response.Cookies.Add(cookie);
            this.Response.Redirect("TestLoginCookie.aspx");
        }
    }
}