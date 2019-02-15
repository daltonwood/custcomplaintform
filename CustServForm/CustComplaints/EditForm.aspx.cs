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
        public XmlDocument locDoc = new XmlDocument();
        public XmlDocument dispDoc = new XmlDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            var path = Server.MapPath(@"~/CustComplaints/Locations.xml");
            var dispPath = Server.MapPath(@"~/CustomComplaints/DispIssues.xml");
            locDoc.Load(path);
        }
        public void addLoc(object sender, EventArgs e)
        {
            XmlNode root = locDoc.SelectSingleNode("/root/location");
            var path = Server.MapPath(@"~/CustComplaints/Locations.xml");
            XmlElement elem = locDoc.CreateElement("location");
            elem.InnerText = locText.Text;
            root.ParentNode.AppendChild(elem);
            locDoc.Save(@path);
            submit.Text = "Success";
        }
        public void addDispIssue(object sender, EventArgs e)
        {
            string val = dispList.Text;
            XmlNode root = locDoc.SelectSingleNode("/root/" + val + "/issue");
            var path = Server.MapPath(@"~/CustomComplaints/DispIssues.xml");
            XmlElement elem = locDoc.CreateElement("issue");
            elem.InnerText = dispIssueText.Text;
            root.ParentNode.AppendChild(elem);
            locDoc.Save(@path);
            submit.Text = "Success";
        }
    }
}