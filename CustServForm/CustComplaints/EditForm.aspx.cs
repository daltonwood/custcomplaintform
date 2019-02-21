using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                var path = Server.MapPath(@"~/CustComplaints/Locations.xml");
                var dispPath = Server.MapPath(@"~/CustComplaints/WebDispIssues.xml");
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
                var dispPath = Server.MapPath(@"~/CustComplaints/WebDispIssues.xml");
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
                var dispPath = Server.MapPath(@"~/CustComplaints/AppDispIssues.xml");
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
                var dispPath = Server.MapPath(@"~/CustComplaints/KioskGateDispIssues.xml");
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
                var dispPath = Server.MapPath(@"~/CustComplaints/POSDispIssues.xml");
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
                    var dispPath = Server.MapPath(@"~/CustComplaints/ValetDispIssues.xml");
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

        public void submitData(object sender, EventArgs e)
        {
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
                updateDisp();
            }
            //Check if disposition textbox has data
            if(dispIssueText.Text.Length != 0)
            {
                //Run UpdateDispIssues method to insert new disposition issue into XML sheet
                UpdateDispIssues();
            }

        }
        private void UpdateLocation()
        {
            XmlDocument locDoc = new XmlDocument();
            var path = Server.MapPath(@"~/CustComplaints/Locations.xml");
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
            var path = Server.MapPath(@"~/CustComplaints/WebDispIssues.xml");
            if (Disp_Radio.SelectedItem.Value == "2")
            {
                path = Server.MapPath(@"~/CustComplaints/AppDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "3")
            {
                path = Server.MapPath(@"~/CustComplaints/KioskGateDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
                path = Server.MapPath(@"~/CustComplaints/POSDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
            {
                path = Server.MapPath(@"~/CustComplaints/ValetDispIssues.xml");
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
        private void updateDisp()
        {
            XmlDocument dispDoc = new XmlDocument();
            var path = Server.MapPath(@"~/CustComplaints/WebDispIssues.xml");
            if (Disp_Radio.SelectedItem.Value == "2")
            {
                path = Server.MapPath(@"~/CustComplaints/AppDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "3")
            {
                path = Server.MapPath(@"~/CustComplaints/KioskGateDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "4")
            {
                path = Server.MapPath(@"~/CustComplaints/POSDispIssues.xml");
            }
            else if (Disp_Radio.SelectedItem.Value == "5")
            {
                path = Server.MapPath(@"~/CustComplaints/ValetDispIssues.xml");
            }
            dispDoc.Load(path);
            string val = newDisp.Text.Replace(' ', '_');
            XmlNode root = dispDoc.DocumentElement;
            XmlElement elem = dispDoc.CreateElement(val);
            root.InsertAfter(elem, root.LastChild);
            dispDoc.Save(@path);
        }
    }
}