using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CreateMsgTemplate : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    LoginRole role = new LoginRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                if (Session["UserType"].ToString() != "Admin")
                {
                    IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 10
                                                   select r;
                    if (roles.Count<LoginRole>() > 0)
                    {
                        role = roles.First<LoginRole>();
                    }
                    else
                    {
                        role.Select = false;
                        role.Insert = false;
                        role.Delete = false;
                        role.Update = false;
                    }
                }
                else
                {
                    role.Select = true;
                    role.Insert = true;
                    role.Delete = true;
                    role.Update = true;
                }
            }
            if (IsPostBack == false)
            {
                if (Session["CompanyId"] != null)
                {
                    GridMsgTemplate.DataSource = obj.MsgTemplates;
                    GridMsgTemplate.DataBind();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex) { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["MagTemplateId"] == null)
            {
                if (role.Insert.Value)
                {
                    IEnumerable<MsgTemplate> comp = from c in obj.MsgTemplates
                                                    where c.MsgHead == txtMsgHeads.Text.ToUpper()
                                                    select c;
                    if (comp.Count<MsgTemplate>() == 0)
                    {
                        if (obj.Sp_MsgTemplate(1, 0, txtMsgHeads.Text.ToUpper(), txtMsg.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                        {
                            Globals.Message(Page, "Created Template successfully...");
                            clear();
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Already exist msg template head...");
                    }
                }
                else Globals.Message(Page, "Not Authorized ??");
                
            }
            else if (Session["MagTemplateId"] != null)
            {
                if (role.Update.Value)
                {
                    if (txtMsgHeads.Text.ToUpper() == Session["txtMsgHeads"].ToString())
                    {
                        UpdateTemplate();
                    }
                    else
                    {
                        IEnumerable<MsgTemplate> comp = from c in obj.MsgTemplates
                                                        where c.MsgHead == txtMsgHeads.Text.ToUpper()
                                                        select c;
                        if (comp.Count<MsgTemplate>() == 0)
                        {
                            UpdateTemplate();
                        }
                        else
                        {
                            msg = "Same Msg Head already exist...";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            txtMsgHeads.Text = Session["txtMsgHeads"].ToString();
                            txtMsgHeads.Focus();
                        }
                    }
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
        }
        catch (Exception ex) { }
    }

    private void UpdateTemplate()
    {
        if (obj.Sp_MsgTemplate(2, Convert.ToInt32(Session["MagTemplateId"]), txtMsgHeads.Text.ToUpper(), txtMsg.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            Globals.Message(Page, "Template Updated successfully...");
            clear();
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            clear();
        }
        catch (Exception ex) { }
    }

    private void clear()
    {
        GridMsgTemplate.DataSource = obj.MsgTemplates;
        GridMsgTemplate.DataBind();
        txtMsgHeads.Text = string.Empty;
        txtMsg.Text = string.Empty;
        Session["MagTemplateId"] = null;
        Session["txtMsgHeads"] = null;
    }
    protected void GridMsgTemplate_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                int id = Convert.ToInt32(GridMsgTemplate.DataKeys[e.NewSelectedIndex].Value);
                Session["MagTemplateId"] = Convert.ToInt32(GridMsgTemplate.DataKeys[e.NewSelectedIndex].Value);
                var DATA = from Cons in obj.MsgTemplates
                           where Cons.MagTemplateId == id
                           select Cons;
                txtMsgHeads.Text = DATA.First().MsgHead;
                Session["txtMsgHeads"] = DATA.First().MsgHead;
                txtMsg.Text = DATA.First().Msg;
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
}