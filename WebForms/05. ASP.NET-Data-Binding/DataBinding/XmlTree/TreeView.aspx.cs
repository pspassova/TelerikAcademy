using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XmlTree
{
    public partial class TreeView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void XmlSource_SelectedNodeChanged(object sender, EventArgs e)
        {
            var selectedNode = this.XmlTreeView.SelectedNode;
            if (selectedNode.ChildNodes.Count == 0)
            {
                this.InnerXmlLabel.Text = selectedNode.Value;
            }
            else
            {
                selectedNode.ToggleExpandState();
            }
        }

        protected void XmlTreeView_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            e.Node.Value = ((XmlElement)e.Node.DataItem).InnerText;
        }
    }
}