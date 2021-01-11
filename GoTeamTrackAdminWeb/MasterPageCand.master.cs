using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
//using SamaySoftware.OnlineTest.Lib;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(SessionManager.LoggedInTCode))
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] != null)
            {
                string jscript101 = "alert('" + Request.QueryString["msg"] + "');";
                //ScriptManager.RegisterStartupScript(ltlName, ltlName.GetType(), "jscript101", jscript101, true);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(SessionManager.AlertMessage))
        {
            string jscript1122 = "alert('" + SessionManager.AlertMessage + "');";
            ScriptManager.RegisterStartupScript(ContentPlaceHolder1, ContentPlaceHolder1.GetType(), "jscript1122", jscript1122, true);
            SessionManager.AlertMessage = null;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(SessionManager.AlertMessage))
        {
            string jscript1122 = "alert('" + SessionManager.AlertMessage + "');";
            ScriptManager.RegisterStartupScript(ContentPlaceHolder1, ContentPlaceHolder1.GetType(), "jscript1122", jscript1122, true);
            SessionManager.AlertMessage = null;
        }
    }
}
