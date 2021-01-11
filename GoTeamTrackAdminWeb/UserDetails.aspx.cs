using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ucode"] != null)
            {
                btnLocationLog.Visible = true;
                btnInOut.Visible = true;

                DataSet theDataSet = new DataSet();
                theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
                DataTable dt = theDataSet.Tables[0];
                DataRow[] drow = dt.Select("UCode = '" + Request.QueryString["ucode"] + "' AND TCode = '" + SessionManager.LoggedInTCode + "'");

                if (drow.Length > 0)
                {
                    txtUserCode.Enabled = false;
                    txtUserCode.Text = drow[0]["UCode"].ToString();
                    txtName.Text = drow[0]["Name"].ToString();
                    txtPassword.Text = drow[0]["Password"].ToString();
                    txtEmail.Text = drow[0]["Email"].ToString();
                    txtRemarks.Text = drow[0]["Remarks"].ToString();
                    chkActive.Checked = Convert.ToBoolean(drow[0]["IsActive"]);

                    RequiredFieldtxtPassword.Visible = false;
                }
                else
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(Server.MapPath("AllTeams/dbusers.cs"));
        DataTable dt = theDataSet.Tables[0];

        if (Request.QueryString["ucode"] != null)
        {
            DataRow[] drow = dt.Select("UCode = '" + txtUserCode.Text + "'");

            if (txtPassword.Text != null && txtPassword.Text != "")
            {
                drow[0]["Password"] = txtPassword.Text;
            }
            drow[0]["Name"] = txtName.Text;
            drow[0]["Email"] = txtEmail.Text;
            //drow[0]["TCode"] = SessionManager.LoggedInTCode;
            drow[0]["IsActive"] = chkActive.Checked;
            drow[0]["Remarks"] = txtRemarks.Text;


            //dt.Rows.Add(drow);

            dt.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            File.WriteAllText(Server.MapPath("AllTeams/dbusers.cs"), xmldata);

            Response.Redirect("UserDetails.aspx?ucode=" + txtUserCode.Text);
        }
        else
        {

            DataRow[] drow = dt.Select("UCode = '" + txtUserCode.Text + "'");
            if (drow.Length > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "btnSave", "alert('User Code not available. Please use another user code.')", true);
                return;
            }

            DataRow row;
            row = dt.NewRow();

            row["UCode"] = txtUserCode.Text;
            row["Password"] = txtPassword.Text;
            row["Name"] = txtName.Text;
            row["Email"] = txtEmail.Text;
            row["TCode"] = SessionManager.LoggedInTCode;
            row["IsActive"] = chkActive.Checked;
            row["Remarks"] = txtRemarks.Text;


            dt.Rows.Add(row);

            dt.AcceptChanges();
            theDataSet.AcceptChanges();

            String xmldata = CommonUtility.DSToXml(theDataSet);
            File.WriteAllText(Server.MapPath("AllTeams/dbusers.cs"), xmldata);

            String userFile = Server.MapPath("AllTeams/" + SessionManager.LoggedInTCode + "/" + txtUserCode.Text);
            System.IO.Directory.CreateDirectory(userFile);

            Response.Redirect("UserDetails.aspx?ucode=" + txtUserCode.Text);
        }




    }

    protected void btnLocationLog_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ucode"] != null)
        {

            string dateTime = DateTime.Now.ToString("yyyyMMdd");
            String userFile = Server.MapPath("~/AllTeams/" + SessionManager.LoggedInTCode + "/" + txtUserCode.Text + "/" + txtUserCode.Text + dateTime + ".cs");
            FileInfo file = new FileInfo(userFile);

            if (File.Exists(userFile))
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();

            }
        }
    }

    protected void btnInOut_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ucode"] != null)
        {


            String userFile = Server.MapPath("~/AllTeams/" + SessionManager.LoggedInTCode + "/" + txtUserCode.Text + "/" + txtUserCode.Text + "_in_out_log.cs");
            FileInfo file = new FileInfo(userFile);
            if (File.Exists(userFile))
            {
                //Response.ContentType = "Application/cs";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + txtUserCode.Text + "_in_out_log.cs");
                //Response.TransmitFile(Server.MapPath(userFile));
                //Response.End();

                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
    }
}
