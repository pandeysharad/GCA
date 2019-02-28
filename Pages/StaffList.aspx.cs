using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_StaffList : System.Web.UI.Page
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
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 5
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
            if (!IsPostBack)
            {
                if (Session["CompanyId"] != null)
                {
                    BindDataGrid();
                }
            }
        }
        catch (Exception ex)
        { }
    }

    private void BindDataGrid()
    {
        if (role.Select.Value)
        {
            lblAuthorized.Visible = false;
            if (txtSearchByStaffId.Text != "")
            {
                var DATA = from Cons in obj.Staffs
                           where Cons.StaffId == txtSearchByStaffId.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                           select Cons;
                GridStaffDetails.DataSource = DATA;
                GridStaffDetails.DataBind();
            }
            else
            {
                if (comSearchBy.SelectedIndex != 0)
                {
                    var DATA = from Cons in obj.Staffs
                               where Cons.Status == comSearchBy.SelectedItem.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons;
                    GridStaffDetails.DataSource = DATA;
                    GridStaffDetails.DataBind();
                }
                else
                {
                    var DATA = from Cons in obj.Staffs
                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons;
                    GridStaffDetails.DataSource = DATA;
                    GridStaffDetails.DataBind();
                }
            }
        }
        else
        {
            lblAuthorized.Visible = true;
            lblAuthorized.Text = "Not Authorized to See..";
        }
    }

    protected void GridStaffDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridStaffDetails.PageIndex = e.NewPageIndex;
        BindDataGrid();
        GridStaffDetails.DataBind();
    }
    protected void GridStaffDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                int id = Convert.ToInt32(GridStaffDetails.DataKeys[e.NewSelectedIndex].Value);
                Session["StaffPId"] = GridStaffDetails.DataKeys[e.NewSelectedIndex].Value;
                Response.Redirect("Staff.aspx");
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearchDetails_Click(object sender, EventArgs e)
    {
        try
        {
            BindDataGrid();
        }
        catch (Exception ex)
        { }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Visibility", "Visibility();", true);
                if (txtSearchByStaffId.Text != "")
                {
                    Session["SLPSearchByStaffId"] = txtSearchByStaffId.Text;
                    Session["SLPBOTH"] = "";
                    Session["SLPACTIVE"] = "";
                    Session["SLPINACTIVE"] = "";
                }
                else if (comSearchBy.Text == "BOTH")
                {
                    Session["SLPBOTH"] = comSearchBy.Text;
                    Session["SLPACTIVE"] = "";
                    Session["SLPINACTIVE"] = "";
                    Session["SLPSearchByStaffId"] = "";
                }
                else if (comSearchBy.Text == "ACTIVE")
                {
                    Session["SLPBOTH"] = "";
                    Session["SLPACTIVE"] = comSearchBy.Text;
                    Session["SLPINACTIVE"] = "";
                    Session["SLPSearchByStaffId"] = "";
                }
                else if (comSearchBy.Text == "INACTIVE")
                {
                    Session["SLPBOTH"] = "";
                    Session["SLPACTIVE"] = "";
                    Session["SLPSearchByStaffId"] = "";
                    Session["SLPINACTIVE"] = comSearchBy.Text;
                }
                string URL = "javascript:window.open('StaffListReport.aspx')";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
}