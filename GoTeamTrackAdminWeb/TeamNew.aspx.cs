using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeamNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(SessionManager.LoggedInTCode != "admin")
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbteams.cs"));
        DataTable dt = theDataSet.Tables[0];
        DataRow[] drow = dt.Select("TCode = '" + txtTeamCode.Text + "'");
        if (drow.Length > 0)
        {
            ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "btnSave", "alert('TCode already used.')", true);
            return;
        }

        DataRow row;
        row = dt.NewRow();

        row["TCode"] = txtTeamCode.Text;
        row["Password"] = txtPassword.Text;
        row["TeamName"] = txtTeamName.Text;
        row["IsActive"] = chkActive.Checked;
        row["StartDate"] = CommonUtility.StringToDateTime(txtStartDate.Text, "dd-MM-yyyy").Value.ToString("yyyy-MM-dd HH:mm:ss");
        row["EndDate"] = CommonUtility.StringToDateTime(txtEndDate.Text, "dd-MM-yyyy").Value.ToString("yyyy-MM-dd HH:mm:ss");
        row["Remarks"] = txtRemarks.Text;
        row["MaxUsers"] = txtMaxUsers.Text;


        dt.Rows.Add(row);

        dt.AcceptChanges();
        theDataSet.AcceptChanges();

        String xmldata = CommonUtility.DSToXml(theDataSet);
        File.WriteAllText(Server.MapPath("AllTeams/dbteams.cs"), xmldata);

        String folderFiles = Server.MapPath("AllTeams/" + txtTeamCode.Text);
        System.IO.Directory.CreateDirectory(folderFiles);

        CreateTaskFiles(txtTeamCode.Text);

        Response.Redirect("TeamNew.aspx?msg=success");
    }

    protected void CreateTaskFiles(string TeamCode)
    {
        DataTable dt = new DataTable("Ongoing");
        dt.Columns.Add("Timestamp", typeof(long));
        dt.Columns.Add("Task", typeof(string));
        dt.Columns.Add("Status", typeof(string));
        dt.Columns.Add("UCode", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("CreateDate", typeof(DateTime));
        dt.Columns.Add("TargetDate", typeof(DateTime));
        dt.Columns.Add("Remarks", typeof(string));
        dt.Columns.Add("RemarksDate", typeof(DateTime));

        DataRow row;
        row = dt.NewRow();

        row["Timestamp"] = DateTime.Now.Ticks.ToString();
        row["Task"] = "Task1";
        row["Status"] = "Status1";
        row["UCode"] = "usercode1";
        row["Name"] = "Name1";
        row["CreateDate"] = DateTime.Now;
        row["TargetDate"] = DateTime.Today;

        dt.Rows.Add(row);
        dt.AcceptChanges();

        DataSet theDataSet = new DataSet();
        theDataSet.Tables.Add(dt);
        theDataSet.AcceptChanges();

        string xmldata = CommonUtility.DSToXml(theDataSet);

        string OngoingTaskFile = Server.MapPath("AllTeams/" + TeamCode + "/TaskOngoing.cs");
        File.WriteAllText(OngoingTaskFile, xmldata);

        string CompletedTaskFile = Server.MapPath("AllTeams/" + TeamCode + "/TaskClosed.cs");
        File.WriteAllText(CompletedTaskFile, xmldata);

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CreateTaskFiles(SessionManager.LoggedInTCode);

    }
}