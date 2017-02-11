using StateManagement.Data;
using StateManagement.Data.Contracts;
using StateManagement.Models.Models;
using System;
using System.Web.UI;

namespace StateManagement
{
    public partial class UsersCountDatabase : Page
    {
        private static int visitorsCount = 1;

        private IStateManagementContext context = new StateManagementContext();

        protected override void OnPreLoad(EventArgs e)
        {
            if (this.Session["visits"] == null)
            {
                this.Session["visits"] = 1;
            }
            else
            {
                visitorsCount = (int)this.Session["visits"];

                this.Session["visits"] = ++visitorsCount;
            }

            InsertVisitorsCountToDatabase(visitorsCount);
            this.MessageLabel.Text = $"The total number of visitors ({visitorsCount}) is now in the database. Refresh to upgrade the number.";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void InsertVisitorsCountToDatabase(int visitorsCount)
        {
            this.context.UsersCount.Add(new UsersCount { Count = visitorsCount });
            this.context.SaveChanges();
        }
    }
}