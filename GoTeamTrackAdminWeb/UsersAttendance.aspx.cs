using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsersAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
            DataTable dtUsers = theDataSet.Tables[0];
            dtUsers.DefaultView.RowFilter = "TCode='" + SessionManager.LoggedInTCode + "'";
            dtUsers.Rows.Add(0, " -SELECT- ");
            dtUsers.DefaultView.Sort = "Name";
            ddlMember.DataSource = dtUsers;
            ddlMember.DataTextField = "Name";
            ddlMember.DataValueField = "UCode";
            ddlMember.DataBind();

        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        DataSet locationDataSet = new DataSet();
        string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddlMember.SelectedValue + "/" + ddlMember.SelectedValue + "_in_out_log.cs");
        string getInOutDatafromFile = File.ReadAllText(Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddlMember.SelectedValue + "/" + ddlMember.SelectedValue + "_in_out_log.cs"));
        if (File.Exists(path))
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DutyTime", typeof(string));
            dt.Columns.Add("DutyStatus", typeof(string));
            dt.Columns.Add("UCode", typeof(string));


            string[] getInOutTime = getInOutDatafromFile.Split('#');
            for (int i = 0; i < getInOutTime.Length; i++)
            {
                string[] tempData = getInOutTime[i].Split(',');
                if (tempData.Length == 2)
                {
                    dt.Rows.Add(tempData[0], tempData[1], ddlMember.SelectedValue);
                }
            }

            dt.DefaultView.Sort = "DutyTime desc";
            rptrUsersAttendance.DataSource = dt;
            rptrUsersAttendance.DataBind();
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
