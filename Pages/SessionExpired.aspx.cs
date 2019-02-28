using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

public partial class SessionExpired : System.Web.UI.Page
{
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!Page.IsPostBack)
        {
            //Session["sessioin"] = true;
            //Configuration con = WebConfigurationManager.OpenWebConfiguration("~/Web.config/");
            //SessionStateSection section = (SessionStateSection)con.GetSection("system.web/sessionState");
            //int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            //ClientScript.RegisterStartupScript(this.GetType(), "sessionAlert", "getTime(" + timeout + ");", true);
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            var DATA1 = (from Cons in obj.Users
                         where Cons.UserLoingId == Session["UserLoingId"].ToString() && Cons.Password == txtPassword.Text && Cons.Status == "Active"
                         select Cons.UserId).Count();

            if (Session["SessionId"] != null)
            {
                if (DATA1 != 0)
                {
                    Response.Redirect("../Pages/Dashboard.aspx", false);
                }
                else
                {
                    msg = "Please enter currect password...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                    txtPassword.Text = string.Empty;
                }
            }
            else
            {
                msg = "Your session has expired please login again";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                txtPassword.Text = string.Empty;
            }
        }
        catch (Exception ex)
        { }
    }
}