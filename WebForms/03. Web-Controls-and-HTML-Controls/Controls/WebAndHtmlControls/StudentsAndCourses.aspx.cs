using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class StudentsAndCourses : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string firstName = this.FirstName.Text;
            string lastName = this.LastName.Text;
            string facultyNumber = this.FacultyNumber.Text;
            string university = this.UniversitiesDropdown.SelectedValue;
            string specialty = this.SpecialitiesDropdown.SelectedValue;

            this.ResultLabel.Text = "<pre>Registered student's details</pre>";
            this.ResultPanel.Controls.Add(new LiteralControl($"First name: <strong>{firstName}</strong>"));
            this.ResultPanel.Controls.Add(new LiteralControl("<br />"));
            this.ResultPanel.Controls.Add(new LiteralControl($"Last name: <strong>{lastName}</strong>"));
            this.ResultPanel.Controls.Add(new LiteralControl("<br />"));
            this.ResultPanel.Controls.Add(new LiteralControl($"Faculty number: <strong>{facultyNumber}</strong>"));
            this.ResultPanel.Controls.Add(new LiteralControl("<br />"));
            this.ResultPanel.Controls.Add(new LiteralControl($"University: <strong>{university}</strong>"));
            this.ResultPanel.Controls.Add(new LiteralControl("<br />"));
            this.ResultPanel.Controls.Add(new LiteralControl($"Specialty: <strong>{specialty}</strong>"));
            this.ResultPanel.Controls.Add(new LiteralControl("<br />"));
            this.ResultPanel.Controls.Add(new LiteralControl("Courses: "));

            foreach (ListItem course in this.CoursesList.Items)
            {
                if (course.Selected)
                {
                    this.ResultPanel.Controls.Add(new LiteralControl($"<strong>{course}</strong>"));
                    this.ResultPanel.Controls.Add(new LiteralControl("<br />"));
                }
            }
        }
    }
}