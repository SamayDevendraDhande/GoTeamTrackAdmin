using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AttendanceReport : System.Web.UI.Page
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

            string pastYear = DateTime.Now.AddYears(-1).Year + "";
            ddlYear.Items.Add(pastYear);
            string currentYear = DateTime.Now.Year + "";
            ddlYear.Items.Add(currentYear);
            string nextYear = DateTime.Now.AddYears(1).Year + "";
            ddlYear.Items.Add(nextYear);

            ddlYear.SelectedValue = currentYear;

            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length; i++)
            {
                ddlMonth.Items.Add(new ListItem(months[i], i.ToString()));
            }

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dtUsers = theDataSet.Tables[0];
        dtUsers.DefaultView.RowFilter = "TCode = '" + SessionManager.LoggedInTCode + "' AND IsActive = 'True'";

        DataTable dt = new DataTable();
        dt.Columns.Add("UserName", typeof(string));
        dt.Columns.Add("UCode", typeof(string));
        dt.Columns.Add("FullDaysCount", typeof(string));
        dt.Columns.Add("HalfDaysCount", typeof(string));
        dt.Columns.Add("OtherDaysCount", typeof(string));
        dt.Columns.Add("DutyTime", typeof(DateTime));
        dt.Columns.Add("DutyStatus", typeof(string));

        for (int i = 0; i < dtUsers.Rows.Count; i++)
        {
            string usercode = dtUsers.Rows[i]["UCode"].ToString();
            string username = dtUsers.Rows[i]["Name"].ToString();
            

            string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + usercode + "/" + usercode + "_in_out_log.cs");

            if (File.Exists(path))
            {
                DataSet locationDataSet = new DataSet();
                string getInOutDatafromFile = File.ReadAllText(path);
                if (File.Exists(path))
                {

                    string[] getInOutTime = getInOutDatafromFile.Split('#');
                    for (int j = 0; j < getInOutTime.Length; j++)
                    {
                        string[] tempData = getInOutTime[j].Split(',');
                        if (tempData.Length == 2)
                        {
                            dt.Rows.Add(username, usercode, "1", "0", "0", tempData[0], tempData[1]);
                        }
                    }

                    dt.DefaultView.Sort = "UserName";
                    rptrUsersAttendance.DataSource = dt;
                    rptrUsersAttendance.DataBind();
                }
            }
        }

        //DataSet locationDataSet = new DataSet();
        //string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddlMember.SelectedValue + "/" + ddlMember.SelectedValue + "_in_out_log.cs");
        //string getInOutDatafromFile = File.ReadAllText(Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddlMember.SelectedValue + "/" + ddlMember.SelectedValue + "_in_out_log.cs"));
        //if (File.Exists(path))
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("DutyTime", typeof(string));
        //    dt.Columns.Add("DutyStatus", typeof(string));
        //    dt.Columns.Add("UCode", typeof(string));


        //    string[] getInOutTime = getInOutDatafromFile.Split('#');
        //    for (int i = 0; i < getInOutTime.Length; i++)
        //    {
        //        string[] tempData = getInOutTime[i].Split(',');
        //        if (tempData.Length == 2)
        //        {
        //            dt.Rows.Add(tempData[0], tempData[1], ddlMember.SelectedValue);
        //        }
        //    }

        //    dt.DefaultView.Sort = "DutyTime desc";
        //    rptrUsersAttendance.DataSource = dt;
        //    rptrUsersAttendance.DataBind();
        //}


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
