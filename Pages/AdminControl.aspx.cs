using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AdminControl : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    int LoginId = 0;
    LoginRole role = new LoginRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                if (Session["UserType"].ToString() != "Admin")
                {
                    LoginId = Convert.ToInt32(Session["UserId"]);
                    IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                                   where r.LoginId.Value == LoginId && r.RoleId==1
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
                    GetCompanyData();

                    var S = (from Cons in obj.Users where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                             select Cons.SerialNo).Max()+1;
                    if (S == null)
                    {
                        txtSerialNo.Text = "1";
                    }
                    else
                    {
                        txtSerialNo.Text =S.ToString();
                    }
                    var DATA = from Cons in obj.Users
                               where Cons.Status == "ACTIVE" && Cons.UserType != "Admin" && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                               select Cons;
                    ddl_UserName.DataSource = DATA;
                    ddl_UserName.DataTextField = "UserName";
                    ddl_UserName.DataValueField = "UserId";
                    ddl_UserName.DataBind();
                    ddl_UserName.Items.Insert(0, new ListItem());
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex)
        { }
    }

    private void GetCompanyData()
    {
        if (role.Select.Value)
        {
            var DATA1 = (from Cons in obj.Settings where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                         select Cons.CompanyId).Count();
            if (DATA1 != 0)
            {
                var DATA = from Cons in obj.Settings
                           where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                           select Cons;
                Session["CompId"] = DATA.First().CompanyId;
                txtSchoolName.Text = DATA.First().SchoolName;
                txtSchoolAddress.Text = DATA.First().Address;
                txtPhoneNo.Text = DATA.First().PhoneNo;
                txtContactNumber.Text = DATA.First().ContactNo;
                txtWebsite.Text = DATA.First().Website;
                txtEmail.Text = DATA.First().EmailId;
            }
            else
            {
                Session["CompId"] = null;
            }
            var DATA2 = from Cons in obj.Users where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                        select Cons;
            GridUsers.DataSource = DATA2;
            GridUsers.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompId"] == null)
            {
                if (role.Select.Value)
                {
                    if (role.Insert.Value)
                    {
                        if (txtSchoolName.Text != "")
                        {
                            if (txtContactNumber.Text != "")
                            {
                                if (txtSchoolAddress.Text != "")
                                {
                                    if (obj.Sp_Setting(1, 0, txtSchoolName.Text, txtSchoolAddress.Text, txtPhoneNo.Text, txtContactNumber.Text, txtWebsite.Text, txtEmail.Text, "", false) == 0)
                                    {
                                        Response.Redirect(Request.RawUrl);
                                    }
                                }
                                else { Globals.Message(Page, "Please enter contact number...."); txtContactNumber.Focus(); }
                            }
                            else { Globals.Message(Page, "Please enter address...."); txtSchoolAddress.Focus(); }
                        }
                        else { Globals.Message(Page, "Please enter school name...."); txtSchoolName.Focus(); }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
            else
            {
                if (role.Select.Value)
                {
                    if (role.Update.Value)
                    {
                        if (obj.Sp_Setting(2,Convert.ToInt32(Session["CompId"]), txtSchoolName.Text, txtSchoolAddress.Text, txtPhoneNo.Text, txtContactNumber.Text, txtWebsite.Text, txtEmail.Text,"",false) == 0)
                        {
                            Response.Redirect(Request.RawUrl);
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
        }
        catch (Exception ex)
        { }
    }
    void userclear()
    {
        lbUserId.Text = "0";
        txtSerialNo.Text = "";
        txtUserName.Text = "";
        ddlUserType.SelectedIndex = 0;
        txtPassword.Text = "";
        txtLoginId.Text = "";
        ddlStatus.SelectedIndex = 0;
        lbUserFlag.Text = "0";
        Session["UId"] = null;
        GetCompanyData();
        var S = (from Cons in obj.Users
                 where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                 select Cons.SerialNo).Max() + 1;
        if (S == null)
        {
            txtSerialNo.Text = "1";
        }
        else
        {
            txtSerialNo.Text = S.ToString();
        }
        var DATA = from Cons in obj.Users
                   where Cons.Status == "ACTIVE" && Cons.UserType != "Admin" && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                   select Cons;
        ddl_UserName.DataSource = DATA;
        ddl_UserName.DataTextField = "UserName";
        ddl_UserName.DataValueField = "UserId";
        ddl_UserName.DataBind();
        ddl_UserName.Items.Insert(0, new ListItem());
    }
    private bool IsValid()
    {
        bool val = true;
        if (ddlUserType.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select user type...");
            ddlUserType.Focus();
            val = false;
        }
        else if (txtUserName.Text == "")
        {
            Globals.Message(Page, "Please enter user name...");
            txtUserName.Focus();
            val = false;
        }
        else if (txtLoginId.Text == "")
        {
            Globals.Message(Page, "Please enter login id...");
            txtLoginId.Focus();
            val = false;
        }
        else if (txtPassword.Text == "")
        {
            Globals.Message(Page, "Please enter password...");
            txtPassword.Focus();
            val = false;
        }
        else if (ddlStatus.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select status...");
            ddlStatus.Focus();
            val = false;
        }
        return val;
    }
    protected void btnUserSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UId"] == null)
            {

                var DATA1 = (from Cons in obj.Users
                             where Cons.UserLoingId == txtLoginId.Text
                             select Cons.UserId).Count();
                if (DATA1 == 0)
                {
                    if (role.Insert.Value)
                    {
                        if(IsValid())
                        {
                            if (obj.Sp_User(1, 0, Convert.ToInt32(txtSerialNo.Text), txtUserName.Text.ToUpper(), ddlUserType.Text, txtLoginId.Text, txtPassword.Text, ddlStatus.Text, 0, Convert.ToInt32(Session["CompanyId"])) == 0)
                            {
                                var DATA = (from Cons in obj.Users
                                            select Cons.UserId).Max();
                                IEnumerable<Role> Roles = from Cons in obj.Roles
                                                          select Cons;
                                foreach (Role Cd in Roles.ToList<Role>())
                                {
                                    LoginRole lrole = new LoginRole();
                                    lrole.RoleId = Cd.RoleId;
                                    lrole.LoginId = Convert.ToInt32(DATA);
                                    lrole.Insert = false;
                                    lrole.Update = false;
                                    lrole.Delete = false;
                                    lrole.Select = false;
                                    obj.LoginRoles.InsertOnSubmit(lrole);
                                    obj.SubmitChanges();
                                }
                                userclear();
                            }
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else
                {
                    msg = "A user with same login id already exists";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
            else if (Session["UId"] != null)
            {
                var DATA2 = (from Cons in obj.Users
                             where Cons.UserLoingId == txtLoginId.Text && Cons.UserId != Convert.ToInt32(Session["UId"])
                             select Cons.UserId).Count();
                if (DATA2 == 0)
                {
                    if (role.Insert.Value)
                    {
                        if (obj.Sp_User(2, Convert.ToInt32(Session["UId"]), Convert.ToInt32(txtSerialNo.Text), txtUserName.Text.ToUpper(), ddlUserType.Text, txtLoginId.Text, txtPassword.Text, ddlStatus.Text, 0, Convert.ToInt32(Session["CompanyId"])) == 0)
                        {
                            userclear();

                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else
                {
                    msg = "A user with same login id already exists";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
        }
        catch (Exception ex)
        { }
    }

    protected void Select_click(object sender, EventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
                Session["UId"] = id.ToString();
                var DATA = from Cons in obj.Users
                           where Cons.UserId == id && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                           select Cons;
                txtSerialNo.Text = DATA.First().SerialNo.ToString();
                txtUserName.Text = DATA.First().UserName;
                ddlUserType.Text = DATA.First().UserType;
                txtLoginId.Text = DATA.First().UserLoingId;
                txtPassword.Text = DATA.First().Password;
                ddlStatus.Text = DATA.First().Status;
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void btnUserClear_Click(object sender, EventArgs e)
    {
        userclear();
    }
    
    protected void ddl_UserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                if (ddl_UserName.SelectedIndex != 0)
                {
                    FillLoginRolesList();
                    if (GridRoles.Rows.Count > 0)
                    {
                        btnUpdate.Visible = true;
                        btnAdd.Visible = false;
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                        btnAdd.Visible = true;
                    }
                }
                else
                {
                    GridRoles.DataSource = null;
                    GridRoles.DataBind();
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
            }
            else { Globals.Message(Page, "Not Authorized ??"); ddl_UserName.SelectedIndex = 0; }
        }
        catch (Exception ex)
        { }
    }
    private void FillLoginRolesList()
    {
        IEnumerable<Role> role = from r in obj.Roles
                                 select r;
        if (role.Count<Role>() > 0)
        {
            GridRoles.DataSource = role;
            GridRoles.DataBind();
        }
    }
    protected void GridRoles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ids = GridRoles.DataKeys[e.Row.RowIndex].Value.ToString();
            if ((!string.IsNullOrEmpty(ids)) && (!string.IsNullOrEmpty(ddl_UserName.SelectedValue)))
            {
                int RoleId = Convert.ToInt32(ids);
                int LoginId = Convert.ToInt32(ddl_UserName.SelectedValue);

                CheckBox insert = (CheckBox)e.Row.FindControl("chkInsert");
                CheckBox update = (CheckBox)e.Row.FindControl("chkUpdate");
                CheckBox delete = (CheckBox)e.Row.FindControl("chkDelete");
                CheckBox select = (CheckBox)e.Row.FindControl("chkSelect");
                IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                               where r.RoleId.Value == RoleId
                                               && r.LoginId.Value == LoginId
                                               select r;
                if (roles.Count<LoginRole>() > 0)
                {
                    insert.Checked = roles.First<LoginRole>().Insert.Value;
                    update.Checked = roles.First<LoginRole>().Update.Value;
                    delete.Checked = roles.First<LoginRole>().Delete.Value;
                    select.Checked = roles.First<LoginRole>().Select.Value;
                }
                else
                {
                    insert.Checked = false;
                    update.Checked = false;
                    delete.Checked = false;
                    select.Checked = false;
                }
            }
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddl_UserName.SelectedIndex != 0)
        {
            if (role.Insert.Value)
            {
                int LogId = Convert.ToInt32(ddl_UserName.SelectedValue);
                IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                               where r.LoginId.Value == LoginId
                                               select r;
                if (roles.Count<LoginRole>() > 0)
                {
                    for (int i = 0; i < GridRoles.Rows.Count; i++)
                    {
                        if (GridRoles.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            CheckBox insert = (CheckBox)GridRoles.Rows[i].FindControl("chkInsert");
                            CheckBox update = (CheckBox)GridRoles.Rows[i].FindControl("chkUpdate");
                            CheckBox delete = (CheckBox)GridRoles.Rows[i].FindControl("chkDelete");
                            CheckBox select = (CheckBox)GridRoles.Rows[i].FindControl("chkSelect");

                            int RoleId = Convert.ToInt32(GridRoles.DataKeys[i].Value.ToString());
                            LoginRole lrole = new LoginRole();
                            lrole.RoleId = RoleId;
                            lrole.LoginId = LogId;
                            lrole.Insert = insert.Checked;
                            lrole.Update = update.Checked;
                            lrole.Delete = delete.Checked;
                            lrole.Select = select.Checked;
                            obj.LoginRoles.InsertOnSubmit(lrole);
                            obj.SubmitChanges();
                        }

                    }
                    Globals.Message(Page, "Permission Saved ??");
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        else { Globals.Message(Page, "Please select user..."); ddl_UserName.Focus(); }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (role.Update.Value)
        {
            for (int i = 0; i < GridRoles.Rows.Count; i++)
            {
                if (GridRoles.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    int RoleId = Convert.ToInt32(GridRoles.DataKeys[i].Value.ToString());
                    CheckBox insert = (CheckBox)GridRoles.Rows[i].FindControl("chkInsert");
                    CheckBox update = (CheckBox)GridRoles.Rows[i].FindControl("chkUpdate");
                    CheckBox delete = (CheckBox)GridRoles.Rows[i].FindControl("chkDelete");
                    CheckBox select = (CheckBox)GridRoles.Rows[i].FindControl("chkSelect");
                    //  DeleteRoles();
                    obj.sp_UpdateLoginRoles(Convert.ToInt32(ddl_UserName.SelectedValue), RoleId, insert.Checked, update.Checked, delete.Checked, select.Checked);
                }
            }
            Globals.Message(Page, "Permission updated ??");
        }
        else Globals.Message(Page, "Not Authorized ??");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //if (Valid())
        //{
        //    if (!string.IsNullOrEmpty(hfId.Value))
        //    {
        //        int LogId = Convert.ToInt32(hfId.Value);
        //        int Rows = context.DeleteLogins(LogId.ToString(), Convert.ToInt32(hfId.Value));
        //        if (Rows > 0)
        //        {
        //            for (int i = 0; i < GridRoles.Rows.Count; i++)
        //            {
        //                if (GridRoles.Rows[i].RowType == DataControlRowType.DataRow)
        //                {
        //                    int RoleId = Convert.ToInt32(GridRoles.DataKeys[i].Value.ToString());
        //                    context.DeleteLoginRoles(LogId, RoleId);
        //                }
        //            }
        //            Clear();
        //            Search();
        //            Utility.Message(Page, "Record Deleted Successfully!!");
        //        }
        //    }
        //}
    }

    //protected void DeleteRoles()
    //{
    //    if (Valid())
    //    {
    //        if (!string.IsNullOrEmpty(hfId.Value))
    //        {
    //            int LogId = Convert.ToInt32(hfId.Value);
    //            int Rows = context.DeleteLogins(LogId.ToString(), Convert.ToInt32(hfId.Value));
    //            if (Rows > 0)
    //            {
    //                for (int i = 0; i < GridRoles.Rows.Count; i++)
    //                {
    //                    if (GridRoles.Rows[i].RowType == DataControlRowType.DataRow)
    //                    {
    //                        int RoleId = Convert.ToInt32(GridRoles.DataKeys[i].Value.ToString());
    //                        context.DeleteLoginRoles(LogId, RoleId);
    //                    }
    //                }

    //            }
    //        }
    //    }
    //}
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_UserName.SelectedIndex = 0;
            GridRoles.DataSource = null;
            GridRoles.DataBind();
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        }
        catch (Exception ex)
        { }
    }
}