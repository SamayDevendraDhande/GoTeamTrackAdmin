using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TaskListClosed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet theDataSet = new DataSet();
            string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs");
            theDataSet.ReadXml(path);
            DataTable dtTask = theDataSet.Tables[0];
            string title = "Closed Tasks ";
            

            string filter = "";
            if (Request.QueryString["ucode"] != null)
            {
                filter = "UCode = '" + Request.QueryString["ucode"] + "' ";
                title += " - " + Request.QueryString["ucode"];
            }

            lblClosedTitle.Text = title;
            dtTask.DefaultView.RowFilter = filter;

            dtTask.DefaultView.Sort = "Task";
            rptrTaskOngoing.DataSource = dtTask;
            rptrTaskOngoing.DataBind();
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        
    }

    public static string DataTabletoJSON(DataTable dt)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, object> row = null;
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.DataType == typeof(DateTime))
                {
                    row.Add(dc.ColumnName, dr[dc] != DBNull.Value ? Convert.ToDateTime(dr[dc]).ToString("yyyy-MM-dd#HH:mm") : "");
                }
                else
                {
                    row.Add(dc.ColumnName, dr[dc] != DBNull.Value ? dr[dc] : "");
                }
            }
            rows.Add(row);
        }
        return jss.Serialize(rows);
    }



    static DataTable ConvertListToDataTable(List<string[]> list)
    {
        // New table.
        DataTable table = new DataTable();

        // Get max columns.
        int columns = 0;
        foreach (var array in list)
        {
            if (array.Length > columns)
            {
                columns = array.Length;
            }
        }

        // Add columns.
        for (int i = 0; i < columns; i++)
        {
            //table.Columns.Add();
            table.Columns[i].ColumnName = list[0][i];
        }

        // Add rows.
        foreach (var array in list)
        {
            table.Rows.Add(array);
        }

        return table;
    }

    protected void btnClosedUsers_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            DataSet theDataSet = new DataSet();
            string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs");
            theDataSet.ReadXml(path);
            DataTable dtTask = theDataSet.Tables[0];
            dtTask.DefaultView.RowFilter = "UCode = '" + e.CommandArgument.ToString() + "'";

            dtTask.DefaultView.Sort = "Task";
            rptrTaskOngoing.DataSource = dtTask;
            rptrTaskOngoing.DataBind();
        }
    }

    protected void btnPending_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            long timestamp = Convert.ToInt64(e.CommandArgument.ToString());


            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs"));
            DataTable dtTask = theDataSet.Tables[0];


            DataRow[] drow = dtTask.Select("Timestamp = " + timestamp);
            //drow[0]["Status"] = "Closed";



            DataSet theDataSet2 = new DataSet();
            theDataSet2.ReadXml(Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs"));
            DataTable dtTask2 = theDataSet2.Tables[0];

            DataRow row = dtTask2.NewRow();

            row["Timestamp"] = drow[0]["Timestamp"];
            row["Task"] = drow[0]["Task"];
            row["Status"] = "Pending";
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
            String folderFiles = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs");
            File.WriteAllText(folderFiles, xmldata);
            //Response.Redirect("TaskListOnGoing.aspx");

            String xmldata2 = CommonUtility.DSToXml(theDataSet2);
            String folderFiles2 = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
            File.WriteAllText(folderFiles2, xmldata2);
            Response.Redirect("TaskListOnGoing.aspx");

        }
    }
}
