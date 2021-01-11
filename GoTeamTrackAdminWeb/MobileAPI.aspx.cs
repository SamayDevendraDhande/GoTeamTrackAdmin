using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class MobileAPI : System.Web.UI.Page
{
    //DataRow[] drow;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string method = Request.Params["method"];
            if (Request.Params["method"] != null && Request.Params["ucode"] != null && Request.Params["password"] != null)
            {
                // 0=invalid user
                // 1=valid user
                // 2=invalid method
                // 3 = invalid input
                // 4 = server error
                // 5 = success

                #region ValidateUser
                string usercode = Request.Params["ucode"];
                string password = Request.Params["password"];

                string uname = "";
                string tname = "";

                DataSet theDataSet = new DataSet();
                theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
                DataTable dt = theDataSet.Tables[0];
                DataRow[] drow = dt.Select("UCode = '" + usercode + "' AND Password = '" + password + "'");

                if (drow.Length == 0)
                {
                    Response.Write("{\"responsecode\":\"0\"}"); // 0 = invalid user
                    return;
                }
                if(drow.Length == 1)
                {

                    DataSet theDataSetTeam = new DataSet();
                    theDataSetTeam.ReadXml(Server.MapPath("AllTeams/dbteams.cs"));
                    DataTable dtTeam = theDataSetTeam.Tables[0];
                    DataRow[] drowTeam = dtTeam.Select("TCode = '" + drow[0]["TCode"].ToString() + "'");

                    uname = drow[0]["Name"].ToString();
                    tname = drowTeam[0]["TeamName"].ToString();
                }
                #endregion

                switch (Request.Params["method"])
                {
                    case "mlogin":
                        mlogin(uname, tname);
                        break;
                    case "msyncdata":
                        msyncdata();
                        break;
                    case "mtasklist":
                        mtasklist();
                        break;
                    case "mtaskupdate":
                        mtaskupdate();
                        break;

                    default:
                        Response.Write("{\"responsecode\":\"2\"}"); // 2 = invalid method
                        return;
                }
            }
            else
            {
                Response.Write("{\"responsecode\":\"3\"}"); // 3 = invalid input
                return;
            }
        }
        catch (Exception ex)
        {
            string exc = ex.ToString();
            Response.Write("{\"responsecode\":\"4\"}"); // 4 = server error
            return;
        }
    }

    private void mlogin(string uname, string tname)
    {
        Response.Write("{\"responsecode\":\"1\",\"uname\": \"" + uname + "\",\"tname\": \"" + tname + "\"}"); // 1 = valid user
        return;
    }
    private void msyncdata()
    {

        String a = Request.Params["inout"];
        String b = Request.Params["gps"];
        if (Request.Params["inout"] != null && Request.Params["gps"] != null)
        {
            //- <UCode>_in_out_log.cs[Permanent log file for OnDuty & OffDuty of the user] >> LogDtm##--##LogType
            //- <UCode>_20200801.cs[Date wise log file for every user] >> LogDtm##--##GPSLat##--##GPSLon

            //drow[0]["UCode"]
            //drow[0]["TCode"]
            //drow[0]["UCode"] +"_"+ DateTime.Today.ToString("yyyyMMdd")+".cs";
            //File.AppendAllText()

            String InOutLog = Request.Params["inout"];
            String LocationLog = Request.Params["gps"];
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
            DataTable dt = theDataSet.Tables[0];

            string usercode = Request.Params["ucode"];
            string password = Request.Params["password"];

            DataRow[] drow = dt.Select("UCode = '" + usercode + "' AND Password = '" + password + "'");
            //int i = drow.Length;
            // string aa = drow[0]["TCode"].ToString();




            string[] locationlog = LocationLog.Split('#');


            for (int j = 0; j < locationlog.Length; j++)
            {
                string[] data = locationlog[j].Split(',');
                if (data.Length == 3)
                {
                    string locationDate = CommonUtility.StringToDateTime(data[0], "yyyy-MM-dd HH:mm:ss").Value.ToString("yyyyMMdd");

                    //String userGPSTrackFile = Server.MapPath("AllTeams/" + drow[0]["TCode"].ToString() + "/" + drow[0]["UCode"].ToString() + "/" + drow[0]["UCode"].ToString() + DateTime.Today.ToString("yyyyMMdd") + ".cs");
                    String userGPSTrackFile = Server.MapPath("AllTeams/" + drow[0]["TCode"].ToString() + "/" + drow[0]["UCode"].ToString() + "/" + drow[0]["UCode"].ToString() + locationDate + ".cs");

                    File.AppendAllText(userGPSTrackFile, locationlog[j] + "#");
                }


            }






            String userInOutFile = Server.MapPath("AllTeams/" + drow[0]["TCode"].ToString() + "/" + drow[0]["UCode"].ToString() + "/" + drow[0]["UCode"].ToString() + "_in_out_log.cs");
            //    String userGPSTrackFile = Server.MapPath("AllTeams/" + drow[0]["TCode"].ToString() + "/" + drow[0]["UCode"].ToString() + "/" + drow[0]["UCode"].ToString() + DateTime.Today.ToString("yyyyMMdd") + ".cs");

            ////MobileAPI.aspx?method=msyncdata&ucode=User6&password=1234&inout=2020-09-10_12:00##--##&gps=89.00100,32.159874##--##
            ////MobileAPI.aspx?method=msyncdata&ucode=User6&password=1234&inout=2020-09-10_12:10%0d%0A&gps=2020-09-10_12:10%23%23--%23%2313.003322%23%23--%23%2380.223366%0d%0A

            File.AppendAllText(userInOutFile, InOutLog);
            //    File.AppendAllText(userGPSTrackFile, LocationLog);

            Response.Write("{\"responsecode\":\"1\"}"); // 1 = valid user
            return;
        }


    }

    private void mtasklist() // ucode, password, status
    {

        string usercode = Request.Params["ucode"];
        string password = Request.Params["password"];
        string status = Request.Params["status"];

        DataSet dsUsers = new DataSet();
        dsUsers.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dtUser = dsUsers.Tables[0];
        DataRow[] drow = dtUser.Select("UCode = '" + usercode + "' AND Password = '" + password + "'");

        if (Request.Params["status"].ToUpper() != "CLOSED") // ONGOING TASKS
        {
            DataSet dsTasks = new DataSet();
            string path = Server.MapPath("/AllTeams/" + drow[0]["TCode"].ToString() + "/TaskOngoing.cs");
            dsTasks.ReadXml(path);
            DataTable dtTask = dsTasks.Tables[0];
            string filter = "UCode = '" + Request.Params["ucode"] + "'  AND Status = '" + Request.Params["status"] + "'";

            dtTask.DefaultView.RowFilter = filter;
            dtTask.DefaultView.Sort = "TargetDate";
            string dataJson = DataTabletoJSON(dtTask.DefaultView.ToTable());


            //DataTable dt1 = new DataTable();
            //DataRow[] dr = dtTask.Select("UCode = '" + Request.Params["ucode"] + "'  AND Status = '" + Request.Params["status"] + "'");
            //if (dr.Length > 0)
            //{
            //    dt1 = dr.CopyToDataTable();
            //}
            //string dataJson = DataTabletoJSON(dt1);
            Response.Write(@"{""responsecode"":""1"", ""screen"": " + dataJson + "}");
            return;
        }
        else // CLOSED TASKS
        {
            DataSet dsTasks = new DataSet();
            string path = Server.MapPath("/AllTeams/" + drow[0]["TCode"].ToString() + "/TaskClosed.cs");
            dsTasks.ReadXml(path);
            DataTable dtTask = dsTasks.Tables[0];
            string filter = "UCode = '" + Request.Params["ucode"] + "'";

            dtTask.DefaultView.RowFilter = filter;
            dtTask.DefaultView.Sort = "TargetDate DESC";
            //string dataJson = DataTabletoJSON(dtTask.DefaultView.ToTable());
            string dataJson = DataTabletoJSON(dtTask.DefaultView.ToTable());

            Response.Write(@"{""responsecode"":""1"", ""screen"": " + dataJson + "}");
            return;

        }

    }

    private void mtaskupdate() // ucode, password, status, remarks, timestamp
    {

        string usercode = Request.Params["ucode"];
        string password = Request.Params["password"];

        DataSet dsUsers = new DataSet();
        dsUsers.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dtUser = dsUsers.Tables[0];
        DataRow[] drow = dtUser.Select("UCode = '" + usercode + "' AND Password = '" + password + "'");

        DataSet dsTasks = new DataSet();
        string path = Server.MapPath("/AllTeams/" + drow[0]["TCode"].ToString() + "/TaskOngoing.cs");
        dsTasks.ReadXml(path);
        DataTable dtTask = dsTasks.Tables[0];
        string filter = "UCode = '" + Request.Params["ucode"] + "'  AND timestamp = '" + Request.Params["timestamp"] + "'";

        var arr = dtTask.Select(filter);

        arr[0]["Status"] = Request.Params["status"];
        arr[0]["Remarks"] = Request.Params["remarks"];
        arr[0]["RemarksDate"] = DateTime.Now;

        dtTask.AcceptChanges();
        dsTasks.AcceptChanges();

        String xmldata = CommonUtility.DSToXml(dsTasks);
        String folderFiles = Server.MapPath("AllTeams/" + drow[0]["TCode"].ToString() + "/TaskOngoing.cs");
        File.WriteAllText(folderFiles, xmldata);

        Response.Write(@"{""responsecode"":""1""}");
        return;


    }

    private string DataTabletoJSON(DataTable dt)
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
                    row.Add(dc.ColumnName, dr[dc] != DBNull.Value ? Convert.ToDateTime(dr[dc]).ToString("yyyy-MM-ddTHH:mm:ss") : "");
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

    public static string DataTableToHTML(DataTable dt)
    {
        string html = "<table>";
        //add header row
        html += "<tr>";
        for (int i = 0; i < dt.Columns.Count; i++)
            html += "<th>" + dt.Columns[i].ColumnName + "</th>";
        html += "</tr>";
        //add rows
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            for (int j = 0; j < dt.Columns.Count; j++)
                html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        return html;
    }

}
