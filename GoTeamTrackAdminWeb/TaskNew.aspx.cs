using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TaskNew : System.Web.UI.Page
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
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        string path = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
        theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
        DataTable dt = theDataSet.Tables[0];
        //DataRow[] drow = dt.Select("TCode = '" + txtTeamCode.Text + "'");
        //if (drow.Length > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "btnSave", "alert('TCode already used.')", true);
        //    return;
        //}

        DataRow row;
        row = dt.NewRow();

        row["Timestamp"] = DateTime.Now.Ticks.ToString();
        row["Task"] = txtTask.Text;
        if (ddlUser.SelectedValue != "")
        {
            row["UCode"] = ddlUser.SelectedValue;
            row["Name"] = ddlUser.SelectedItem.Text;
            row["Status"] = "Pending";
        }
        else
        {
            row["UCode"] = "";
            row["Name"] = "";
            row["Status"] = "Unallocated";
        }
        string dateC = DateTime.Now.Date.ToString();
        row["CreateDate"] = DateTime.Now.Date.ToString();
        var TargetDate = CommonUtility.StringToDateTime(txtTargetDate.Text, "dd-MM-yyyy");
        if (TargetDate.HasValue)
        {
            row["TargetDate"] = TargetDate;
        }
        else
        {
            row["TargetDate"] = DateTime.Today;
        }
        dt.Rows.Add(row);

        dt.AcceptChanges();
        theDataSet.AcceptChanges();

        String xmldata = CommonUtility.DSToXml(theDataSet);
        String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
        File.WriteAllText(folderFiles, xmldata);

        Response.Redirect("TaskNew.aspx?msg=success");
    }
}
