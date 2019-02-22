using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CustServForm
{
    public partial class AppComplaint : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            var path = Server.MapPath(@"~/CustComplaints/xml/Locations.xml");
            XmlDocument locDoc = new XmlDocument();
            locDoc.Load(path);
            locDDList.Items.Clear();
            if (!IsPostBack)
            {
                dispDetails.Items.Add("Sign In");
                dispDetails.Items.Add("Can't edit profile");
                calendar.Visible = false;

                //Load Disposition Categories into Drop Down Menu
                XmlDocument dispDoc = new XmlDocument();
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/AppDispIssues.xml");
                dispDoc.Load(dispPath);
                dispList.Items.Clear();
                XmlNodeList dispNode = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    dispList.Items.Add(i);
                }

                //Mobile OS List
                MobileOSList.Items.Add("Android");
                MobileOSList.Items.Add("iOS");
            }
            //Load Location XML list into Location Drop Down Menu
            XmlNodeList node = locDoc.SelectNodes("/root/location");
            foreach(XmlNode n in node)
            {
                ListItem i = new ListItem();
                i.Text = n.InnerText.ToString().Replace('_', ' ');
                locDDList.Items.Add(i);
            }

        }
        public void submitForm(object sender, EventArgs e)
        {
            
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
            dateTextBox.Text = (calendar.SelectedDate.ToShortDateString());
            calendar.Visible = false;
        }
        //Load new disposition issues when a new disposition category is selected
        public void dispListChanged(object sender, EventArgs e)
        {
            XmlDocument dispDoc = new XmlDocument();
            var dispPath = Server.MapPath(@"~/CustComplaints/xml/AppDispIssues.xml");
            dispDoc.Load(dispPath);
            XmlNodeList dispNode = dispDoc.SelectNodes("/root/" + dispList.SelectedItem.ToString() + "/issue");
            dispDetails.Items.Clear();
            foreach (XmlNode n in dispNode)
            {
                ListItem i = new ListItem();
                i.Text = n.InnerText.ToString();
                dispDetails.Items.Add(i);
            }
        }

        public void fp_selectedIndexChanged(object sender, EventArgs e) {
            if (FP_Radio.SelectedItem.Value == "1") {
                FPIDTxtBox.Visible = true;
                FPTier.Visible = true;
            }
            else {
                FPIDTxtBox.Visible = false;
                FPTier.Visible = false;

            }
        }
        public void showCal(object sender, EventArgs e)
        {
            updatePage();
            if (calendar.Visible.Equals(false))
                calendar.Visible = true;
            else { calendar.Visible = false; }
        }
        public void updatePage()
        {

        }

    }
}