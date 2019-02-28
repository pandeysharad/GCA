using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq.SqlClient;

public partial class Pages_JobEnquiry : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    int b = 0;
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
                    ddl_Status.SelectedIndex = 1;
                    dtEnquiryDate.Text = Convert.ToDateTime(System.DateTime.Now).ToString("dd/MM/yyyy");
                    var DATA = (from Cons in obj.JobEnquiries
                                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons.JobEnquiryNo).Max()+1;
                    if (DATA == null)
                    {
                        txtJobEnquiryNo.Text = "1";
                    }
                    else
                    {
                        txtJobEnquiryNo.Text = DATA.ToString();
                    }
                    for (int i = 0; i <= 10; i++)
                    {
                        ddlNoOfEnpInYear.Items.Add(new ListItem(i.ToString()));
                        ddlNoOfExpinMonth.Items.Add(new ListItem(i.ToString()));
                    }
                    BindDataGrid();
                    FillDropdown.FillQualifications(ddlQualification,Convert.ToInt32(Session["CompanyId"].ToString()));
                    if (Session["JobEnquiryId"] != null)
                    {
                        GetEnquiry();
                        
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }

    private void GetEnquiry()
    {
        int id = Convert.ToInt32(Session["JobEnquiryId"]);
        var DATA1 = from Cons in obj.JobEnquiries
                    where Cons.JobEnquiryId == id && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
        txtJobEnquiryNo.Text =DATA1.First().JobEnquiryNo.ToString();
        dtEnquiryDate.Text =Convert.ToDateTime( DATA1.First().EnquiryDate).ToString("dd/MM/yyyy");
        txtName.Text = DATA1.First().Name;
        txtContactNo.Text = DATA1.First().ContactNo;
        if (DATA1.First().ContactNo == DATA1.First().WhatsappNo)
        {
            CheckBox1.Checked = true;
        }
        else
        {
            CheckBox1.Checked = false;
        }
        txtWhatsAppNo.Text = DATA1.First().WhatsappNo;
        txtAddress.Text = DATA1.First().Address;
        txtEmailId.Text = DATA1.First().EmailId;
        ddlNoOfExpinMonth.SelectedIndex = Convert.ToInt32(DATA1.First().ExpMonth);
        ddlNoOfEnpInYear.SelectedIndex = Convert.ToInt32(DATA1.First().ExpYear);
        if (Convert.ToInt32(DATA1.First().ExpYear) > 0 || Convert.ToInt32(DATA1.First().ExpMonth) > 0)
        {
            txtPreviousOrganization.Text = DATA1.First().PreviousOrganization;
            txtDesignation.Text = DATA1.First().Designation;
            divPreviousOrganization.Visible = true;
            divDesignation.Visible = true;
        }
        else
        {
            divPreviousOrganization.Visible = false;
            divDesignation.Visible = false;
        }
        ddlQualification.ClearSelection();
        foreach (ListItem li in ddlQualification.Items)
        {
            if (li.Text == DATA1.First().Qualification.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        txtRemarks.Text = DATA1.First().Remarks;
        if(DATA1.First().Status=="INTERESTED")
        {
            ddl_Status.SelectedIndex = 1;
        }
        else if (DATA1.First().Status == "NOT INTERESTED")
        {
            ddl_Status.SelectedIndex = 2;
        }
    }
    private void BindDataGrid()
    {
        if (role.Select.Value)
        {
            lblAuthorized.Visible = false;
            if (ddl_Search.Text == "By Student")
            {
                var DATA1 = from Cons in obj.JobEnquiries
                            where SqlMethods.Like(Cons.Name, "" + txtSearchByStudentName.Text + "%") && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                GridEnquiry.DataSource = DATA1;
                GridEnquiry.DataBind();
            }
            else if (ddl_Search.Text == "By Contact No")
            {
                var DATA1 = from Cons in obj.JobEnquiries
                            where SqlMethods.Like(Cons.ContactNo, "" + txtSearchByContact.Text + "%") && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                GridEnquiry.DataSource = DATA1;
                GridEnquiry.DataBind();
            }
            else if (ddl_Search.Text == "By Date")
            {
                var DATA1 = from Cons in obj.JobEnquiries
                            where Cons.EnquiryDate >= DateTime.Parse(dtSDate.Text) &&
                               Cons.EnquiryDate <= DateTime.Parse(dtEDate.Text) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                GridEnquiry.DataSource = DATA1;
                GridEnquiry.DataBind();
            }
        }
        else
        {
            lblAuthorized.Visible = true;
            lblAuthorized.Text = "Not Authorized to See..";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Visibility", "Visibility();", true);
    }
    private bool Isval()
    {
        bool val = true;
        if (dtEnquiryDate.Text == "")
        {
            Globals.Message(Page, "Please enter/select enquiry date...");
            dtEnquiryDate.Focus();
            val = false;
        }
        else if (txtName.Text == "")
        {
            Globals.Message(Page, "Please enter name...");
            txtName.Focus();
            val = false;
        }
        else if (txtContactNo.Text == "")
        {
            Globals.Message(Page, "Please enter contact number...");
            txtContactNo.Focus();
            val = false;
        }
        else if (ddlQualification.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select qualification...");
            ddlQualification.Focus();
            val = false;
        }
        else if (ddl_Status.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select qualification...");
            ddlQualification.Focus();
            val = false;
        }
        return val;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Isval())
            {
                if (Session["JobEnquiryId"] == null)
                {
                    if (role.Insert.Value)
                    {
                        IEnumerable<JobEnquiry> JobEnquiries = from id in obj.JobEnquiries
                                                         where id.JobEnquiryNo == Convert.ToInt32(txtJobEnquiryNo.Text) && id.Remove==false
                                                            && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                            select id;

                        if (JobEnquiries.Count<JobEnquiry>() <= 0)
                        {
                            if (obj.Sp_JobEnquiry(1, 0, Convert.ToInt32(txtJobEnquiryNo.Text), dtEnquiryDate.Text != "" ? Convert.ToDateTime(dtEnquiryDate.Text) : System.DateTime.Now, txtName.Text, txtContactNo.Text, txtWhatsAppNo.Text, txtAddress.Text, txtEmailId.Text, ddlNoOfEnpInYear.SelectedItem.Text, ddlNoOfExpinMonth.SelectedItem.Text,
                                txtDesignation.Text, txtPreviousOrganization.Text, ddlQualification.SelectedItem.Text, txtRemarks.Text, ddl_Status.SelectedItem.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                            {
                                msg = "Record insert successfully!!";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                Clear();
                            }
                        }
                        else
                        {
                            Globals.Message(Page, "Job enquiry no. already exist...");
                            Clear();
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else if (Session["JobEnquiryId"] != null)
                {
                    if (role.Update.Value)
                    {
                        if (obj.Sp_JobEnquiry(2, Convert.ToInt32(Session["JobEnquiryId"]), Convert.ToInt32(txtJobEnquiryNo.Text), dtEnquiryDate.Text != "" ? Convert.ToDateTime(dtEnquiryDate.Text) : System.DateTime.Now, txtName.Text, txtContactNo.Text, txtWhatsAppNo.Text, txtAddress.Text, txtEmailId.Text, ddlNoOfEnpInYear.SelectedItem.Text, ddlNoOfExpinMonth.SelectedItem.Text,
                           txtDesignation.Text, txtPreviousOrganization.Text, ddlQualification.SelectedItem.Text, txtRemarks.Text, ddl_Status.SelectedItem.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                        {
                            msg = "Record updated successfully!!";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            Clear();
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
            }
        }
        catch (Exception ex)
        { }
    }

    private void Clear()
    {
        try
        {
            dtEnquiryDate.Text = Convert.ToDateTime(System.DateTime.Now).ToString("dd/MM/yyyy");
            var DATA = (from Cons in obj.JobEnquiries
                        select Cons.JobEnquiryNo).Max() + 1;
            if (DATA == null)
            {
                txtJobEnquiryNo.Text = "1";
            }
            else
            {
                txtJobEnquiryNo.Text = DATA.ToString();
            }
            ddlNoOfEnpInYear.ClearSelection();
            ddlNoOfExpinMonth.ClearSelection();
            for (int i = 0; i <= 10; i++)
            {
                ddlNoOfEnpInYear.Items.Add(new ListItem(i.ToString()));
                ddlNoOfExpinMonth.Items.Add(new ListItem(i.ToString()));
            }
            BindDataGrid();
            FillDropdown.FillQualifications(ddlQualification, Convert.ToInt32(Session["CompanyId"].ToString()));
            dtEnquiryDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtWhatsAppNo.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtPreviousOrganization.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            ddl_Status.SelectedIndex = 0;
            Session["JobEnquiryId"] = null;
            Session["JEPContactNo"] = null;
            Session["JEPStudentName"] = null;
            Session["JEPdtSDate"] = null;
            Session["JEPdtEDate"] = null;
            Session["JobEnquiryId1"] = null;
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
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (CheckBox1.Checked)
            {
                txtWhatsAppNo.Text = txtContactNo.Text;
                txtAddress.Focus();
            }
            else
            {
                txtWhatsAppNo.Text = "";
                txtWhatsAppNo.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlNoOfEnpInYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShowOrgnization(ref ddlNoOfEnpInYear, ref ddlNoOfExpinMonth);
            if (ddlNoOfEnpInYear.SelectedIndex > 1)
            {
                ddlYear.SelectedIndex = 1;
            }
            else
            {
                ddlYear.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        { }

    }

    private void ShowOrgnization(ref DropDownList dll1,ref DropDownList ddl2)
    {
        if (dll1.SelectedIndex != 0 || ddl2.SelectedIndex != 0)
        {
            divPreviousOrganization.Visible = true;
            divDesignation.Visible = true;
        }
        else
        {
            txtPreviousOrganization.Text = "";
            txtDesignation.Text = "";
            divPreviousOrganization.Visible = false;
            divDesignation.Visible = false;
        }
    }
    protected void ddlNoOfExpinMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShowOrgnization(ref ddlNoOfEnpInYear, ref ddlNoOfExpinMonth);
            if (ddlNoOfExpinMonth.SelectedIndex > 1)
            {
                ddlMonth.SelectedIndex = 1;
            }
            else
            {
                ddlMonth.SelectedIndex = 0;
            }
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
                if (ddl_Search.Text == "By Student")
                {
                    Session["JEPStudentName"] = txtSearchByStudentName.Text;
                    Session["JEPContactNo"] = "";
                    Session["JEPdtSDate"] = "";
                    Session["JEPdtEDate"] = "";
                }
                else if (ddl_Search.Text == "By Contact No")
                {
                    Session["JEPContactNo"] = txtSearchByContact.Text;
                    Session["JEPStudentName"] = "";
                    Session["JEPdtSDate"] = "";
                    Session["JEPdtEDate"] = "";
                }
                else if (ddl_Search.Text == "By Date")
                {
                    Session["JEPdtSDate"] = dtSDate.Text;
                    Session["JEPdtEDate"] = dtEDate.Text;
                    Session["JEPContactNo"] = "";
                    Session["JEPStudentName"] = "";
                }
                string URL = "javascript:window.open('JobEquiryReport.aspx')";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
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
    protected void OnSelectedJoin(object sender, EventArgs e)
    {
        try
        {
            if (role.Insert.Value)
            {
                string JobEnquiryId = (sender as LinkButton).CommandArgument;
                b = 1;
                Session["JobEnquiryId1"] = JobEnquiryId;
                Response.Redirect("Staff.aspx");
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void GridEnquiry_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (role.Update.Value)
        {
            if (b != 1)
            {
                Session["JobEnquiryId"] = GridEnquiry.DataKeys[e.NewSelectedIndex].Value;
                Response.Redirect(Request.RawUrl);
            }
        }
        else Globals.Message(Page, "Not Authorized ??");
    }
    protected void GridEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridEnquiry.PageIndex = e.NewPageIndex;
        BindDataGrid();
        GridEnquiry.DataBind();
    }
}