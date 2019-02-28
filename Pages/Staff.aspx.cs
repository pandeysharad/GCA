using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Pages_Staff : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    int SerialNo = 0;
    string StaffId = "";
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
                    imgStaffImg.ImageUrl = "~/images/male.png";
                    FillDropdown.FillCast(comCategory,Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.FillReligion(comReligion, Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.FillQualifications(ddlQualification, Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.FillDepartments(ddlDepartment, Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.Fill12thStream(ddl12Stream, Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.FillGraduationStream(ddlGraduationStream, Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.FillPostGraduationStream(ddlPostGraduationStream, Convert.ToInt32(Session["CompanyId"].ToString()));
                    FillDropdown.FillStaffType(comStaffType, Convert.ToInt32(Session["CompanyId"].ToString()));
                    comNationality.SelectedIndex = 1;
                    comStatus.SelectedIndex = 1;
                    txtJoinDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
                    if (Session["StaffPId"] == null)
                    {
                        GenerateStaffId();
                    }
                    for (int i = 0; i <= 10; i++)
                    {
                        ddlNoOfEnpInYear.Items.Add(new ListItem(i.ToString()));
                        ddlNoOfExpinMonth.Items.Add(new ListItem(i.ToString()));
                    }
                    if (Session["JobEnquiryId1"] != null)
                    {
                        var DATA = from Cons in obj.JobEnquiries
                                   where Cons.JobEnquiryId == Convert.ToInt32(Session["JobEnquiryId1"])
                                   select Cons;
                        txtStaffName.Text = DATA.First().Name;
                        txtContactNo.Text = DATA.First().ContactNo;
                        txtWhatsappNo.Text = DATA.First().WhatsappNo;
                        txtAddress.Text = DATA.First().Address;
                        txtEmailId.Text = DATA.First().EmailId;
                        ddlNoOfEnpInYear.SelectedIndex = Convert.ToInt32(DATA.First().ExpYear);
                        ddlNoOfExpinMonth.SelectedIndex = Convert.ToInt32(DATA.First().ExpMonth);
                        if (ddlNoOfEnpInYear.SelectedIndex != 0 || ddlNoOfExpinMonth.SelectedIndex != 0)
                        {
                            divDesignation.Visible = true;
                            txtDesignation.Text = DATA.First().Designation;
                        }
                        else
                        {
                            divDesignation.Visible = false;
                            txtDesignation.Text = "";
                        }
                    }
                    if (Session["StaffPId"] != null)
                    {
                        GetStaffData();
                    }
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

    private void GetStaffData()
    {
       
            var DATA = from Cons in obj.Staffs
                       where Cons.StaffPId == Convert.ToInt32((Session["StaffPId"]))
                       select Cons;
            txtStaffId.Text = DATA.First().StaffId.ToString();
            Session["txtStaffId"] = DATA.First().StaffId.ToString();
            comStaffType.ClearSelection();
            foreach (ListItem li in comStaffType.Items)
            {
                if (li.Text == DATA.First().StaffType.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            lblDoc.Visible = true;
            txtJoinDate.Text =Convert.ToDateTime(DATA.First().JoinDate).ToString("dd/MM/yyyy");
            txtStaffName.Text = DATA.First().StaffName;
            txtContactNo.Text = DATA.First().ContactNo;
            if (DATA.First().ContactNo == DATA.First().WhatsAppNo)
            {
                CheckBox1.Checked = true;
            }
            else
            {
                CheckBox1.Checked = false;
            }
            txtWhatsappNo.Text = DATA.First().WhatsAppNo;
            txtEmailId.Text = DATA.First().EmailId;
            txtFathersName.Text = DATA.First().FatherName;
            txtMotherName.Text = DATA.First().MotherName;
            txtParentContact.Text = DATA.First().ParentContact;
            txtDOB.Text = Convert.ToDateTime(DATA.First().DOB).ToString("dd/MM/yyyy");
            txtAge.Text = DATA.First().Age;
            comGender.Text = DATA.First().Gender;
            txtPANCard.Text = DATA.First().PANCardNo;
            txtSamagraId.Text = DATA.First().SamagraId;
            txtAddress.Text = DATA.First().Address;
            ddlNoOfEnpInYear.SelectedIndex = Convert.ToInt32(DATA.First().ExpYear);
            ddlNoOfExpinMonth.SelectedIndex = Convert.ToInt32(DATA.First().ExpMonth);
            if (ddlNoOfEnpInYear.SelectedIndex != 0 || ddlNoOfExpinMonth.SelectedIndex != 0)
            {
                divDesignation.Visible = true;
                divRegineDate.Visible = true;
                txtDesignation.Text = DATA.First().Designation;
                txtRegineDate.Text = Convert.ToDateTime(DATA.First().RegineDate).ToString("dd/MM/yyyy");
            }
            else
            {
                divDesignation.Visible = false;
                divRegineDate.Visible = false;
                txtRegineDate.Text = "";
                txtDesignation.Text = "";
            }
            ddlQualification.ClearSelection();
            foreach (ListItem li in ddlQualification.Items)
            {
                if (li.Text == DATA.First().Qualification.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            ddlDepartment.ClearSelection();
            foreach (ListItem li in ddlDepartment.Items)
            {
                if (li.Text == DATA.First().Department.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtBasicSalary.Text = DATA.First().BasicSalary.ToString();
            txtAccountNo.Text = DATA.First().AccountNo;
            txtBankName.Text = DATA.First().bankName;
            txtBranchName.Text = DATA.First().Branch;
            txtIFSCCode.Text = DATA.First().IFSCCode;
            imgStaffImg.ImageUrl = DATA.First().StaffPicture;
            comCategory.ClearSelection();
            foreach (ListItem li in comCategory.Items)
            {
                if (li.Text == DATA.First().Category.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            comReligion.ClearSelection();
            foreach (ListItem li in comReligion.Items)
            {
                if (li.Text == DATA.First().Religion.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtAadharNo.Text = DATA.First().AadharCardNo;
            comNationality.ClearSelection();
            foreach (ListItem li in comNationality.Items)
            {
                if (li.Text == DATA.First().Nationality.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            comStatus.Text = DATA.First().Status;
            ddl12Stream.ClearSelection();
            foreach (ListItem li in ddl12Stream.Items)
            {
                if (li.Text == DATA.First().TwelvethStream.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txt12Subject.Text = DATA.First().TwelvethSubject;
            ddlGraduationStream.ClearSelection();
            foreach (ListItem li in ddlGraduationStream.Items)
            {
                if (li.Text == DATA.First().GraduationStrean.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtGraduationSubject.Text = DATA.First().GraduationSubject;
            ddlPostGraduationStream.ClearSelection();
            foreach (ListItem li in ddlPostGraduationStream.Items)
            {
                if (li.Text == DATA.First().PostGraduationStream.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtPostGraduationSubject.Text = DATA.First().PostGraduationSubject;
            Session["StaffSerialNo"] = DATA.First().StaffSerialNo.ToString();
    }

    private void GenerateStaffId()
    {
        try
        {
            var DATA = (from Cons in obj.Staffs
                        select Cons.StaffSerialNo).Max() + 1;
            if (DATA == null)
            {
                SerialNo = 101;
            }
            else
            {
                SerialNo = Convert.ToInt32(DATA.ToString());
            }
            Session["StaffSerialNo"] = SerialNo;
            if (SerialNo > 0)
            {
                StaffId = "B-";
                StaffId = StaffId + SerialNo.ToString();
                txtStaffId.Text = StaffId;
            }
        }
        catch (Exception ex)
        { }
    }
    private void GetAge()
    {
        DataSet ds = new DataSet();
        ds = AllMethods.CALCULATEAGE(txtDOB.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtAge.Text = dr[0].ToString();
            }
        }
    }
    protected void chkStaffNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkStaffNo.Checked)
            {
                txtStaffId.Enabled = true;
                txtStaffId.Focus();
            }
            else
            {
                txtStaffId.Enabled = false;
                comStaffType.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnPicUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["StaffPId"] == null)
            {
                if (role.Insert.Value)
                {
                    string filename = Path.GetFileName(imgUpload.PostedFile.FileName);

                    if (File.Exists(Server.MapPath("~/StaffImages/" + filename)) == false)
                    {
                        imgUpload.SaveAs(Server.MapPath("~/StaffImages/" + filename));
                        imgStaffImg.ImageUrl = "~/StaffImages/" + filename;
                    }
                    else
                    {
                        msg = "A picture is alrady exists with same name.. Please rename selected picture before upload";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                    }
                }
                else Globals.Message(Page, "Not Authorized ??");
            }
            else
            {
                string filename = Path.GetFileName(imgUpload.PostedFile.FileName);

                if (File.Exists(Server.MapPath("~/StaffImages/" + filename)) == false)
                {
                    imgUpload.SaveAs(Server.MapPath("~/StaffImages/" + filename));
                    imgStaffImg.ImageUrl = "~/StaffImages/" + filename;
                }
                else
                {
                    msg = "A picture is alrady exists with same name.. Please rename selected picture before upload";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
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
            GenerateStaffId();
            FillDropdown.FillCast(comCategory, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.FillReligion(comReligion, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.FillQualifications(ddlQualification, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.FillDepartments(ddlDepartment, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.Fill12thStream(ddl12Stream, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.FillGraduationStream(ddlGraduationStream, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.FillPostGraduationStream(ddlPostGraduationStream, Convert.ToInt32(Session["CompanyId"].ToString()));
            FillDropdown.FillStaffType(comStaffType, Convert.ToInt32(Session["CompanyId"].ToString()));
            ddlNoOfEnpInYear.ClearSelection();
            ddlNoOfExpinMonth.ClearSelection();
            for (int i = 0; i <= 10; i++)
            {
                ddlNoOfEnpInYear.Items.Add(new ListItem(i.ToString()));
                ddlNoOfExpinMonth.Items.Add(new ListItem(i.ToString()));
            }
            comNationality.SelectedIndex = 1;
            lblDoc.Visible = false;
            comStaffType.SelectedIndex = 0; 
            txtJoinDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtStaffName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtWhatsappNo.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFathersName.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtParentContact.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtAge.Text = string.Empty;
            comGender.SelectedIndex = 0;
            txtPANCard.Text = string.Empty;
            txtSamagraId.Text = string.Empty;
            txtAddress.Text = string.Empty;
            divDesignation.Visible = false;
            txtDesignation.Text = string.Empty;
            ddlQualification.SelectedIndex = 0;
            ddlDepartment.SelectedIndex =0;
            txtBasicSalary.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtIFSCCode.Text = string.Empty;
            imgStaffImg.ImageUrl = "~/images/male.png";
            comCategory.SelectedIndex = 0;
            comReligion.SelectedIndex = 0;
            txtAadharNo.Text = string.Empty;
            comNationality.SelectedIndex = 0;
            comStatus.SelectedIndex = 0;
            divRegineDate.Visible = false;
            txtRegineDate.Text = string.Empty;
            ddl12Stream.SelectedIndex = 0;
            txt12Subject.Text = string.Empty;
            ddlGraduationStream.SelectedIndex = 0;
            txtGraduationSubject.Text = string.Empty;
            ddlPostGraduationStream.SelectedIndex = 0;
            txtPostGraduationSubject.Text = string.Empty;
            Session["StaffPId"] = null;
            Session["txtStaffId"] = null;
            Session["JobEnquiryId1"] = null;
        }
        catch (Exception ex)
        { }
    }
    private bool Isval()
    {
        bool Val = true;
        if (txtStaffId.Text == "")
        {
             Globals.Message(Page, "Please refresh page to generate staffid....");
             txtStaffId.Focus();
             Val = false;
        }
        else if (comStaffType.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select staff type....");
            comStaffType.Focus();
            Val = false;
        }
        else if (txtJoinDate.Text=="")
        {
            Globals.Message(Page, "Please enter/select joining date....");
            txtJoinDate.Focus();
            Val = false;
        }
        else if (txtStaffName.Text == "")
        {
            Globals.Message(Page, "Please enter staff name....");
            txtStaffName.Focus();
            Val = false;
        }
        else if (txtContactNo.Text == "")
        {
            Globals.Message(Page, "Please enter contact number....");
            txtContactNo.Focus();
            Val = false;
        }
        else if (txtDOB.Text == "")
        {
            Globals.Message(Page, "Please enter/select DOB....");
            txtDOB.Focus();
            Val = false;
        }
        else if (comGender.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select gender....");
            comGender.Focus();
            Val = false;
        }
        else if (comCategory.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select cast....");
            comCategory.Focus();
            Val = false;
        }
        else if (comReligion.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select religion....");
            comReligion.Focus();
            Val = false;
        }
        else if (comNationality.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select nationality....");
            comNationality.Focus();
            Val = false;
        }
        else if (comStatus.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select status....");
            comStatus.Focus();
            Val = false;
        }
        return Val;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Isval())
            {
                if (Session["StaffPId"] == null)
                {
                    if (role.Insert.Value)
                    {
                        IEnumerable<Staff> comp = from c in obj.Staffs
                                                  where c.StaffId == txtStaffId.Text
                                                  select c;
                        if (comp.Count<Staff>() == 0)
                        {
                            if (obj.Sp_Staff(1, 0, txtStaffId.Text, Convert.ToInt32(Session["StaffSerialNo"]), comStaffType.SelectedItem.Text, Convert.ToDateTime(Convert.ToDateTime(txtJoinDate.Text).ToString("dd/MM/yyyy")), txtStaffName.Text, txtContactNo.Text, txtWhatsappNo.Text, txtEmailId.Text, txtFathersName.Text, txtMotherName.Text, txtParentContact.Text,
                            Convert.ToDateTime(Convert.ToDateTime(txtDOB.Text).ToString("dd/MM/yyyy")), txtAge.Text, comGender.SelectedItem.Text, txtPANCard.Text, txtSamagraId.Text, txtAddress.Text, Convert.ToInt32(ddlNoOfEnpInYear.SelectedItem.Text), Convert.ToInt32(ddlNoOfExpinMonth.SelectedItem.Text), txtDesignation.Text, ddlQualification.SelectedItem.Text, ddlDepartment.SelectedItem.Text,
                              txtBasicSalary.Text != "" ? Convert.ToDecimal(txtBasicSalary.Text) : 0, txtAccountNo.Text, txtBankName.Text, txtBranchName.Text, txtIFSCCode.Text, imgStaffImg.ImageUrl != "" && imgStaffImg.ImageUrl != null ? imgStaffImg.ImageUrl.ToString() : "", comCategory.SelectedItem.Text, comReligion.SelectedItem.Text, txtAadharNo.Text, comNationality.SelectedItem.Text,
                              comStatus.SelectedItem.Text,txtRegineDate.Text, ddl12Stream.SelectedItem.Text, txt12Subject.Text, ddlGraduationStream.SelectedItem.Text, txtGraduationSubject.Text, ddlPostGraduationStream.SelectedItem.Text, txtPostGraduationSubject.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                            {
                                msg = "Record insert successfully!!";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                Clear();
                            }
                        }
                        else
                        {
                            msg = "Same Staff Id already exist...";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            txtStaffId.Focus();
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else if (Session["StaffPId"] != null)
                {
                    if (role.Update.Value)
                    {
                        if (txtStaffId.Text == Session["txtStaffId"].ToString())
                        {
                            UpdateStaff();
                        }
                        else
                        {
                            IEnumerable<Staff> comp = from c in obj.Staffs
                                                      where c.StaffId == txtStaffId.Text
                                                      select c;
                            if (comp.Count<Staff>() == 0)
                            {
                                UpdateStaff();
                            }
                            else
                            {
                                msg = "Same Staff Id already exist...";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                txtStaffId.Text = Session["txtStaffId"].ToString();
                                txtStaffId.Focus();
                            }
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
            }
        }
        catch (Exception ex)
        { }
    }

    private void UpdateStaff()
    {
        if (obj.Sp_Staff(2, Convert.ToInt32(Session["StaffPId"]), txtStaffId.Text, Convert.ToInt32(Session["StaffSerialNo"]), comStaffType.SelectedItem.Text, Convert.ToDateTime(Convert.ToDateTime(txtJoinDate.Text).ToString("dd/MM/yyyy")), txtStaffName.Text, txtContactNo.Text, txtWhatsappNo.Text, txtEmailId.Text, txtFathersName.Text, txtMotherName.Text, txtParentContact.Text,
           Convert.ToDateTime(Convert.ToDateTime(txtDOB.Text).ToString("dd/MM/yyyy")), txtAge.Text, comGender.SelectedItem.Text, txtPANCard.Text, txtSamagraId.Text, txtAddress.Text, Convert.ToInt32(ddlNoOfEnpInYear.SelectedItem.Text), Convert.ToInt32(ddlNoOfExpinMonth.SelectedItem.Text), txtDesignation.Text, ddlQualification.SelectedItem.Text, ddlDepartment.SelectedItem.Text,
             txtBasicSalary.Text != "" ? Convert.ToDecimal(txtBasicSalary.Text) : 0, txtAccountNo.Text, txtBankName.Text, txtBranchName.Text, txtIFSCCode.Text, imgStaffImg.ImageUrl != "" && imgStaffImg.ImageUrl != null ? imgStaffImg.ImageUrl.ToString() : "", comCategory.SelectedItem.Text, comReligion.SelectedItem.Text, txtAadharNo.Text, comNationality.SelectedItem.Text,
             comStatus.SelectedItem.Text,txtRegineDate.Text, ddl12Stream.SelectedItem.Text, txt12Subject.Text, ddlGraduationStream.SelectedItem.Text, txtGraduationSubject.Text, ddlPostGraduationStream.SelectedItem.Text, txtPostGraduationSubject.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            msg = "Record updated successfully!!";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            Clear();
        }
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
    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetAge();
        }
        catch (Exception ex)
        { }
    }
    protected void ddlNoOfEnpInYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShowOrgnization(ref ddlNoOfEnpInYear, ref ddlNoOfExpinMonth);
        }
        catch (Exception ex)
        { }

    }

    private void ShowOrgnization(ref DropDownList dll1, ref DropDownList ddl2)
    {
        if (dll1.SelectedIndex != 0 || ddl2.SelectedIndex != 0)
        {
            divDesignation.Visible = true;
            divRegineDate.Visible = true;
        }
        else
        {
            txtDesignation.Text = "";
            txtRegineDate.Text = "";
            divRegineDate.Visible = false;
            divDesignation.Visible = false;
        }
    }
    protected void ddlNoOfExpinMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShowOrgnization(ref ddlNoOfEnpInYear, ref ddlNoOfExpinMonth);
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
                txtWhatsappNo.Text = txtContactNo.Text;
                txtEmailId.Focus();
            }
            else
            {
                txtWhatsappNo.Text = "";
                txtWhatsappNo.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void lblDoc_Click(object sender, EventArgs e)
    {
        try
        {
            string URL = "javascript:window.open('StaffDocumentUpload.aspx')";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
        }
        catch (Exception ex)
        { }
    }
    protected void btnClearImg_Click(object sender, EventArgs e)
    {
        try
        {
            imgStaffImg.ImageUrl = "~/images/male.png";
        }
        catch (Exception ex)
        { }
    }
    protected void comGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (comGender.SelectedIndex == 1)
            {
                imgStaffImg.ImageUrl = "~/images/male.png";
            }
            else if (comGender.SelectedIndex == 2)
            {
                imgStaffImg.ImageUrl = "~/images/female.png";
            }
            else
            {
                imgStaffImg.ImageUrl = "~/images/male.png";
            }
        }
        catch (Exception ex)
        { }
    }
}