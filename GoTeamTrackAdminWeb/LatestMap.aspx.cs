using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LatestMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
            DataTable dtUsers = theDataSet.Tables[0];
            dtUsers.DefaultView.RowFilter = "TCode='" + SessionManager.LoggedInTCode + "'";
            DataTable ddt = new DataTable();
            ddt = dtUsers.DefaultView.ToTable();
            //var dt1 = dtUsers.Select("TCode='" + SessionManager.LoggedInTCode + "'").CopyToDataTable();

            //DataRow[] drow = dtUsers.Select("TCode='" + SessionManager.LoggedInTCode + "'");

            DataTable dt = new DataTable();
            dt.Columns.Add("GPSTime", typeof(string));
            dt.Columns.Add("Latitude", typeof(string));
            dt.Columns.Add("Longitude", typeof(string));


            //for(int i = 0; i<drow.Length; i++)
            //for (int i = 0; i < dtUsers.Rows.Count; i++)
            for (int i = 0; i < ddt.Rows.Count; i++)
            {
                DataSet locationDataSet = new DataSet();
                //string getlocationDatafromFile = File.ReadAllText(Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + drow[i]["UCode"].ToString() + "/" + drow[i]["UCode"].ToString() + DateTime.Today.ToString("yyyyMMdd") + ".cs"));
                string UName = ddt.Rows[i]["Name"].ToString();
                string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddt.Rows[i]["UCode"].ToString() + "/" + ddt.Rows[i]["UCode"].ToString() + DateTime.Today.ToString("yyyyMMdd") + ".cs");
                
                if (File.Exists(path))
                {
                    string getlocationDatafromFile = File.ReadAllText(Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddt.Rows[i]["UCode"].ToString() + "/" + ddt.Rows[i]["UCode"].ToString() + DateTime.Today.ToString("yyyyMMdd") + ".cs"));
                    string[] getLocationTimeArray = getlocationDatafromFile.Split('#');

                    if(getLocationTimeArray.Length >= 2)
                    {
                        string latestlocation = getLocationTimeArray[getLocationTimeArray.Length - 2];

                        string[] tempData = latestlocation.Split(',');
                        if (tempData.Length == 3)
                        {
                            string time = CommonUtility.StringToDateTime(tempData[0], "yyyy-MM-dd HH:mm:ss").Value.ToString("HH:mm");
                            dt.Rows.Add(UName + " " + time, tempData[1], tempData[2]);
                        }
                    }
                }
            }

            txtJson1.Text = DataTabletoJSON(dt);
            PlaceHolderMap.Visible = true;




            //DataRow[] drow = dtUsers.Select("UCode = '" + Request.QueryString["ucode"] + "'");
            //string UCode = drow[0]["UCode"].ToString();
            //string TCode = drow[0]["TCode"].ToString();

            //DataSet ds = new DataSet();
            //ds.ReadXml(Server.MapPath("AllTeams/" + TCode + "/" + UCode + "/" + UCode + "20200911.cs"));
            //DataTable dtUserLocation = ds.Tables[0];
        }
    }

    //protected void btnShow_Click(object sender, EventArgs e)
    //{
    //    DataSet locationDataSet = new DataSet();
    //    string getlocationDatafromFile = File.ReadAllText(Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + ddlMember.SelectedValue + "/" + ddlMember.SelectedValue + CommonUtility.StringToDateTime(txtDate.Text, "dd-MM-yyyy").Value.ToString("yyyyMMdd") + ".cs"));
    //    //locationDataSet.ReadXml(Server.MapPath("AllTeams/"+SessionManager.LoggedInTCode+"/"+ddlMember.SelectedValue+"/"+ ddlMember.SelectedValue + CommonUtility.StringToDateTime(txtDate.Text, "dd-MM-yyyy").Value.ToString("yyyyMMdd") + ".cs"));
    //    //string path = "AllTeams/" + SessionManager.LoggedInTCode + "/" + ddlMember.SelectedValue + "/" + ddlMember.SelectedValue + "20200911.cs";
    //    //DataTable dtUsersLocation = locationDataSet.Tables[0];


    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("GPSTime", typeof(string));
    //    dt.Columns.Add("Latitude", typeof(string));
    //    dt.Columns.Add("Longitude", typeof(string));


    //    string[] getLocationTimeArray = getlocationDatafromFile.Split('#');
    //    for (int i = 0; i < getLocationTimeArray.Length; i++)
    //    {
    //        string[] tempData = getLocationTimeArray[i].Split(',');
    //        if (tempData.Length == 3)
    //        {
    //            dt.Rows.Add(tempData[0], tempData[1], tempData[2]);
    //        }
    //    }

    //    if (getLocationTimeArray.Length > 0)
    //    {
    //        txtJson1.Text = DataTabletoJSON(dt);
    //        PlaceHolderMap.Visible = true;
    //    }
    //    else
    //    {
    //        PlaceHolderMap.Visible = false;
    //    }






    //    //List<string[]> list = new List<string[]>();
    //    //list.Add(new string[] { "GPSTime", "Latitude", "Longitude" });
    //    //for (int i = 0; i < getLocationTimeArray.Length; i++)
    //    //{
    //    //    string[] tempData = getLocationTimeArray[i].Split(',');
    //    //    if (tempData.Length == 3)
    //    //    {
    //    //        list.Add(new string[] { tempData[0], tempData[1], tempData[2] });
    //    //    }

    //    //}

    //    //DataTable table = ConvertListToDataTable(list);

    //    //if (ddlMember.SelectedItem.Value != "0" && txtDate.Text != "")
    //    //{
    //    //    DateTime dtm = CommonUtility.StringToDateTime(txtDate.Text, "dd-MM-yyyy").Value;
    //    //    DataTable dt = GPSLogBLL.SelectLogByMemberDate(Convert.ToInt32(ddlMember.SelectedItem.Value), dtm);
    //    //    if (dt.Rows.Count > 0)
    //    //    {
    //    //        dt.Columns.Remove("GPSLogID");
    //    //        dt.Columns.Remove("MemberID");
    //    //        txtJson1.Text = DataTabletoJSON(dt);
    //    //        PlaceHolderMap.Visible = true;
    //    //    }
    //    //    else
    //    //    {
    //    //        PlaceHolderMap.Visible = false;
    //    //    }
    //    //}
    //}

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
