﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CustServForm
{
    public partial class WebComplaint : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = Server.MapPath(@"~/CustComplaints/Locations.xml");
            XmlDocument locDoc = new XmlDocument();
            locDoc.Load(path);
            locDDList.Items.Clear();
            if (!IsPostBack)
            {
                dispDetails.Items.Add("Sign In");
                dispDetails.Items.Add("Can't edit profile");
                calendar.Visible = false;

                XmlDocument dispDoc = new XmlDocument();
                var dispPath = Server.MapPath(@"~/CustComplaints/DispIssues.xml");
                dispDoc.Load(dispPath);
                dispList.Items.Clear();
                XmlNodeList dispNode = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name;
                    dispList.Items.Add(i);
                }
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

        public void dispListChanged(object sender, EventArgs e)
        {
            dispDetails.Items.Clear();
            if (dispList.SelectedIndex == 0)
            {
                dispDetails.Items.Add("Sign In");
                dispDetails.Items.Add("Can't edit profile");
            }
        }

        public void dateChanged(object sender, EventArgs e)
        {
            dateTextBox.Text = (calendar.SelectedDate.ToShortDateString());
        }
        public void showCal(object sender, EventArgs e)
        {
            if (calendar.Visible.Equals(false))
            {
                calendar.Visible = true;
            }
            else { calendar.Visible = false; }
        }

        /*
            public void submitClicked(object sender, EventArgs e)
            On button click, take all data and store in new class "FormData"  
            Use new class to export data to Samanage API
        */
    }
}