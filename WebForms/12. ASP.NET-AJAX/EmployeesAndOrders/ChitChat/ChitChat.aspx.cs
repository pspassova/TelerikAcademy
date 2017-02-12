using ChitChat.Data;
using ChitChat.Data.Contracts;
using ChitChat.Models.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChitChat
{
    public partial class ChitChat : Page
    {
        private IChitChatContext context = new ChitChatContext();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.MessagesListView.DataSource = context.Messages.ToList();
            this.MessagesListView.DataBind();

            this.MessagesTextBox.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            string username = this.Server.HtmlEncode(this.UsernameTextBox.Text);
            string message = this.Server.HtmlEncode(this.MessagesTextBox.Text);

            context.Messages.Add(new Message
            {
                Sender = username,
                Content = message
            });
            context.SaveChanges();
        }
    }
}