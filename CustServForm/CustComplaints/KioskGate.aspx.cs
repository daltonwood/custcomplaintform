using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Newtonsoft.Json;

namespace CustServForm.CustComplaints
{
    public partial class KioskGate : System.Web.UI.Page
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
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/KioskGateDispIssues.xml");
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
            }
            //Load Location XML list into Location Drop Down Menu
            XmlNodeList node = locDoc.SelectNodes("/root/location");
            foreach (XmlNode n in node)
            {
                ListItem i = new ListItem();
                i.Text = n.InnerText.ToString().Replace('_', ' ');
                locDDList.Items.Add(i);
            }
        }

        public void dispListChanged(object sender, EventArgs e)
        {
            XmlDocument dispDoc = new XmlDocument();
            dispDetails.Items.Clear();
            var dispPath = Server.MapPath(@"~/CustComplaints/xml/KioskGateDispIssues.xml");
            dispDoc.Load(dispPath);
            XmlNodeList dispNode = dispDoc.GetElementsByTagName(dispList.SelectedItem.Value);
            dispDetails.Items.Clear();
            foreach (XmlNode n in dispNode)
            {
                ListItem i = new ListItem();
                i.Text = n.InnerText.ToString();
                dispDetails.Items.Add(i);
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
            gcsDateTextBox.Text = (calendar.SelectedDate.ToShortDateString());
            calendar.Visible = false;
        }

        public void fp_selectedIndexChanged(object sender, EventArgs e)
        {
            if (FP_Radio.SelectedItem.Value == "1")
            {
                FPIDTxtBox.Visible = true;
                FPTier.Visible = true;

            }
            else
            {
                FPIDTxtBox.Visible = false;
                FPTier.Visible = false;

            }
        }

        public void showCal(object sender, EventArgs e)
        {
            if(calendar.Visible.Equals(false))
                calendar.Visible = true;
            else { calendar.Visible = false; }
        }

        public void submitForm(object sender, EventArgs e)
        {
            SamanageConnectAPI.PostToSamanage();
        }
    }
}