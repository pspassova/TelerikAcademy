using System;

namespace WebAndHtmlControls
{
    public partial class Random : System.Web.UI.Page
    {
        private readonly System.Random randomGenerator = new System.Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GeneratorButton_Click(object sender, EventArgs e)
        {
            int lowerBound = int.Parse(this.LowerRangeInput.Value);
            int upperBound = int.Parse(this.UpperRangeInput.Value);
            int randomNumber = this.randomGenerator.Next(lowerBound, upperBound);

            this.ResultLabel.Text = randomNumber.ToString();
        }
    }
}