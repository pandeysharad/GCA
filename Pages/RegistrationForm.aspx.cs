using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_RegistrationForm : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg, AddNo;
    int serial;
    int a = 1;
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
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 2
                                                   select r;
                    if (roles.Count<LoginRole>() > 0)
                    {
                        role = roles.First<LoginRole>();
                    }
                    else
                    {
                        LinkButton LnkDelete =
                        (LinkButton)GridRegistrationForm.HeaderRow.FindControl("LnkDelete");
                        LnkDelete.Visible = false;
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
                    txtAmount.Text = AllMethods.SelectAdmissionFormFees(Convert.ToInt32(Session["CompanyId"])).ToString();
                    dtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    GenerateAddNo();
                    var D = from Cons in obj.Courses
                            where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                    ddl_Course.DataSource = D;
                    ddl_Course.DataTextField = "CourseName";
                    ddl_Course.DataValueField = "CourseId";
                    ddl_Course.DataBind();
                    ddl_Course.Items.Insert(0, new ListItem());

                    if (Session["AdmissionNo"] != null)
                    {
                        int EnquiryId = Convert.ToInt32(Session["AdmissionNo"]);
                        var DATA1 = from Cons in obj.Enquiries
                                    where Cons.EnquiryId == EnquiryId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        txtStudentName.Text = DATA1.First().StudentName;
                        txtAddress.Text = DATA1.First().Address;
                        txtContactNo.Text = DATA1.First().ContactNo;
                        dtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                        ddl_Course.ClearSelection();
                        foreach (ListItem li in ddl_Course.Items)
                        {
                            if (li.Text == DATA1.First().EnquiryForCourse.ToString())
                            {
                                li.Selected = true;
                                break;
                            }
                        }
                    }
                    GridBind();
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

    private void GridBind1()
    {
        var DATA = from Cons in obj.RegistrationForms
                   where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                   select Cons;
        GridRegistrationForm.DataSource = DATA;
        GridRegistrationForm.Columns[4].HeaderText = Session["ClassLableText"].ToString().ToUpper();
        GridRegistrationForm.DataBind();
    }
    private void GridBind()
    {
        if (txtSearchFormNo.Text != string.Empty && txtSearchStudentName.Text == string.Empty)
        {
            var DATA = from Cons in obj.RegistrationForms
                       where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       && Cons.FormNo == txtSearchFormNo.Text.Trim()
                       orderby Cons.FrormRegistrationId descending
                       select Cons;
            GridRegistrationForm.DataSource = DATA;
            GridRegistrationForm.Columns[4].HeaderText = Session["ClassLableText"].ToString().ToUpper();
            GridRegistrationForm.DataBind();
        }
        else if (txtSearchFormNo.Text == string.Empty && txtSearchStudentName.Text != string.Empty)
        {
            var DATA = from Cons in obj.RegistrationForms
                       where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       && Cons.StudentName == txtSearchStudentName.Text.Trim()
                       orderby Cons.FrormRegistrationId descending
                       select Cons;
            GridRegistrationForm.DataSource = DATA;
            GridRegistrationForm.Columns[4].HeaderText = Session["ClassLableText"].ToString().ToUpper();
            GridRegistrationForm.DataBind();
        }
        else if (txtSearchFormNo.Text == string.Empty && txtSearchStudentName.Text == string.Empty)
        {
            var DATA = from Cons in obj.RegistrationForms
                       where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       orderby Cons.FrormRegistrationId descending
                       select Cons;
            GridRegistrationForm.DataSource = DATA;
            GridRegistrationForm.Columns[4].HeaderText = Session["ClassLableText"].ToString().ToUpper();
            GridRegistrationForm.DataBind();
        }
    }
    private void GenerateAddNo()
    {
        if (Session["AdmissionId"] == null)
        {
            var DATA = (from i in obj.RegistrationForms
                          where i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                          select i.Serial).Max() + 1;
            if (DATA == null)
            {
                serial= 101;
            }
            else
            {
                serial =Convert.ToInt32(DATA);
            }
            Session["serial"] = serial;
            var DATA1 = from Cons in obj.Sessions
                        where Cons.Sessionid == Convert.ToInt32(Session["SessionId"]) && Cons.Remove == false
                        select Cons;
            string SessionName = DATA1.First().SessionName;
            int Ad = 0;
            AddNo = SessionName.Substring(0, 4);
            AddNo = AddNo.Substring(2, 2);
            Ad = Convert.ToInt32(AddNo) + 1;
            AddNo = AddNo + Ad.ToString();
            txtFormNo.Text = AddNo + serial.ToString();
            //txtFormNo.Text = AllMethods.GetRegistrationFormNo();
        }
    }
    public bool Isvalid()
    {
        bool val = true;
        if (txtFormNo.Text == "")
        {
            msg = "Please generate form no...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtFormNo.Focus();
        }
        else if (txtStudentName.Text == "")
        {
            msg = "Please enter student name..";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtStudentName.Focus();
        }
        else if (ddl_Course.SelectedIndex == 0)
        {
            msg = "Please select class...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            ddl_Course.Focus();
        }
        else if (txtContactNo.Text == "")
        {
            msg = "Please enter contact number...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtContactNo.Focus();
        }
       
        else if (dtDate.Text=="")
        {
            msg = "Please select date...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            dtDate.Focus();
        }
        else if (txtAmount.Text == "")
        {
            msg = "Please enter amount...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtAmount.Focus();
        }
        return val;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Isvalid())
            {
                if (Session["FrormRegistrationId"] == null)
                {
                    if (obj.Sp_RegistrationForm(1, 0, Session["AdmissionNo"] != null ? Convert.ToInt32(Session["AdmissionNo"]) : 0, Convert.ToInt32(Session["serial"].ToString()), txtFormNo.Text, txtStudentName.Text, txtFatherName.Text, ddl_Course.SelectedItem.Text, txtAddress.Text, txtContactNo.Text, Convert.ToDateTime(dtDate.Text), txtAmount.Text != "" ? Convert.ToDecimal(txtAmount.Text) : 0, txtRemarks.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        Globals.Message(Page, "Saved Successfully...");
                        var DATA1 = (from Cons in obj.RegistrationForms
                                     where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                     select Cons.FrormRegistrationId).Max();

                        Session["FrormRegistrationId1"] = DATA1;
                        string URL = "javascript:window.open('AddmisionFormPrint.aspx')";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        Clear();
                    }
                }
                else if (Session["FrormRegistrationId"] != null)
                {
                    if (obj.Sp_RegistrationForm(2, Convert.ToInt32(Session["FrormRegistrationId"]), Session["AdmissionNo"] != null ? Convert.ToInt32(Session["AdmissionNo"]) : 0, Convert.ToInt32(Session["serial"].ToString()), txtFormNo.Text, txtStudentName.Text, txtFatherName.Text, ddl_Course.SelectedItem.Text, txtAddress.Text, txtContactNo.Text, Convert.ToDateTime(dtDate.Text), txtAmount.Text != "" ? Convert.ToDecimal(txtAmount.Text) : 0, txtRemarks.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        Globals.Message(Page, "Updated Successfully...");
                        Session["FrormRegistrationId1"] = Session["FrormRegistrationId"].ToString();
                        string URL = "javascript:window.open('AddmisionFormPrint.aspx')";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        Clear();
                    }
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
            Session["AdmissionNo"] = null;
            GenerateAddNo();
            GridBind();
            txtFatherName.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            ddl_Course.SelectedIndex = 0;
            txtAddress.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            dtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtAmount.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            Session["FrormRegistrationId"] = null;
            GridRegistrationForm.SelectedRow.BackColor = System.Drawing.Color.White;
            GridRegistrationForm.SelectedRow.ForeColor = System.Drawing.Color.Black;
        }
        catch (Exception ex)
        { }

    }

    protected void GridRegistrationForm_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (b != 1)
        {
            int id = Convert.ToInt32(GridRegistrationForm.DataKeys[e.NewSelectedIndex].Value);
            Session["FrormRegistrationId"] = Convert.ToInt32(GridRegistrationForm.DataKeys[e.NewSelectedIndex].Value);
            var DATA1 = from Cons in obj.RegistrationForms
                       where Cons.FrormRegistrationId == Convert.ToInt32(id) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons;
            txtFormNo.Text = DATA1.First().FormNo;
            txtStudentName.Text = DATA1.First().StudentName;
            txtAddress.Text = DATA1.First().Address;
            txtContactNo.Text = DATA1.First().ContactNo;
            dtDate.Text =Convert.ToDateTime(DATA1.First().Date).ToString("dd/MM/yyyy");
            ddl_Course.ClearSelection();
            foreach (ListItem li in ddl_Course.Items)
            {
                if (li.Text == DATA1.First().Class.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtFatherName.Text = DATA1.First().FatherName;
            txtRemarks.Text = DATA1.First().Remarks;
            txtAmount.Text = DATA1.First().Amount.ToString();
        }
    }
    protected void GridRegistrationForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridRegistrationForm.PageIndex = e.NewPageIndex;
        GridBind();
        GridRegistrationForm.DataBind();
    }
    protected void LnkDelete_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (role.Delete.Value)
            {
                string FrormRegistrationId = (sender as LinkButton).CommandArgument;
                if (obj.Sp_RegistrationForm(3, Convert.ToInt32(FrormRegistrationId), Session["AdmissionNo"] != null ? Convert.ToInt32(Session["AdmissionNo"]) : 0, Convert.ToInt32(Session["serial"].ToString()), txtFormNo.Text, txtStudentName.Text, txtFatherName.Text, ddl_Course.SelectedItem.Text, txtAddress.Text, txtContactNo.Text, Convert.ToDateTime(dtDate.Text), txtAmount.Text != "" ? Convert.ToDecimal(txtAmount.Text) : 0, txtRemarks.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                {
                    Globals.Message(Page, "Deleted Successfully...");
                    GridBind();
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        { }
    }
    protected void OnSelectedJoin(object sender, EventArgs e)
    {
        try
        {
            string FrormRegistrationId = (sender as LinkButton).CommandArgument;
            Session["FrormRegistrationId"] = FrormRegistrationId;

            var DATA = from Cons in obj.RegistrationForms
                       where Cons.FrormRegistrationId==Convert.ToInt32(FrormRegistrationId) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons;
            if (DATA.First().FrormRegistrationId == 0)
            {
                Session["AdmissionNo"] = null;
            }
            else
            {
                Session["AdmissionNo"] = DATA.First().EnquiryId.ToString();
            }
            Session["AdmissionId"] = null;
            b = 1;
            Response.Redirect("Addmision.aspx");
        }
        catch (Exception ex)
        { }
    }
    protected void OnSelectedPrint(object sender, EventArgs e)
    {
        try
        {
            string FrormRegistrationId = (sender as LinkButton).CommandArgument;
            Session["FrormRegistrationId1"] = FrormRegistrationId;

            var DATA = from Cons in obj.RegistrationForms
                       where Cons.FrormRegistrationId == Convert.ToInt32(FrormRegistrationId) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons;

            string URL = "javascript:window.open('AddmisionFormPrint.aspx')";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
        }
        catch (Exception ex)
        { }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void GridRegistrationForm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int FrormRegistrationId = Convert.ToInt32(GridRegistrationForm.DataKeys[e.Row.RowIndex].Value.ToString());
                IEnumerable<RegistrationForm> RegistrationForms = from id in obj.RegistrationForms
                                                                  where id.FrormRegistrationId==FrormRegistrationId && id.Remove==true && id.CompanyId == Convert.ToInt32(Session["CompanyId"])
                                                                  select id;

                if (RegistrationForms.Count<RegistrationForm>() > 0)
                {
                    ((LinkButton)e.Row.FindControl("LnkJoin")).Text = "Joined";
                    ((LinkButton)e.Row.FindControl("LnkJoin")).Enabled = false;
                }
                if (Session["UserId"] != null)
                {
                    if (Session["UserType"].ToString() != "Admin")
                    {
                        IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                                       where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 2
                                                       select r;
                        if (roles.Count<LoginRole>() > 0)
                        {
                           // LinkButton LnkDelete =
                           //(LinkButton)GridRegistrationForm.data.FindControl("LnkDelete");
                            LinkButton LnkDelete = (e.Row.FindControl("LnkDelete") as LinkButton);
                            LnkDelete.Visible = false;
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
            }
        }
        catch (Exception ex) { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridBind();
    }
}