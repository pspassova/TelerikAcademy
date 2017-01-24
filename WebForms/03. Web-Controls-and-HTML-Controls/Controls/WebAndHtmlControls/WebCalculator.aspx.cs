using System;
using System.Web.UI;

namespace WebAndHtmlControls
{
    public partial class WebCalculator : Page
    {
        private static string operand;
        private static string value;
        private static double result;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 1;
        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 2;
        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 3;
        }

        protected void ButtonFour_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 4;
        }

        protected void ButtonFive_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 5;
        }

        protected void ButtonSix_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 6;
        }

        protected void ButtonSeven_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 7;
        }

        protected void ButtonEight_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 8;
        }

        protected void ButtonNine_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 9;
        }

        protected void ButtonZero_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text += 0;
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                operand = "+";
                value = this.InputTextBox.Text;
                this.InputTextBox.Text = string.Empty;
            }
        }

        protected void ButtonSubtract_Click(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                operand = "-";
                value = this.InputTextBox.Text;
                this.InputTextBox.Text = string.Empty;
            }
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                operand = "*";
                value = this.InputTextBox.Text;
                this.InputTextBox.Text = string.Empty;
            }
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                operand = "/";
                value = this.InputTextBox.Text;
                this.InputTextBox.Text = string.Empty;
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.InputTextBox.Text = string.Empty;
        }

        protected void ButtonSqrt_Click(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                this.InputTextBox.Text = Math.Sqrt(Double.Parse(this.InputTextBox.Text)).ToString();
            }
        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            switch (operand)
            {
                case "+":
                    result = Double.Parse(value) + double.Parse(this.InputTextBox.Text);
                    this.InputTextBox.Text = result.ToString();
                    break;
                case "-":
                    result = Double.Parse(value) - double.Parse(this.InputTextBox.Text);
                    this.InputTextBox.Text = result.ToString();
                    break;
                case "*":
                    result = Double.Parse(value) * double.Parse(this.InputTextBox.Text);
                    this.InputTextBox.Text = result.ToString();
                    break;
                case "/":
                    result = Double.Parse(value) / double.Parse(this.InputTextBox.Text);
                    this.InputTextBox.Text = result.ToString();
                    break;
                default:
                    break;
            }

            operand = string.Empty;
            value = string.Empty;
        }
    }
}