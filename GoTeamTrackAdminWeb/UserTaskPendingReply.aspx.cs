using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserTaskPendingReply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            DataSet theDataSet = new DataSet();
            string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInUTCode + "/TaskOngoing.cs");
            theDataSet.ReadXml(path);
            DataTable dtTask = theDataSet.Tables[0];
            string filter = "";

            filter = "UCode = '" + SessionManager.LoggedInUCode + "' AND Status = 'Pending'";

            dtTask.DefaultView.RowFilter = filter;

            dtTask.DefaultView.Sort = "Task";
            rptrPendingTask.DataSource = dtTask;
            rptrPendingTask.DataBind();

            filter = "UCode = '" + SessionManager.LoggedInUCode + "' AND Status = 'Reply'";

            dtTask.DefaultView.RowFilter = filter;

            dtTask.DefaultView.Sort = "Task";
            rptrReplyTasks.DataSource = dtTask;
            rptrReplyTasks.DataBind();





        }
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


}
