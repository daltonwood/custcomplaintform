using System;
using System.Collections.Generic;
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
                var path = Server.MapPath(@"~/CustComplaints/xml/Locations.xml");
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/WebDispIssues.xml");
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
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/WebDispIssues.xml");
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList node = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in node)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    dispList.Items.Add(i);
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
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/AppDispIssues.xml");
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList node = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in node)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    dispList.Items.Add(i);
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
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/KioskGateDispIssues.xml");
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList node = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in node)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    dispList.Items.Add(i);
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
                var dispPath = Server.MapPath(@"~/CustComplaints/xml/POSDispIssues.xml");
                dispDoc.Load(dispPath);
                dispList.Items.Clear();

                XmlNodeList node = dispDoc.DocumentElement.ChildNodes;
                foreach (XmlNode n in node)
                {
                    ListItem i = new ListItem();
                    i.Text = n.Name.Replace('_', ' ');
                    dispList.Items.Add(i);
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
                    var dispPath = Server.MapPath(@"~/CustComplaints/xml/ValetDispIssues.xml");
                    dispDoc.Load(dispPath);
                    dispList.Items.Clear();

                    XmlNodeList node = dispDoc.DocumentElement.ChildNodes;
                    foreach (XmlNode n in node)
                    {
                        ListItem i = new ListItem();
                        i.Text = n.Name.Replace('_', ' ');
                        dispList.Items.Add(i);
                    }

                    DispLabel.Visible = true;
                    newDisp.Visible = true;
                    DispLabel2.Visible = true;
                    dispList.Visible = true;
                    dispIssueText.Visible = true;
            }
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
            Exception ex = Server.GetLastError();
            //Check Location for < > " or ' 
            //Commented out due to null exception being thrown every submit button click
           /*if (ex.Equals(null) && location.Contains("<"))
            {
                ex = new Exception("Invalid Input for Location. Please refrain from using <, >, ', or \".");
            }
            */
            //Check newDisposition for < > " or ' 
            if (newDisposition.Contains("<"))
            {
                ex = new Exception("Invalid Input for New Disposition Type. Please refrain from using <, >, ', or \".");
            }
            //Check dispositionText for < > " or ' 
            if (dispositionText.Contains("<"))
            {
                ex = new Exception("Invalid Input for New Issue. Please refrain from using <, >, ', or \".");
            }

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
            var path = Server.MapPath(@"~/CustComplaints/xml/Locations.xml");
            locDoc.Load(path);
            XmlNode root = locDoc.SelectSingleNode("/root/location");
            XmlElement elem = locDoc.CreateElement("location");
            elem.InnerText = locText.Text;
            root.ParentNode.AppendChild(elem);
            locDoc.Save(@path);
        }
        private void UpdateDispIssues()
        {
            XmlDocument dispDoc = new XmlDocument();
            var path = Server.MapPath(@"~/CustComplaints/xml/WebDispIssues.xml");
            if (Disp_Radio.SelectedItem.Value == "2")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/AppDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "3")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/KioskGateDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/POSDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/ValetDispIssues.xml");
            }
            dispDoc.Load(path);
            string val = dispList.Text;
            string nodeLoc = ("/root/" + val);
            XmlNode root = dispDoc.SelectSingleNode(nodeLoc);
            XmlElement elem = dispDoc.CreateElement("issue");
            elem.InnerText = dispIssueText.Text;
            root.AppendChild(elem);
            dispDoc.Save(@path);
        }
        //Add new Disposition Category to XML sheet
        private void UpdateDisp()
        {
            XmlDocument dispDoc = new XmlDocument();
            var path = Server.MapPath(@"~/CustComplaints/xml/WebDispIssues.xml");
            if (Disp_Radio.SelectedItem.Value == "2")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/AppDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "3")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/KioskGateDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/POSDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
            {
                path = Server.MapPath(@"~/CustComplaints/xml/ValetDispIssues.xml");
            }
            dispDoc.Load(path);
            string val = newDisp.Text.Replace(' ', '_');
            XmlNode root = dispDoc.DocumentElement;
            XmlElement elem = dispDoc.CreateElement(val);
            root.InsertAfter(elem, root.LastChild);
            dispDoc.Save(@path);
        }

        //Add new origin of complaint and hint
        private void UpdateOrigin()
        {
            XmlDocument origDoc = new XmlDocument();
            var path = Server.MapPath(@"~/CustComplaints/xml/OriginOfComplaint.xml");
            origDoc.Load(path);
            string val = originText.Text.Replace(' ', '_');
            XmlNode root = origDoc.DocumentElement;
            XmlElement elem = origDoc.CreateElement(val);
            elem.InnerText = originPHText.Text;
            root.InsertAfter(elem, root.LastChild);
            origDoc.Save(@path);
        }
    }
}