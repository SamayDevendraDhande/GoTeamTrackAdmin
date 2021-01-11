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
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //if (!SessionManager.LoggedInUserDetail.UserDetailID.HasValue || SessionManager.LoggedInUserDetail.UserDetailID <= 0)
        //{
        //    //Response.Redirect("../Index.aspx");
        //    if (Request.Cookies["usertype"].Value == "admin")
        //    {
        //        List<UserDetail> lstUd = UserDetailBLL.SelectList(new UserDetail() { Username = Request.Cookies["username"].Value, Password = Request.Cookies["password"].Value });

        //        if (lstUd.Count == 1)
        //        {
        //            SessionManager.LoggedInUserDetail = lstUd[0];
        //            SessionManager.LoggedInStudent = null;
        //            Session["newlogin"] = "1";

        //            var cookie1 = new HttpCookie("usertype", "admin");
        //            var cookie2 = new HttpCookie("username", Request.Cookies["username"].Value);
        //            var cookie3 = new HttpCookie("password", Request.Cookies["password"].Value);
        //            cookie1.Expires = DateTime.Today.AddYears(2);
        //            cookie2.Expires = DateTime.Today.AddYears(2);
        //            cookie3.Expires = DateTime.Today.AddYears(2);
        //            Response.Cookies.Add(cookie1);
        //            Response.Cookies.Add(cookie2);
        //            Response.Cookies.Add(cookie3);

        //            //Response.Redirect("web/AdminDashboard.aspx");
        //            //return;
        //        }
        //        else
        //        {
        //            Response.Redirect("../Index.aspx");
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("../Index.aspx");
        //    }
        //}

        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] != null)
            {
                string jscript101 = "alert('" + Request.QueryString["msg"] + "');";
                ScriptManager.RegisterStartupScript(ltlName, ltlName.GetType(), "jscript101", jscript101, true);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //PlaceHolderStaff.Visible = true;
        //ltlName.Text = SessionManager.LoggedInUserDetail.Name;

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
