using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CustServForm.CustComplaints
{
    public partial class GCSComplaint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = Server.MapPath(@"~/CustComplaints/Locations.xml");
            XmlDocument locDoc = new XmlDocument();
            locDoc.Load(path);
            locDDList.Items.Clear();
            if (!IsPostBack)
            {
                calendar.Visible = false;
            }

            XmlNodeList node = locDoc.SelectNodes("/root/location");
            foreach (XmlNode n in node)
            {
                ListItem i = new ListItem();
                i.Text = n.InnerText.ToString();
                locDDList.Items.Add(i);
            }
        }

        public void originChanged(object sender, EventArgs e)
        {
            if (Mobilelist1.SelectedIndex == 0)
            {
                originTxtBox.Attributes.Add("Placeholder", "Paste Listen 360 comment here.");
            }
            if (Mobilelist1.SelectedIndex == 1)
            {
                originTxtBox.Attributes.Add("Placeholder", "Paste customer email here.");
            }
            if (Mobilelist1.SelectedIndex == 2)
            {
                originTxtBox.Attributes.Add("Placeholder", "Paste social media comment here.");
            }
            if (Mobilelist1.SelectedIndex == 3)
            {
                originTxtBox.Attributes.Add("Placeholder", "Enter any additional info here");
            }
        }

        public void dateChanged(object sender, EventArgs e)
        {
            gcsDateTextBox.Text = (calendar.SelectedDate.ToShortDateString());
        }

        public void showCal(object sender, EventArgs e)
        {
            if(calendar.Visible.Equals(false))
                calendar.Visible = true;
            else { calendar.Visible = false; }
        }
    }
}