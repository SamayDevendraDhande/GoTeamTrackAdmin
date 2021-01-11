using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserTaskDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
            DataTable dtUsers = theDataSet.Tables[0];
            DataRow[] drowU = dtUsers.Select("UCode = '" + SessionManager.LoggedInUCode + "'");
            //dtUsers.Rows.Add("", "", "None", "", SessionManager.LoggedInTCode, true, "");
            //dtUsers.DefaultView.RowFilter = "TCode = '" + SessionManager.LoggedInTCode + "' AND IsActive = 'True'";
            //dtUsers.DefaultView.Sort = "Name";
            //ddlUser.DataSource = dtUsers;
            //ddlUser.DataTextField = "Name";
            //ddlUser.DataValueField = "UCode";
            //ddlUser.DataBind();
            //ddlUser.SelectedValue = "";

            /*string tid = Request.QueryString["TID"];
            string status = Request.QueryString["status"];
            if(status == "Completed")
            {
                lnkBtnCompleted.Visible = true;
                lnkBtnReply.Visible = false;
            }
            if (status == "Reply")
            {
                lnkBtnCompleted.Visible = false;
                lnkBtnReply.Visible = true;
            }*/

            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);
            theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + drowU[0]["TCode"] + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);

            if (drow.Length == 1)
            {
                lblCreateDate.Text = drow[0]["CreateDate"] != DBNull.Value ? Convert.ToDateTime(drow[0]["CreateDate"]).ToString("dd-MM-yyyy") : "";
                lblTask.Text = drow[0]["Task"].ToString();
                lblTargetDate.Text = drow[0]["TargetDate"] != DBNull.Value ? Convert.ToDateTime(drow[0]["TargetDate"]).ToString("dd-MM-yyyy") : "";

                lblStatus.Text = drow[0]["Status"].ToString();
                txtRemarks.Text = drow[0]["Remarks"].ToString();
                lblRemarksDate.Text = drow[0]["RemarksDate"] != DBNull.Value ? Convert.ToDateTime(drow[0]["RemarksDate"]).ToString("dd-MM-yyyy") : "";

                //if (drow[0]["RemarksDate"].ToString() != "")
                //{
                //    txtRemarksDate.Text = CommonUtility.StringToDateTime(drow[0]["RemarksDate"].ToString(), "dd-MM-yyyy hh:mm:ss tt").Value.ToString("dd-MM-yyyy");
                //}
            }
        }
    }


    protected void btnCompleted_Command(object sender, CommandEventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);



            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInUTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            drow[0]["Status"] = "Completed";
            drow[0]["RemarksDate"] = DateTime.Now.Date.ToString();
            dtTask.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInUTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles, xmldata);
            Response.Redirect("UserTaskDetail.aspx?TID=" + timestamp.ToString());

        }
    }

    protected void btnReply_Command(object sender, CommandEventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);

            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInUTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            drow[0]["Status"] = "Reply";
            drow[0]["RemarksDate"] = DateTime.Now.Date.ToString();
            dtTask.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInUTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles, xmldata);
            Response.Redirect("UserTaskDetail.aspx?TID=" + timestamp.ToString());

        }
    }
}
