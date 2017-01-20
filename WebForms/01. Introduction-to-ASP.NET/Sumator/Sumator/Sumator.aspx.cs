using Sumator.Contracts;
using Sumator.Models;
using System;

namespace Sumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        private ISumatorBusinessLogic sumator;

        public Sumator()
        {
            this.sumator = new SumatorBusinessLogic();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SumButton_Click(object sender, EventArgs e)
        {
            try
            {
                double sum = this.sumator.Sum(double.Parse(this.FirstNumber.Text), double.Parse(this.SecondNumber.Text));

                this.FinalSumLabel.Text = sum.ToString();
            }
            catch (Exception)
            {
                this.FinalSumLabel.Text = "Invalid numbers!";
            }
        }
    }
}