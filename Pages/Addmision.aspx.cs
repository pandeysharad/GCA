using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.Linq.SqlClient;
using System.Globalization;
using System.Data;

public partial class Pages_Addmision : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg, AddNo;
    int serial;
    int a = 1;
    LoginRole role = new LoginRole();
    public string row = "";
    public string row1 = "";
    public string LabelTrasportType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            FillSchoolName();
            if (ddlStudentComingFrom.SelectedIndex == 1)
            {
                LabelTrasportType = "Self Transport Type";
            }
            else if (ddlStudentComingFrom.SelectedIndex == 2)
            {
                LabelTrasportType = "Public Transport Type";
            }
            var settings = obj.Settings.Where(x => x.CompanyId == Convert.ToInt32(Session["CompanyId"]));
            if (settings.FirstOrDefault().CompanyType == "college")
            {
                LabelTrasportType = "43.  University";
            }
            if (Session["UserType"].ToString() != "Admin")
            {
                IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                               where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 3
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
                chkOtherInformation.Checked = true;
                DivOtherInformation.Visible = true;
                chkBank1.Checked = true;
                Bank1.Visible = true;
                TrasportType.Visible = false;
                ChkTransport.Visible = false;
                ddlStudentComingFrom.SelectedIndex = 1;
                string ComIdSessionId = "";
                ComIdSessionId = Session["CompanyId"].ToString();
                ComIdSessionId += "," + Session["SessionId"].ToString();
                AutoCompleteExtender12.ContextKey = ComIdSessionId;
                AutoCompleteExtender13.ContextKey = ComIdSessionId;
                AutoCompleteExtender14.ContextKey = ComIdSessionId;

                try
                {
                    ddlStudentComingFrom_SelectedIndexChanged(null, null);
                }
                catch (Exception ex) { }
                GetData();
                FillSchoolName();
                Img1.ImageUrl = "~/images/male.png";
                txtMotherOccupation.Text = "House Wife";
                ViewState["AdmStatus"] = "ALL";
                Session["AdmStatus"] = "ALL";
                ViewState["ClassName"] = "ALL";
                Session["ClassName"] = "ALL";
                ViewState["CourseStatus"] = "ALL";
                Session["CourseStatus"] = "ALL";
                ViewState["ddlSection"] = "ALL";
                Session["ddlSection"] = "ALL";
                FillDropdown.FillSINGLEVALUEDATA(ddlSection, "SECTION", Convert.ToInt32(Session["CompanyId"].ToString()));
                FillDropdown.FillAdmissionStatus(ddlStatus, Convert.ToInt32(Session["CompanyId"].ToString()));
                FillDropdown.FillCast(ddl_Catrgory, Convert.ToInt32(Session["CompanyId"].ToString()));
                FillDropdown.FillReligion(ddl_Religion, Convert.ToInt32(Session["CompanyId"].ToString()));
                FillDropdown.FillSTREAM(ddlStream, Convert.ToInt32(Session["CompanyId"].ToString()));
                ddlStatus.SelectedIndex = 1;
                dtAdmissionDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                //GenerateAddNoByAdmisionDate();
                ddl_Nationality.SelectedIndex = 1;
                var D = from Cons in obj.Courses
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
                ddl_Course.DataSource = D;

                ddl_PreviousClass.DataSource = D;
                ddl_PreviousClass.DataTextField = "CourseName";
                ddl_Course.DataTextField = "CourseName";
                ddl_Course.DataValueField = "CourseId";


                GetBindDropDownClass();


                ddlAdmittedClass.DataSource = D;
                ddlAdmittedClass.DataTextField = "CourseName";
                ddlAdmittedClass.DataValueField = "CourseName";

                ddlAdmittedClass.DataBind();
                ddlAdmittedClass.Items.Insert(0, new ListItem());
                ddl_Course.DataBind();
                ddl_Course.Items.Insert(0, new ListItem());

                ddl_PreviousClass.DataBind();

                ddl_PreviousClass.Items.Insert(0, "NEW");

                var B = from Cons in obj.BusTransports
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId==Convert.ToInt32(Session["SessionId"])
                        select Cons;
                ddlTo.DataSource = B;
                ddlTo.DataTextField = "To";
                ddlTo.DataValueField = "TransportId";
                ddlTo.DataBind();
                ddlTo.Items.Insert(0, new ListItem());

                for (int i = 0; i <= 10; i++)
                {
                    ddlNoOfChildInFamily.Items.Add(new ListItem(i.ToString()));
                    ddlNoOfBrothers.Items.Add(new ListItem(i.ToString()));
                    ddlNoOfSisters.Items.Add(new ListItem(i.ToString()));
                    //ddlNoOfChildInFamily.Items.Insert(i, new ListItem(i.ToString()));
                }
                //for (int i = DateTime.Today.Year; i <= 2050; i++)
                //{
                //    string date = "";
                //    int j = Convert.ToInt32(DateTime.Today.AddYears(a).ToString("yy"));
                //    date = i.ToString() + "-" + j.ToString();
                //    ddlNoOfSisters.Items.Add(new ListItem(date));
                //    a++;
                //}
                var D1 = from Cons in obj.Sessions
                         where Cons.Sessionid == Convert.ToInt32(Session["SessionId"])
                         select Cons;
                ddlSession.DataSource = D1;
                ddlSession.DataTextField = "SessionName";
                ddlSession.DataBind();
                if (Session["AdmissionNo"] != null)
                {
                    int EnquiryId = Convert.ToInt32(Session["AdmissionNo"]);

                    var DATA1 = from Cons in obj.Enquiries
                                where Cons.EnquiryId == EnquiryId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;

                    var DATA2 = from Cons in obj.RegistrationForms
                                where Cons.FrormRegistrationId == Convert.ToInt32(Session["FrormRegistrationId"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;

                    txtStudent.Text = DATA1.First().StudentName;
                    txtAddress.Text = DATA1.First().Address;
                    txtContact.Text = DATA1.First().ContactNo;
                    txtEmailId.Text = DATA1.First().EmailId;
                    txtFatherName.Text = DATA2.First().FatherName;
                    txtFormNo.Text = DATA2.First().FormNo;
                    ddl_Course.ClearSelection();
                    foreach (ListItem li in ddl_Course.Items)
                    {
                        if (li.Text == DATA1.First().EnquiryForCourse.ToString())
                        {
                            li.Selected = true;
                            break;
                        }
                    }
                    txtFees.Text = DATA1.First().fees;
                    txtFeesAfterDisc.Text = DATA1.First().fees;
                    Session["AddImgPath"] = DATA1.First().Image;
                    Img1.ImageUrl = DATA1.First().Image;
                    txtVillage.Text = DATA1.First().Village;
                    ddl_PreviousClass.Text = DATA1.First().PreviousClass;
                    if (ddl_PreviousClass.SelectedItem.Text != "NEW")
                    {
                        divPCP.Visible = true;
                        divPreviousSchool.Visible = true;
                        txtPCP.Text = DATA1.First().PCP;
                        txtPreviousSchool.Text = DATA1.First().PreviousSchool;
                    }
                    else
                    {
                        divPCP.Visible = false;
                        divPreviousSchool.Visible = false;
                        txtPCP.Text = string.Empty;
                        txtPreviousSchool.Text = string.Empty;
                    }
                    try
                    {
                        ddl_Course_SelectedIndexChanged(null, null);
                    }
                    catch (Exception ex) { }
                }
                else if (Session["FrormRegistrationId"] != null)
                {
                    var DATA1 = from Cons in obj.RegistrationForms
                                where Cons.FrormRegistrationId == Convert.ToInt32(Session["FrormRegistrationId"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    txtStudent.Text = DATA1.First().StudentName;
                    txtAddress.Text = DATA1.First().Address;
                    txtContact.Text = DATA1.First().ContactNo;
                    txtFatherName.Text = DATA1.First().FatherName;
                    txtFormNo.Text = DATA1.First().FormNo;
                    ddl_Course.ClearSelection();
                    foreach (ListItem li in ddl_Course.Items)
                    {
                        if (li.Text == DATA1.First().Class.ToString())
                        {
                            li.Selected = true;
                            break;
                        }
                    }
                    try
                    {
                        ddl_Course_SelectedIndexChanged(null, null);
                    }
                    catch (Exception ex) { }

                }
                CheckHideShowStudentCommingFrom();
                if (!string.IsNullOrEmpty(Request.QueryString["AdmissionIdFromGoTo"]))
                {
                    Session["AdmissionId"] = Request.QueryString["AdmissionIdFromGoTo"].ToString();
                }
                if (Session["AdmissionId"] != null)
                {
                    SelectAdimissionData();
                }


                BindCourseGrid();

                BindDataGrid();
                
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

    }
    protected void CheckHideShowStudentCommingFrom()
    {
        try
        {
            var settings = obj.Settings.Where(x => x.CompanyId == Convert.ToInt32(Session["CompanyId"]));
            if (settings.FirstOrDefault().CompanyType == "college")
            {
                HideShowStudentCommingFrom.Visible = false;
                LabelTrasportType = "43.  University";
                FillDropdown.FillSINGLEVALUEDATA(ddlTrasportType, "UNIVERSITY", Convert.ToInt32(Session["CompanyId"].ToString()));
                ddlTrasportType.SelectedIndex = 0;
                ddlStudentComingFrom.SelectedItem.Text = "UNIVERSITY";
            }
            else if (settings.FirstOrDefault().CompanyType == "school")
            {
                HideShowStudentCommingFrom.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GetData()
    {
        //Student Staus
        DataSet dsStudentStatus = AllMethods.GetDashboard(3, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
        GridStudentStaus.DataSource = dsStudentStatus;
        GridStudentStaus.DataBind();
    }
    protected void GetBindDropDownClass()
    {
        var D = from Cons in obj.Courses
                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                select Cons;


        trClass1.Visible = false;
        trClass2.Visible = false;
        trClass3.Visible = false;
        trOther1.Visible = false;
        ddlClass1.DataSource = D;
        ddlClass1.DataTextField = "CourseName";
        ddlClass1.DataValueField = "CourseId";
        ddlClass1.DataBind();
        ddlClass1.Items.Insert(0, new ListItem());

        ddlClass2.DataSource = D;
        ddlClass2.DataTextField = "CourseName";
        ddlClass2.DataValueField = "CourseId";
        ddlClass2.DataBind();
        ddlClass2.Items.Insert(0, new ListItem());

        ddlClass3.DataSource = D;
        ddlClass3.DataTextField = "CourseName";
        ddlClass3.DataValueField = "CourseId";
        ddlClass3.DataBind();
        ddlClass3.Items.Insert(0, new ListItem());

        ddlClassOther1.DataSource = D;
        ddlClassOther1.DataTextField = "CourseName";
        ddlClassOther1.DataValueField = "CourseId";
        ddlClassOther1.DataBind();
        ddlClassOther1.Items.Insert(0, new ListItem());
    }
    protected void FillSchoolName()
    {
        var Profile = from Cons in obj.Settings
                      where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                      select Cons;
        txtFrom.Text = Profile.First().SchoolName;
        txtFrom.Enabled = false;
    }
    private void BindCourseGrid()
    {
        try
        {
            if (role.Select.Value)
            {

                lblCourseAuthorized.Visible = false;
                if (txtSearch.Text != "")
                {
                    if (ViewState["ClassName"].ToString() == "ALL" && ViewState["CourseStatus"].ToString() == "ALL")
                    {

                        var DATA = from Cons in obj.Addmisions
                                   where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && SqlMethods.Like(Cons.StudentName, "" + txtSearch.Text + "%") || SqlMethods.Like(Cons.CourseName, "" + txtSearch.Text + "%")
                                   select Cons;
                        GridStudentCourse.DataSource = DATA;
                        GridStudentCourse.DataBind();
                    }
                    else if (ViewState["ClassName"].ToString() != "ALL" && ViewState["CourseStatus"].ToString() != "ALL")
                    {
                        if (ViewState["ddlSection"].ToString() == "ALL")
                        {
                            var DATA = from Cons in obj.Addmisions
                                       where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtSearch.Text + "%") || SqlMethods.Like(Cons.CourseName, "" + txtSearch.Text + "%"))
                                       select Cons;
                            GridStudentCourse.DataSource = DATA;
                            GridStudentCourse.DataBind();
                        }
                        else
                        {
                            var DATA = from Cons in obj.Addmisions
                                       where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Section == ViewState["ddlSection"].ToString() && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtSearch.Text + "%") || SqlMethods.Like(Cons.CourseName, "" + txtSearch.Text + "%"))
                                       select Cons;
                            GridStudentCourse.DataSource = DATA;
                            GridStudentCourse.DataBind();
                        }
                    }
                    else
                    {
                        if (ViewState["ClassName"].ToString() != "ALL")
                        {
                            if (ViewState["ddlSection"].ToString() == "ALL")
                            {
                                var DATA = from Cons in obj.Addmisions
                                           where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtSearch.Text + "%") || SqlMethods.Like(Cons.CourseName, "" + txtSearch.Text + "%"))
                                           select Cons;
                                GridStudentCourse.DataSource = DATA;
                                GridStudentCourse.DataBind();
                            }
                            else
                            {
                                var DATA = from Cons in obj.Addmisions
                                           where Cons.Section == ViewState["ddlSection"].ToString() && Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtSearch.Text + "%") || SqlMethods.Like(Cons.CourseName, "" + txtSearch.Text + "%"))
                                           select Cons;
                                GridStudentCourse.DataSource = DATA;
                                GridStudentCourse.DataBind();
                            }
                        }
                        else if (ViewState["CourseStatus"].ToString() != "ALL")
                        {
                            var DATA = from Cons in obj.Addmisions
                                       where Cons.Remove == false && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtSearch.Text + "%") || SqlMethods.Like(Cons.CourseName, "" + txtSearch.Text + "%"))
                                       select Cons;
                            GridStudentCourse.DataSource = DATA;
                            GridStudentCourse.DataBind();
                        }
                    }
                }
                else
                {
                    if (ViewState["ClassName"].ToString() == "ALL" && ViewState["CourseStatus"].ToString() == "ALL")
                    {
                        var DATA = from Cons in obj.Addmisions
                                   where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                   select Cons;
                        GridStudentCourse.DataSource = DATA;
                        GridStudentCourse.DataBind();
                    }
                    else if (ViewState["ClassName"].ToString() != "ALL" && ViewState["CourseStatus"].ToString() != "ALL")
                    {
                        if (ViewState["ddlSection"].ToString() == "ALL")
                        {
                            var DATA = from Cons in obj.Addmisions
                                       where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                       select Cons;
                            GridStudentCourse.DataSource = DATA;
                            GridStudentCourse.DataBind();
                        }
                        else
                        {
                            var DATA = from Cons in obj.Addmisions
                                       where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Section == ViewState["ddlSection"].ToString() && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                       select Cons;
                            GridStudentCourse.DataSource = DATA;
                            GridStudentCourse.DataBind();
                        }

                    }
                    else
                    {
                        if (ViewState["ClassName"].ToString() != "ALL")
                        {

                            if (ViewState["ddlSection"].ToString() == "ALL")
                            {
                                var DATA = from Cons in obj.Addmisions
                                           where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                           select Cons;
                                GridStudentCourse.DataSource = DATA;
                                GridStudentCourse.DataBind();
                            }
                            else
                            {
                                var DATA = from Cons in obj.Addmisions
                                           where Cons.Section == ViewState["ddlSection"].ToString() && Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                           select Cons;
                                GridStudentCourse.DataSource = DATA;
                                GridStudentCourse.DataBind();
                            }
                        }
                        else if (ViewState["CourseStatus"].ToString() != "ALL")
                        {
                            var DATA = from Cons in obj.Addmisions
                                       where Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                       select Cons;
                            GridStudentCourse.DataSource = DATA;
                            GridStudentCourse.DataBind();
                        }
                    }
                }

                DropDownList ddlCourseName =
    (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseName");
                BindCouseName(ddlCourseName);
                DropDownList ddlCourseSatus =
 (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseStatus");
                BindCourseStatus(ddlCourseSatus);
                DropDownList ddlSection1 =
  (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlSection");
                BindSection(ddlSection1);
            }
            else
            {
                lblCourseAuthorized.Visible = true;
                lblCourseAuthorized.Text = "Not Authorized to See..";
            }
        }
        catch (Exception ex)
        { }
    }

    private void BindCouseName(DropDownList ddlCourseName)
    {
        try
        {
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.CourseId ascending
                        select new
                        {
                            ClassName = Cons.CourseName,
                            CourseId = Cons.CourseId
                        })
                       .ToList()
                       .Distinct();
            ddlCourseName.DataSource = DATA;
            ddlCourseName.DataTextField = "ClassName";
            ddlCourseName.DataValueField = "CourseId";
            ddlCourseName.DataBind();
            ddlCourseName.Items.FindByValue(ViewState["ClassName"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        { }
    }
    private void BindCourseStatus(DropDownList ddlCourseSatus)
    {
        try
        {
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            Status = Cons.R1
                        })
                       .ToList()
                       .Distinct();
            ddlCourseSatus.DataSource = DATA;
            ddlCourseSatus.DataTextField = "Status";
            ddlCourseSatus.DataValueField = "Status";
            ddlCourseSatus.DataBind();
            ddlCourseSatus.Items.FindByValue(ViewState["CourseStatus"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        { }
    }
    private void BindStatus(DropDownList ddlStatus)
    {
        try
        {
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            Status = Cons.R1
                        })
                       .ToList()
                       .Distinct();
            ddlStatus.DataSource = DATA;
            ddlStatus.DataTextField = "Status";
            ddlStatus.DataValueField = "Status";
            ddlStatus.DataBind();
            ddlStatus.Items.FindByValue(ViewState["AdmStatus"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        { }
    }

    private void GetAge()
    {
        DataSet ds = new DataSet();
        ds = AllMethods.CALCULATEAGE(dt_BOD.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtAge.Text = dr[0].ToString();
            }
        }
    }
    private void BindDataGrid()
    {
        try
        {
            if (role.Select.Value)
            {
                lblAuthorized.Visible = false;
                if (ddl_Search.Text == "By Student")
                {
                    if (ViewState["AdmStatus"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where SqlMethods.Like(Cons.StudentName, "" + txtSearchByStudentName.Text + "%") && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();
                        getShivlings("0", DATA1.First().StudentName);
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where SqlMethods.Like(Cons.StudentName, "" + txtSearchByStudentName.Text + "%") && Cons.R1 == ViewState["AdmStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();
                        getShivlings("0", DATA1.First().StudentName);
                    }
                }
                else if (ddl_Search.Text == "By Adimission No")
                {
                    if (ViewState["AdmStatus"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.AdmissionNo == txtSearchByAdimissionNo.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();
                        getShivlings(DATA1.First().AdmissionNo, "");
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.AdmissionNo == txtSearchByAdimissionNo.Text && Cons.R1 == ViewState["AdmStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();
                        getShivlings(DATA1.First().AdmissionNo, "");
                    }
                }
                else if (ddl_Search.Text == "By Contact No")
                {
                    if (ViewState["AdmStatus"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where SqlMethods.Like(Cons.ContactNo, "" + txtSearchByContact.Text + "%") && Cons.R1 == ViewState["AdmStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();

                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where SqlMethods.Like(Cons.ContactNo, "" + txtSearchByContact.Text + "%") && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();
                    }
                }
                else if (ddl_Search.Text == "By Date")
                {
                    if (ViewState["AdmStatus"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.AdmissionDate >= DateTime.Parse(dtSDate.Text) &&
                                       Cons.AdmissionDate <= DateTime.Parse(dtEDate.Text) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();

                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.AdmissionDate >= DateTime.Parse(dtSDate.Text) &&
                                       Cons.AdmissionDate <= DateTime.Parse(dtEDate.Text) && Cons.R1 == ViewState["AdmStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    orderby Cons.AdmissionId descending
                                    select Cons;
                        GridAdmission.DataSource = DATA1;
                        GridAdmission.Columns[7].HeaderText = Session["ClassLableText"].ToString();
                        GridAdmission.DataBind();
                    }
                }

                DropDownList ddlStatus =
        (DropDownList)GridAdmission.HeaderRow.FindControl("ddlStatus");
                BindStatus(ddlStatus);
            }
            else
            {
                lblAuthorized.Visible = true;
                lblAuthorized.Text = "Not Authorized to See..";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Visibility", "Visibility();", true);

        }
        catch (Exception ex) { }
    }

    private void SelectAdimissionData()
    {
        var DATA = from Cons in obj.Addmisions
                   where Cons.AdmissionId == Convert.ToInt32(Session["AdmissionId"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                   select Cons;
        txtAdmissionNo.Text = DATA.First().AdmissionNo;
        getShivlings(DATA.First().AdmissionNo, "");
        Accordian.SelectedIndex = 0;
        Session["AdmNo"] = txtAdmissionNo.Text;
        txtVillage.Text = DATA.First().EnrollmentNo;
        dtAdmissionDate.Text = Convert.ToDateTime(DATA.First().AdmissionDate).ToString("dd/MM/yyyy");
        txtStudent.Text = DATA.First().StudentName;
        txtContact.Text = DATA.First().ContactNo;
        txtFatherName.Text = DATA.First().FatherName;
        txtFatherOccupation.Text = DATA.First().Foccupation;
        txtMother.Text = DATA.First().MotherName;
        txtMotherOccupation.Text = DATA.First().Moccupation;
        txtParentContact.Text = DATA.First().ParentContact;
        dt_BOD.Text = DATA.First().DOB.ToString();
        txtAge.Text = DATA.First().StudentAge.ToString();
        //ddlSection.Text = DATA.First().Section;
        txtEmailId.Text = DATA.First().EmailId;
        ddlGender.Text = DATA.First().Gender;
        AdmittedClass.Visible = true;
        ddlSection.ClearSelection();
        foreach (ListItem li in ddlSection.Items)
        {
            if (li.Text == DATA.First().Section.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        ddlAdmittedClass.ClearSelection();
        foreach (ListItem li in ddlAdmittedClass.Items)
        {
            if (li.Text == DATA.First().AdmittedInClass.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        ddl_Catrgory.ClearSelection();
        foreach (ListItem li in ddl_Catrgory.Items)
        {
            if (li.Text == DATA.First().Category.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        ddl_Religion.ClearSelection();
        foreach (ListItem li in ddl_Religion.Items)
        {
            if (li.Text == DATA.First().Religion.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        if (DATA.First().Nationality == "THIRD" && DATA.First().Course1 != null && DATA.First().Course1 != 0 && DATA.First().StudentName1 != null && DATA.First().StudentName1 != 0 && DATA.First().Course2 != null && DATA.First().Course2 != 0 && DATA.First().StudentName2 != null && DATA.First().StudentName2 != 0)
        {
            trClass1.Visible = true;
            trClass2.Visible = true;
            ddlClass1.ClearSelection();
            foreach (ListItem li in ddlClass1.Items)
            {
                if (li.Value == DATA.First().Course1.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            FillDropdown.FillStudentNameByClass(ddlStudentName1, Convert.ToInt32(ddlClass1.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
            ddlStudentName1.ClearSelection();
            foreach (ListItem li in ddlStudentName1.Items)
            {
                if (li.Value == DATA.First().StudentName1.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtRelation1.Text = DATA.First().Relation1;

            ddlClass2.ClearSelection();
            foreach (ListItem li in ddlClass2.Items)
            {
                if (li.Value == DATA.First().Course2.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            FillDropdown.FillStudentNameByClass(ddlStudentName2, Convert.ToInt32(ddlClass2.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
            ddlStudentName2.ClearSelection();
            foreach (ListItem li in ddlStudentName2.Items)
            {
                if (li.Value == DATA.First().StudentName2.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtRelation2.Text = DATA.First().Relation2;
        }

        if (DATA.First().Nationality == "SECOND" && DATA.First().Course1 != null && DATA.First().Course1 != 0 && DATA.First().StudentName1 != null && DATA.First().StudentName1 != 0)
        {
            trClass1.Visible = true;
            ddlClass1.ClearSelection();
            foreach (ListItem li in ddlClass1.Items)
            {
                if (li.Value == DATA.First().Course1.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            FillDropdown.FillStudentNameByClass(ddlStudentName1, Convert.ToInt32(ddlClass1.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
            ddlStudentName1.ClearSelection();
            foreach (ListItem li in ddlStudentName1.Items)
            {
                if (li.Value == DATA.First().StudentName1.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtRelation1.Text = DATA.First().Relation1;
        }

        if (DATA.First().Nationality == "OTHER" && DATA.First().CourseOther1 != null && DATA.First().CourseOther1 != 0 && DATA.First().StudentOther1 != null && DATA.First().StudentOther1 != 0)
        {
            trOther1.Visible = true;
            ddlClassOther1.ClearSelection();
            foreach (ListItem li in ddlClassOther1.Items)
            {
                if (li.Value == DATA.First().CourseOther1.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            FillDropdown.FillStudentNameByClass(ddlStudentNameOther1, Convert.ToInt32(ddlClassOther1.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
            ddlStudentNameOther1.ClearSelection();
            foreach (ListItem li in ddlStudentNameOther1.Items)
            {
                if (li.Value == DATA.First().StudentOther1.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            txtRelationOther1.Text = DATA.First().RelationOther1;
        }

        txtAddress.Text = DATA.First().Address;
        Session["AddImgPath"] = DATA.First().StudentPhoto;
        Img1.ImageUrl = DATA.First().StudentPhoto;
        txtAadharCardNo.Text = DATA.First().AadharCardNo;
        ddl_Nationality.Text = DATA.First().Nationality;
        txtPreviousSchool.Text = DATA.First().Status;
        ddl_Course.SelectedValue = DATA.First().CourseId.ToString();
        txtFees.Text = DATA.First().CourseFees.ToString();
        dd_DiscountType.Text = DATA.First().CourseDiscountType;
        if (DATA.First().DiscountApproval == 3)
        {
            txtDiscount.Enabled = false;
        }
        else
        {
            txtDiscount.Enabled = true;
        }
        txtDiscount.Text = DATA.First().CourseDiscount.ToString();
        txtFeesAfterDisc.Text = DATA.First().CourseFeesAfterDisc.ToString();
        txtFeesRemarks.Text = DATA.First().CourseRemarks;
        Session["serial"] = DATA.First().SerialNo.ToString();
        lblDoc.Visible = true;
        txtSamegraId.Text = DATA.First().SamegraId;
        txtFamilyId.Text = DATA.First().FamilyId;
        if (DATA.First().Bank1 != "")
        {
            chkBank1.Checked = true;
            Bank1.Visible = true;
            txtBankName1.Text = DATA.First().BankName1;
            txtAccountNumber1.Text = DATA.First().Bank1;
            txtIFSCcode1.Text = DATA.First().IFSC1;
            txtBranchName1.Text = DATA.First().BranchName1;
        }
        else
        {
            chkBank1.Checked = false;
            Bank1.Visible = false;
            txtBankName1.Text = "";
            txtAccountNumber1.Text = "";
            txtIFSCcode1.Text = "";
            txtBranchName1.Text = "";
        }
        if (DATA.First().Bank2 != "")
        {
            chkBank2.Checked = true;
            Bank2.Visible = true;
            txtBankName2.Text = DATA.First().BankName2;
            txtAccountNumber2.Text = DATA.First().Bank2;
            txtIFSCcode2.Text = DATA.First().IFSC2;
            txtBranchName2.Text = DATA.First().BranchName;
        }
        else
        {
            chkBank2.Checked = false;
            Bank2.Visible = false;
            txtBankName2.Text = "";
            txtAccountNumber2.Text = "";
            txtIFSCcode2.Text = "";
            txtBranchName2.Text = "";
        }
        if (DATA.First().Status != "NEW")
        {
            divPCP.Visible = true;
            divPreviousSchool.Visible = true;
            txtPCP.Text = DATA.First().PCP;
            txtPreviousSchool.Text = DATA.First().Status;
        }
        else
        {
            divPCP.Visible = false;
            divPreviousSchool.Visible = false;
            txtPCP.Text = string.Empty;
            txtPreviousSchool.Text = string.Empty;
        }
        ddlPaymentType.Text = DATA.First().PaymentType;

        if (DATA.First().PaymentType == "Installment")
        {
            Install.Visible = true;
            txtNoOfInstallment.Text = DATA.First().NoOfInstallment.ToString();
        }
        else
        {
            Install.Visible = false;
            txtNoOfInstallment.Text = string.Empty;
        }
        if (DATA.First().PreviousClass != "NEW")
        {
            divPCP.Visible = true;
            divPreviousSchool.Visible = true;
            ddl_PreviousClass.Text = DATA.First().PreviousClass;
            txtPCP.Text = DATA.First().PCP;
            txtPreviousSchool.Text = DATA.First().Status;
        }
        else
        {
            divPCP.Visible = false;
            ddl_PreviousClass.SelectedIndex = 0;
            divPreviousSchool.Visible = false;
            txtPCP.Text = string.Empty;
            txtPreviousSchool.Text = string.Empty;
        }
        if (DATA.First().From != "" && DATA.First().To != "")
        {
            ddlStudentComingFrom.SelectedIndex = 1;
            ChkTransport.Checked = true;
            TrasportId.Visible = true;
            txtFrom.Text = DATA.First().From;
            var B = from Cons in obj.BusTransports
                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
            ddlTo.DataSource = B;
            ddlTo.DataTextField = "To";
            ddlTo.DataValueField = "TransportId";
            ddlTo.DataBind();
            ddlTo.Items.Insert(0, new ListItem());
            ddlTo.ClearSelection();
            foreach (ListItem li in ddlTo.Items)
            {
                if (li.Text == DATA.First().To.ToString())
                {
                    li.Selected = true;
                    break;
                }
            }
            //ddlTo.SelectedItem.Text = DATA.First().AreaId.ToString();
            txtTransportFees.Text = DATA.First().TransportFees.ToString();
            ddlTransportDiscType.Text = DATA.First().TransportDiscountType;
            txtTransportDisc.Text = DATA.First().TransportDiscount.ToString();
            txtTransportFeesAfterDisc.Text = DATA.First().TransportFeesAfterDisc.ToString();
            txtTransportRemarks.Text = DATA.First().TransportRemarks;
        }
        else
        {
            txtFrom.Text = "";
            ddlTo.SelectedIndex = 0;
            txtTransportFees.Text = "";
            ddlTransportDiscType.SelectedIndex = 0;
            txtTransportDisc.Text = "";
            txtTransportFeesAfterDisc.Text = "";
            txtTransportRemarks.Text = "";
            ChkTransport.Checked = false;
            TrasportId.Visible = false;
        }
        if (DATA.First().StudentCommingCategoty == "SCHOOL TRANSPORT")
        {
            ddlStudentComingFrom.SelectedIndex = 0;
            FillDropdown.FillSELFTRANSPORT(ddlTrasportType, Convert.ToInt32(Session["CompanyId"].ToString()));
            ddlTrasportType.SelectedValue = DATA.First().AreaId.ToString();
            TrasportType.Visible = false;
        }
        else if (DATA.First().StudentCommingCategoty == "SELF TRANSPORT")
        {
            ddlStudentComingFrom.SelectedIndex = 1;
            TrasportType.Visible = true;
            FillDropdown.FillSELFTRANSPORT(ddlTrasportType, Convert.ToInt32(Session["CompanyId"].ToString()));
            ddlTrasportType.SelectedValue = DATA.First().AreaId.ToString();
            LabelTrasportType = "Self Transport Type";
        }
        else if (DATA.First().StudentCommingCategoty == "PUBLIC TRANSPORT")
        {
            ddlStudentComingFrom.SelectedIndex = 2;
            TrasportType.Visible = true;
            FillDropdown.FillPUBLICTRANSPORT(ddlTrasportType, Convert.ToInt32(Session["CompanyId"].ToString()));
            ddlTrasportType.SelectedValue = DATA.First().AreaId.ToString();
            LabelTrasportType = "Public Transport Type";
        }
        else if (DATA.First().StudentCommingCategoty == "UNIVERSITY")
        {
            CheckHideShowStudentCommingFrom();
            ddlStudentComingFrom.SelectedItem.Text = "UNIVERSITY";
            ddlTrasportType.ClearSelection();
            FillDropdown.FillSINGLEVALUEDATA(ddlTrasportType,"UNIVERSITY", Convert.ToInt32(Session["CompanyId"].ToString()));
            ddlTrasportType.SelectedValue = DATA.First().AreaId.ToString();
        }
        else
        {
            TrasportType.Visible = false;
        }
        if (!String.IsNullOrEmpty(DATA.First().PMADate.ToString()))
        {
            dtPMADate.Text = Convert.ToDateTime(DATA.First().PMADate).ToString("dd/MM/yyyy");
        }
        else
        {
            dtPMADate.Text = "";
        }
        if (DATA.First().NoOfChildInFamily != "0" || DATA.First().NoOfBrothers != "0" || DATA.First().NoOfSisters != "0" || DATA.First().AnualIncome != 0 || DATA.First().BloodGroup != "" || DATA.First().Height != "")
        {
            chkOtherInformation.Checked = true;
            DivOtherInformation.Visible = true;
            ddlNoOfChildInFamily.SelectedIndex = Convert.ToInt32(DATA.First().NoOfChildInFamily);
            ddlNoOfBrothers.SelectedIndex = Convert.ToInt32(DATA.First().NoOfBrothers);
            ddlNoOfSisters.SelectedIndex = Convert.ToInt32(DATA.First().NoOfSisters);
            txtBloodGroup.Text = DATA.First().BloodGroup;
            txtAnualIncome.Text = DATA.First().AnualIncome.ToString();
            txtHeight.Text = DATA.First().Height;

        }
        else
        {
            chkOtherInformation.Checked = false;
            DivOtherInformation.Visible = false;
            ddlNoOfChildInFamily.SelectedIndex = 0;
            ddlNoOfBrothers.SelectedIndex = 0;
            ddlNoOfSisters.SelectedIndex = 0;
            txtBloodGroup.Text = "";
            txtAnualIncome.Text = "";
        }

        var D = (from Cons in obj.Payments
                 where Cons.AdmissionId == Convert.ToInt32(Session["AdmissionId"]) && Cons.Remove == false && Cons.ComapanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                 select Cons.PaymentId).Count();
        if (D != 0)
        {
            txtNoOfInstallment.Enabled = false;
            ddlPaymentType.Enabled = false;
        }
        else
        {
            txtNoOfInstallment.Enabled = true;
            ddlPaymentType.Enabled = true;

        }
        txtTotalFees.Text = DATA.First().TotalFees.ToString();
        txttotOtherFee.Text = (DATA.First().TotalFees - DATA.First().CourseFees).ToString();

        ddlStream.ClearSelection();
        foreach (ListItem li in ddlStream.Items)
        {
            if (li.Text == DATA.First().Stream.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        ddlStatus.ClearSelection();
        foreach (ListItem li in ddlStatus.Items)
        {
            if (li.Text == DATA.First().R1.ToString())
            {
                li.Selected = true;
                break;
            }
        }
        txtFormNo.Text = DATA.First().R2;
        if (ddlStatus.SelectedItem.Text == "TC ISSUED")
        {
            TC.Visible = true;
            txtTcIssueDate.Text = DATA.First().R3;
        }
        else
        {
            TC.Visible = false;
            txtTcIssueDate.Text = "";
        }
    }
    protected void ChkTransport_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChkTransport.Checked)
            {
                TrasportId.Visible = true;
            }
            else
            {
                TrasportId.Visible = false;
            }

        }
        catch (Exception ex)
        { }
    }
    protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddNo = "";
        try
        {
            double TotalOtherFees = 0, CourseFees = 0;
            var D1 = from Cons in obj.Courses
                     where Cons.CourseId == Convert.ToInt32(ddl_Course.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                     select Cons;
            string str = "", year = "";
            str = DateTime.Now.Year.ToString();
            year = str.Substring(0, 4);
            string str1 = Convert.ToDateTime(dtAdmissionDate.Text).Year.ToString();
            if (year == str1)
            {
                IEnumerable<Other_Fee> inv = from o in obj.Other_Fees
                                             where o.CourseId == Convert.ToInt32(ddl_Course.SelectedValue)
                                             && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select o;
                TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));
            }
            else
            {
                IEnumerable<Other_Fee> inv = from o in obj.Other_Fees
                                             where o.CourseId == Convert.ToInt32(ddl_Course.SelectedValue)
                                             && o.FeesType != "ADMISSION FEES"
                                             && o.FeesType != "REGISTRATION FEES"
                                             && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select o;
                TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));
            }
            if (ddl_Nationality.SelectedIndex != 0)
            {
                if (ddl_Course.SelectedIndex != 0)
                {
                    if (ddl_Nationality.SelectedItem.Text == "FIRST")
                    {
                        txtFees.Text = D1.First().TotalFirstChild.ToString();
                        txtFeesAfterDisc.Text = D1.First().TotalFirstChild.ToString();
                        CourseFees = Convert.ToDouble(txtFeesAfterDisc.Text);
                        txtTotalFees.Text = (CourseFees + TotalOtherFees).ToString();

                    }
                    else if (ddl_Nationality.SelectedItem.Text == "SECOND")
                    {
                        txtFees.Text = D1.First().TotalSecondChild.ToString();
                        txtFeesAfterDisc.Text = D1.First().TotalSecondChild.ToString();
                        CourseFees = Convert.ToDouble(txtFeesAfterDisc.Text);
                        txtTotalFees.Text = (CourseFees + TotalOtherFees).ToString();
                    }
                    else
                    {
                        txtFees.Text = D1.First().TotalThirdChild.ToString();
                        txtFeesAfterDisc.Text = D1.First().TotalThirdChild.ToString();
                        CourseFees = Convert.ToDouble(txtFeesAfterDisc.Text);
                        txtTotalFees.Text = (CourseFees + TotalOtherFees).ToString();
                    }
                    txttotOtherFee.Text = TotalOtherFees.ToString();
                }
                else
                {
                    txtFees.Text = "";
                    txtFeesAfterDisc.Text = "";
                    txttotOtherFee.Text = null;
                }
            }
            else
            {
                msg = "Please select child status....";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
            DisCountCourseFees();
        }
        catch (Exception ex)
        { }

    }
    public string GenerateAddNoByAdmisionDate()
    {
        if (dtAdmissionDate.Text == "" || dtAdmissionDate.Text.Length < 10)
        {
            Globals.Message(Page, "Please Enter Valid !!!!");
            dtAdmissionDate.Focus();
        }
        else
        {
            try
            {
                string AddmisionSessionYesrWise = dtAdmissionDate.Text.Substring(8, 2);
                var AddmisionNo = AddmisionSessionYesrWise + Convert.ToInt32(Convert.ToInt32(AddmisionSessionYesrWise) + 1).ToString();
                if (AddmisionNo.Length == 3)
                {
                    AddmisionNo = AddmisionSessionYesrWise + "0" + AddmisionNo.Substring(2, 1);
                }
                if (chkAdmissionNo.Checked)
                {
                    serial = Convert.ToInt32(txtAdmissionNo.Text.Substring(4, 4));
                }
                else
                {
                    serial = Convert.ToInt32(AllMethods.SelectSerialNo(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToDateTime(dtAdmissionDate.Text)));
                }
                Session["serial"] = serial;

                if (serial < 10)
                {
                    AddNo = AddNo + "000" + serial;
                }
                else if (serial >= 10 && serial < 100)
                {
                    AddNo = AddNo + "00" + serial;
                }
                else if (serial >= 100 && serial < 1000)
                {
                    AddNo = AddNo + "0" + serial;
                }
                else if (serial >= 1000 && serial < 10000)
                {
                    AddNo = AddNo + serial;
                }
                txtAdmissionNo.Text = AddmisionNo + AddNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return txtAdmissionNo.Text;
    }
    //private void GenerateAddNo()
    //{
    //    if (Session["AdmissionId"] == null)
    //    {
    //        AllMethods m = AllMethods.SelectSerialNo(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
    //        serial = Convert.ToInt32(m.SerNo);
    //        Session["serial"] = Convert.ToInt32(m.SerNo);
    //        var DATA1 = from Cons in obj.Sessions
    //                    where Cons.Sessionid == Convert.ToInt32(Session["SessionId"]) && Cons.Remove == false
    //                    select Cons;
    //        string SessionName = DATA1.First().SessionName;
    //        int Ad = 0;
    //        AddNo = SessionName.Substring(0, 4);
    //        AddNo = AddNo.Substring(2, 2);
    //        Ad = Convert.ToInt32(AddNo) + 1;
    //        AddNo = AddNo + Ad.ToString();
    //        if (serial < 10)
    //        {
    //            AddNo = AddNo + "000" + serial;
    //        }
    //        else if (serial >= 10 && serial < 100)
    //        {
    //            AddNo = AddNo + "00" + serial;
    //        }
    //        else if (serial >= 100 && serial < 1000)
    //        {
    //            AddNo = AddNo +"0"+ serial;
    //        }
    //        else if (serial >= 1000 && serial < 10000)
    //        {
    //            AddNo = AddNo + serial;
    //        }
    //        txtAdmissionNo.Text = AddNo;
    //    }
    //}
    protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTo.SelectedIndex != 0)
            {
                var D1 = from Cons in obj.BusTransports
                         where Cons.TransportId == Convert.ToInt32(ddlTo.SelectedValue) && Cons.Remove == false
                         select Cons;
                txtTransportFees.Text = D1.First().TotalFees.ToString();
                txtTransportFeesAfterDisc.Text = D1.First().TotalFees.ToString();
            }
            else
            {
                txtTransportFees.Text = "";
                txtTransportFeesAfterDisc.Text = "";
            }
            DiscountTransportFees();
        }
        catch (Exception ex)
        { }
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        DisCountCourseFees();
    }
    private void DisCountCourseFees()
    {
        try
        {
            double TotalOtherFees = 0, CourseFees = 0;
            decimal fees = 0, Disc = 0, feesAfterDesc = 0;
            try
            {
                fees = Convert.ToDecimal(txtFees.Text);
            }
            catch (Exception ex)
            { fees = 0; }
            try
            {
                Disc = Convert.ToDecimal(txtDiscount.Text);
            }
            catch (Exception ex)
            { Disc = 0; }
            if (dd_DiscountType.Text == "Flat" && dd_DiscountType.SelectedIndex == 0)
            {
                feesAfterDesc = fees - Disc;
                txtFeesAfterDisc.Text = feesAfterDesc.ToString();
            }
            else if (dd_DiscountType.Text == "Percent" && dd_DiscountType.SelectedIndex == 1)
            {
                feesAfterDesc = (fees * Disc) / 100;
                txtFeesAfterDisc.Text = Convert.ToString(fees - feesAfterDesc);
            }
            string str = "", year = "";
            str = ddlSession.SelectedItem.Text;
            //year = str.Substring(0, 4);
            year = DateTime.Now.Year.ToString();
            string str1 = Convert.ToDateTime(dtAdmissionDate.Text).Year.ToString();
            if (year == str1)
            {
                IEnumerable<Other_Fee> inv = from o in obj.Other_Fees
                                             where o.CourseId == Convert.ToInt32(ddl_Course.SelectedValue)
                                             && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select o;
                TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));
            }
            else
            {
                IEnumerable<Other_Fee> inv = from o in obj.Other_Fees
                                             where o.CourseId == Convert.ToInt32(ddl_Course.SelectedValue)
                                             && o.FeesType != "ADMISSION FEES"
                                             && o.FeesType != "REGISTRATION FEES"
                                             && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select o;
                TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));
            }
            CourseFees = Convert.ToDouble(txtFees.Text);
            txtTotalFees.Text = (CourseFees + TotalOtherFees).ToString();
        }
        catch (Exception ex)
        { }
    }
    protected void dd_DiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtDiscount.Text = "";
            txtFeesAfterDisc.Text = txtFees.Text;
            txtDiscount.Focus();
            DisCountCourseFees();
        }
        catch (Exception ex)
        { }
    }
    protected void txtTransportDisc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DiscountTransportFees();
        }
        catch (Exception ex)
        { }
    }

    private void DiscountTransportFees()
    {
        decimal fees = 0, Disc = 0, feesAfterDesc = 0;
        try
        {
            fees = Convert.ToDecimal(txtTransportFees.Text);
        }
        catch (Exception ex)
        { fees = 0; }
        try
        {
            Disc = Convert.ToDecimal(txtTransportDisc.Text);
        }
        catch (Exception ex)
        { Disc = 0; }
        if (ddlTransportDiscType.Text == "Flat" && ddlTransportDiscType.SelectedIndex == 0)
        {
            feesAfterDesc = fees - Disc;
            txtTransportFeesAfterDisc.Text = feesAfterDesc.ToString();
        }
        else if (ddlTransportDiscType.Text == "Percent" && ddlTransportDiscType.SelectedIndex == 1)
        {
            feesAfterDesc = (fees * Disc) / 100;
            txtTransportFeesAfterDisc.Text = Convert.ToString(fees - feesAfterDesc);
        }
    }
    protected void ddlTransportDiscType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtTransportDisc.Text = "";
            txtTransportFeesAfterDisc.Text = txtTransportFees.Text;
            txtTransportDisc.Focus();
            DiscountTransportFees();
        }
        catch (Exception ex)
        { }
    }
    protected void btnPicUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["AdmissionId"] == null)
            {
                if (role.Insert.Value)
                {
                    string filename = Path.GetFileName(UploadImage.PostedFile.FileName);

                    if (File.Exists(Server.MapPath("~/images/" + filename)) == false)
                    {
                        UploadImage.SaveAs(Server.MapPath("~/images/" + filename));
                        Img1.ImageUrl = "~/images/" + filename;
                        Session["AddImgPath"] = "~/images/" + filename;
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
                    Session["AddImgPath"] = "~/images/" + filename;
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
    protected void btnClearImg_Click(object sender, EventArgs e)
    {
        try
        {
            Img1.ImageUrl = "~/images/male.png";
        }
        catch (Exception ex)
        { }
    }
    public bool Isvalid()
    {
        bool val = true;
        if (ddl_Nationality.SelectedItem.Text == "SECOND")
        {
            if (ddlClass1.SelectedIndex <= 0)
            {
                msg = "Please enter/select Class...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlClass1.Focus();
            }
            if (ddlStudentName1.SelectedIndex <= 0)
            {
                msg = "Please enter/select Student Name...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlStudentName1.Focus();
            }
        }
        else if (ddl_Nationality.SelectedItem.Text == "THIRD")
        {
            if (ddlClass1.SelectedIndex <= 0)
            {
                msg = "Please enter/select Class...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlClass1.Focus();
            }
            if (ddlStudentName1.SelectedIndex <= 0)
            {
                msg = "Please enter/select Student Name...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlStudentName1.Focus();
            }
            if (ddlClass2.SelectedIndex <= 0)
            {
                msg = "Please enter/select Class...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlClass2.Focus();
            }
            if (ddlStudentName2.SelectedIndex <= 0)
            {
                msg = "Please enter/select Student Name...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlStudentName2.Focus();
            }
        }
        else if (ddl_Nationality.SelectedItem.Text == "OTHER")
        {
            if (ddlClassOther1.SelectedIndex <= 0)
            {
                msg = "Please enter/select Class...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlClassOther1.Focus();
            }
            if (ddlStudentNameOther1.SelectedIndex <= 0)
            {
                msg = "Please enter/select Student Name...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                ddlStudentNameOther1.Focus();
            }
        }
        if (dtAdmissionDate.Text == "")
        {
            msg = "Please enter/select admission date...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            dtAdmissionDate.Focus();
        }
        else if (txtStudent.Text == "")
        {
            msg = "Please enter student name..";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtStudent.Focus();
        }
        else if (txtContact.Text == "")
        {
            msg = "Please enter contact number...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtContact.Focus();
        }
        else if (txtFatherName.Text == "")
        {
            msg = "Please enter father name...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtFatherName.Focus();
        }
        else if (txtMother.Text == "")
        {
            msg = "Please enter mother name...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtMother.Focus();
        }
        else if (dt_BOD.Text == "")
        {
            
            msg = "Please enter/select DOB...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            dt_BOD.Focus();
        }
        else if (dt_BOD.Text.Length<10)
        {
            msg = "Please enter/select correct format (DD/MM/YYYY)";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            dt_BOD.Focus();
        }
        else if (ddlGender.SelectedIndex == 0)
        {
            msg = "Please select gender...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            ddlGender.Focus();
        }
        else if (ddl_Catrgory.SelectedIndex == 0)
        {
            msg = "Please select cast...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            ddl_Catrgory.Focus();
        }
        else if (ddl_Nationality.SelectedIndex == 0)
        {
            msg = "Please select child status...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            ddl_Nationality.Focus();
        }
        else if (ddl_Course.SelectedIndex == 0)
        {
            msg = "Please select class...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            ddl_Course.Focus();
        }
        else if (ddlPaymentType.SelectedIndex == 0)
        {
            msg = "Please select installment type...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            ddlPaymentType.Focus();
        }
        else if (ddlPaymentType.SelectedIndex == 1 && txtNoOfInstallment.Text == "")
        {
            msg = "Please  enter no. of installments...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            val = false;
            txtNoOfInstallment.Focus();
        }
        else if (dt_BOD.Text != "")
        {
            try
            {
                string Date = "";
                Date = Convert.ToDateTime(dt_BOD.Text).ToString("dd/MM/yyyy");
            }
            catch (Exception eee)
            {
                msg = "Enter Valid Date";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                val = false;
                dt_BOD.Focus();
            }
        }
        return val;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Isvalid())
            {
                btnSave.Enabled = false;
                if (Session["AdmissionId"] == null)
                {
                    if (role.Insert.Value)
                    {
                        //if (!chkAdmissionNo.Checked)
                        //{
                        //    //GenerateAddNo();
                        //    GenerateAddNoByAdmisionDate();
                        //}
                        //else
                        //{
                        //    string Adn = "", str = "", str1 = "";
                        //    Adn = txtAdmissionNo.Text;

                        //    str = Adn.Substring(4);
                        //    int Count = 0;
                        //    string serial = "";
                        //    Count = str.Length;
                        //    for (int i = 0; i <= Count; i++)
                        //    {
                        //        if (i != Count)
                        //        {
                        //            str1 = str.Substring(i, 1);
                        //            if (str1 != "0")
                        //            {
                        //                serial = str.Substring(i);
                        //                Session["serial"] = serial;
                        //                break;
                        //            }
                        //        }
                        //    }
                        //}
                        GenerateAddNoByAdmisionDate();
                        IEnumerable<Addmision> Addmisions = from id in obj.Addmisions
                                                            where id.AdmissionNo == txtAdmissionNo.Text
                                                            && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                            select id;
                        if (Addmisions.Count<Addmision>() <= 0)
                        {
                            if (Session["AdmissionNo"] != null)
                            {
                                if (obj.SP_Enquiry(3, Convert.ToInt32(Session["AdmissionNo"]), 0, "", "", "", "", "", "", "",
                                "", Convert.ToDateTime(dtAdmissionDate.Text), Convert.ToDateTime(dtAdmissionDate.Text), "", "", "", 0, Convert.ToInt32(Session["CompanyId"]), "", "", Convert.ToInt32(Session["SessionId"])) == 0)
                                {
                                }
                            }
                            if (Session["FrormRegistrationId"] != null)
                            {
                                if (obj.Sp_RegistrationForm(4, Convert.ToInt32(Session["FrormRegistrationId"]), Session["AdmissionNo"] != null ? Convert.ToInt32(Session["AdmissionNo"]) : 0, Convert.ToInt32(Session["serial"].ToString()), txtFormNo.Text, "", txtFatherName.Text, ddl_Course.SelectedItem.Text, txtAddress.Text, "", Convert.ToDateTime(System.DateTime.Now), 0, "", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                                {
                                }
                            }
                            string status = "";
                            if (ddlStatus.SelectedItem.Text.ToUpper() == "GOVT. SCHEME")
                            {
                                status = "ACTIVE RTE";
                            }
                            else
                            {
                                status = ddlStatus.SelectedItem.Text;
                            }
                            if (obj.SP_Addmision(1, 0, Convert.ToInt32(Session["serial"]), txtAdmissionNo.Text, txtVillage.Text, Convert.ToDateTime(dtAdmissionDate.Text), ddlSession.SelectedItem.Text, txtStudent.Text, txtContact.Text, txtFatherName.Text, txtMother.Text, txtParentContact.Text,
                                dt_BOD.Text, ddlSection.SelectedItem.Text, txtEmailId.Text, "", ddlGender.SelectedItem.Text, ddl_Catrgory.SelectedItem.Text, ddl_Religion.SelectedItem.Text, txtAddress.Text, txtAadharCardNo.Text,
                                Img1.ImageUrl != null ? Img1.ImageUrl : "", ddl_Nationality.SelectedItem.Text, txtPreviousSchool.Text, ddl_Course.SelectedItem.Text, Convert.ToDecimal(txtFees.Text), dd_DiscountType.SelectedItem.Text,
                                txtDiscount.Text != "" ? Convert.ToDecimal(txtDiscount.Text) : 0, Convert.ToDecimal(txtFeesAfterDisc.Text), txtFeesRemarks.Text, ChkTransport.Checked ? txtFrom.Text : "", ChkTransport.Checked ? ddlTo.SelectedItem.Text : "", ChkTransport.Checked ? Convert.ToDecimal(txtTransportFees.Text) : 0, ChkTransport.Checked ? ddlTransportDiscType.SelectedItem.Text : "",
                                 ChkTransport.Checked ? txtTransportDisc.Text != "" ? Convert.ToDecimal(txtTransportDisc.Text) : 0 : 0, ChkTransport.Checked ? Convert.ToDecimal(txtTransportFeesAfterDisc.Text) : 0, ChkTransport.Checked ? txtTransportRemarks.Text : "", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), ddlPaymentType.SelectedItem.Text, ddlPaymentType.SelectedItem.Text == "Installment" ? Convert.ToInt32(txtNoOfInstallment.Text) : 0,
                                 txtFatherOccupation.Text, txtMotherOccupation.Text, txtSamegraId.Text, txtFamilyId.Text, txtAccountNumber1.Text, txtIFSCcode1.Text, txtBranchName1.Text, txtAccountNumber2.Text, txtIFSCcode2.Text, txtBranchName2.Text, Convert.ToInt32(Session["SessionId"]), ddl_PreviousClass.SelectedItem.Text, ddl_PreviousClass.SelectedIndex != 0 ? txtPCP.Text : "0", Convert.ToInt32(ddl_Course.SelectedValue), ddlNoOfChildInFamily.SelectedItem.Text, ddlNoOfBrothers.SelectedItem.Text,
                                 ddlNoOfSisters.SelectedItem.Text, txtAnualIncome.Text != "" ? Convert.ToDecimal(txtAnualIncome.Text) : 0, txtAge.Text, txtBloodGroup.Text, txtHeight.Text, ddlStream.SelectedItem.Text, txtTotalFees.Text != "" ? Convert.ToDecimal(txtTotalFees.Text) : 0, ddlAdmittedClass.SelectedIndex != 0 ? ddlAdmittedClass.SelectedItem.Text : ddl_Course.SelectedItem.Text,
                                 status, txtFormNo.Text, txtTcIssueDate.Text.Trim(), "", txtBankName1.Text, txtBankName2.Text
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClass1.SelectedValue) ? 0 : Convert.ToInt32(ddlClass1.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentName1.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentName1.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClass2.SelectedValue) ? 0 : Convert.ToInt32(ddlClass2.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentName2.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentName2.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClass3.SelectedValue) ? 0 : Convert.ToInt32(ddlClass3.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentName3.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentName3.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClassOther1.SelectedValue) ? 0 : Convert.ToInt32(ddlClassOther1.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentNameOther1.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentNameOther1.SelectedValue))
                                 , txtRelation1.Text, txtRelation2.Text, txtRelation3.Text, txtRelationOther1.Text, ddlStudentComingFrom.SelectedItem.Text, ddlStudentComingFrom.SelectedIndex != 0 ? Convert.ToInt32(ddlTrasportType.SelectedValue) : Convert.ToInt32(ddlTo.SelectedValue), dtPMADate.Text,txtFees.Text!=txtFeesAfterDisc.Text  ? 1 : 0,"") == 0)
                            {
                                msg = "Record inserted successfully...";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                if (ddlPaymentType.SelectedItem.Text == "Installment")
                                {
                                    var DATA = (from Cons in obj.Addmisions
                                                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                select Cons.AdmissionId).Max();

                                    int admId = Convert.ToInt32(DATA);
                                    decimal Course = 0, Transport = 0;
                                    try
                                    {
                                        if (ddlStatus.SelectedItem.Text == "ACTIVE BPL" || ddlStatus.SelectedItem.Text == "ACTIVE RTE")
                                        {
                                            Course = 0;
                                        }
                                        else
                                        {
                                            Course = (Convert.ToDecimal(txtFees.Text) / Convert.ToInt32(txtNoOfInstallment.Text));
                                        }
                                        if (ChkTransport.Checked)
                                        {
                                            Transport = (Convert.ToDecimal(txtTransportFeesAfterDisc.Text) / Convert.ToInt32(txtNoOfInstallment.Text));
                                        }
                                        else
                                        {
                                            Transport = 0;
                                        }
                                    }
                                    catch (Exception ex) { }
                                    string str = "", year = "";
                                    str = ddlSession.SelectedItem.Text;
                                    year = str.Substring(0, 4);
                                    DateTime date = Convert.ToDateTime("01/04/" + year);
                                    for (int i = 1; i <= Convert.ToInt32(txtNoOfInstallment.Text); i++)
                                    {
                                        obj.Sp_Installments(1, 0, admId, Course,Transport, Convert.ToDateTime(date), 0, 0, Course,Transport,  "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 2)
                                            date = date.AddMonths(5);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 3)
                                            date = date.AddMonths(3);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 4)
                                            date = date.AddDays(80);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 5)
                                            date = date.AddDays(65);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 6)
                                            date = date.AddDays(55);
                                    }
                                }
                                else if (ddlPaymentType.SelectedItem.Text == "Monthly")
                                {
                                    var DATA = (from Cons in obj.Addmisions
                                                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                select Cons.AdmissionId).Max();

                                    int admId = Convert.ToInt32(DATA);

                                    decimal Course = 0, Transport = 0;
                                    if (ddlStatus.SelectedItem.Text == "ACTIVE BPL" || ddlStatus.SelectedItem.Text == "ACTIVE RTE")
                                    {
                                        Course = 0;
                                    }
                                    else
                                    {
                                        Course = (Convert.ToDecimal(txtFees.Text) / 12);
                                    }
                                    if (ChkTransport.Checked)
                                    {
                                        Transport = (Convert.ToDecimal(txtTransportFeesAfterDisc.Text) / 12);
                                    }
                                    else
                                    {
                                        Transport = 0;
                                    }
                                    string str = "", year = "";
                                    str = ddlSession.SelectedItem.Text;
                                    year = str.Substring(0, 4);
                                    DateTime date = Convert.ToDateTime("01/04/" + year);
                                    int Month = Convert.ToInt32(date.Month.ToString());
                                    for (int i = 1; i <= 12; i++)
                                    {
                                            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
                                            obj.Sp_MonthlyInstallments(1, 0, admId, monthName, Course, Transport, Convert.ToDateTime(date), 0, 0, Course, Transport, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                      
                                        date = date.AddDays(31);
                                        Month = Month + 1;
                                        if (Month > 12)
                                            Month = 1;
                                    }
                                }
                                Clear();
                                //GenerateAddNoByAdmisionDate();
                            }
                        }
                        else
                        {
                            msg = "Admission number is already exist...";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            if (!chkAdmissionNo.Checked)
                            {
                                //GenerateAddNo();
                                GenerateAddNoByAdmisionDate();
                            }
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else if (Session["AdmissionId"] != null)
                {
                    if (role.Update.Value)
                    {
                        string status = "";
                        if (ddlStatus.SelectedItem.Text.ToUpper() == "GOVT. SCHEME")
                        {
                            status = "ACTIVE RTE";
                        }
                        else
                        {
                            status = ddlStatus.SelectedItem.Text;
                        }
                        if (obj.SP_Addmision(2, Convert.ToInt32(Session["AdmissionId"]), Convert.ToInt32(Session["serial"]), txtAdmissionNo.Text, txtVillage.Text, Convert.ToDateTime(dtAdmissionDate.Text), ddlSession.SelectedItem.Text, txtStudent.Text, txtContact.Text, txtFatherName.Text, txtMother.Text, txtParentContact.Text,
                                dt_BOD.Text, ddlSection.SelectedItem.Text, txtEmailId.Text, "", ddlGender.SelectedItem.Text, ddl_Catrgory.SelectedItem.Text, ddl_Religion.SelectedItem.Text, txtAddress.Text, txtAadharCardNo.Text,
                                Img1.ImageUrl != null ? Img1.ImageUrl : "", ddl_Nationality.SelectedItem.Text, txtPreviousSchool.Text, ddl_Course.SelectedItem.Text, Convert.ToDecimal(txtFees.Text), dd_DiscountType.SelectedItem.Text,
                                 txtDiscount.Text != "" ? Convert.ToDecimal(txtDiscount.Text) : 0, Convert.ToDecimal(txtFeesAfterDisc.Text), txtFeesRemarks.Text, ChkTransport.Checked ? txtFrom.Text : "", ChkTransport.Checked ? ddlTo.SelectedItem.Text : "", ChkTransport.Checked ? Convert.ToDecimal(txtTransportFees.Text) : 0, ChkTransport.Checked ? ddlTransportDiscType.SelectedItem.Text : "",
                                 ChkTransport.Checked ? txtTransportDisc.Text != "" ? Convert.ToDecimal(txtTransportDisc.Text) : 0 : 0, ChkTransport.Checked ? Convert.ToDecimal(txtTransportFeesAfterDisc.Text) : 0, ChkTransport.Checked ? txtTransportRemarks.Text : "", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), ddlPaymentType.SelectedItem.Text, ddlPaymentType.SelectedItem.Text == "Installment" ? Convert.ToInt32(txtNoOfInstallment.Text) : 0,
                                 txtFatherOccupation.Text, txtMotherOccupation.Text, txtSamegraId.Text, txtFamilyId.Text, txtAccountNumber1.Text, txtIFSCcode1.Text, txtBranchName1.Text, txtAccountNumber2.Text, txtIFSCcode2.Text, txtBranchName2.Text, Convert.ToInt32(Session["SessionId"]), ddl_PreviousClass.SelectedItem.Text, ddl_PreviousClass.SelectedIndex != 0 ? txtPCP.Text : "0", Convert.ToInt32(ddl_Course.SelectedValue), ddlNoOfChildInFamily.SelectedItem.Text, ddlNoOfBrothers.SelectedItem.Text,
                                 ddlNoOfSisters.SelectedItem.Text, txtAnualIncome.Text != "" ? Convert.ToDecimal(txtAnualIncome.Text) : 0, txtAge.Text, txtBloodGroup.Text, txtHeight.Text, ddlStream.SelectedItem.Text, txtTotalFees.Text != "" ? Convert.ToDecimal(txtTotalFees.Text) : 0, ddlAdmittedClass.SelectedIndex != 0 ? ddlAdmittedClass.SelectedItem.Text : ddl_Course.SelectedItem.Text,
                                 status, txtFormNo.Text, txtTcIssueDate.Text.Trim(), "", txtBankName1.Text, txtBankName2.Text
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClass1.SelectedValue) ? 0 : Convert.ToInt32(ddlClass1.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentName1.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentName1.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClass2.SelectedValue) ? 0 : Convert.ToInt32(ddlClass2.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentName2.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentName2.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClass3.SelectedValue) ? 0 : Convert.ToInt32(ddlClass3.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentName3.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentName3.SelectedValue))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlClassOther1.SelectedValue) ? 0 : Convert.ToInt32(Convert.ToInt32(ddlClassOther1.SelectedValue)))
                                 , Convert.ToInt32(string.IsNullOrEmpty(ddlStudentNameOther1.SelectedValue) ? 0 : Convert.ToInt32(ddlStudentNameOther1.SelectedValue)),
                                 txtRelation1.Text, txtRelation2.Text, txtRelation3.Text, txtRelationOther1.Text, ddlStudentComingFrom.SelectedItem.Text, ddlStudentComingFrom.SelectedIndex != 0 ? Convert.ToInt32(ddlTrasportType.SelectedValue) : Convert.ToInt32(ddlTo.SelectedValue), dtPMADate.Text,txtFees.Text != txtFeesAfterDisc.Text ? 1 : 0,""
                                 ) == 0)
                        {
                            var D = (from Cons in obj.Payments
                                     where Cons.AdmissionId == Convert.ToInt32(Session["AdmissionId"]) && Cons.Remove == false && Cons.ComapanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                     select Cons.PaymentId).Count();
                            //msg = "Record updated successfully...";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            if (D == 0)
                            {
                                msg = "Record updated successfully...";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                if (ddlPaymentType.SelectedItem.Text == "Installment")
                                {
                                    int admId = Convert.ToInt32(Session["AdmissionId"]);
                                    try
                                    {
                                        obj.Sp_MonthlyInstallments(3, 0, admId, "", 0, 0, Convert.ToDateTime(dtAdmissionDate.Text), 0, 0, 0, 0, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                        obj.Sp_Installments(3, 0, admId, 0, 0, Convert.ToDateTime(dtAdmissionDate.Text), 0, 0, 0, 0, "BALANCE", 0, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                    }
                                    catch (Exception ex)
                                    { }

                                    decimal Course = 0, Transport = 0;
                                    try
                                    {
                                        if (ddlStatus.SelectedItem.Text == "ACTIVE RTE" || ddlStatus.SelectedItem.Text == "ACTIVE BPL")
                                        {
                                            Course = 0;
                                        }
                                        else
                                        {
                                            Course = (Convert.ToDecimal(txtFees.Text) / Convert.ToInt32(txtNoOfInstallment.Text));
                                        }
                                        if (ChkTransport.Checked)
                                        {
                                            Transport = (Convert.ToDecimal(txtTransportFeesAfterDisc.Text) / Convert.ToInt32(txtNoOfInstallment.Text));
                                        }
                                        else
                                        {
                                            Transport = 0;
                                        }
                                    }
                                    catch (Exception ex) { }
                                    string str = "", year = "";
                                    str = ddlSession.SelectedItem.Text;
                                    year = str.Substring(0, 4);
                                    DateTime date = Convert.ToDateTime("01/04/" + year);
                                    obj.Sp_Installments(3, 0, admId, Course, Transport, Convert.ToDateTime(dtAdmissionDate.Text), 0, 0, Course, Transport, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                    for (int i = 1; i <= Convert.ToInt32(txtNoOfInstallment.Text); i++)
                                    {
                                        obj.Sp_Installments(1, 0, admId, Course, Transport, Convert.ToDateTime(date), 0, 0, Course, Transport, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 2)
                                            date = date.AddMonths(5);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 3)
                                            date = date.AddMonths(3);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 4)
                                            date = date.AddDays(80);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 5)
                                            date = date.AddDays(65);
                                        if (Convert.ToInt32(txtNoOfInstallment.Text) == 6)
                                            date = date.AddDays(55);
                                    }
                                }
                                else if (ddlPaymentType.SelectedItem.Text == "Monthly")
                                {
                                    int admId = Convert.ToInt32(Session["AdmissionId"]);
                                    try
                                    {
                                        obj.Sp_Installments(3, 0, admId, 0, 0, Convert.ToDateTime(dtAdmissionDate.Text), 0, 0, 0, 0, "BALANCE", 0, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                        obj.Sp_MonthlyInstallments(3, 0, admId, "", 0, 0, Convert.ToDateTime(dtAdmissionDate.Text), 0, 0, 0, 0, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                    }
                                    catch (Exception ex)
                                    { }

                                    decimal Course = 0, Transport = 0;
                                    if (ddlStatus.SelectedItem.Text == "ACTIVE BPL" || ddlStatus.SelectedItem.Text == "ACTIVE RTE")
                                    {
                                        Course = 0;
                                    }
                                    else
                                    {
                                        Course = (Convert.ToDecimal(txtFees.Text) / 12);
                                    }
                                    if (ChkTransport.Checked)
                                    {
                                        Transport = (Convert.ToDecimal(txtTransportFeesAfterDisc.Text) / 12);
                                    }
                                    else
                                    {
                                        Transport = 0;
                                    }
                                    string str = "", year = "";
                                    str = ddlSession.SelectedItem.Text;
                                    year = str.Substring(0, 4);
                                    DateTime date = Convert.ToDateTime("01/04/" + year);
                                    int Month = Convert.ToInt32(date.Month.ToString());
                                    for (int i = 1; i <= 12; i++)
                                    {
                                        string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
                                        obj.Sp_MonthlyInstallments(1, 0, admId, monthName, Math.Round(Course, 0), Math.Round(Transport, 0), Convert.ToDateTime(date), 0, 0, Math.Round(Course, 0), Math.Round(Transport, 0), "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));

                                        date = date.AddDays(31);
                                        Month = Month + 1;
                                        if (Month > 12)
                                            Month = 1;
                                    }

                                }
                            }
                            else
                            {
                                //decimal Transport = 0;
                                //if (ChkTransport.Checked)
                                //{
                                //    IEnumerable<Installment> AdmissionIds = from i in obj.Installments
                                //                                            where i.AdmissionId == Convert.ToInt32(Session["AdmissionId"]) && i.PaymentStatus == "BALANCE" && i.TransportFees == 0
                                //                                            && i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                                //                                            select i;
                                //    if (AdmissionIds.Count<Installment>() > 0)
                                //    {
                                //        ddlAddmisionIds.DataSource = AdmissionIds;
                                //        ddlAddmisionIds.DataTextField = "InstallmentId";
                                //        ddlAddmisionIds.DataValueField = "InstallmentId";
                                //        ddlAddmisionIds.DataBind();
                                //    }
                                //    IEnumerable<MonthlyInstallment> AdmissionIds1 = from i in obj.MonthlyInstallments
                                //                                                    where i.AdmissionId == Convert.ToInt32(Session["AdmissionId"]) && i.PaymentStatus == "BALANCE" && i.TransportFees == 0
                                //                                                    && i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                                //                                                    select i;
                                //    if (AdmissionIds1.Count<MonthlyInstallment>() > 0)
                                //    {
                                //        ddlAddmisionIds.DataSource = AdmissionIds1;
                                //        ddlAddmisionIds.DataTextField = "MonthlyInstId";
                                //        ddlAddmisionIds.DataValueField = "MonthlyInstId";
                                //        ddlAddmisionIds.DataBind();
                                //    }
                                //    if (AdmissionIds.Count<Installment>() > 0)
                                //    {
                                //        if (ddlAddmisionIds.Items.Count > 0)
                                //        {
                                //            Transport = (Convert.ToDecimal(txtTransportFeesAfterDisc.Text) / Convert.ToInt32(ddlAddmisionIds.Items.Count));
                                //            for (int i = 0; i < ddlAddmisionIds.Items.Count; i++)
                                //            {
                                //                obj.Sp_Installments(2, Convert.ToInt32(ddlAddmisionIds.Items[i].ToString()), 0, 0, Transport, Convert.ToDateTime(System.DateTime.Now), 0, 0, 0, Transport, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                //            }
                                //        }
                                //    }
                                //    else if (AdmissionIds1.Count<MonthlyInstallment>() > 0)
                                //    {
                                //        if (ddlAddmisionIds.Items.Count > 0)
                                //        {
                                //            Transport = (Convert.ToDecimal(txtTransportFeesAfterDisc.Text) / Convert.ToInt32(ddlAddmisionIds.Items.Count));
                                //            for (int i = 0; i < ddlAddmisionIds.Items.Count; i++)
                                //            {
                                //                obj.Sp_MonthlyInstallments(2, Convert.ToInt32(ddlAddmisionIds.Items[i].ToString()), 0, "", 0, Transport, Convert.ToDateTime(System.DateTime.Now), 0, 0, 0, Transport, "BALANCE", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                //            }
                                //        }
                                //    }
                                //}
                                msg = "Admission information updated...";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            }
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
    protected void GridAdmission_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                int id = Convert.ToInt32(GridAdmission.DataKeys[e.NewSelectedIndex].Value);
                Session["AdmissionId"] = GridAdmission.DataKeys[e.NewSelectedIndex].Value;
                Session["AdmissionNo"] = null;
                Response.Redirect(Request.RawUrl);
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void GridStudentCourse_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                int id = Convert.ToInt32(GridStudentCourse.DataKeys[e.NewSelectedIndex].Value);
                Session["AdmissionId"] = GridStudentCourse.DataKeys[e.NewSelectedIndex].Value;
                Session["AdmissionNo"] = null;
                Response.Redirect(Request.RawUrl);
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
            chkOtherInformation.Checked = true;
            DivOtherInformation.Visible = true;
            chkBank1.Checked = true;
            Bank1.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }

    private void Clear()
    {
        txtDiscount.Enabled = true;
        txtTotalFees.Text = "0";
        ddl_Course.ClearSelection();
        txtFees.Text = "";
        ddlPaymentType.ClearSelection();
        dtPMADate.Text = "";
        Session["AdmissionId"] = null;
        Session["AdmissionNo"] = null;
        txtAdmissionNo.Text = string.Empty;
        txtVillage.Text = "";
        dtAdmissionDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        txtStudent.Text = string.Empty;
        txtContact.Text = "";
        txtFatherName.Text = "";
        txtFatherOccupation.Text = "";
        txtMotherOccupation.Text = "House Wife";
        txtMother.Text = "";
        txtParentContact.Text = "";
        dt_BOD.Text = "";
        ddlSection.ClearSelection();
        txtEmailId.Text = "";
        ddlAdmittedClass.SelectedIndex = 0;
        ddlGender.SelectedIndex = 0;
        ddl_Catrgory.SelectedIndex = 0;
        ddl_Religion.SelectedIndex = 0;
        txtAddress.Text = "";
        Session["AddImgPath"] = null;
        Img1.ImageUrl = "~/images/male.png";
        txtAadharCardNo.Text = "";
        ddlStatus.SelectedIndex = 1;
        ddl_Nationality.SelectedIndex = 1;
        ddl_PreviousClass.SelectedIndex = 0;
        divPCP.Visible = false;
        divPreviousSchool.Visible = false;
        txtPCP.Text = string.Empty;
        txtPreviousSchool.Text = string.Empty;
        chkBank1.Checked = false;
        Bank1.Visible = false;
        txtAccountNumber1.Text = "";
        txtIFSCcode1.Text = "";
        txtBranchName1.Text = "";
        chkBank2.Checked = false;
        Bank2.Visible = false;
        txtAccountNumber2.Text = "";
        txtIFSCcode2.Text = "";
        txtBranchName2.Text = "";
        ddl_Course.SelectedIndex = 0;
        ddlPaymentType.SelectedIndex = 0;
        txtNoOfInstallment.Text = "";
        Install.Visible = false;
        txtFees.Text = "";
        dd_DiscountType.SelectedIndex = 0;
        txtDiscount.Text = "";
        txtFeesAfterDisc.Text = "";
        txtFeesRemarks.Text = "";
        txtSamegraId.Text = "";
        txtFamilyId.Text = "";
        Session["serial"] = null;
        txtFrom.Text = "";
        ddlTo.SelectedItem.Text = "";
        txtTransportFees.Text = "";
        ddlTransportDiscType.SelectedIndex = 0;
        txtTransportDisc.Text = "";
        txtTransportFeesAfterDisc.Text = "";
        txtTransportRemarks.Text = "";
        txtNoOfInstallment.Enabled = true;
        ddlPaymentType.Enabled = true;
        ChkTransport.Checked = false;
        TrasportId.Visible = false;
        lblDoc.Visible = false;

        chkOtherInformation.Checked = false;
        DivOtherInformation.Visible = false;
        ddlNoOfChildInFamily.SelectedIndex = 0;
        ddlNoOfBrothers.SelectedIndex = 0;
        ddlNoOfSisters.SelectedIndex = 0;
        txtBloodGroup.Text = "";
        txtAnualIncome.Text = "";
        txtHeight.Text = "";
        txtAge.Text = "";
        txtTotalFees.Text = "";
        ddlStream.SelectedIndex = 0;
        ddlTo.ClearSelection();
        TrasportType.Visible = false;
        ChkTransport.Visible = false;
        ddlStudentComingFrom.SelectedIndex = 1;

        try
        {
            ddlStudentComingFrom_SelectedIndexChanged(null, null);
        }
        catch (Exception ex) { }
        btnSave.Enabled = true;
        txtAdmissionNo.Enabled = false;
        chkAdmissionNo.Checked = false;
        AdmittedClass.Visible = false;
        try
        {
            BindDataGrid();
            BindCourseGrid();
        }
        catch (Exception ex) { }
        //Session.Abandon();
        TC.Visible = false;
        txtTcIssueDate.Text = "";
        Session["APStudentName"] = null;
        Session["APContactNo"] = null;
        Session["APAdminssionNo"] = null;
        Session["APdtSDate"] = null;
        Session["APdtEDate"] = null;
        Session["ASearchCourse"] = null;
        ddlAddmisionIds.Items.Clear();
        ddlClass1.ClearSelection();
        ddlClass2.ClearSelection();
        ddlClass3.ClearSelection();
        ddlClassOther1.ClearSelection();
        ddlStudentName1.ClearSelection();
        ddlStudentName2.ClearSelection();
        ddlStudentName3.ClearSelection();
        ddlStudentNameOther1.ClearSelection();
        txtRelation1.Text = "";
        txtRelation2.Text = "";
        txtRelation3.Text = "";
        txtRelationOther1.Text = "";
        try
        {
            var B = from Cons in obj.BusTransports
                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                select Cons;
        ddlTo.DataSource = B;
        ddlTo.DataTextField = "To";
        ddlTo.DataValueField = "TransportId";
        ddlTo.DataBind();
        ddlTo.Items.Insert(0, new ListItem());
        CheckHideShowStudentCommingFrom();
        //Response.Redirect(Request.RawUrl);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnSearchDetails_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                BindDataGrid();
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void btnCourseSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                BindCourseGrid();
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPaymentType.SelectedItem.Text != "--Select--" && ddlPaymentType.SelectedItem.Text != "Monthly")
            {
                if (ddlPaymentType.SelectedItem.Text == "Installment")
                {
                    Install.Visible = true;
                    txtNoOfInstallment.Focus();
                }
            }
            else
            {
                Install.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlStudentComingFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStudentComingFrom.SelectedIndex == 0)
            {
                TrasportType.Visible = false;
                ChkTransport.Checked = true;
                ChkTransport_CheckedChanged(null, null);
            }
            else if (ddlStudentComingFrom.SelectedIndex == 1)
            {
                LabelTrasportType = "Self Transport Type";
                TrasportType.Visible = true;
                ChkTransport.Checked = false;
                ChkTransport_CheckedChanged(null, null);
                FillDropdown.FillSELFTRANSPORT(ddlTrasportType, Convert.ToInt32(Session["CompanyId"].ToString()));
                ddlTrasportType.SelectedIndex = 1;
            }
            else if (ddlStudentComingFrom.SelectedIndex == 2)
            {
                LabelTrasportType = "Public Transport Type";
                TrasportType.Visible = true;
                ChkTransport.Checked = false;
                ChkTransport_CheckedChanged(null, null);
                FillDropdown.FillPUBLICTRANSPORT(ddlTrasportType, Convert.ToInt32(Session["CompanyId"].ToString()));
            }
        }
        catch (Exception ex)
        { }
    }
    protected void lblDoc_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                //Response.Redirect("DocumentUpload.aspx");
                string URL = "javascript:window.open('DocumentUpload.aspx')";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Visibility", "Visibility();", true);
            if (role.Select.Value)
            {
                if (ddl_Search.Text == "By Student")
                {
                    Session["APStudentName"] = txtSearchByStudentName.Text;
                    Session["APContactNo"] = "";
                    Session["APAdminssionNo"] = "";
                    Session["APdtSDate"] = "";
                    Session["APdtEDate"] = "";
                }
                else if (ddl_Search.Text == "By Adimission No")
                {
                    Session["APStudentName"] = "";
                    Session["APContactNo"] = "";
                    Session["APAdminssionNo"] = txtSearchByAdimissionNo.Text;
                    Session["APdtSDate"] = "";
                    Session["APdtEDate"] = "";
                }
                else if (ddl_Search.Text == "By Contact No")
                {
                    Session["APStudentName"] = "";
                    Session["APContactNo"] = txtSearchByContact.Text;
                    Session["APAdminssionNo"] = "";
                    Session["APdtSDate"] = "";
                    Session["APdtEDate"] = "";
                }
                else if (ddl_Search.Text == "By Date")
                {
                    Session["APStudentName"] = "";
                    Session["APContactNo"] = "";
                    Session["APAdminssionNo"] = "";
                    Session["APdtSDate"] = dtSDate.Text;
                    Session["APdtEDate"] = dtEDate.Text;
                }
                string URL = "javascript:window.open('AdmissionPrint.aspx')";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void btnCoursePrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                if (txtSearch.Text != "")
                {
                    Session["ASearchCourse"] = txtSearch.Text;
                }
                else
                {
                    Session["ASearchCourse"] = "";

                }
                string URL = "javascript:window.open('CoursePrint.aspx')";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }

    protected void chkBank1_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkBank1.Checked)
            {
                Bank1.Visible = true;
                txtBankName1.Focus();
            }
            else
            {
                Bank1.Visible = false;
            }

        }
        catch (Exception ex)
        { }
    }
    protected void chkBank2_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkBank2.Checked)
            {
                Bank2.Visible = true;
                txtBankName2.Focus();
            }
            else
            {
                Bank2.Visible = false;
            }

        }
        catch (Exception ex)
        { }
    }
    protected void GridAdmission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridAdmission.PageIndex = e.NewPageIndex;
            BindDataGrid();
            GridAdmission.DataBind();
            DropDownList ddlStatus =
       (DropDownList)GridAdmission.HeaderRow.FindControl("ddlStatus");
            BindStatus(ddlStatus);
        }
        catch (Exception ex)
        { }
    }
    protected void GridStudentCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridStudentCourse.PageIndex = e.NewPageIndex;
            BindCourseGrid();
            GridStudentCourse.DataBind();
            DropDownList ddlCourseName =
  (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseName");
            BindCouseName(ddlCourseName);

            DropDownList ddlCourseStatus1 =
    (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseStatus");
            BindCourseStatus(ddlCourseStatus1);
        }
        catch (Exception ex) { }
    }
    protected void ddl_PreviousClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_PreviousClass.SelectedIndex != 0)
            {
                divPCP.Visible = true;
                divPreviousSchool.Visible = true;
                txtPCP.Focus();
            }
            else
            {
                divPCP.Visible = false;
                divPreviousSchool.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void chkOtherInformation_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkOtherInformation.Checked)
            {
                DivOtherInformation.Visible = true;
            }
            else
            {
                DivOtherInformation.Visible = false;
            }

        }
        catch (Exception ex)
        { }
    }

    protected void dt_BOD_TextChanged(object sender, EventArgs e)
    {
        try
        {
                if (Convert.ToDateTime(dt_BOD.Text) <= System.DateTime.Now)
                {
                    GetAge();
                }
                else
                {
                    Globals.Message(Page, "You are not able to select this date...");
                    dt_BOD.Text = DateTime.Today.ToString("dd/MM/yyyy");
                }
        }
        catch (Exception ex)
        { }
    }
    protected void chkAdmissionNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAdmissionNo.Checked)
            {
                txtAdmissionNo.Enabled = true;
                txtAdmissionNo.Focus();
            }
            else
            {
                txtAdmissionNo.Enabled = false;
                dtAdmissionDate.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void dtAdmissionDate_TextChanged(object sender, EventArgs e)
    {
        GenerateAddNoByAdmisionDate();
        try
        {
            try
            {
                ddl_Course_SelectedIndexChanged(null, null);
                DisCountCourseFees();
            }
            catch (Exception ex)
            { }
            string str = "", year = "";
            str = ddlSession.SelectedItem.Text;
            year = str.Substring(0, 4);
            string str1 = Convert.ToDateTime(dtAdmissionDate.Text).Year.ToString();
            if (year != str1)
            {
                AdmittedClass.Visible = true;
            }
            else
            {
                AdmittedClass.Visible = false;
            }
        }
        catch (Exception ex) { }
    }


    protected void StatusChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlStatus = (DropDownList)sender;
            ViewState["AdmStatus"] = ddlStatus.SelectedValue;
            Session["AdmStatus"] = ddlStatus.SelectedValue;
            if (ddlStatus.SelectedIndex != 0)
            {
                var DATA1 = from Cons in obj.Addmisions
                            where Cons.R1 == ddlStatus.SelectedValue && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            orderby Cons.AdmissionId descending
                            select Cons;
                GridAdmission.DataSource = DATA1;
                GridAdmission.DataBind();
            }
            else
            {
                var DATA1 = from Cons in obj.Addmisions
                            where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            orderby Cons.AdmissionId descending
                            select Cons;
                GridAdmission.DataSource = DATA1;
                GridAdmission.DataBind();
            }
            DropDownList ddlStatus1 =
     (DropDownList)GridAdmission.HeaderRow.FindControl("ddlStatus");
            BindStatus(ddlStatus1);
        }
        catch (Exception ex)
        { }
    }

    protected void CourseNameChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlClassName = (DropDownList)sender;
            ViewState["ClassName"] = ddlClassName.SelectedValue;
            Session["ClassName"] = ddlClassName.SelectedValue;
            if (ddlClassName.SelectedIndex != 0)
            {
                if (ViewState["CourseStatus"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.CourseId == Convert.ToInt32(ddlClassName.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStudentCourse.DataSource = DATA1;
                    GridStudentCourse.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.CourseId == Convert.ToInt32(ddlClassName.SelectedValue) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStudentCourse.DataSource = DATA1;
                    GridStudentCourse.DataBind();
                }
            }
            else
            {
                if (ViewState["CourseStatus"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStudentCourse.DataSource = DATA1;
                    GridStudentCourse.DataBind();
                }
                else
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStudentCourse.DataSource = DATA1;
                    GridStudentCourse.DataBind();
                }
            }
            DropDownList ddlClassName1 =
     (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseName");
            BindCouseName(ddlClassName1);
            DropDownList ddlCourseStatus1 =
    (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseStatus");
            BindCourseStatus(ddlCourseStatus1);

            BindSection(ddlClassName);
            DropDownList ddlSection =
(DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlSection");
            ddlSection.SelectedIndex = 0;
        }
        catch (Exception ex)
        { }
    }

    private void BindSection(DropDownList ddlClassName)
    {
        DropDownList ddlSection =
(DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlSection");
        var DATA = (from Cons in obj.Addmisions
                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select new
                    {
                        Section = Cons.Section
                    })
               .ToList()
               .Distinct();
        ddlSection.DataSource = DATA;
        ddlSection.DataTextField = "Section";
        ddlSection.DataValueField = "Section";
        ddlSection.DataBind();
        ddlSection.Items.FindByValue(ViewState["ddlSection"].ToString())
            .Selected = true;
    }
    protected void SectionChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSection = (DropDownList)sender;
            ViewState["ddlSection"] = ddlSection.SelectedValue;
            Session["ddlSection"] = ddlSection.SelectedValue;
            if (ddlSection.SelectedIndex != 0)
            {
                if (ViewState["ClassName"].ToString() == "ALL")
                {
                    if (ViewState["CourseStatus"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                }
                else
                {
                    if (ViewState["CourseStatus"].ToString() == "ALL")
                    {

                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Section == ddlSection.SelectedValue && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Section == ddlSection.SelectedValue && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                }
            }
            else
            {
                if (ViewState["ClassName"].ToString() == "ALL")
                {
                    if (ViewState["CourseStatus"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                }
                else
                {
                    if (ViewState["CourseStatus"].ToString() == "ALL")
                    {

                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.R1 == ViewState["CourseStatus"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                }
            }
            DropDownList ddlClassName1 =
     (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseName");
            BindCouseName(ddlClassName1);
            DropDownList ddlCourseStatus1 =
    (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseStatus");
            BindCourseStatus(ddlCourseStatus1);

            DropDownList ddlSection1 =
   (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlSection");
            BindSection(ddlSection1);

        }
        catch (Exception ex)
        { }
    }
    protected void CourseStatusChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCourseStatus = (DropDownList)sender;

            ViewState["CourseStatus"] = ddlCourseStatus.SelectedValue;
            Session["CourseStatus"] = ddlCourseStatus.SelectedValue;
            if (ddlCourseStatus.SelectedIndex != 0)
            {
                if (ViewState["ClassName"].ToString() == "ALL")
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.R1 == ddlCourseStatus.SelectedValue && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStudentCourse.DataSource = DATA1;
                    GridStudentCourse.DataBind();
                }
                else
                {
                    if (ViewState["ddlSection"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.R1 == ddlCourseStatus.SelectedValue && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.R1 == ddlCourseStatus.SelectedValue && Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Section == ViewState["ddlSection"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                }
            }
            else
            {
                if (ViewState["ClassName"].ToString() != "ALL")
                {
                    if (ViewState["ddlSection"].ToString() == "ALL")
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.Addmisions
                                    where Cons.CourseId == Convert.ToInt32(ViewState["ClassName"]) && Cons.Section == ViewState["ddlSection"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        GridStudentCourse.DataSource = DATA1;
                        GridStudentCourse.DataBind();
                    }
                }
                else
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStudentCourse.DataSource = DATA1;
                    GridStudentCourse.DataBind();
                }
            }
            DropDownList ddlCourseStatus1 =
     (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseStatus");
            BindCourseStatus(ddlCourseStatus1);
            DropDownList ddlClassName1 =
    (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlCourseName");
            BindCouseName(ddlClassName1);

            DropDownList ddlSection1 =
 (DropDownList)GridStudentCourse.HeaderRow.FindControl("ddlSection");
            BindSection(ddlSection1);
        }
        catch (Exception ex)
        { }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedItem.Text == "TC ISSUED")
            {
                TC.Visible = true;
                txtTcIssueDate.Focus();
            }
            else
            {
                TC.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnCalAge_Click(object sender, EventArgs e)
    {
        try
        {
            Accordian.SelectedIndex = 0;
            if (Convert.ToDateTime(dt_BOD.Text) <= System.DateTime.Now)
            {

                GetAge();

            }
            else
            {
                Globals.Message(Page, "You are not able to select this date...");
                dt_BOD.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }
        catch (Exception ex)
        { }
    }

    public void getShivlings(string AdnNo, string StudentName)
    {
        int i = 1;
        if (AdnNo != "")
        {
            IEnumerable<Addmision> Addmision = from Cons in obj.Addmisions
                                               where Cons.AdmissionNo == AdnNo.ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;


            if (Addmision.First().FamilyId != "")
            {
                IEnumerable<Addmision> adm = from Cons in obj.Addmisions
                                             where Cons.FamilyId == Addmision.First().FamilyId && Cons.AdmissionNo != Addmision.First().AdmissionNo && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select Cons;
                foreach (Addmision Cd in adm.ToList<Addmision>())
                {
                    Label lbl = new Label();
                    lbl.Text = "Student Name:-" + Cd.StudentName + ", Class:-" + Cd.CourseName + "<br/>";
                    if (i == 1)
                    {
                        lbl.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (i == 3)
                    {
                        lbl.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (i == 4)
                    {
                        lbl.ForeColor = System.Drawing.Color.Brown;
                    }

                    lbl.Font.Bold = true;
                    PnlLabel.Controls.Add(lbl);
                    i++;
                }
            }
            else
            {
                IEnumerable<Addmision> adm = from Cons in obj.Addmisions
                                             where Cons.FatherName == Addmision.First().FatherName && Cons.MotherName == Addmision.First().MotherName && Cons.AdmissionNo != Addmision.First().AdmissionNo && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select Cons;
                foreach (Addmision Cd in adm.ToList<Addmision>())
                {
                    Label lbl = new Label();
                    lbl.Text = "Student Name:-" + Cd.StudentName + ", Class:-" + Cd.CourseName + "<br/>";
                    if (i == 1)
                    {
                        lbl.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (i == 3)
                    {
                        lbl.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (i == 4)
                    {
                        lbl.ForeColor = System.Drawing.Color.Brown;
                    }

                    lbl.Font.Bold = true;
                    PnlLabel.Controls.Add(lbl);
                    i++;
                }
            }
            if (i >= 2)
            {
                Accordian.SelectedIndex = 0;
            }
            else
            {
                Accordian.SelectedIndex = -1;
            }
        }
        else if (StudentName != "")
        {
            IEnumerable<Addmision> Addmision = from Cons in obj.Addmisions
                                               where Cons.StudentName == StudentName && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;


            if (Addmision.First().FamilyId != "")
            {
                IEnumerable<Addmision> adm = from Cons in obj.Addmisions
                                             where Cons.FamilyId == Addmision.First().FamilyId && Cons.AdmissionNo != Addmision.First().AdmissionNo && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select Cons;
                foreach (Addmision Cd in adm.ToList<Addmision>())
                {
                    Label lbl = new Label();
                    lbl.Text = "Student Name:-" + Cd.StudentName + ", Class:-" + Cd.CourseName + "<br/>";
                    if (i == 1)
                    {
                        lbl.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (i == 3)
                    {
                        lbl.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (i == 4)
                    {
                        lbl.ForeColor = System.Drawing.Color.Brown;
                    }
                    lbl.Font.Bold = true;
                    PnlLabel.Controls.Add(lbl);
                    i++;
                }
            }
            else
            {
                IEnumerable<Addmision> adm = from Cons in obj.Addmisions
                                             where Cons.FatherName == Addmision.First().FatherName && Cons.MotherName == Addmision.First().MotherName && Cons.AdmissionNo != Addmision.First().AdmissionNo && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                             select Cons;
                foreach (Addmision Cd in adm.ToList<Addmision>())
                {
                    Label lbl = new Label();
                    lbl.Text = "Student Name:-" + Cd.StudentName + ", Class:-" + Cd.CourseName + "<br/>";
                    if (i == 1)
                    {
                        lbl.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (i == 3)
                    {
                        lbl.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (i == 4)
                    {
                        lbl.ForeColor = System.Drawing.Color.Brown;
                    }
                    lbl.Font.Bold = true;
                    PnlLabel.Controls.Add(lbl);
                    i++;
                }
            }
            if (i >= 2)
            {
                Accordian.SelectedIndex = 0;
            }
            else
            {
                Accordian.SelectedIndex = -1;
            }
        }
    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlGender.SelectedIndex == 1)
            {
                Img1.ImageUrl = "~/images/male.png";
            }
            else if (ddlGender.SelectedIndex == 2)
            {
                Img1.ImageUrl = "~/images/female.png";
            }
            else
            {
                Img1.ImageUrl = "~/images/male.png";
            }
        }
        catch (Exception ex)
        { }
    }

    protected void ddl_Nationality_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClass1.ClearSelection();
        ddlClass2.ClearSelection();
        ddlClass3.ClearSelection();
        ddlClassOther1.ClearSelection();
        ddlStudentName1.Items.Clear();
        ddlStudentName2.Items.Clear();
        ddlStudentName3.Items.Clear();
        ddlStudentNameOther1.ClearSelection();
        txtRelationOther1.Text = "";
        txtRelation1.Text = "";
        txtRelation2.Text = "";
        txtRelation3.Text = "";
        if (ddl_Nationality.SelectedItem.Text == "SECOND")
        {
            trClass1.Visible = true;
            trClass2.Visible = false;
            trClass3.Visible = false;
            trOther1.Visible = false;
        }
        else if (ddl_Nationality.SelectedItem.Text == "THIRD")
        {
            trClass1.Visible = true;
            trClass2.Visible = true;
            trClass3.Visible = false;
            trOther1.Visible = false;
        }
        else if (ddl_Nationality.SelectedItem.Text == "OTHER")
        {
            trClass1.Visible = false;
            trClass2.Visible = false;
            trClass3.Visible = false;
            trOther1.Visible = true;
        }
        else
        {
            trClass1.Visible = false;
            trClass2.Visible = false;
            trClass3.Visible = false;
            trOther1.Visible = false;
        }
        try
        {
            ddl_Course_SelectedIndexChanged(null, null);
        }
        catch (Exception ex)
        { }
    }
    protected void ddlClass1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass1.SelectedIndex > 0)
        {
            FillDropdown.FillStudentNameByClass(ddlStudentName1, Convert.ToInt32(ddlClass1.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
        }
    }
    protected void ddlClass2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass2.SelectedIndex > 0)
        {
            FillDropdown.FillStudentNameByClass(ddlStudentName2, Convert.ToInt32(ddlClass2.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
        }
    }
    protected void ddlClassOther1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassOther1.SelectedIndex > 0)
        {
            FillDropdown.FillStudentNameByClass(ddlStudentNameOther1, Convert.ToInt32(ddlClassOther1.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
        }
    }
    protected void ddlClass3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass3.SelectedIndex > 0)
        {
            FillDropdown.FillStudentNameByClass(ddlStudentName3, Convert.ToInt32(ddlClass3.SelectedValue), Convert.ToInt32(Session["CompanyId"]));
        }
    }
    protected void txtAdmissionNo_TextChanged(object sender, EventArgs e)
    {
        GenerateAddNoByAdmisionDate();
    }
}