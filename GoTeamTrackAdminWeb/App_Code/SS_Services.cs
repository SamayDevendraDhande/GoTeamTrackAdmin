using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
//using SamaySoftware.OnlineTest.Lib;

/// <summary>
/// Summary description for SS_Services
/// </summary>
public class SS_Services
{
    //private HttpRequest Request;
    //private HttpResponse Response;

    //public void Invoke(HttpRequest request, HttpResponse response)
    //{
    //    this.Request = request;
    //    this.Response = response;

    //    switch (Request.QueryString["method"])
    //    {
    //        case "addcalitem":
    //            addcalitem();
    //            break;
    //        case "editcalitemtime":
    //            editcalitemtime();
    //            break;
    //        //case "getplantmonitorsbyvids":
    //        //    getplantmonitorsbyvids();
    //        //    break;
    //        //case "getpointsforxbarrchart":
    //        //    getpointsforxbarrchart();
    //        //    break;
    //        default:
    //            break;
    //    }
    //}

    //private void addcalitem()
    //{
    //    CalendarItem calendarItem = new CalendarItem();

    //    calendarItem.CoBatchID = CommonUtility.StringToIntDefault(Request.QueryString["bid"]);
    //    calendarItem.Title = Request.QueryString["title"];
    //    calendarItem.Description = "";
    //    calendarItem.Location = "";
    //    calendarItem.AccessLevel = "";
    //    calendarItem.ItemFor = "Candidate";
    //    calendarItem.ItemType = "";
    //    calendarItem.ReferenceID = 0;
    //    calendarItem.ReferenceType = "";
    //    calendarItem.UserDetailID = 0; //SessionManager.LoggedInUserDetail.UserDetailID;
    //    calendarItem.AccountID = SessionManager.CurrentAccountID;
    //    calendarItem.CreateDate = DateTime.Now;
    //    calendarItem.StartDate = CommonUtility.StringToDateTime(Request.QueryString["startdate"], "yyyy-MM-dd-HH-mm");
    //    calendarItem.EndDate = CommonUtility.StringToDateTime(Request.QueryString["enddate"], "yyyy-MM-dd-HH-mm");
    //    calendarItem.TrainerID = SessionManager.LoggedInStudent.StudentID;

    //    calendarItem.CalendarItemID = CalendarItemBLL.Insert(calendarItem);

    //    Response.Clear();
    //    Response.Write(calendarItem.CalendarItemID);
    //    Response.End();
    //    Response.Flush();
    //}

    //private void editcalitemtime()
    //{
    //    try
    //    {
    //        CalendarItem calendarItem = CalendarItemBLL.SelectList(new CalendarItem() { CalendarItemID = Convert.ToInt32(Request.QueryString["id"]) })[0];

    //        //calendarItem.UserDetailID = SessionManager.LoggedInUserDetail.UserDetailID;
    //        calendarItem.CreateDate = DateTime.Now;
    //        calendarItem.StartDate = CommonUtility.StringToDateTime(Request.QueryString["startdate"], "yyyy-MM-dd-HH-mm");
    //        calendarItem.EndDate = CommonUtility.StringToDateTime(Request.QueryString["enddate"], "yyyy-MM-dd-HH-mm");

    //        CalendarItemBLL.Update(calendarItem);

    //        Response.Clear();
    //        Response.Write("success");
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Clear();
    //        Response.Write("fail");
    //    }
    //    finally
    //    {
    //        Response.End();
    //        Response.Flush();
    //    }
    //}

    //private void getpointsbyvid()
    //{
    //    var v = VariableBLL.SelectList(new Variable() { VariableID = Convert.ToInt32(Request.QueryString["vid"]) })[0];
    //    var dt = VarDataBLL.SelectForRunChart(Convert.ToInt32(Request.QueryString["vid"]));

    //    StringBuilder json1 = new StringBuilder("");
    //    json1.Append("\"maindata\": {");
    //    StringBuilder json2 = new StringBuilder("");
    //    json2.Append("\"violationdata\": {");
    //    StringBuilder json3 = new StringBuilder("");
    //    json3.Append("\"violationids\": {");
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        json1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["Value"]).ToString("N" + v.DisplayPrecision) + ",");
    //        if (dt.Rows[i]["ViolationID"] != DBNull.Value)
    //        {
    //            json2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["Value"]).ToString("N" + v.DisplayPrecision) + ",");
    //            json3.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["ViolationID"]).ToString() + ",");
    //        }
    //    }
    //    json1.Append("\"0\":null");
    //    json1.Append("}");
    //    json2.Append("\"0\":null");
    //    json2.Append("}");
    //    json3.Append("\"0\":null");
    //    json3.Append("}");

    //    var FinalResponse = "{" + json1.Append("," + json2.ToString()).Append("," + json3.ToString()) + "}";
    //    Response.Clear();
    //    Response.Write(FinalResponse);
    //    Response.End();
    //    Response.Flush();
    //}

    //private void getplantmonitorsbyvids()
    //{
    //    StringBuilder json1 = new StringBuilder("");
    //    json1.Append("\"variables\": {");

    //    //VariableID, ViolationIDs, LastColor
    //    var dt = VarDataBLL.SelectPMByVIDs(Request.QueryString["variableids"]);
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        var LastColor = (dt.Rows[i]["LastColor"] == DBNull.Value || dt.Rows[i]["LastColor"].ToString() == "") ? "#88FF88" : dt.Rows[i]["LastColor"];
    //        json1.Append("\"" + dt.Rows[i]["VariableID"] + "\": { \"vid\": \"" + dt.Rows[i]["VariableID"] + "\", \"vids\": \"" + dt.Rows[i]["ViolationIDs"] + "\", \"color\": \"" + LastColor + "\"},");
    //    }

    //    json1.Append("\"0\":null");
    //    json1.Append("}");

    //    var FinalResponse = "{" + json1 + "}";
    //    Response.Clear();
    //    Response.Write(FinalResponse);
    //    Response.End();
    //    Response.Flush();
    //}

    //private void getpointsforxbarrchart()
    //{
    //    var v = VariableBLL.SelectList(new Variable() { VariableID = Convert.ToInt32(Request.QueryString["vid"]) })[0];
    //    var dt = VarDataBLL.SelectForXbarRChart(Convert.ToInt32(Request.QueryString["vid"]));

    //    float UCL1 = -1;
    //    float CL1 = -1;
    //    float LCL1 = -1;
    //    float UCL2 = -1;
    //    float CL2 = -1;
    //    float LCL2 = -1;

    //    StringBuilder jsonmain1 = new StringBuilder("");
    //    jsonmain1.Append("\"points_main1\": {");
    //    StringBuilder jsonUCL1 = new StringBuilder("");
    //    jsonUCL1.Append("\"points_UCL1\": {");
    //    StringBuilder jsonCL1 = new StringBuilder("");
    //    jsonCL1.Append("\"points_CL1\": {");
    //    StringBuilder jsonLCL1 = new StringBuilder("");
    //    jsonLCL1.Append("\"points_LCL1\": {");
    //    StringBuilder jsonViolations1 = new StringBuilder("");
    //    jsonViolations1.Append("\"points_Violations1\": {");
    //    StringBuilder jsonViolationIDs1 = new StringBuilder("");
    //    jsonViolationIDs1.Append("\"ViolationIDs1\": {");

    //    StringBuilder jsonmain2 = new StringBuilder("");
    //    jsonmain2.Append("\"points_main2\": {");
    //    StringBuilder jsonUCL2 = new StringBuilder("");
    //    jsonUCL2.Append("\"points_UCL2\": {");
    //    StringBuilder jsonCL2 = new StringBuilder("");
    //    jsonCL2.Append("\"points_CL2\": {");
    //    StringBuilder jsonLCL2 = new StringBuilder("");
    //    jsonLCL2.Append("\"points_LCL2\": {");
    //    StringBuilder jsonViolations2 = new StringBuilder("");
    //    jsonViolations2.Append("\"points_Violations2\": {");
    //    StringBuilder jsonViolationIDs2 = new StringBuilder("");
    //    jsonViolationIDs2.Append("\"ViolationIDs2\": {");

    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        jsonmain1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["Xbar"]).ToString("N" + v.DisplayPrecision) + ",");
    //        jsonmain2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["R"]).ToString("N" + v.DisplayPrecision) + ",");

    //        if (dt.Rows[i]["ViolationID"] != DBNull.Value)
    //        {
    //            jsonViolations1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["Xbar"]).ToString("N" + v.DisplayPrecision) + ",");
    //            jsonViolationIDs1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["ViolationID"]).ToString() + ",");
    //            jsonViolations2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["R"]).ToString("N" + v.DisplayPrecision) + ",");
    //            jsonViolationIDs2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["ViolationID"]).ToString() + ",");
    //        }

    //        if (UCL1.ToString("N" + v.DisplayPrecision) != Convert.ToSingle(dt.Rows[i]["UCL1"]).ToString("N" + v.DisplayPrecision) || (i == dt.Rows.Count - 1))
    //        {
    //            jsonUCL1.Append("\"" + (i) + "\"" + ":" + UCL1.ToString("N" + v.DisplayPrecision) + ",");
    //            jsonUCL1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["UCL1"]).ToString("N" + v.DisplayPrecision) + ",");
    //            UCL1 = Convert.ToSingle(dt.Rows[i]["UCL1"]);
    //        }
    //        if (CL1.ToString("N" + v.DisplayPrecision) != Convert.ToSingle(dt.Rows[i]["CL1"]).ToString("N" + v.DisplayPrecision) || (i == dt.Rows.Count - 1))
    //        {
    //            jsonCL1.Append("\"" + (i) + "\"" + ":" + CL1.ToString("N" + v.DisplayPrecision) + ",");
    //            jsonCL1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["CL1"]).ToString("N" + v.DisplayPrecision) + ",");
    //            CL1 = Convert.ToSingle(dt.Rows[i]["CL1"]);
    //        }
    //        if (LCL1.ToString("N" + v.DisplayPrecision) != Convert.ToSingle(dt.Rows[i]["LCL1"]).ToString("N" + v.DisplayPrecision) || (i == dt.Rows.Count - 1))
    //        {
    //            jsonLCL1.Append("\"" + (i) + "\"" + ":" + LCL1.ToString("N" + v.DisplayPrecision) + ",");
    //            jsonLCL1.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["LCL1"]).ToString("N" + v.DisplayPrecision) + ",");
    //            LCL1 = Convert.ToSingle(dt.Rows[i]["LCL1"]);
    //        }
    //        if (UCL2.ToString("N" + v.DisplayPrecision) != Convert.ToSingle(dt.Rows[i]["UCL2"]).ToString("N" + v.DisplayPrecision) || (i == dt.Rows.Count - 1))
    //        {
    //            jsonUCL2.Append("\"" + (i) + "\"" + ":" + UCL2.ToString("N" + v.DisplayPrecision) + ",");
    //            jsonUCL2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["UCL2"]).ToString("N" + v.DisplayPrecision) + ",");
    //            UCL2 = Convert.ToSingle(dt.Rows[i]["UCL2"]);
    //        }
    //        if (CL2.ToString("N" + v.DisplayPrecision) != Convert.ToSingle(dt.Rows[i]["CL2"]).ToString("N" + v.DisplayPrecision) || (i == dt.Rows.Count - 1))
    //        {
    //            jsonCL2.Append("\"" + (i) + "\"" + ":" + CL2.ToString("N" + v.DisplayPrecision) + ",");
    //            jsonCL2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["CL2"]).ToString("N" + v.DisplayPrecision) + ",");
    //            CL2 = Convert.ToSingle(dt.Rows[i]["CL2"]);
    //        }
    //        if (LCL2.ToString("N" + v.DisplayPrecision) != Convert.ToSingle(dt.Rows[i]["LCL2"]).ToString("N" + v.DisplayPrecision) || (i == dt.Rows.Count - 1))
    //        {
    //            jsonLCL2.Append("\"" + (i) + "\"" + ":" + LCL2.ToString("N" + v.DisplayPrecision) + ",");
    //            jsonLCL2.Append("\"" + (i + 1) + "\"" + ":" + Convert.ToSingle(dt.Rows[i]["LCL2"]).ToString("N" + v.DisplayPrecision) + ",");
    //            LCL2 = Convert.ToSingle(dt.Rows[i]["LCL2"]);
    //        }
    //    }
    //    jsonmain1.Append("\"0\":null");
    //    jsonmain1.Append("}");
    //    jsonUCL1.Append("\"0\":null");
    //    jsonUCL1.Append("}");
    //    jsonCL1.Append("\"0\":null");
    //    jsonCL1.Append("}");
    //    jsonLCL1.Append("\"0\":null");
    //    jsonLCL1.Append("}");
    //    jsonViolations1.Append("\"0\":null");
    //    jsonViolations1.Append("}");
    //    jsonViolationIDs1.Append("\"0\":null");
    //    jsonViolationIDs1.Append("}");
    //    jsonmain2.Append("\"0\":null");
    //    jsonmain2.Append("}");
    //    jsonUCL2.Append("\"0\":null");
    //    jsonUCL2.Append("}");
    //    jsonCL2.Append("\"0\":null");
    //    jsonCL2.Append("}");
    //    jsonLCL2.Append("\"0\":null");
    //    jsonLCL2.Append("}");
    //    jsonViolations2.Append("\"0\":null");
    //    jsonViolations2.Append("}");
    //    jsonViolationIDs2.Append("\"0\":null");
    //    jsonViolationIDs2.Append("}");

    //    var FinalResponse = "{" + jsonmain1.Append("," + jsonUCL1.ToString())
    //                                        .Append("," + jsonCL1.ToString())
    //                                        .Append("," + jsonLCL1.ToString())
    //                                        .Append("," + jsonViolations1.ToString())
    //                                        .Append("," + jsonViolationIDs1.ToString())
    //                                        .Append("," + jsonmain2.ToString())
    //                                        .Append("," + jsonUCL2.ToString())
    //                                        .Append("," + jsonCL2.ToString())
    //                                        .Append("," + jsonLCL2.ToString())
    //                                        .Append("," + jsonViolations2.ToString())
    //                                        .Append("," + jsonViolationIDs2.ToString())
    //                        + "}";

    //    Response.Clear();
    //    Response.Write(FinalResponse);
    //    Response.End();
    //    Response.Flush();
    //}
}
