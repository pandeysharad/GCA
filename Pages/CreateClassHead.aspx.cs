using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CreateClassHead : System.Web.UI.Page
{
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    LoginRole role = new LoginRole();
    public int Sno = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                if (Session["UserType"].ToString() != "Admin")
                {
                    IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 11
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
                    GridBind();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
        }
        catch (Exception ex) { }
    }
  
    private void Clear()
    {
        txtClassHead.Text = "";
        txtClassHead.Focus();
        GridBind();
        Session["ClassHeadId"] = null;
        Session["txtClassHead"] = null;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
                if (Session["ClassHeadId"] == null)
                {
                    if (role.Insert.Value)
                    {
                        if (txtClassHead.Text != "")
                        {
                            if (obj.Sp_ClassHead(1, 0, txtClassHead.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                            {
                                Globals.Message(Page, "Record inserted successfully...");
                                Clear();
                            }

                        }
                        else
                        {
                            Globals.Message(Page, "Please enter class head...");
                            txtClassHead.Focus();
                        }

                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else if (Session["ClassHeadId"] != null)
                {
                    if (role.Update.Value)
                    {
                        if (txtClassHead.Text == Session["txtClassHead"].ToString())
                        {
                            Update();
                        }
                        else
                        {
                            IEnumerable<ClassHead> comp = from c in obj.ClassHeads
                                                          where c.Head == txtClassHead.Text && c.CompanyId == Convert.ToInt32(Session["CompanyId"].ToString())
                                                          select c;
                            if (comp.Count<ClassHead>() == 0)
                            {
                                Update();
                            }
                            else
                            {
                                msg = "Same head already exist...";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                txtClassHead.Text = Session["txtClassHead"].ToString();
                                txtClassHead.Focus();
                            }
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }

          
        }
        catch (Exception ex)
        { }
    }

    private void Update()
    {
        if (obj.Sp_ClassHead(2, Convert.ToInt32(Session["ClassHeadId"]), txtClassHead.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            Globals.Message(Page, "Record updated successfully...");
            Clear();
        }
    }

    private void GridBind()
    {
        IEnumerable<ClassHead> DATA1 = from Cons in obj.ClassHeads
                                       where Cons.Remove == false && Cons.CompanyId==Convert.ToInt32(Session["CompanyId"].ToString())
                                       select Cons;
        if (DATA1.Count<ClassHead>() > 0)
        {
            GridClassHead.DataSource = DATA1;
            GridClassHead.DataBind();
        }
    }


    protected void GridClassHead_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                Session["ClassHeadId"] = GridClassHead.DataKeys[e.NewSelectedIndex].Value;
                if (Session["ClassHeadId"] != null)
                {
                    var DATA2 = from Cons in obj.ClassHeads
                                where Cons.ClassHeadId == Convert.ToInt32(Session["ClassHeadId"]) && Cons.Remove == false
                                select Cons;
                    txtClassHead.Text = DATA2.First().Head;
                    Session["txtClassHead"] = DATA2.First().Head;
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch (Exception ex)
        { }
    }
    protected void GridClassHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridClassHead.PageIndex = e.NewPageIndex;
            GridBind();
            GridClassHead.DataBind();
        }
        catch (Exception ex) { }
    }
    protected void LnkDelete_OnClick(object sender, EventArgs e)
    {
        if (role.Delete.Value)
        {
            string id = (sender as LinkButton).CommandArgument;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (id != "")
            {
                if (obj.Sp_ClassHead(3, Convert.ToInt32(id), txtClassHead.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                {
                    GridBind();
                }
            }
        }
        else Globals.Message(Page, "Not Authorized ??");
    }
}