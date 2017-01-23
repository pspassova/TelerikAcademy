using System;

namespace LifecycleEvents
{
    public partial class Events : System.Web.UI.Page
    {
        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    this.PageEventsLabel.Text += "Page - PreInit has been invoked.<br/>";
        //}

        protected void Page_Init(object sender, EventArgs e)
        {
            this.PageEventsLabel.Text += "Page - Init has been invoked.<br/>";
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            this.PageEventsLabel.Text += "Page - InitComplete has been invoked.<br/>";
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.PageEventsLabel.Text += "Page - PreLoad has been invoked.<br/>";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageEventsLabel.Text += "Page - Load has been invoked.<br/>";
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            this.PageEventsLabel.Text += "Page - LoadComplete has been invoked.<br/>";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.PageEventsLabel.Text += "Page - PreRender has been invoked.<br/>";
        }

        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    this.PageEventsLabel.Text += "Page - Unload has been invoked.<br/>";
        //}

        protected void EventsButton_Click(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - Click has been invoked.<br />";
        }

        protected void EventsButton_Init(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - Init has been invoked.<br />";
        }

        protected void EventsButton_Load(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - Load has been invoked.<br />";
        }

        protected void EventsButton_PreRender(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - PreRender has been invoked.<br />";
        }

        //protected void EventsButton_Unload(object sender, EventArgs e)
        //{
        //    this.ButtonEventsLabel.Text += "Button - Unload has been invoked.";
        //}

        protected void EventsButton_Command(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - Command has been invoked.<br />";
        }

        protected void EventsButton_DataBinding(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - DataBinding has been invoked.<br />";
        }

        protected void EventsButton_Disposed(object sender, EventArgs e)
        {
            this.ButtonEventsLabel.Text += "Button - Disposed has been invoked.<br />";
        }
    }
}