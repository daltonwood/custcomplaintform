using CustServForm.CustComplaints;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
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

                //Load disposition issues into dropdown menu
                dispDoc.Load(dispPath);
                dispNode = dispDoc.SelectNodes("/root/" + dispList.SelectedItem.ToString() + "/issue");
                dispDetails.Items.Clear();
                foreach (XmlNode n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.InnerText.ToString();
                    dispDetails.Items.Add(i);
                }

                //Load Origin of Complaint categories into Drop Down Menu
                XmlDocument origDoc = new XmlDocument();
                var origPath = Server.MapPath(@"~/CustComplaints/xml/OriginOfComplaint.xml");
                origDoc.Load(origPath);
                originList.Items.Clear();
                XmlNodeList origNode = origDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in origNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    originList.Items.Add(i);   
                }

                //Find xml node based on selected item of dropdown menu
                string val = originList.SelectedItem.Text.Replace(' ', '_');
                origDoc.Load(origPath);
                XmlNode root = origDoc.DocumentElement;
                originTxtBox.Attributes.Add("placeholder", root.SelectSingleNode(" / root / " + val).InnerXml.ToString());

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

        public void originChanged(object sender, EventArgs e)
        {
            //Find xml node based on selected item of dropdown menu
            XmlDocument origDoc = new XmlDocument();
            var path = Server.MapPath(@"~/CustComplaints/xml/OriginOfComplaint.xml");
            string val = originList.SelectedItem.Text.Replace(' ', '_');
            origDoc.Load(path);
            XmlNode root = origDoc.DocumentElement;

            originTxtBox.Attributes.Add("placeholder", root.SelectSingleNode(" / root / " + val).InnerXml.ToString());

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
            XmlNodeList dispNode = dispDoc.SelectNodes("/root/" + dispList.SelectedItem.ToString().Replace(' ', '_') + "/issue");
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
            if (calendar.Visible.Equals(false))
                calendar.Visible = true;
            else { calendar.Visible = false; }
        }


        //Error handling for < and > characters
        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is HttpRequestValidationException)
            {
                MessageBox.Show("Formatting Error: Please remove any < or > characters from your text.");
            }
            // Clear the error from the server.
            Server.ClearError();
        }
        public void SubmitForm(object sender, EventArgs e)
        {
            FormData formData = new FormData();
            formData.Fill(locDDList.SelectedItem.Text, Convert.ToInt32(FP_Radio.SelectedValue), CustEmail.Text, dateTextBox.Text, originList.SelectedItem.Text, originTxtBox.Text, dispList.SelectedItem.Text, dispDetails.SelectedItem.Text, commentBox.Text, CustName.Text, ReservationTextBox.Text);
            JObject body = formData.FormatJSON("App Complaint");
            if (SamanageConnectAPI.PostToSamanage(body))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "alert('Form Submitted Successfully!')", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "alert('Form Failed to Submit...')", true);
        }

    }
}