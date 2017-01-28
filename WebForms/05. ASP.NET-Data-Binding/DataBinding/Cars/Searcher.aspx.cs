using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Cars
{
    public partial class Searcher : Page
    {
        private CarItemsProvider dataProvider = new CarItemsProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ProducerNameDropdown.DataSource = this.dataProvider.GetAllProducers();
                this.ExtrasCheckbox.DataSource = this.dataProvider.GetAllExtras();
                this.EngineRadiobutton.DataSource = this.dataProvider.GetAllEngines();
                Page.DataBind();

            }
        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            string producerName = this.ProducerNameDropdown.SelectedValue;
            string model = this.ProducerModelDropdown.SelectedValue;
            string engine = this.EngineRadiobutton.SelectedValue;

            HashSet<string> extras = new HashSet<string>();
            for (int i = 0; i < this.ExtrasCheckbox.Items.Count; i++)
            {
                if (this.ExtrasCheckbox.Items[i].Selected)
                {
                    extras.Add(this.ExtrasCheckbox.Items[i].Text);
                }
            }

            this.SearchResultLiteral.Text = $"Found car: {producerName} {model}, engine: {engine}, extras: {string.Join(", ", extras)}.";
        }

        protected void ProducerNameDropdown_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProducerModelDropdown.DataSource = this.dataProvider.GetAllProducers().Single(p => p.Name == this.ProducerNameDropdown.SelectedValue).Models;
            this.ProducerModelDropdown.DataBind();
        }
    }
}