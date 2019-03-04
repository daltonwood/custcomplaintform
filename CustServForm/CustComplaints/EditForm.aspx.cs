using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Xml;

namespace CustServForm.CustComplaints
{
    public partial class EditForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XmlDocument locDoc = new XmlDocument();
                XmlDocument dispDoc = new XmlDocument();
                var path = Server.MapPath(@ConfigurationManager.AppSettings["locationPath"]);
                var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["webPath"]);
                locDoc.Load(path);
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList node = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in node)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    dispList.Items.Add(i);
                }
            }
        }

        public void disp_selectedIndexChanged(object sender, EventArgs e) {
            if (Disp_Radio.SelectedItem.Value == "1")
            {
                XmlDocument dispDoc = new XmlDocument();
                var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["webPath"]);
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList dispNode = dispDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[0].Value;
                    if (!isDuplicate(dispList, i.Text)) { dispList.Items.Add(i); }
                }

                DispLabel.Visible = true;
                newDisp.Visible = true;
                DispLabel2.Visible = true;
                dispList.Visible = true;
                dispIssueText.Visible = true;
            }

            else if (Disp_Radio.SelectedItem.Value == "2")
            {
                XmlDocument dispDoc = new XmlDocument();
                var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["appPath"]);
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList dispNode = dispDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[0].Value;
                    if (!isDuplicate(dispList, i.Text)) { dispList.Items.Add(i); }
                }

                DispLabel.Visible = true;
                newDisp.Visible = true;
                DispLabel2.Visible = true;
                dispList.Visible = true;
                dispIssueText.Visible = true;
            }

            else if(Disp_Radio.SelectedItem.Value == "3")
            {
                XmlDocument dispDoc = new XmlDocument();
                var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["kioskPath"]);
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList dispNode = dispDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[0].Value;
                    if (!isDuplicate(dispList, i.Text)) { dispList.Items.Add(i); }
                }

                DispLabel.Visible = true;
                newDisp.Visible = true;
                DispLabel2.Visible = true;
                dispList.Visible = true;
                dispIssueText.Visible = true;
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
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

                DispLabel.Visible = true;
                newDisp.Visible = true;
                DispLabel2.Visible = true;
                dispList.Visible = true;
                dispIssueText.Visible = true;
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
                {
                    XmlDocument dispDoc = new XmlDocument();
                    var dispPath = Server.MapPath(@ConfigurationManager.AppSettings["valetPath"]);
                    dispDoc.Load(dispPath);
                    dispList.Items.Clear();

                XmlNodeList dispNode = dispDoc.SelectNodes("/root/Unit");
                foreach (XmlElement n in dispNode)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Attributes[0].Value;
                    if (!isDuplicate(dispList, i.Text)) { dispList.Items.Add(i); }
                }

                DispLabel.Visible = true;
                    newDisp.Visible = true;
                    DispLabel2.Visible = true;
                    dispList.Visible = true;
                    dispIssueText.Visible = true;
            }
        }

        private bool isDuplicate(DropDownList dispList, string text)
        {
            Boolean b = false;
            foreach (ListItem l in dispList.Items)
            {
                b = l.Text == text;
            }

            return b;
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            var error = exc.ToString().Substring(0, 54);

            // Handle specific exception.
            if (error.Equals("System.Web.HttpRequestValidationException (0x80004005)"))
            {
                MessageBox.Show("Please refrain from using the < character.", "Error: Invalid Input",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Clear the error from the server.
            // Server.ClearError();
        }

        public void SubmitData(object sender, EventArgs e)
        {
            //Error handling
            var location = locText.Text;
            var newDisposition = newDisp.Text;
            var dispositionText = dispIssueText.Text;

            //Check if location textbox has data
            if (locText.Text.Length != 0)
            {
                //Run UpdateLocation method to insert new location into XML sheet
                UpdateLocation();
            }
            //Check if new disposition textbox has data
            if(newDisp.Text.Length != 0)
            {
                //Run UpdateDisp method to insert new disposition into XML sheet
                UpdateDisp();
            }
            //Check if disposition textbox has data
            if(dispIssueText.Text.Length != 0)
            {
                //Run UpdateDispIssues method to insert new disposition issue into XML sheet
                UpdateDispIssues();
            }
            //Check if new Origin textbox has data
            if(originText.Text.Length != 0)
            {
                //Run UpdateOrigin method to insert new Origin Of Complaint into XML sheet
                UpdateOrigin();
            }

        }

        private void UpdateLocation()
        {
            XmlDocument locDoc = new XmlDocument();
            var path = Server.MapPath(@ConfigurationManager.AppSettings["locationPath"]);
            locDoc.Load(path);
            XmlNode root = locDoc.SelectSingleNode("/root/Unit");
            XmlElement elem = locDoc.CreateElement("Unit");
            elem.SetAttribute("Location", locText.Text);
            root.ParentNode.AppendChild(elem);
            locDoc.Save(@path);
            MessageBox.Show("Location Added!");
        }

        private void UpdateDispIssues()
        {
            XmlDocument dispDoc = new XmlDocument();
            var path = Server.MapPath(@ConfigurationManager.AppSettings["webPath"]);
            if (Disp_Radio.SelectedItem.Value == "2")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["appPath"]);
            }
            else if (Disp_Radio.SelectedItem.Value == "3")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["kioskPath"]);
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["posPath"]);
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["valetPath"]);
            }
            dispDoc.Load(path);
            string val = dispList.Text;
            XmlNode root = dispDoc.DocumentElement;
            XmlElement elem = dispDoc.CreateElement("Unit");
            elem.SetAttribute("DispType", dispList.Text);
            elem.SetAttribute("issue", dispIssueText.Text);
            root.AppendChild(elem);
            dispDoc.Save(@path);
            MessageBox.Show("Disposition Issue Added!");
        }

        //Add new Disposition Category to XML sheet
        private void UpdateDisp()
        {
            XmlDocument dispDoc = new XmlDocument();
            var path = Server.MapPath(@ConfigurationManager.AppSettings["webPath"]);
            if (Disp_Radio.SelectedItem.Value == "2")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["appPath"]);
            }
            else if (Disp_Radio.SelectedItem.Value == "3")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["kioskPath"]);
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["posPath"]);
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
            {
                path = Server.MapPath(@ConfigurationManager.AppSettings["valetPath"]);
            }
            dispDoc.Load(path);
            string val = newDisp.Text;                    
            XmlNode root = dispDoc.DocumentElement;
            XmlElement elem = dispDoc.CreateElement("Unit");
            elem.SetAttribute("DispType", val);
            elem.SetAttribute("issue", "");
            root.InsertAfter(elem, root.LastChild);
            dispDoc.Save(@path);
            MessageBox.Show("Disposition Type Added!");
        }

        //Add new origin of complaint and hint
        private void UpdateOrigin()
        {
            XmlDocument origDoc = new XmlDocument();
            var path = Server.MapPath(@ConfigurationManager.AppSettings["originPath"]);
            origDoc.Load(path);
            string val = originText.Text;
            XmlNode root = origDoc.DocumentElement;
            XmlElement elem = origDoc.CreateElement("Unit");
            elem.SetAttribute("OriginType", val);
            elem.SetAttribute("Hint", originPHText.Text);
            root.InsertAfter(elem, root.LastChild);
            origDoc.Save(@path);
            MessageBox.Show("Origin Added!");
        }
    }
}