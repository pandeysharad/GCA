using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Session : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    AllMethods m = new AllMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridSessions.DataSource =obj.Sessions;
            GridSessions.DataBind();

            if (Session["Sessionid"] != null)
            {
                var DATA1 = from Cons in obj.Sessions
                            where Cons.Sessionid ==Convert.ToInt32(Session["Sessionid"])
                            select Cons;
                txtSession.Text = DATA1.First().SessionName;
                ddl_Status.Text = DATA1.First().Status;
            }
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridSessions.PageIndex = e.NewPageIndex;
        GridSessions.DataSource = obj.Sessions;
        GridSessions.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Sessionid"] == null)
            {
                if (AllMethods.SelectSessionId(txtSession.Text)==null)
                {
                    if (ddl_Status.Text == "ACTIVE")
                    {
                        if (obj.SP_Session(2, 0, txtSession.Text, "INACTIVE", 0, 0) == 0) { }
                    }
                    if (obj.SP_Session(1, 0, txtSession.Text, ddl_Status.Text, 0, 0) == 0)
                    {
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                }
                else
                {
                    msg = "Session is already exist!!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
            else if (Session["Sessionid"] != null)
            {
                AllMethods m = AllMethods.SelectSessionId(txtSession.Text);
                if (m != null)
                {
                    if (Convert.ToInt32(m.Sessionid) ==Convert.ToInt32(Session["Sessionid"]))
                    {
                        if (ddl_Status.Text == "ACTIVE")
                        {
                            if (obj.SP_Session(2, 0, txtSession.Text, "INACTIVE", 0, 0) == 0) { }
                        }
                        if (obj.SP_Session(3, Convert.ToInt32(Session["Sessionid"]), txtSession.Text, ddl_Status.Text, 0, 0) == 0)
                        {
                            Response.Redirect(Request.UrlReferrer.ToString());
                        }
                    }
                    else
                    {
                        msg = "Session is already exist!!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                    }
                }
                else
                {
                    if (ddl_Status.Text == "ACTIVE")
                    {
                        if (obj.SP_Session(2, 0, txtSession.Text, "INACTIVE", 0, 0) == 0) { }
                    }
                    if (obj.SP_Session(3, Convert.ToInt32(Session["Sessionid"]), txtSession.Text, ddl_Status.Text, 0, 0) == 0)
                    {
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void GridSessions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Session["Sessionid"] = GridSessions.DataKeys[e.NewSelectedIndex].Value;
        lbFlag.Text = "1";
        Response.Redirect(Request.RawUrl);
    }
}