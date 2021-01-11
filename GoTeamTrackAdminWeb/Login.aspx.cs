using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        errorDiv.Visible = false;
        ForgotPasswordDiv.Visible = false;

        SessionManager.LoggedInTCode = "";
        SessionManager.LoggedInTName = ""; 
        SessionManager.LoggedInUCode = "";
        SessionManager.LoggedInUName = "";
        SessionManager.LoggedInUTCode = "";
        SessionManager.LoggedInUTName = "";

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        DataSet theDataSetUser = new DataSet();
        theDataSetUser.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dtUser = theDataSetUser.Tables[0];
        DataRow[] drowUser = dtUser.Select("UCode = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "'");
        if (drowUser.Length > 0)
        {

            DataSet theDataSetTeam = new DataSet();
            theDataSetTeam.ReadXml(Server.MapPath("AllTeams/dbteams.cs"));
            DataTable dtTeam = theDataSetTeam.Tables[0];
            DataRow[] drowTeam = dtTeam.Select("TCode = '" + drowUser[0]["TCode"].ToString() + "'");


            SessionManager.LoggedInUCode= drowUser[0]["UCode"].ToString();
            SessionManager.LoggedInUName= drowUser[0]["Name"].ToString();
            SessionManager.LoggedInUTCode = drowUser[0]["TCode"].ToString();

            if(drowTeam.Length == 1)
            {
                SessionManager.LoggedInUTName = drowTeam[0]["TeamName"].ToString();
            }

            Response.Redirect("UserTaskPendingReply.aspx");
            return;
        }

        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbteams.cs"));
        DataTable dt = theDataSet.Tables[0];
        DataRow[] drow = dt.Select("TCode = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "'");
        if (drow.Length > 0)
        {
            SessionManager.LoggedInTCode = drow[0]["TCode"].ToString();
            SessionManager.LoggedInTName = drow[0]["TeamName"].ToString();
            Response.Redirect("AdminDashboard.aspx");
            return;
        }

    }
    private void ErrorMessage()
    {
        errorDiv.Visible = true;
    }
}
