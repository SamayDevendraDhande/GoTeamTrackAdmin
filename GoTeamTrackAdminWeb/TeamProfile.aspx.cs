using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeamProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbteams.cs"));
        DataTable dt = theDataSet.Tables[0];
        DataRow[] drow = dt.Select("TCode = '" + SessionManager.LoggedInTCode + "'");

        txtTeamCode.Text = drow[0]["TCode"].ToString();
        txtTeamName.Text = drow[0]["TeamName"].ToString();
        txtStartDate.Text = drow[0]["StartDate"].ToString();
        txtEndDate.Text = drow[0]["EndDate"].ToString();
        txtMaxUsers.Text = drow[0]["MaxUsers"].ToString();
        chkActive.Checked = Convert.ToBoolean(drow[0]["IsActive"]);
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    DataSet theDataSet = new DataSet();
    //    theDataSet.ReadXml(Server.MapPath("AllTeams/dbteams.cs"));
    //    DataTable dt = theDataSet.Tables[0];
    //    DataRow[] drow = dt.Select("TCode = '" + txtTeamCode.Text + "'");
    //    if (drow.Length > 0)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "btnSave", "alert('TCode already used.')", true);
    //        return;
    //    }

    //    DataRow row;
    //    row = dt.NewRow();

    //    row["TCode"] = txtTeamCode.Text;
    //    row["Password"] = txtPassword.Text;
    //    row["TeamName"] = txtTeamName.Text;
    //    row["IsActive"] = chkActive.Checked;
    //    row["StartDate"] = CommonUtility.StringToDateTime(txtStartDate.Text, "dd-MM-yyyy").Value.ToString("yyyy-MM-dd HH:mm:ss");
    //    row["EndDate"] = CommonUtility.StringToDateTime(txtEndDate.Text, "dd-MM-yyyy").Value.ToString("yyyy-MM-dd HH:mm:ss");
    //    row["Remarks"] = txtRemarks.Text;
    //    row["MaxUsers"] = txtMaxUsers.Text;


    //    dt.Rows.Add(row);

    //    dt.AcceptChanges();
    //    theDataSet.AcceptChanges();

    //    String xmldata = CommonUtility.DSToXml(theDataSet);
    //    File.WriteAllText(Server.MapPath("AllTeams/dbteams.cs"), xmldata);

    //    String folderFiles = Server.MapPath("AllTeams/" + txtTeamCode.Text);
    //    System.IO.Directory.CreateDirectory(folderFiles);


    //    Response.Redirect("TeamNew.aspx");
    //}
}