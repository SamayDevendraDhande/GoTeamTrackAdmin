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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml.Serialization;

public class CommonUtility
{
    public static string ServerURL = "http://localhost:52442/OnlineTestWeb";
    
    public CommonUtility()
    {

    }

    public static string DSToXml(DataSet ds)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (TextWriter streamWriter = new StreamWriter(memoryStream))
            {
                var xmlSerializer = new XmlSerializer(typeof(DataSet));
                xmlSerializer.Serialize(streamWriter, ds);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }

    public static void DataTableToCSV(DataTable dt, string title, string file, string[] columns)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(title);
        sb.AppendLine("");


        for (int i = 0; i < dt.Columns.Count; i++)
        {
            DataColumn dc = dt.Columns[i];
            if (!columns.Contains(dc.Caption))
            {
                dt.Columns.Remove(dc);
                i--;
            }
        }
        dt.AcceptChanges();

        string[] columnNames = dt.Columns.Cast<DataColumn>().
                                          Select(column => column.ColumnName).
                                          ToArray();
        sb.AppendLine(string.Join(",", columnNames));

        foreach (DataRow row in dt.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString()).
                                            ToArray();
            sb.AppendLine(string.Join(",", fields));
        }

        File.WriteAllText(file, sb.ToString());
    }

    public static void DataTableToCSV(DataTable dt, string title, string file)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(title);
        sb.AppendLine("");

        string[] columnNames = dt.Columns.Cast<DataColumn>().
                                          Select(column => column.ColumnName).
                                          ToArray();
        sb.AppendLine(string.Join(",", columnNames));

        foreach (DataRow row in dt.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString()).
                                            ToArray();
            sb.AppendLine(string.Join(",", fields));
        }

        File.WriteAllText(file, sb.ToString());
    }

    public static DateTime? StringToDateTime(string value, string format)
    {
        if (format == "")
        {
            format = "dd-MM-yyyy";
        }
        DateTime dtmTemp = new DateTime();
        if (DateTime.TryParseExact(value, format, null, System.Globalization.DateTimeStyles.None, out dtmTemp))
        {
            return dtmTemp;
        }
        else
        {
            return null;
        }
    }

    public static float? StringToFloat(string value)
    {
        float temp1 = 0.0F;
        if (float.TryParse(value, out temp1))
        {
            return temp1;
        }
        else
        {
            return null;
        }
    }

    public static float StringToFloatDefault(string value)
    {
        float temp1 = 0.0F;
        if (float.TryParse(value, out temp1))
        {
            return temp1;
        }
        else
        {
            return 0.0F;
        }
    }

    public static int? StringToInt(string value)
    {
        int temp1 = 0;
        if (int.TryParse(value, out temp1))
        {
            return temp1;
        }
        else
        {
            return null;
        }
    }

    public static int StringToIntDefault(string value)
    {
        int temp1 = 0;
        if (int.TryParse(value, out temp1))
        {
            return temp1;
        }
        else
        {
            return 0;
        }
    }

    //public static string Enrypt(string str)
    //{
    //    return QuestionBLL.Enrypt(str);
    //}

    //public static string Decrypt(string str)
    //{
    //    return QuestionBLL.Decrypt(str);
    //}
}
