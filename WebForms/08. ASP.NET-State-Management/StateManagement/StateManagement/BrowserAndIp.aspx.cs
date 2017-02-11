using System;

namespace StateManagement
{
    public partial class BrowserAndIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BrowserTypeLabel.Text = $"Browser's type: {Request.UserAgent}";
            this.IpAddressLabel.Text = $"Client's IP address: {Request.UserHostAddress}";
        }
    }
}