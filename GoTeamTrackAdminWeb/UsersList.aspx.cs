using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsersList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dtUsers = theDataSet.Tables[0];
        dtUsers.DefaultView.RowFilter = "TCode = '" + SessionManager.LoggedInTCode + "'";
        dtUsers.DefaultView.Sort = "Name";
        rptrUsers.DataSource = dtUsers;
        rptrUsers.DataBind();


    }
}