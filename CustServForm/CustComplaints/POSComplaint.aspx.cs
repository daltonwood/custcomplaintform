using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustServForm.CustComplaints
{
    public partial class POSComplaint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Loading location dropdown
            var path = Server.MapPath(@ConfigurationManager.AppSettings["locationPath"]);
            XmlDocument locDoc = new XmlDocument();
            locDoc.Load(path);
            locDDList.Items.Clear();
            
            //Initial page loading
            if (!IsPostBack)
            {
                calendar.Visible = false;

                //Load Disposition Categories into Drop Down Menu
                XmlDocument dispDoc = new XmlDocument();
                var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["posPath"]);
                dispDoc.Load(dispPath);
                dispList.Items.Clear();
                XmlNodeList dispNode = dispDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[0].Value;
                    if (!isDuplicate(dispList, i.Text)) { dispList.Items.Add(i); }
                }

                //Load disposition issues into dropdown menu
                dispDoc.Load(dispPath);
                dispNode = dispDoc.SelectNodes("/root/Unit");
                dispDetails.Items.Clear();
                foreach (XmlElement n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[1].Value;
                    if (n.Attributes[0].Value.Equals(dispList.SelectedValue) | !n.Attributes[0].Value.Equals(""))
                    {
                        dispDetails.Items.Add(i);
                    }
                }

                //Load Origin of Complaint categories into Drop Down Menu
                XmlDocument origDoc = new XmlDocument();
                var origPath = Server.MapPath(@ConfigurationManager.AppSettings["originPath"]);
                origDoc.Load(origPath);
                originList.Items.Clear();
                XmlNodeList origNode = origDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in origNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[0].Value;
                    originList.Items.Add(i);
                }

                //Find xml node based on selected item of dropdown menu
                string val = originList.SelectedItem.Text;
                origDoc.Load(origPath);
                XmlNodeList origTypeNode = origDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in origTypeNode)
                {
                    if (n.Attributes[0].Value == originList.SelectedValue)
                    {
                        originTxtBox.Attributes.Add("placeholder", n.Attributes[1].Value);
                    }
                }
            }
            //Load Location XML list into Location Drop Down Menu
            XmlNodeList node = locDoc.SelectNodes("/root/Unit");
            foreach (XmlElement n in node)
            {
                ListItem i = new ListItem();
                i.Text = n.Attributes[0].Value;
                locDDList.Items.Add(i);
            }
            //Resizes origin textbox to fit text
            int charRows = 0;
            string tbContent;
            int chars = 0;
            tbContent = originTxtBox.Text;
            originTxtBox.Columns = 50;
            chars = tbContent.Length;
            charRows = chars / originTxtBox.Columns;
            int remaining = chars - charRows * originTxtBox.Columns;
            if (remaining == 0)
            {
                originTxtBox.Rows = charRows;
                originTxtBox.TextMode = TextBoxMode.MultiLine;
            }
            else
            {
                originTxtBox.Rows = charRows + 1;
                originTxtBox.TextMode = TextBoxMode.MultiLine;
            }
        }


        //Checks for duplicates in dropdownlists
        private bool isDuplicate(DropDownList dispList, string text)
        {
            Boolean b = false;
            foreach (ListItem l in dispList.Items)
            {
                b = l.Text == text;
            }

            return b;
        }

        //Load new disposition issues when a new disposition category is selected
        public void dispListChanged(object sender, EventArgs e)
        {
            XmlDocument dispDoc = new XmlDocument();
            var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["posPath"]);
            //Load disposition issues into dropdown menu
            dispDoc.Load(dispPath);
            XmlNodeList dispNode = dispDoc.SelectNodes("/root/Unit");
            dispDetails.Items.Clear();
            foreach (XmlElement n in dispNode)
            {
                ListItem i = new ListItem();
                i.Text = n.Attributes[1].Value;
                if (n.Attributes[0].Value.Equals(dispList.SelectedValue) & !n.Attributes[1].Value.Equals(""))
                {
                    dispDetails.Items.Add(i);
                }
            }
        }

        //Updates the page based on the change in Origin of Complaint
        public void originChanged(object sender, EventArgs e)
        {
            //Find xml node based on selected item of dropdown menu
            XmlDocument origDoc = new XmlDocument();
            var path = Server.MapPath(@ConfigurationManager.AppSettings["originPath"]);
            string val = originList.SelectedItem.Text;
            origDoc.Load(path);
            XmlNodeList origTypeNode = origDoc.SelectNodes("/root/Unit");
            foreach (XmlElement n in origTypeNode)
            {
                if (n.Attributes[0].Value == originList.SelectedValue)
                {
                    originTxtBox.Attributes.Add("placeholder", n.Attributes[1].Value);
                }
            }

        }

        //Adds the date of the incident to the form
        public void dateChanged(object sender, EventArgs e)
        {
            gcsDateTextBox.Text = (calendar.SelectedDate.ToShortDateString());
            calendar.Visible = false;
        }

        //Updates page based on customer's membership
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

        //Displays/Hides calendar
        public void showCal(object sender, EventArgs e)
        {
            if(calendar.Visible.Equals(false))
                calendar.Visible = true;
            else { calendar.Visible = false; }
            calendar.SelectedDate = calendar.TodaysDate;
            gcsDateTextBox.Text = DateTime.Today.ToString("MM/dd/yyyy");
        }

        //Submits the contents of the form to Samanage
        public void SubmitForm(object sender, EventArgs e)
        {
            FormData formData = new FormData();
            formData.Fill(locDDList.SelectedItem.Text, Convert.ToInt32(FP_Radio.SelectedValue), CustEmail.Text, gcsDateTextBox.Text, 
                originList.SelectedItem.Text, Server.HtmlEncode(originTxtBox.Text), dispList.SelectedItem.Text, dispDetails.SelectedItem.Text, 
                Server.HtmlEncode(commentBox.Text), CustName.Text, ReservationTextBox.Text, FPTier: FPTier.SelectedValue, 
                FPNumber: FPIDTxtBox.Text, ticket: TicketTextBox.Text, ParkingType: parkingDDL.SelectedValue);
            JObject body = formData.FormatJSON("POS Complaint");
            if (SamanageConnectAPI.PostToSamanage(body))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "alert('Form Submitted Successfully!'); window.location='POSComplaint.aspx'", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "alert('Form Failed to Submit. Please try again.')", true);

        }
    }
}