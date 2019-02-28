using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Reports : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    LoginRole role = new LoginRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            if (Session["UserType"].ToString() != "Admin")
            {
                IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                               where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 4
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
                ddlClassName.DataSource = obj.Courses.Distinct();
                ddlClassName.DataValueField = "CourseId";
                ddlClassName.DataTextField = "CourseName";
                ddlClassName.DataBind();
                ddlClassName.Items.Insert(0, new ListItem("All","0"));
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                if (RadReportType.SelectedIndex < 0)
                {
                    Globals.Message(Page, "Please select a report !!");
                    return;
                }
                if (txtFrom.Text != "")
                {
                    if (txtTo.Text != "")
                    {
                        string URL = string.Empty;
                        if (RadReportType.SelectedIndex == 0)
                        {
                            URL = "javascript:window.open('../Reports/InstallmentsDueSheet.aspx?CourseId=" + ddlClassName.SelectedValue + "&From=" + txtFrom.Text + "&To=" + txtTo.Text + "','','');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                        else if (RadReportType.SelectedIndex == 1)
                        {
                            URL = "javascript:window.open('../Reports/MonthlyDueSheet.aspx?CourseId=" + ddlClassName.SelectedValue + "&From=" + txtFrom.Text + "&To=" + txtTo.Text + "','','');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                        else if (RadReportType.SelectedIndex == 2)
                        {
                            URL = "javascript:window.open('../Reports/AllReceivedAndBalanceSheet.aspx?CourseId=" + ddlClassName.SelectedValue + "&From=" + txtFrom.Text + "&To=" + txtTo.Text + "','','');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                        else if (RadReportType.SelectedIndex == 3)
                        {
                            URL = "javascript:window.open('../Reports/SchollWiseCollection.aspx?From=" + txtFrom.Text + "&To=" + txtTo.Text + "','','');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                        else if (RadReportType.SelectedIndex == 4)
                        {
                            URL = "javascript:window.open('../Reports/ClassWiseCollection.aspx?CourseId=" + ddlClassName.SelectedValue + "&From=" + txtFrom.Text + "&To=" + txtTo.Text + "','','');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                        else
                        {
                            Globals.Message(Page, "Please select a report !!");
                        }
                    }
                    else { Globals.Message(Page, "Please select end/to date !!"); txtFrom.Focus(); }
                }
                else { Globals.Message(Page, "Please select start/from date !!"); txtTo.Focus(); }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void ChkToday_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkToday.Checked)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            txtFrom.Text =string.Empty;
            txtTo.Text =string.Empty;
        }
    }
    protected void txtFrom_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            if (DateTime.Now.ToShortDateString() == Convert.ToDateTime(txtFrom.Text).ToShortDateString() && DateTime.Now.ToShortDateString() == Convert.ToDateTime(txtTo.Text).ToShortDateString())
            {
                ChkToday.Checked = true;
            }
            else
            {
                ChkToday.Checked = false;
            }
        }
        catch (Exception ex) { }
    }
    protected void txtTo_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            if (DateTime.Now.ToShortDateString() == Convert.ToDateTime(txtFrom.Text).ToShortDateString() && DateTime.Now.ToShortDateString() == Convert.ToDateTime(txtTo.Text).ToShortDateString())
            {
                ChkToday.Checked = true;
            }
            else
            {
                ChkToday.Checked = false;
            }
        }
        catch (Exception ex)
        { }
    }

    protected void RadReportType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
                    if (RadReportType.SelectedIndex == 3)
                    {
                        ddlClassName.SelectedIndex = 0;
                        ddlClassName.Enabled = false;
                    }
                    else
                    {
                        ddlClassName.Enabled = true;
                    }
           
        }
        catch (Exception ex)
        { }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            ddlClassName.SelectedIndex = 0;
            RadReportType.SelectedIndex = -1;
            txtFrom.Text = string.Empty;
            txtTo.Text = string.Empty;
            ChkToday.Checked = false;

        }
        catch (Exception ex)
        { }
    }
}