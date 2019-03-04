using System;
using System.Collections.Generic;
using System.Configuration;
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
        string originPath = string.Empty;
        string posPath = string.Empty;
        string valetPath = string.Empty;
        string webPath = string.Empty;
        string locationPath = string.Empty;
        string locPath = string.Empty;

        /*
            Gridview uses a combination of a datatable and a dataset. 
            A dataset is like an organized string that a datatable uses to construct its organized table.
            Both are necessary to effectively load and save data to and from a Gridview.
            Gridview is simply the front end that displays the data in the data table.
            This is the best way to display information from an XML file on a .NET website.
        */

        //XmlDocument appDispIssues = new XmlDocument();
        //XmlDocument KioskGateDispIssues = new XmlDocument();
        //XmlDocument Locations = new XmlDocument();
        //XmlDocument OriginOfComplaint = new XmlDocument();
        //XmlDocument POSDispIssues = new XmlDocument();
        //XmlDocument ValetDispIssues = new XmlDocument();
        //XmlDocument WebDispIssues = new XmlDocument();
        XmlDocument xmlDoc = new XmlDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            appPath = Server.MapPath(@ConfigurationManager.AppSettings["appPath"]);
            kioskPath = Server.MapPath(@ConfigurationManager.AppSettings["kioskPath"]);
            locationPath = Server.MapPath(@ConfigurationManager.AppSettings["locationPath"]);
            originPath = Server.MapPath(@ConfigurationManager.AppSettings["originPath"]);
            posPath = Server.MapPath(@ConfigurationManager.AppSettings["posPath"]);
            valetPath = Server.MapPath(@ConfigurationManager.AppSettings["valetPath"]);
            webPath = Server.MapPath(@ConfigurationManager.AppSettings["webPath"]);
            if (!IsPostBack)
            {
                EditList.SelectedValue = "Location";
                locPath = locationPath;
                //Create new data set and sets it to equal the Address Book 
                DataSet ds = new DataSet();
                ds.ReadXml(locPath);
                //Create 2 DataTable's (Work better with GridView)
                DataTable temp = ds.Tables[0];
                DataTable dt = new DataTable();
                //Get the current location from the drop down menu and set it as an integer
                //int locationIndex = locIndex.SelectedIndex;
                //Create an empty integer list

                //Add columns to the data table
                dt.Columns.Add("Location");

                //Import rows from data table temp to data table dt
                for (int x = 0; x < temp.Rows.Count; x++)
                {
                    //if (menuId[x] == locationIndex)

                    dt.ImportRow(temp.Rows[x]);

                }

                locTable.DataSource = dt.DefaultView;
                locTable.DataBind();
            }

            switch (EditList.SelectedValue)
            {
                case "App":
                    locPath = appPath;
                    break;
                case "Location":
                    locPath = locationPath;
                    break;
                case "Kiosk":
                    locPath = kioskPath;
                    break;
                case "Origin":
                    locPath = originPath;
                    break;
                case "POS":
                    locPath = posPath;
                    break;
                case "Valet":
                    locPath = valetPath;
                    break;
                case "Web":
                    locPath = webPath;
                    break;
            }

            changeEditor(sender, e);



        }

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

        protected void DeleteLocation(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(locationPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(locationPath);
            Page_Load(Server, e);
        }

        protected void EditLocation(object sender, GridViewEditEventArgs e)
        {
            locTable.EditIndex = e.NewEditIndex;
            locTable.DataBind();
        }

        protected void UpdateLocation(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(locationPath);
            //int locIndex = e.RowIndex+1;


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    //n.SetAttribute("Location", e.NewValues["Location"].ToString());
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                }
                i++;
            }



            xmlDoc.Save(@locationPath);
            locTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditLocation(object sender, GridViewCancelEditEventArgs e)
        {
            locTable.EditIndex = -1;
            Page_Load(Server, e);
        }

        protected void DeleteApp(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(appPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(appPath);
            Page_Load(Server, e);
        }

        protected void EditApp(object sender, GridViewEditEventArgs e)
        {
            appTable.EditIndex = e.NewEditIndex;
            appTable.DataBind();
        }

        protected void UpdateApp(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(appPath);
            //int locIndex = e.RowIndex+1;


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                    n.Attributes[1].Value = e.NewValues[1].ToString();

                }
                i++;
            }



            xmlDoc.Save(@appPath);
            appTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditApp(object sender, GridViewCancelEditEventArgs e)
        {
            appTable.EditIndex = -1;
            Page_Load(Server, e);
        }

        protected void DeleteKiosk(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(kioskPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(kioskPath);
            Page_Load(Server, e);
        }

        protected void EditKiosk(object sender, GridViewEditEventArgs e)
        {
            kioskTable.EditIndex = e.NewEditIndex;
            kioskTable.DataBind();
        }

        protected void UpdateKiosk(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(kioskPath);
            //int locIndex = e.RowIndex+1;


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                    n.Attributes[1].Value = e.NewValues[1].ToString();

                }
                i++;
            }



            xmlDoc.Save(@kioskPath);
            kioskTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditKiosk(object sender, GridViewCancelEditEventArgs e)
        {
            kioskTable.EditIndex = -1;
            Page_Load(Server, e);
        }

        protected void DeleteOrigin(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(originPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(originPath);
            Page_Load(Server, e);
        }

        protected void EditOrigin(object sender, GridViewEditEventArgs e)
        {
            originTable.EditIndex = e.NewEditIndex;
            originTable.DataBind();
        }

        protected void UpdateOrigin(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(originPath);


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                    n.Attributes[1].Value = e.NewValues[1].ToString();

                }
                i++;
            }



            xmlDoc.Save(@originPath);
            originTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditOrigin(object sender, GridViewCancelEditEventArgs e)
        {
            originTable.EditIndex = -1;
            Page_Load(Server, e);
        }

        protected void DeletePOS(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(posPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(posPath);
            Page_Load(Server, e);
        }

        protected void EditPOS(object sender, GridViewEditEventArgs e)
        {
            posTable.EditIndex = e.NewEditIndex;
            posTable.DataBind();
        }

        protected void UpdatePOS(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(posPath);
            //int locIndex = e.RowIndex+1;


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                    n.Attributes[1].Value = e.NewValues[1].ToString();

                }
                i++;
            }



            xmlDoc.Save(@posPath);
            posTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditPOS(object sender, GridViewCancelEditEventArgs e)
        {
            posTable.EditIndex = -1;
            Page_Load(Server, e);
        }


        protected void DeleteValet(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(valetPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(valetPath);
            Page_Load(Server, e);
        }

        protected void EditValet(object sender, GridViewEditEventArgs e)
        {
            valetTable.EditIndex = e.NewEditIndex;
            valetTable.DataBind();
        }

        protected void UpdateValet(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(valetPath);
            //int locIndex = e.RowIndex+1;


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                    n.Attributes[1].Value = e.NewValues[1].ToString();

                }
                i++;
            }



            xmlDoc.Save(@valetPath);
            valetTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditValet(object sender, GridViewCancelEditEventArgs e)
        {
            valetTable.EditIndex = -1;
            Page_Load(Server, e);
        }

        protected void DeleteWeb(object sender, GridViewDeleteEventArgs e)
        {
            xmlDoc.Load(webPath);
            XmlNode node = xmlDoc.DocumentElement;
            node.RemoveChild(node.ChildNodes[e.RowIndex]);
            xmlDoc.Save(webPath);
            Page_Load(Server, e);
        }

        protected void EditWeb(object sender, GridViewEditEventArgs e)
        {
            webTable.EditIndex = e.NewEditIndex;
            webTable.DataBind();
        }

        protected void UpdateWeb(object sender, GridViewUpdateEventArgs e)
        {
            xmlDoc.Load(webPath);
            //int locIndex = e.RowIndex+1;


            XmlNodeList node = xmlDoc.SelectNodes("/root/Unit");
            //Create int i to iterate alongside each XML element
            int i = 0;


            foreach (XmlElement n in node)
            {
                //Check the selected Row Index against the current iteration of i
                if (e.RowIndex == i)
                {
                    n.Attributes[0].Value = e.NewValues[0].ToString();
                    n.Attributes[1].Value = e.NewValues[1].ToString();

                }
                i++;
            }



            xmlDoc.Save(@webPath);
            webTable.EditIndex = -1;

            Page_Load(Server, e);
        }

        protected void CancelEditWeb(object sender, GridViewCancelEditEventArgs e)
        {
            webTable.EditIndex = -1;
            Page_Load(Server, e);
        }

        public void changeEditor(object sender, EventArgs e)
        {
            appTable.Visible = false;
            kioskTable.Visible = false;
            locTable.Visible = false;
            originTable.Visible = false;
            posTable.Visible = false;
            valetTable.Visible = false;
            webTable.Visible = false;


            switch (EditList.SelectedValue) {
                case "App":
                    appTable.Visible = true;
                    locPath = appPath;
                    //Create new data set and sets it to equal the Address Book 
                    DataSet ds = new DataSet();
                    ds.ReadXml(@appPath);
                    //Create 2 DataTable's (Work better with GridView)
                    DataTable temp = ds.Tables[0];
                    DataTable dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("DispType");
                    dt.Columns.Add("issue");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    appTable.DataSource = dt.DefaultView;
                    appTable.DataBind();
                    break;
                case "Kiosk":
                    kioskTable.Visible = true;
                    locPath = kioskPath;
                    //Create new data set and sets it to equal the Address Book 
                    ds = new DataSet();
                    ds.ReadXml(@kioskPath);
                    //Create 2 DataTable's (Work better with GridView)
                    temp = ds.Tables[0];
                    dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("DispType");
                    dt.Columns.Add("issue");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    kioskTable.DataSource = dt.DefaultView;
                    kioskTable.DataBind();
                    break;
                case "Location":
                    locTable.Visible = true;
                    locPath = locationPath;
                    //Create new data set and sets it to equal the Address Book 
                    ds = new DataSet();
                    ds.ReadXml(@locationPath);
                    //Create 2 DataTable's (Work better with GridView)
                    temp = ds.Tables[0];
                    dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("Location");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    locTable.DataSource = dt.DefaultView;
                    locTable.DataBind();
                    break;
                case "Origin":
                    originTable.Visible = true;
                    locPath = originPath;
                    //Create new data set and sets it to equal the Address Book 
                    ds = new DataSet();
                    ds.ReadXml(@originPath);
                    //Create 2 DataTable's (Work better with GridView)
                    temp = ds.Tables[0];
                    dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("OriginType");
                    dt.Columns.Add("Hint");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    originTable.DataSource = dt.DefaultView;
                    originTable.DataBind();
                    break;
                case "POS":
                    posTable.Visible = true;
                    locPath = posPath;
                    //Create new data set and sets it to equal the Address Book 
                    ds = new DataSet();
                    ds.ReadXml(@posPath);
                    //Create 2 DataTable's (Work better with GridView)
                    temp = ds.Tables[0];
                    dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("DispType");
                    dt.Columns.Add("issue");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    posTable.DataSource = dt.DefaultView;
                    posTable.DataBind();
                    break;
                case "Valet":
                    valetTable.Visible = true;
                    locPath = valetPath;
                    //Create new data set and sets it to equal the Address Book 
                    ds = new DataSet();
                    ds.ReadXml(@valetPath);
                    //Create 2 DataTable's (Work better with GridView)
                    temp = ds.Tables[0];
                    dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("DispType");
                    dt.Columns.Add("issue");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    valetTable.DataSource = dt.DefaultView;
                    valetTable.DataBind();
                    break;
                case "Web":
                    webTable.Visible = true;
                    locPath = valetPath;
                    //Create new data set and sets it to equal the Address Book 
                    ds = new DataSet();
                    ds.ReadXml(@webPath);
                    //Create 2 DataTable's (Work better with GridView)
                    temp = ds.Tables[0];
                    dt = new DataTable();
                    //Get the current location from the drop down menu and set it as an integer
                    //int locationIndex = locIndex.SelectedIndex;
                    //Create an empty integer list

                    //Add columns to the data table
                    dt.Columns.Add("DispType");
                    dt.Columns.Add("issue");

                    //Import rows from data table temp to data table dt
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        //if (menuId[x] == locationIndex)

                        dt.ImportRow(temp.Rows[x]);

                    }

                    webTable.DataSource = dt.DefaultView;
                    webTable.DataBind();
                    break;
            }

        }
    }
}

        