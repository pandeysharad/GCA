using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.Linq.SqlClient;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Drawing;
using System.Data;

public partial class Pages_Enquiry : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    int b = 0;
    public int Fg=0;
    LoginRole role = new LoginRole();
    public int row = 0;
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
                    var S = from Cons in obj.Sessions
                               where Cons.Remove == false
                               select Cons;
                    ddlSession.DataSource = S;
                    ddlSession.DataTextField = "SessionName";
                    ddlSession.DataValueField = "Sessionid";
                    ddlSession.DataBind();
                    ddlSession.Items.Insert(0, "Select Session");

                    Img1.ImageUrl = "~/images/male.png";
                    ViewState["Status"] = "ALL";
                    Session["Status"] = "ALL";
                    ddl_Status.SelectedIndex = 1;
                    divPCP.Visible = false;
                    dtEnquiryDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    dtNextCallDate.Text = DateTime.Today.AddDays(5).ToString("dd/MM/yyyy");
                    dtSDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    dtEDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    var DATA = (from Cons in obj.Enquiries
                                where Cons.Remove==false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons.EnquiryNo).Max() + 1;
                    if (DATA == null)
                    {
                        txtEnquiryNo.Text = "1";
                    }
                    else
                    {
                        txtEnquiryNo.Text = DATA.ToString();
                    }

                    var D = from Cons in obj.Courses
                            where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;

                    
                    ddl_EnquiryForCourse.DataSource = D;
                    ddl_PreviousClass.DataSource = D;
                    ddl_PreviousClass.DataTextField = "CourseName";
                    ddl_EnquiryForCourse.DataTextField = "CourseName";
                    ddl_EnquiryForCourse.DataValueField = "CourseId";

                    ddl_EnquiryForCourse.DataBind();

                    ddl_EnquiryForCourse.Items.Insert(0, new ListItem());

                    ddl_PreviousClass.DataBind();

                    ddl_PreviousClass.Items.Insert(0, "NEW");
                        BindDataGrid();

                        try
                        {
                            var DATA1 = from Cons in obj.Settings
                                       where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                                       select Cons;
                            Session["SendMsg"] = DATA1.First().SendMsg;
                        }
                        catch (Exception ex)
                        { }
                    if (Session["id"] != null)
                    {
                        GetEnquiry();
                        Fg = 1;
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

    private void BindDataGrid()
    {
        if (role.Select.Value)
        {
            lblAuthorized.Visible = false;
            if (ddl_Search.Text == "By Student")
            {
                if (ViewState["Status"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.StudentName, "" + txtSearchByStudentName.Text + "%")  && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.StudentName, "" + txtSearchByStudentName.Text + "%") && Cons.Status == ViewState["Status"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
            }
            else if (ddl_Search.Text == "By Contact No")
            {

                if (ViewState["Status"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.ContactNo, "" + txtSearchByContact.Text + "%")  && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.ContactNo, "" + txtSearchByContact.Text + "%") && Cons.Status == ViewState["Status"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
            }
            else if (ddl_Search.Text == "By Date")
            {
                if (ViewState["Status"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where Cons.EnquiryDate >= DateTime.Parse(dtSDate.Text) &&
                                   Cons.EnquiryDate <= DateTime.Parse(dtEDate.Text)  && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where Cons.EnquiryDate >= DateTime.Parse(dtSDate.Text) &&
                                   Cons.EnquiryDate <= DateTime.Parse(dtEDate.Text) && Cons.Status == ViewState["Status"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
            }
            else if (ddl_Search.Text == "By Previous School")
            {
                if (ViewState["Status"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.PreviousSchool, "" + txtSearchByPreviousSchool.Text + "%")  && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.PreviousSchool, "" + txtSearchByPreviousSchool.Text + "%") && Cons.Status == ViewState["Status"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.DataBind();
                }
            }
            else if (ddl_Search.Text == "By Village")
            {
                if (ViewState["Status"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.Village, "" + txtSearchByVillage.Text + "%")  && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where SqlMethods.Like(Cons.Village, "" + txtSearchByVillage.Text + "%") && Cons.Status == ViewState["Status"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                orderby Cons.EnquiryId descending
                                select Cons;
                    GridEnquiry.DataSource = DATA1;
                    GridEnquiry.Columns[4].HeaderText = "PRE-" + Session["ClassLableText"].ToString().ToUpper();
                    GridEnquiry.Columns[5].HeaderText = "PRE-" + Session["SchoolLableText"].ToString().ToUpper();
                    GridEnquiry.DataBind();
                }
            }
            DropDownList ddlStatus =
      (DropDownList)GridEnquiry.HeaderRow.FindControl("ddlStatus");
            BindStatus(ddlStatus);
        }
        else
        {
            lblAuthorized.Visible = true;
            lblAuthorized.Text = "Not Authorized to See..";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Visibility", "Visibility();", true);

    }

    private void BindStatus(DropDownList ddlStatus)
    {
        try
        {
            var DATA = (from Cons in obj.Enquiries
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            Status = Cons.Status
                        })
                       .ToList()
                       .Distinct();
            ddlStatus.DataSource = DATA;
            ddlStatus.DataTextField = "Status";
            ddlStatus.DataValueField = "Status";
            ddlStatus.DataBind();
            ddlStatus.Items.FindByValue(ViewState["Status"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        { }
    }
    private bool Isvalid()
    {
        bool val = true;
        if (txtStudentName.Text == "")
        {
            val = false;
        }
        else
        {
            val = true;
        }
        if (txtContactNo.Text == "")
        {
            val = false;
        }
        else
        {
            val = true;
        }
        if (ddl_EnquiryForCourse.Text == "")
        {
            val = false;
        }
        else
        {
            val = true;
        }
        return val;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Isvalid())
            {
                if (Session["id"] == null)
                {
                    if (role.Insert.Value)
                    {
                        IEnumerable<Enquiry> Enquiries = from id in obj.Enquiries
                                                         where id.EnquiryNo == Convert.ToInt32(txtEnquiryNo.Text) && id.Remove==false
                                                            && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                            select id;

                        if (Enquiries.Count<Enquiry>() <= 0)
                        {
                            if (obj.SP_Enquiry(1, 0, Convert.ToInt32(txtEnquiryNo.Text), txtStudentName.Text, txtAddress.Text, txtContactNo.Text.Trim(), txtEmailId.Text, ddl_EnquiryForCourse.SelectedItem.Text, ddl_PreviousClass.SelectedItem.Text, ddl_PreviousClass.SelectedIndex != 0 ? txtPCP.Text : "0",
                                txtFees.Text, Convert.ToDateTime(dtEnquiryDate.Text), Convert.ToDateTime(dtNextCallDate.Text), Img1.ImageUrl != null ? Img1.ImageUrl : "", txtRemarks.Text, ddl_Status.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), txtPreviousSchool.Text, txtVillage.Text,ddlSession.SelectedIndex!=0 ? Convert.ToInt32(ddlSession.SelectedValue) :Convert.ToInt32(Session["SessionId"])) == 0)
                            {
                                if (Convert.ToBoolean(Session["SendMsg"]) == true)
                                {
                                    try
                                    {
                                        var DATA = (from Cons in obj.Enquiries
                                                    where  Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])

                                                    select Cons.EnquiryId).Max();

                                        var DATA1 = from Cons in obj.Enquiries
                                                    where Cons.EnquiryId==DATA && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])

                                                    select Cons;

                                        string msg ="Welcome\nDear " + DATA1.First().StudentName + ",\nThanks for your interest in "+ Session["SchoolName"].ToString()+".\nWe will be soon in touch with you to join hands for successfull career.";
                                        string Mobile = DATA1.First().ContactNo;
                                        //string api = Session["MsgAPI"].ToString();
                                        //string api1 = (api.Replace("mobile", Mobile));
                                        //string api2 = (api1.Replace("msg", msg));
                                        try
                                        {
                                            SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                            //WebClient client = new WebClient();
                                            //string baseURL = api2;
                                            //client.OpenRead(baseURL);
                                        }
                                        catch (Exception ex)
                                        { }
                                    }
                                    catch (Exception ex)
                                    { }
                                }

                                Clear();
                                Globals.Message(Page, "Record Insert Successfully!!");
                            }
                        }
                        else
                        {
                            Globals.Message(Page, "Enquiry no. already exist...");
                            Clear(); 
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Not Authorized ??");
                    }
                }
                else if (Session["id"] != null)
                {
                    if (role.Update.Value)
                    {
                        if (obj.SP_Enquiry(2, Convert.ToInt32(Session["id"]), Convert.ToInt32(txtEnquiryNo.Text), txtStudentName.Text, txtAddress.Text, txtContactNo.Text.Trim(), txtEmailId.Text, ddl_EnquiryForCourse.SelectedItem.Text, ddl_PreviousClass.SelectedItem.Text, ddl_PreviousClass.SelectedIndex != 0 ? txtPCP.Text : "0",
                            txtFees.Text, Convert.ToDateTime(dtEnquiryDate.Text), Convert.ToDateTime(dtNextCallDate.Text), Img1.ImageUrl != null ? Img1.ImageUrl : "", txtRemarks.Text, ddl_Status.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), txtPreviousSchool.Text, txtVillage.Text, ddlSession.SelectedIndex != 0 ? Convert.ToInt32(ddlSession.SelectedValue) : Convert.ToInt32(Session["SessionId"])) == 0)
                        {
                            Clear();
                            msg = "Record updated Successfully!!";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Not Authorized ??");
                    }
                }
            }
            else
            { 
                    msg = "Fill all nessesory field!!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);

            }
        }
        catch (Exception ex)
        { }
    }

    private void GetEnquiry()
    {
        int id = Convert.ToInt32(Session["id"]);
        var DATA1 = from Cons in obj.Enquiries
                    where Cons.EnquiryId==id && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
        txtEnquiryNo.Text = DATA1.First().EnquiryNo.ToString();
        txtStudentName.Text =DATA1.First().StudentName;
        txtAddress.Text =DATA1.First().Address;
        txtContactNo.Text =DATA1.First().ContactNo;
        txtEmailId.Text =DATA1.First().EmailId;
        txtVillage.Text = DATA1.First().Village;
        ddl_PreviousClass.Text =DATA1.First().PreviousClass;
        if (ddl_PreviousClass.SelectedItem.Text != "NEW")
        {
            divPCP.Visible = true;
            divPrevousSchool.Visible = true;
            txtPCP.Text = DATA1.First().PCP;
            txtPreviousSchool.Text = DATA1.First().PreviousSchool;
        }
        else
        {
            txtPCP.Text = string.Empty;
            txtPreviousSchool.Text = string.Empty;
        }
        ddl_EnquiryForCourse.ClearSelection();
        foreach (ListItem li in ddl_EnquiryForCourse.Items)
        {
            if (li.Text == DATA1.First().EnquiryForCourse.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        txtFees.Text =DATA1.First().fees;
        dtEnquiryDate.Text =Convert.ToDateTime(DATA1.First().EnquiryDate).ToString("dd/MM/yyyy");
        dtNextCallDate.Text = Convert.ToDateTime(DATA1.First().NextCallDate).ToString("dd/MM/yyyy");
        Session["ImgPath"] =DATA1.First().Image; 
        Img1.ImageUrl =DATA1.First().Image;
        txtRemarks.Text =DATA1.First().Remarks;
        ddl_Status.Text =DATA1.First().Status;
        ddlSession.SelectedValue = DATA1.First().SessionId.ToString();
    }
    protected void ddl_EnquiryForCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_EnquiryForCourse.SelectedIndex != 0)
            {
                //var D1 = from Cons in obj.Courses
                //         where Cons.CourseId == Convert.ToInt32(ddl_EnquiryForCourse.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                //         select Cons;
                //txtFees.Text = D1.First().TotalFirstChild.ToString();
                double TotalOtherFees = 0,CourseFees=0;
                IEnumerable<Other_Fee> inv =from o in obj.Other_Fees
                                          where o.CourseId==Convert.ToInt32(ddl_EnquiryForCourse.SelectedValue)
                                          && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(Session["SessionId"])
                                          select o;
                TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));

                IEnumerable<Course> Courses = from c in obj.Courses
                                              where c.CourseId == Convert.ToInt32(ddl_EnquiryForCourse.SelectedValue)
                                             && c.Remove == false && c.CompanyId == Convert.ToInt32(Session["CompanyId"]) && c.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select c;
                CourseFees =Convert.ToDouble(Courses.First().TotalFirstChild);
                txtFees.Text = (TotalOtherFees + CourseFees).ToString();
                DataSet ds = AllMethods.GetAllFeeDetailsInEnquiry(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(ddl_EnquiryForCourse.SelectedValue));
                EnquiryFeeDetails.DataSource = ds;
                EnquiryFeeDetails.DataBind();
            }
            else
            {
                txtFees.Text = string.Empty;
                EnquiryFeeDetails.DataSource = null;
                EnquiryFeeDetails.DataBind();
            }
            //DataSet ds = AllMethods.GetAllFeeDetailsInEnquiry(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(ddl_EnquiryForCourse.SelectedValue));
            
        }
        catch (Exception ex)
        { }
    }

  
    protected void btnPicUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] == null)
            {
                if (role.Insert.Value)
                {
                    string filename = Path.GetFileName(UploadImage.PostedFile.FileName);

                    if (File.Exists(Server.MapPath("~/images/" + filename)) == false)
                    {
                        UploadImage.SaveAs(Server.MapPath("~/images/" + filename));
                        Img1.ImageUrl = "~/images/" + filename;
                        Session["ImgPath"] = "~/images/" + filename;
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
                string filename = Path.GetFileName(UploadImage.PostedFile.FileName);

                if (File.Exists(Server.MapPath("~/images/" + filename)) == false)
                {
                    UploadImage.SaveAs(Server.MapPath("~/images/" + filename));
                    Img1.ImageUrl = "~/images/" + filename;
                    Session["ImgPath"] = "~/images/" + filename;
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
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Clear();
    }
    void Clear()
    {
        try
        {
            dtEnquiryDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            dtSDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            dtEDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            BindDataGrid();
            var DATA = (from Cons in obj.Enquiries
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons.EnquiryNo).Max() + 1;
            if (DATA == null)
            {
                txtEnquiryNo.Text = "1";
            }
            else
            {
                txtEnquiryNo.Text = DATA.ToString();
            }

            txtStudentName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailId.Text = "";
            txtVillage.Text = string.Empty;
            txtPreviousSchool.Text = string.Empty;

            var D = from Cons in obj.Courses
                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;


            ddl_EnquiryForCourse.DataSource = D;
            ddl_PreviousClass.DataSource = D;
            ddl_PreviousClass.DataTextField = "CourseName";
            ddl_EnquiryForCourse.DataTextField = "CourseName";
            ddl_EnquiryForCourse.DataValueField = "CourseId";

            ddl_EnquiryForCourse.DataBind();

            ddl_EnquiryForCourse.Items.Insert(0, new ListItem());

            ddl_PreviousClass.DataBind();

            ddl_PreviousClass.Items.Insert(0, "NEW");

            divPCP.Visible = false;
            divPrevousSchool.Visible = false;
            txtPCP.Text = string.Empty;
            txtFees.Text = "";
            dtEnquiryDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            dtNextCallDate.Text = DateTime.Today.AddDays(5).ToString("dd/MM/yyyy");
            Img1.ImageUrl = "~/images/male.png";
            txtRemarks.Text = "";
            ddl_Status.SelectedIndex = 1;
            lbFlag.Text = "0";
            lbEnquiryId.Text = "0";
            Session["id"] = null;
            Session["ImgPath"] = null;
            Session["EPdtSDate"] = null;
            Session["EPdtEDate"] =null;
            Session["EPContactNo"] = null;
            Session["EPStudentName"] = null;
            Session["EPPreviousSchool"] = null;
            Session["EPVillage"] = null;
            EnquiryFeeDetails.DataSource = null;
            EnquiryFeeDetails.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void OnSelectedJoin(object sender, EventArgs e)
    {
        try
        {
            string EnquiryId = (sender as LinkButton).CommandArgument;
            Session["AdmissionNo"] = EnquiryId;
            Session["AdmissionId"] = null;
            b = 1;
            Response.Redirect("RegistrationForm.aspx");
        }
        catch (Exception ex)
        { }
    }
    protected void GridEnquiry_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (b != 1)
        {
            int id = Convert.ToInt32(GridEnquiry.DataKeys[e.NewSelectedIndex].Value);
            Session["id"] = GridEnquiry.DataKeys[e.NewSelectedIndex].Value;
            lbEnquiryId.Text= GridEnquiry.DataKeys[e.NewSelectedIndex].Value.ToString();
            lbFlag.Text = "1";
            Response.Redirect(Request.RawUrl);
        }
    }


    protected void btnSearchDetails_Click(object sender, EventArgs e)
    {
        if (role.Select.Value)
        {
            BindDataGrid();
        }
        else Globals.Message(Page, "Not Authorized ??");
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (role.Select.Value)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Visibility", "Visibility();", true);
            if (ddl_Search.Text == "By Student")
            {
                Session["EPStudentName"] = txtSearchByStudentName.Text;
                Session["EPContactNo"] = "";
                Session["EPdtSDate"] = "";
                Session["EPdtEDate"] = "";
                Session["EPPreviousSchool"] = "";
                Session["EPVillage"] = "";
            }
            else if (ddl_Search.Text == "By Contact No")
            {
                Session["EPContactNo"] = txtSearchByContact.Text;
                Session["EPStudentName"] = "";
                Session["EPdtSDate"] = "";
                Session["EPdtEDate"] = "";
                Session["EPPreviousSchool"] = "";
                Session["EPVillage"] = "";
            }
            else if (ddl_Search.Text == "By Date")
            {
                Session["EPdtSDate"] = dtSDate.Text;
                Session["EPdtEDate"] = dtEDate.Text;
                Session["EPContactNo"] = "";
                Session["EPStudentName"] = "";
                Session["EPPreviousSchool"] = "";
                Session["EPVillage"] = "";
            }
            else if (ddl_Search.Text == "By Previous School")
            {
                Session["EPdtSDate"] = "";
                Session["EPdtEDate"] = "";
                Session["EPContactNo"] = "";
                Session["EPStudentName"] = "";
                Session["EPPreviousSchool"] = txtSearchByPreviousSchool.Text;
                Session["EPVillage"] = "";
            }
            else if (ddl_Search.Text == "By Village")
            {
                Session["EPdtSDate"] = "";
                Session["EPdtEDate"] = "";
                Session["EPContactNo"] = "";
                Session["EPStudentName"] = "";
                Session["EPPreviousSchool"] = "";
                Session["EPVillage"] = txtSearchByVillage.Text;
            }
            string URL = "javascript:window.open('EnquiryPrint.aspx')";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
        }
        else
        {
            Globals.Message(Page, "Not Authorized ??");
        }
    }
    protected void ddl_PreviousClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_PreviousClass.SelectedIndex != 0)
            {
                divPCP.Visible = true;
                divPrevousSchool.Visible = true;
                txtPCP.Focus();
            }
            else
            {
                divPCP.Visible = false;
                divPrevousSchool.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnClearImg_Click(object sender, EventArgs e)
    {
        try
        {
            Img1.ImageUrl = "~/images/male.png";
        }
        catch (Exception ex)
        { }
    }
    protected void GridEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridEnquiry.PageIndex = e.NewPageIndex;
        BindDataGrid();
        GridEnquiry.DataBind();
        DropDownList ddlStatus =
     (DropDownList)GridEnquiry.HeaderRow.FindControl("ddlStatus");
        BindStatus(ddlStatus);
    }
    protected void LnkDelete_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (role.Delete.Value)
            {
                string id = (sender as LinkButton).CommandArgument;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                if (id != "")
                {
                    if (obj.SP_Enquiry(4, Convert.ToInt32(id), Convert.ToInt32(txtEnquiryNo.Text), txtStudentName.Text, txtAddress.Text, txtContactNo.Text, txtEmailId.Text, ddl_EnquiryForCourse.SelectedItem.Text, ddl_PreviousClass.SelectedItem.Text, ddl_PreviousClass.SelectedIndex != 0 ? txtPCP.Text : "0",
                                    txtFees.Text, Convert.ToDateTime(dtEnquiryDate.Text), Convert.ToDateTime(dtNextCallDate.Text), Img1.ImageUrl != null ? Img1.ImageUrl  : "", txtRemarks.Text, ddl_Status.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), txtPreviousSchool.Text, txtVillage.Text, Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        Globals.Message(Page, "Record Successfully Deleted");
                        BindDataGrid();
                    }
                }
            }
            else
            {
                Globals.Message(Page, "Not Authorized ??");
            }
        }
        catch (Exception ex)
        { }
    }
    protected void StatusChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlStatus = (DropDownList)sender;
            ViewState["Status"] = ddlStatus.SelectedValue;
            Session["Status"] = ddlStatus.SelectedValue;
            if (ddlStatus.SelectedIndex != 0)
            {
                var DATA1 = from Cons in obj.Enquiries
                            where Cons.Status == ddlStatus.SelectedValue && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            orderby Cons.EnquiryId descending
                            select Cons;
                GridEnquiry.DataSource = DATA1;
                GridEnquiry.DataBind();
            }
            else
            {
                var DATA1 = from Cons in obj.Enquiries
                            where  Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            orderby Cons.EnquiryId descending
                            select Cons;
                GridEnquiry.DataSource = DATA1;
                GridEnquiry.DataBind();
            }
            DropDownList ddlStatus1 =
     (DropDownList)GridEnquiry.HeaderRow.FindControl("ddlStatus");
            BindStatus(ddlStatus1);
        }
        catch (Exception ex)
        { }
    }
    protected void GridEnquiry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                row++;
                int EnquiryId = Convert.ToInt32(GridEnquiry.DataKeys[e.Row.RowIndex].Value.ToString());

                IEnumerable<RegistrationForm> RegistrationForms = from id in obj.RegistrationForms
                                                                  where id.EnquiryId == EnquiryId && id.CompanyId==Convert.ToInt32(Session["CompanyId"]) 
                                                   select id;

                var DATA1 = from Cons in obj.Enquiries
                            where Cons.EnquiryId == EnquiryId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;

                if (DATA1.First().Status == "INTERESTED")
                {
                    e.Row.BackColor = Color.Yellow;
                }
                if (RegistrationForms.Count<RegistrationForm>() > 0)
                {
                    ((LinkButton)e.Row.FindControl("LnkJoin")).Text = "Form Done";

                    ((LinkButton)e.Row.FindControl("LnkJoin")).Enabled = false;
                }
            }
        }
        catch (Exception ex) { }
    }
    
}