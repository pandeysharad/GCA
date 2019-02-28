using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_OtherFees : System.Web.UI.Page
{
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
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
                FillDropdown.FillSINGLEVALUEDATA(ddlTo, "OTHER FEES HEAD", Convert.ToInt32(Session["CompanyId"]));
                if (Session["CompanyId"] != null)
                {
                    var DATACOURSE = from Cons in obj.Courses
                                     where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                     select Cons;
                    ddlSelectClass.DataSource = DATACOURSE;
                    ddlSelectClass.DataTextField = "CourseName";
                    ddlSelectClass.DataValueField = "CourseId";
                    ddlSelectClass.DataBind();
                    ddlSelectClass.Items.Insert(0, new ListItem("--SELECT--", "0"));
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
        }
        catch (Exception ex) { }
    }
    protected void ddlSelectClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                if (ddlSelectClass.SelectedIndex != 0)
                {
                    IEnumerable<Other_Fee> DATA1 = from Cons in obj.Other_Fees
                                                   where Cons.CourseId == Convert.ToInt32(ddlSelectClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                   select Cons;
                    if (DATA1.Count<Other_Fee>() > 0)
                    {
                        GridOtherFees.DataSource = DATA1;
                        GridOtherFees.DataBind();
                    }
                    else
                    {
                        GridOtherFees.DataSource = null;
                        GridOtherFees.DataSource = null;
                        GridOtherFees.DataBind();
                    }
                    var DATA = (from Cons in obj.Other_Fees
                                where Cons.CourseId == Convert.ToInt32(ddlSelectClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons.SerialNo).Max() + 1;
                    if (DATA == null)
                    {
                        txtSerialNo.Text = "1";
                    }
                    else
                    {
                        txtSerialNo.Text = DATA.ToString();
                    }
                }
                else
                {
                    GridOtherFees.DataSource = null;
                    GridOtherFees.DataBind();
                    txtFeesType.Text = string.Empty;
                    txtFees.Text = string.Empty;
                    txtSerialNo.Text = "";
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        {
        }
    }
    private void Clear()
    {
        btnDelete.Visible = false;
        if (ddlSelectClass.SelectedIndex != 0)
        {
            var DATA = (from Cons in obj.Other_Fees
                        where Cons.CourseId == Convert.ToInt32(ddlSelectClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons.SerialNo).Max() + 1;
            if (DATA == null)
            {
                txtSerialNo.Text = "1";
            }
            else
            {
                txtSerialNo.Text = DATA.ToString();
            }

            IEnumerable<Other_Fee> DATA1 = from Cons in obj.Other_Fees
                                           where Cons.CourseId == Convert.ToInt32(ddlSelectClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                           select Cons;
            if (DATA1.Count<Other_Fee>() > 0)
            {
                GridOtherFees.DataSource = DATA1;
                GridOtherFees.DataBind();
                txtFeesType.Text = string.Empty;
                txtFees.Text = string.Empty;
                ddlTo.ClearSelection();
                txtFeesType.Focus();
                ddlTakePayment.ClearSelection();
            }
            else
            {
                Session["OtherFeesId"] = null;
                GridOtherFees.DataSource = null;
                GridOtherFees.DataBind();
            }
        }
        else
        {
            txtSerialNo.Text = "";
            txtFeesType.Text = string.Empty;
            txtFees.Text = string.Empty;
            Session["OtherFeesId"] = null;
            txtFeesType.Focus();
            ddlTakePayment.ClearSelection();
        }
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTakePayment.SelectedIndex > 0)
            {
                if (txtFeesType.Text != "")
                {
                    if (txtFees.Text != "")
                    {
                        if (Session["OtherFeesId"] == null)
                        {
                            if (role.Insert.Value)
                            {
                                AllMethods c = AllMethods.SelectOtherFeesId(txtFeesType.Text.ToUpper(), Convert.ToInt32(ddlSelectClass.SelectedValue), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                if (c == null)
                                {
                                    if (obj.Sp_Other_Fees(1, 0, Convert.ToInt32(ddlSelectClass.SelectedValue), Convert.ToInt32(txtSerialNo.Text), txtFeesType.Text.ToUpper(), Convert.ToDecimal(txtFees.Text), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["SessionId"]),ddlTakePayment.SelectedItem.Text) == 0)
                                    {
                                        Clear();
                                        msg = "Record inserted successfully...";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                    }
                                }
                                else
                                {
                                    msg = "This fees type is already exist...";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                    txtFeesType.Focus();
                                }
                            }
                            else Globals.Message(Page, "Not Authorized ??");
                        }
                        else
                        {
                            if (role.Update.Value)
                            {
                                if (txtFeesType.Text == Session["txtFeesType"].ToString())
                                {
                                    UpdateOtherFees();
                                    Session["OtherFeesId"] = null;
                                }
                                else
                                {
                                    IEnumerable<Other_Fee> comp = from c in obj.Other_Fees
                                                                  where c.FeesType == txtFeesType.Text && c.CourseId == Convert.ToInt32(ddlSelectClass.SelectedValue) &&
                                                                  c.Remove == false && c.CompanyId == Convert.ToInt32(Session["CompanyId"]) && c.SessionId == Convert.ToInt32(Session["SessionId"])
                                                                  select c;
                                    if (comp.Count<Other_Fee>() == 0)
                                    {
                                        UpdateOtherFees();
                                        Session["OtherFeesId"] = null;
                                    }
                                    else
                                    {
                                        msg = "Same Fees Type already exist...";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                        txtFeesType.Text = Session["txtFeesType"].ToString();
                                        txtFeesType.Focus();
                                    }
                                }
                            }
                            else Globals.Message(Page, "Not Authorized ??");

                        }
                    }
                    else
                    {
                        msg = "Please enter fees...";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                        txtFees.Focus();
                    }
                }
                else
                {
                    msg = "Please enter other fees type...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                    txtFeesType.Focus();
                }
            }
            else
            {
                msg = "Please select Fees Type...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                ddlTakePayment.Focus();
            }
        }
        catch (Exception ex)
        { }
    }

    private void UpdateOtherFees()
    {
        if (obj.Sp_Other_Fees(2, Convert.ToInt32(Session["OtherFeesId"]), Convert.ToInt32(ddlSelectClass.SelectedValue), Convert.ToInt32(txtSerialNo.Text), txtFeesType.Text.ToUpper(), Convert.ToDecimal(txtFees.Text), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["SessionId"]),ddlTakePayment.SelectedItem.Text) == 0)
        {
            Clear();
            msg = "Record updated successfully...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
        }
    }
    protected void GridOtherFees_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                btnDelete.Visible = true;
                Session["OtherFeesId"] = GridOtherFees.DataKeys[e.NewSelectedIndex].Value;
                if (Session["OtherFeesId"] != null)
                {
                    var DATA2 = from Cons in obj.Other_Fees
                                where Cons.OtherFeesId == Convert.ToInt32(Session["OtherFeesId"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    txtSerialNo.Text = DATA2.First().SerialNo.ToString();
                    txtFeesType.Text = DATA2.First().FeesType;
                    ddlTo.ClearSelection();
                    foreach (ListItem li in ddlTo.Items)
                    {
                        if (li.Text == DATA2.First().FeesType.ToString())
                        {
                            txtFeesType.Visible = false;
                            li.Selected = true;
                            break;
                        }
                    }
                    if (ddlTo.SelectedIndex == 0)
                        txtFeesType.Visible = true;

                    //ddlTakePayment.SelectedItem.Text = DATA2.First().PayType;
                    Session["txtFeesType"] = DATA2.First().FeesType;
                    txtFees.Text = DATA2.First().Fees.ToString();
                    ddlSelectClass.SelectedValue = DATA2.First().CourseId.ToString();
                    ddlTakePayment.ClearSelection();
                    if (DATA2.First().PayType != "")
                    {
                        foreach (ListItem li in ddlTakePayment.Items)
                        {
                            if (li.Text == DATA2.First().PayType.ToString())
                            {
                                li.Selected = true;
                                break;
                            }
                        }
                    }
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
    protected void GridOtherFees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            GridOtherFees.PageIndex = e.NewPageIndex;
            IEnumerable<Other_Fee> DATA1 = from Cons in obj.Other_Fees
                                           where Cons.CourseId == Convert.ToInt32(ddlSelectClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                           select Cons;
            if (DATA1.Count<Other_Fee>() > 0)
            {
                GridOtherFees.DataSource = DATA1;
                GridOtherFees.DataBind();
            }
            else
            {
                GridOtherFees.DataSource = null;
                GridOtherFees.DataSource = null;
                GridOtherFees.DataBind();
            }
            GridOtherFees.DataBind();
        }
        catch (Exception ex) { }
    }
    protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTo.SelectedItem.Text == "NEW")
            {
                txtFeesType.Visible = true;
                txtFeesType.Text = "";
                txtFeesType.Focus();
                ddlTo.SelectedItem.Text = "";
            }
            else
            {
                txtFeesType.Text = ddlTo.SelectedItem.Text;
                txtFeesType.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteOtherFees();
    }
    private void DeleteOtherFees()
    {
        int deleteOrNot = Convert.ToInt32(AllMethods.CheckOtherFeesHeadDeleteOrNot(ddlTo.SelectedItem.Text, Convert.ToInt32(ddlSelectClass.SelectedValue), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])));
        if (deleteOrNot != 0)
        {
            Globals.Message(Page, "Already paid amount for this head ...");
            Clear();
        }
        else
        {
            if (obj.Sp_Other_Fees(3, Convert.ToInt32(Session["OtherFeesId"]), Convert.ToInt32(ddlSelectClass.SelectedValue), Convert.ToInt32(txtSerialNo.Text), txtFeesType.Text.ToUpper(), Convert.ToDecimal(txtFees.Text), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["SessionId"]),"") == 0)
            {
                Clear();
                msg = "Record delete successfully...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
    }
}