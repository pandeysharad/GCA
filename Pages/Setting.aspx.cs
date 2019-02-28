using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Setting : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    public int SrNo = 1;
    int s = 0;
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
                    var DATA = from Cons in obj.Settings
                               where Cons.CompanyId==Convert.ToInt32(Session["CompanyId"])
                               select Cons;
                    txtMsgAPI.Text = DATA.First().MsgAPI;
                    if (DATA.First().SendMsg == true)
                    {
                        chkSendMsg.Checked = true;
                    }
                    else if (DATA.First().SendMsg == false)
                    {
                        chkSendMsg.Checked = false;
                    }
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
            if (role.Update.Value)
            {
                if (obj.Sp_Setting(3, Convert.ToInt32(Session["CompanyId"]), "", "", "", "", "", "", txtMsgAPI.Text, chkSendMsg.Checked ? true : false) == 0)
                {
                    Globals.Message(Page, "Saved Successfully....");
                }
             }
             else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
}