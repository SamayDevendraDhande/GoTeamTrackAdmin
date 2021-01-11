using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblTitle.Text = "Admin Dashboard";
        DataSet theDataSetOnGoing = new DataSet();
        string pathOnGoing = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/TaskOngoing.cs");
        theDataSetOnGoing.ReadXml(pathOnGoing);
        DataTable dtTask = theDataSetOnGoing.Tables[0];


        //DataSet theDataSetClosed = new DataSet();
        //string pathClosed = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/TaskClosed.cs");
        //theDataSetClosed.ReadXml(pathClosed);
        //DataTable dtTaskClosed = theDataSetClosed.Tables[0];


        int TotalPending = 0;
        int TotalReply= 0;
        int TotalComplete= 0;


        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dtUsers = theDataSet.Tables[0];
        dtUsers.DefaultView.RowFilter = "TCode = '" + SessionManager.LoggedInTCode + "' AND IsActive = 'True'";

        dtUsers.Columns.Add("Present", typeof(string));
        dtUsers.Columns.Add("OnDuty", typeof(string));
        dtUsers.Columns.Add("OverdueCount", typeof(string));
        dtUsers.Columns.Add("PendingCount", typeof(string));
        dtUsers.Columns.Add("ReplyCount", typeof(string));
        dtUsers.Columns.Add("CompletedCount", typeof(string));
        dtUsers.Columns.Add("TotalCount", typeof(string));
        //dtUsers.Columns.Add("TotalClosed", typeof(string));

        for (int i = 0; i < dtUsers.Rows.Count; i++)
        {
            string usercode = dtUsers.Rows[i]["UCode"].ToString();
            string path = Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + usercode + "/" + usercode + "_in_out_log.cs");

            dtUsers.Rows[i]["PendingCount"] = dtTask.Select("UCode = '" + usercode + "' AND Status = 'Pending'").Length.ToString();
            TotalPending += Convert.ToInt32(dtUsers.Rows[i]["PendingCount"]);
            dtUsers.Rows[i]["ReplyCount"] = dtTask.Select("UCode = '" + usercode + "' AND Status = 'Reply'").Length.ToString();
            TotalReply += Convert.ToInt32(dtUsers.Rows[i]["ReplyCount"]);
            dtUsers.Rows[i]["CompletedCount"] = dtTask.Select("UCode = '" + usercode + "' AND Status = 'Completed'").Length.ToString();
            TotalComplete += Convert.ToInt32(dtUsers.Rows[i]["CompletedCount"]);
            int totalCount = Convert.ToInt32(dtUsers.Rows[i]["PendingCount"]) + Convert.ToInt32(dtUsers.Rows[i]["ReplyCount"]) + Convert.ToInt32(dtUsers.Rows[i]["CompletedCount"]);

            //dtUsers.Rows[i]["TotalClosed"] = dtTaskClosed.Select("UCode = '" + usercode + "'").Length.ToString();


            dtUsers.Rows[i]["TotalCount"] = totalCount.ToString();
            if (File.Exists(path))
            {
                string getInOutDatafromFile = File.ReadAllText(Server.MapPath("/AllTeams/" + SessionManager.LoggedInTCode + "/" + usercode + "/" + usercode + "_in_out_log.cs"));

                string[] getInOutTime = getInOutDatafromFile.Split(new Char[]{ '#' }, StringSplitOptions.RemoveEmptyEntries);
                int index = getInOutTime.Length - 1;
                if (index >= 0)
                {
                    string[] tempData = getInOutTime[index].Split(',');
                    if (tempData.Length == 2)
                    {
                        string time = CommonUtility.StringToDateTime(tempData[0], "yyyy-MM-dd HH:mm:ss").Value.ToString("yyyy-MM-dd");
                        DateTime dtmDutyTime = CommonUtility.StringToDateTime(time, "yyyy-MM-dd").Value;
                        if (dtmDutyTime.Date == DateTime.Today)
                        {
                            dtUsers.Rows[i]["Present"] = "Yes";
                            // YES present
                            if (tempData[1].ToUpper() == "ONDUTY")
                            {
                                dtUsers.Rows[i]["OnDuty"] = "Yes";
                            }
                            else
                            {
                                dtUsers.Rows[i]["OnDuty"] = "No";
                            }
                            //dtUsers.AcceptChanges();
                        }
                        else
                        {
                            dtUsers.Rows[i]["Present"] = "No";
                            dtUsers.Rows[i]["OnDuty"] = "No";
                            //dtUsers.AcceptChanges();
                        }
                        //dtUsers.Rows.Add(tempData[0], tempData[1], ddlMember.SelectedValue);
                    }
                }
                else
                {
                    dtUsers.Rows[i]["Present"] = "No";
                    dtUsers.Rows[i]["OnDuty"] = "No";
                    //dtUsers.AcceptChanges();
                }
            }
            else
            {
                dtUsers.Rows[i]["Present"] = "No";
                dtUsers.Rows[i]["OnDuty"] = "No";
                //dtUsers.AcceptChanges();
            }


        }

        lblPendingTask.Text = TotalPending.ToString();
        lblReplyTask.Text = TotalReply.ToString();
        lblCompletedTask.Text = TotalComplete.ToString();

        dtUsers.AcceptChanges();
        dtUsers.DefaultView.Sort = "Name";
        rptrUsers.DataSource = dtUsers;
        rptrUsers.DataBind();
    }
}