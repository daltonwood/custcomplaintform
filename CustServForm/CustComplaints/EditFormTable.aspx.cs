using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Xml;

namespace CustServForm.CustComplaints
{
    public partial class EditFormTable : System.Web.UI.Page
    {
        
        string appPath = string.Empty;
        string kioskPath = string.Empty;
        string locPath = string.Empty;
        string origPath = string.Empty;
        string POSPath = string.Empty;
        string valetPath = string.Empty;
        string webPath = string.Empty;

        /*
            Gridview uses a combination of a datatable and a dataset. 
            A dataset is like an organized string that a datatable uses to construct its organized table.
            Both are necessary to effectively load and save data to and from a Gridview.
            Gridview is simply the front end that displays the data in the data table.
            This is the best way to display information from an XML file on a .NET website.
        */

        XmlDocument appDispIssues = new XmlDocument();
        XmlDocument KioskGateDispIssues = new XmlDocument();
        XmlDocument Locations = new XmlDocument();
        XmlDocument OriginOfComplaint = new XmlDocument();
        XmlDocument POSDispIssues = new XmlDocument();
        XmlDocument ValetDispIssues = new XmlDocument();
        XmlDocument WebDispIssues = new XmlDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            appPath = Server.MapPath(@"~/CustComplaints/xml/AppDispIssues.xml");
            kioskPath = Server.MapPath(@"~/CustComplaints/xml/KioskGateDispIssues.xml");
            locPath = Server.MapPath(@"~/CustComplaints/xml/Locations.xml");
            origPath = Server.MapPath(@"~/CustComplaints/xml/OriginOfComplaint.xml");
            POSPath = Server.MapPath(@"~/CustComplaints/xml/POSDispIssues.xml");
            valetPath = Server.MapPath(@"~/CustComplaints/xml/ValetDispIssues.xml");
            webPath = Server.MapPath(@"~/CustComplaints/xml/WebDispIssues.xml");

            //Construct a new dataset named ds
            //This simply contains data in a structured way that datatable can easily handle
            DataSet ds = new DataSet();
            ds.ReadXml(@locPath);

            //Construct a new datatable named dt 
            DataTable temp = ds.Tables["location"];
            DataTable dt = new DataTable();

            for (int x = 0; x < temp.Rows.Count; x++)
            {
                dt.ImportRow(temp.Rows[x]);
            }

            
            locTable.DataSource = dt.DefaultView;
            locTable.DataBind();
        }

        protected void DeleteLocation(object sender, GridViewDeleteEventArgs e)
        {
            Locations.Load(locPath);
            XmlNode node = Locations.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            Locations.Save(locPath);
            Page_Load(Server, e);
        }

        protected void EditLocation(object sender, GridViewEditEventArgs e)
        {
            locTable.EditIndex = e.NewEditIndex;
            locTable.DataBind();
        }

        protected void UpdateLocation(object sender, GridViewUpdateEventArgs e)
        {
            Locations.Load(locPath);
            int locIndex = e.RowIndex+1;

            Locations.Save(@locPath);
            locTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditLocation(object sender, GridViewCancelEditEventArgs e)
        {
            locTable.EditIndex = -1;
            Page_Load(Server, e);
        }
    }
}

        