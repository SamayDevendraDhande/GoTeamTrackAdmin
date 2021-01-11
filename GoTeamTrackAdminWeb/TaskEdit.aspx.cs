using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TaskEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
            DataTable dtUsers = theDataSet.Tables[0];
            dtUsers.Rows.Add("", "", "None", "", SessionManager.LoggedInTCode, true, "");
            dtUsers.DefaultView.RowFilter = "TCode = '" + SessionManager.LoggedInTCode + "' AND IsActive = 'True'";
            dtUsers.DefaultView.Sort = "Name";
            ddlUser.DataSource = dtUsers;
            ddlUser.DataTextField = "Name";
            ddlUser.DataValueField = "UCode";
            ddlUser.DataBind();
            ddlUser.SelectedValue = "";

            string tid = Request.QueryString["TID"];
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);
            theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);

            if (drow.Length == 1)
            {
                txtCreateDate.Text = drow[0]["CreateDate"] != DBNull.Value ? Convert.ToDateTime(drow[0]["CreateDate"]).ToString("dd-MM-yyyy") : "";
                txtTask.Text = drow[0]["Task"].ToString();
                txtTargetDate.Text = drow[0]["TargetDate"] != DBNull.Value ? Convert.ToDateTime(drow[0]["TargetDate"]).ToString("dd-MM-yyyy") : "";
                ddlUser.SelectedValue = drow[0]["UCode"].ToString();
                ddlStatus.SelectedValue = drow[0]["Status"].ToString();
                txtRemarks.Text = drow[0]["Remarks"].ToString();
                txtRemarksDate.Text = drow[0]["RemarksDate"] != DBNull.Value ? Convert.ToDateTime(drow[0]["RemarksDate"]).ToString("dd-MM-yyyy") : "";

                //if (drow[0]["RemarksDate"].ToString() != "")
                //{
                //    txtRemarksDate.Text = CommonUtility.StringToDateTime(drow[0]["RemarksDate"].ToString(), "dd-MM-yyyy hh:mm:ss tt").Value.ToString("dd-MM-yyyy");
                //}
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        string path = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
        theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
        DataTable dt = theDataSet.Tables[0];
        long timestamp = Convert.ToInt64(Request.QueryString["TID"]);
        DataRow[] row = dt.Select("Timestamp = " + timestamp);
        row[0]["Status"] = ddlUser.SelectedValue == "" ? "Unallocated" : ddlStatus.SelectedValue;

        //row[0]["Timestamp"] = Convert.ToInt64(row[0]["Timestamp"]);
        row[0]["Task"] = txtTask.Text;
        if (ddlUser.SelectedValue != "")
        {
            row[0]["UCode"] = ddlUser.SelectedValue;
            row[0]["Name"] = ddlUser.SelectedItem.Text;
            if(row[0]["Status"].ToString() == "Unallocated")
            {
                row[0]["Status"] = "Pending";
            }
        }
        else
        {
            row[0]["UCode"] = "";
            row[0]["Name"] = "";
        }

        var TargetDate = CommonUtility.StringToDateTime(txtTargetDate.Text, "dd-MM-yyyy");
        if (TargetDate.HasValue)
        {
            row[0]["TargetDate"] = TargetDate;
        }
        row[0]["Remarks"] = txtRemarks.Text;

        //dt.Rows.Add(row);

        dt.AcceptChanges();
        theDataSet.AcceptChanges();

        String xmldata = CommonUtility.DSToXml(theDataSet);
        String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
        File.WriteAllText(folderFiles, xmldata);

        Response.Redirect("TaskEdit.aspx?TID=" + Request.QueryString["TID"] + "&msg=success");
    }

    protected void btnUnallocated_Command(object sender, CommandEventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);

            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            drow[0]["Status"] = "Unallocated";

            dtTask.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles, xmldata);
            Response.Redirect("TaskEdit.aspx?TID=" + timestamp.ToString());

        }
    }

    protected void btnPending_Command(object sender, CommandEventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);

            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            drow[0]["Status"] = "Pending";

            dtTask.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles, xmldata);
            Response.Redirect("TaskEdit.aspx?TID=" + timestamp.ToString());

        }
    }

    protected void btnCompleted_Command(object sender, CommandEventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);

            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            drow[0]["Status"] = "Completed";

            dtTask.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles, xmldata);
            Response.Redirect("TaskEdit.aspx?TID=" + timestamp.ToString());

        }
    }

    protected void btnClosed_Command(object sender, CommandEventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            long timestamp = Convert.ToInt64(Request.QueryString["TID"]);

            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            //drow[0]["Status"] = "Closed";



            DataSet theDataSet2 = new DataSet();
            theDataSet2.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs"));
            DataTable dtTask2 = theDataSet2.Tables[0];

            DataRow row = dtTask2.NewRow();

            row["Timestamp"] = drow[0]["Timestamp"];
            row["Task"] = drow[0]["Task"];
            row["Status"] = drow[0]["Status"];
            row["UCode"] = drow[0]["UCode"];
            row["Name"] = drow[0]["Name"];
            row["CreateDate"] = drow[0]["CreateDate"];
            row["TargetDate"] = drow[0]["TargetDate"];
            row["Remarks"] = drow[0]["Remarks"];
            row["RemarksDate"] = drow[0]["RemarksDate"];

            dtTask2.Rows.Add(row);

            dtTask2.AcceptChanges();
            theDataSet2.AcceptChanges();

            drow[0].Delete();

            dtTask.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles, xmldata);
            //Response.Redirect("TaskListOnGoing.aspx");

            String xmldata2 = CommonUtility.DSToXml(theDataSet2);
            String folderFiles2 = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs");
            File.WriteAllText(folderFiles2, xmldata2);
            Response.Redirect("TaskEdit.aspx?TID=" + timestamp.ToString());

        }
    }
}
