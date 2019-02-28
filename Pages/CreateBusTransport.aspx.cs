using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CreateBusTransport : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    int b = 0;
    LoginRole role = new LoginRole();
    protected void Page_Load(object sender, EventArgs e)
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
        if (!IsPostBack)
        {
            if (Session["CompanyId"] != null)
            {
                BindGrid();
                FillSchoolName();
                if (Session["Transportid"] != null)
                {
                    GetTransport();
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }

    private void BindGrid()
    {
        try
        {
            if (role.Select.Value)
            {
                var DATA1 = from Cons in obj.BusTransports
                            where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                            select Cons;
                GridKM.DataSource = DATA1;
                GridKM.DataBind();
            }

            var D = from Cons in obj.BusTransports
                    where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                    select Cons;
            ddlTo.DataSource = D;
            ddlTo.DataTextField = "To";
            ddlTo.DataBind();
            ddlTo.Items.Insert(0, new ListItem());
            ddlTo.Items.Insert(1, "NEW");

        }
        catch (Exception ex)
        { }
    }

    private void GetTransport()
    {
        int id = Convert.ToInt32(Session["Transportid"]);
        AllMethods m = AllMethods.GetTransportData(id);
        txtFrom.Text = m.From;
        txtTo.Visible = true;
        txtTo.Text = m.To;
        if (m.KM != "0.00" && m.RPKM != "0.00")
        {
            ChkKM.Checked = true;
            KM.Visible = true;
            txtKM.Text = m.KM;
            txtRPKM.Text = m.RPKM;
        }
        else
        {
            KM.Visible = false;
            txtKM.Text ="";
            txtRPKM.Text ="";
        }
        txtTotalFees.Text = m.TotalFees;
    }
    protected void ChkKM_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkKM.Checked)
        {
            KM.Visible = true;
            txtKM.Focus();
        }
        else
        {
            KM.Visible = false;
        }
    }
    private void Clear()
    {
        KM.Visible = false;
        ChkKM.Checked = false;
        txtKM.Text = string.Empty;
        txtRPKM.Text =string.Empty;
        txtTotalFees.Text =string.Empty;
        txtTo.Text = string.Empty;
        txtTo.Visible = false;
        BindGrid();
        Session["Transportid"] = null;
        FillSchoolName();
    }
    protected void FillSchoolName()
    {
        var Profile = from Cons in obj.Settings
                      where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                      select Cons;
        txtFrom.Text = Profile.First().SchoolName;
        txtFrom.Enabled = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Transportid"] == null)
            {
                if (role.Insert.Value)
                {
                    if (obj.SP_BusTransport(1, 0, txtFrom.Text, txtTo.Text, ChkKM.Checked ? Convert.ToDecimal(txtKM.Text) : 0, ChkKM.Checked ? Convert.ToDecimal(txtRPKM.Text) : 0, Convert.ToDecimal(txtTotalFees.Text), 0,
Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        msg = "Record Insert Successfully!!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                        Clear();
                    }
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
            else if (Session["Transportid"] != null)
            {
                if (role.Update.Value)
                {
                    if (obj.SP_BusTransport(2, Convert.ToInt32(Session["Transportid"]), txtFrom.Text, txtTo.Text, ChkKM.Checked ? Convert.ToDecimal(txtKM.Text) : 0, ChkKM.Checked ? Convert.ToDecimal(txtRPKM.Text) : 0, Convert.ToDecimal(txtTotalFees.Text), 0,
Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        msg = "Record Updated Successfully!!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                        Clear();
                    }
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
        }
        catch (Exception ex)
        { }
    }
    protected void txtRPKM_TextChanged(object sender, EventArgs e)
    {
        Cal();
        txtTotalFees.Focus();
    }

    private void Cal()
    {
        try
        {
            decimal KM = 0, RPKM = 0, Fees = 0;
            try
            {
                KM = Convert.ToDecimal(txtKM.Text);
            }
            catch (Exception ex)
            { KM = 0; }
            try
            {
                RPKM = Convert.ToDecimal(txtRPKM.Text);
            }
            catch (Exception ex)
            { RPKM = 0; }
            Fees = KM * RPKM;
            txtTotalFees.Text = Fees.ToString();
        }
        catch (Exception ex)
        { }
    }
    protected void txtKM_TextChanged(object sender, EventArgs e)
    {
        Cal();
        txtRPKM.Focus();
    }
    protected void GridKM_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                int id = Convert.ToInt32(GridKM.DataKeys[e.NewSelectedIndex].Value);
                Session["Transportid"] = GridKM.DataKeys[e.NewSelectedIndex].Value;
                Response.Redirect(Request.RawUrl);
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTo.Text == "NEW")
            {
                txtTo.Visible = true;
                txtTotalFees.Text = "";
                txtTo.Focus();
                ddlTo.Text = "";
            }
            else
            {
                txtTo.Text = ddlTo.SelectedItem.Text;
                txtTo.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
}