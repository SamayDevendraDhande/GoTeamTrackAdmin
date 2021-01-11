using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
//using SamaySoftware.OnlineTest.Lib;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// Summary description for SessionManager
/// </summary>
public class SessionManager
{
    public SessionManager()
    {
    }

    public static string LoggedInTCode
    {
        get
        {
            return HttpContext.Current.Session["LoggedInTCode"] != null ? (string)HttpContext.Current.Session["LoggedInTCode"] : "";
        }
        set
        {
            SetSession("LoggedInTCode", value);
        }
    }

    public static string LoggedInTName
    {
        get
        {
            return HttpContext.Current.Session["LoggedInTName"] != null ? (string)HttpContext.Current.Session["LoggedInTName"] : "";
        }
        set
        {
            SetSession("LoggedInTName", value);
        }
    }

    public static string LoggedInUCode
    {
        get
        {
            return HttpContext.Current.Session["LoggedInUCode"] != null ? (string)HttpContext.Current.Session["LoggedInUCode"] : "";
        }
        set
        {
            SetSession("LoggedInUCode", value);
        }
    }

    public static string LoggedInUName
    {
        get
        {
            return HttpContext.Current.Session["LoggedInUName"] != null ? (string)HttpContext.Current.Session["LoggedInUName"] : "";
        }
        set
        {
            SetSession("LoggedInUName", value);
        }
    }

    public static string LoggedInUTCode
    {
        get
        {
            return HttpContext.Current.Session["LoggedInUTCode"] != null ? (string)HttpContext.Current.Session["LoggedInUTCode"] : "";
        }
        set
        {
            SetSession("LoggedInUTCode", value);
        }
    }

    public static string LoggedInUTName
    {
        get
        {
            return HttpContext.Current.Session["LoggedInUTName"] != null ? (string)HttpContext.Current.Session["LoggedInUTName"] : "";
        }
        set
        {
            SetSession("LoggedInUTName", value);
        }
    }

    public static string AlertMessage
    {
        get
        {
            return HttpContext.Current.Session["AlertMessage"] != null ? (string)HttpContext.Current.Session["AlertMessage"] : "";
        }
        set
        {
            SetSession("AlertMessage", value);
        }
    }

    private static void SetSession(string key, object value)
    {
        if (HttpContext.Current.Session[key] == null) //IF the key does not exist in session
        {
            HttpContext.Current.Session.Add(key, value);
        }
        else
        {
            HttpContext.Current.Session[key] = value;
        }
    }
    
}
