using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_TransferDataCurrentSessionToOtherSession : System.Web.UI.Page
{
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    LoginRole role = new LoginRole();
    public int SrNo = 0;
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
                    var DATA = from Cons in obj.Sessions
                               where Cons.Remove == false
                               select Cons;
                    ddlFromSession.DataSource = DATA;
                    ddlFromSession.DataTextField = "SessionName";
                    ddlFromSession.DataValueField = "Sessionid";
                    ddlFromSession.DataBind();
                    ddlFromSession.Items.Insert(0, "--Select--");

                    ddlTo.DataSource = DATA;
                    ddlTo.DataTextField = "SessionName";
                    ddlTo.DataValueField = "Sessionid";
                    ddlTo.DataBind();
                    ddlTo.Items.Insert(0, "--Select--");

                    var D = from Cons in obj.Courses
                            where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                    ddlClass.DataSource = D;
                    ddlClass.DataTextField = "CourseName";
                    ddlClass.DataValueField = "CourseId";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, "--Select--");
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
        }
        catch (Exception ex) { }
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (ddlFromSession.SelectedIndex != 0)
            {
                if (ddlTo.SelectedIndex != 0)
                {
                    if (ddlTansferType.SelectedIndex != 0)
                    {
                        if (ddlFromSession.SelectedValue != ddlTo.SelectedValue)
                        {
                            if (ddlTansferType.SelectedIndex == 1)
                            {
                                var Count = (from Cons in obj.Courses
                                             where Cons.CompanyId==Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlTo.SelectedValue.ToString())
                                                   select Cons).Count();
                                if (Count == 0)
                                {
                                    ClassTranfer();
                                }
                                else
                                {
                                    Globals.Message(Page, "Record already exisxt...");
                                }
                            }
                            if (ddlTansferType.SelectedIndex == 2)
                            {
                                if (ddlClass.SelectedIndex != 0)
                                {
                                    var Adm = (from Cons in obj.Addmisions
                                                 where Cons.CourseId==Convert.ToInt32(ddlClass.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlFromSession.SelectedValue.ToString())
                                                 select Cons).Count();
                                    if (Adm != 0)
                                    {
                                        StudentTransfer();
                                    }
                                    else
                                    {
                                        Globals.Message(Page, "Selected from do not have records");
                                        ddlClass.Focus();
                                    }
                                }
                                else
                                {
                                    Globals.Message(Page, "Please select class first...");
                                    ddlClass.Focus();
                                }
                            }
                        }
                        else
                        {
                            Globals.Message(Page, "From and To should not same...");
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Please select which types of records you wants to tranfer...");
                        ddlTansferType.Focus();
                    }
                }
                else
                {
                    Globals.Message(Page, "Please select To.");
                    ddlTo.Focus();
                }
            }
            else
            {
                Globals.Message(Page, "Please select from.");
                ddlFromSession.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlTansferType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTansferType.SelectedIndex == 2)
        {
            GridStudentWiseData.Visible = true;
            ClassId.Visible = true;
        }
        else
        {
            GridStudentWiseData.Visible = false;
            ClassId.Visible = false;
        }
    }
    protected void ddlClass_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedIndex > 0)
        {
            GridStudentWiseData.Visible = true;
            DataSet ds = AllMethods.GetStudentByClassForSessionUpdate(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlClass.SelectedValue));
            GridStudentWiseData.DataSource = ds;
            GridStudentWiseData.DataBind();
        }
        else
        {
            GridStudentWiseData.Visible = false;
        }
    }
    private void ClassTranfer()
    {
        try
        {
            int OldCourseId = 0, i = 0;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();

            ds = AllMethods.SelectFromClassData(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(ddlFromSession.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    i++;
                    OldCourseId = Convert.ToInt32(dr[0].ToString());
                    if (obj.Sp_Course(1, 0, Convert.ToInt32(dr[1].ToString()), dr[2].ToString(), Convert.ToDecimal(dr[3].ToString()), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToDecimal(dr[6].ToString()), Convert.ToDecimal(dr[7].ToString()), Convert.ToInt32(ddlTo.SelectedValue.ToString()), "", "",
 dr[11].ToString(), Convert.ToDecimal(dr[12].ToString()), dr[13].ToString(), Convert.ToDecimal(dr[14].ToString()), Convert.ToDecimal(dr[15].ToString()), Convert.ToDecimal(dr[16].ToString()), Convert.ToDecimal(dr[17].ToString())) == 0)
                    {
                        var NewCourseId = (from Cons in obj.Courses
                                           select Cons.CourseId).Max();
                        //Course Head Transfer
                        ds1 = AllMethods.SelectFromCousreHeadData(OldCourseId);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            {
                                obj.Sp_CourseHead(1, 0, Convert.ToInt32(NewCourseId), dr1[2].ToString(), Convert.ToDecimal(dr1[3].ToString()), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(ddlTo.SelectedValue.ToString()));
                            }
                        }
                        //Other Fees Transfer
                        ds2 = AllMethods.SelectFromOtherFeesData(OldCourseId);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                obj.Sp_Other_Fees(1, 0, Convert.ToInt32(NewCourseId), Convert.ToInt32(dr2[2].ToString()), dr2[3].ToString(), Convert.ToDecimal(dr2[4].ToString()), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddlTo.SelectedValue.ToString()), dr2[8].ToString());
                            }
                        }
                       
                    }
                }
                //Bus Transport Transfer
                ds3 = AllMethods.SelectBusTransportToTransfer(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(ddlFromSession.SelectedValue));
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        obj.SP_BusTransport(1, 0, dr3[1].ToString(), dr3[2].ToString(), Convert.ToDecimal(dr3[3].ToString()), Convert.ToDecimal(dr3[4].ToString()), Convert.ToDecimal(dr3[5].ToString()), Convert.ToInt32(Session["UserId"]),
                            Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(ddlTo.SelectedValue.ToString()));
                    }
                }
                if (ds.Tables[0].Rows.Count == i)
                {
                    ddlTansferType.SelectedIndex = 0;
                    ddlFromSession.SelectedIndex = 0;
                    ddlTo.SelectedIndex = 0;
                    Globals.Message(Page, "Data Sucessfully Transferd...");
                }
                else
                {
                    ddlTansferType.SelectedIndex = 0;
                    ddlFromSession.SelectedIndex = 0;
                    ddlTo.SelectedIndex = 0;
                    Globals.Message(Page, "Data not Sucessfully Transferd...");
                }
            }
            else
            {
                Globals.Message(Page, "From Session is not old session..");
            }
        }
        catch (Exception ex)
        { }
    }
    private void StudentTransfer()
    {
        try
        {
            string CourseName = "";
            string ActualCourseName = "";
            int a1 = 0, b = 0, s1 = 0,c=0,CourseId=0;
            double TotalOtherFees = 0, CourseFees = 0;
            for (int Index = 0; Index < GridStudentWiseData.Rows.Count; Index++)
            {
                int AdmissionId = Convert.ToInt32(GridStudentWiseData.DataKeys[Index].Value.ToString());
                IEnumerable<Addmision> Addmision = from Cons in obj.Addmisions
                                                   where Cons.AdmissionId == AdmissionId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlFromSession.SelectedValue)
                                                   select Cons;

                foreach (Addmision Cd in Addmision)
                {
                    CourseName = Cd.CourseName;
                    ActualCourseName = GetCourseName(CourseName);
                    IEnumerable<Course> Course = from Cons in obj.Courses
                                                 where Cons.CourseName == ActualCourseName && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlTo.SelectedValue)
                                                 select Cons;
                    if (Course.Count<Course>() > 0)
                    {
                        a1 = 1;
                    }
                    else
                    {
                        b = 1;
                        break;
                    }
                    IEnumerable<Addmision> Addmision1 = from Cons in obj.Addmisions
                                                        where Cons.CourseId == Course.First().CourseId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlTo.SelectedValue)
                                                   select Cons;
                    if (Addmision1.Count<Addmision>() <= 0)
                    {
                        a1 = 1;
                    }
                    else
                    {
                        c = 1;
                        break;
                    }
                }
            }
            for (int Index = 0; Index < GridStudentWiseData.Rows.Count; Index++)
            {
                int AdmissionId = Convert.ToInt32(GridStudentWiseData.DataKeys[Index].Value.ToString());
                IEnumerable<Addmision> Addmision = from Cons in obj.Addmisions
                                                   where Cons.AdmissionId == AdmissionId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlFromSession.SelectedValue)
                                                   select Cons;
                DropDownList ddlStatus = (DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlStatus");
                DropDownList ddlExamStatus = (DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlExamStatus");
                foreach (Addmision Cd in Addmision)
                {
                    Addmision a = new Addmision();
                    CourseName = Cd.CourseName;
                    ActualCourseName = GetCourseName(CourseName);
                    IEnumerable<Course> Course = from Cons in obj.Courses
                                                 where Cons.CourseName == ActualCourseName && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlTo.SelectedValue)
                                                 select Cons;
                    CourseId = Course.First().CourseId;
                    if (a1 == 1 && b == 0)
                    {
                        if (a1 == 1 && c == 0)
                        {
                            IEnumerable<Other_Fee> inv = from o in obj.Other_Fees
                                                         where o.CourseId == Course.First().CourseId
                                                         && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(ddlTo.SelectedValue)
                                                         select o;
                            TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));
                            CourseFees = Convert.ToDouble(Course.First().TotalFirstChild);
                            obj.SP_Addmision(1, Course.First().CourseId, Cd.SerialNo, Cd.AdmissionNo, Cd.EnrollmentNo, Cd.AdmissionDate, Cd.Session, Cd.StudentName, Cd.ContactNo, Cd.FatherName, Cd.MotherName, Cd.ParentContact,
                                       Cd.DOB, Cd.Section, Cd.EmailId, Cd.Medium, Cd.Medium, Cd.Category, Cd.Religion, Cd.Address, Cd.AadharCardNo,
                                       Cd.StudentPhoto, Cd.Nationality, Cd.Status, Course.First().CourseName, Convert.ToDecimal(Course.First().TotalFirstChild), Cd.CourseDiscountType,
                                        Cd.CourseDiscount, Convert.ToDecimal(Course.First().TotalFirstChild), Cd.CourseRemarks, Cd.From, Cd.To, Cd.TransportFees, Cd.TransportDiscountType,
                                        Cd.TransportDiscount, Cd.TransportFeesAfterDisc, Cd.TransportRemarks, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Cd.PaymentType, Cd.NoOfInstallment,
                                        Cd.Foccupation, Cd.Moccupation, Cd.SamegraId, Cd.FamilyId, Cd.Bank1, Cd.IFSC1, Cd.BranchName1, Cd.Bank2, Cd.IFSC2, Cd.BranchName, Convert.ToInt32(ddlTo.SelectedValue), Cd.PreviousClass, Cd.PCP, Course.First().CourseId, Cd.NoOfChildInFamily, Cd.NoOfBrothers,
                                        Cd.NoOfSisters, Cd.AnualIncome, Cd.StudentAge, Cd.BloodGroup, Cd.Height, Cd.Stream, Convert.ToDecimal(TotalOtherFees + CourseFees), Cd.AdmittedInClass,ddlStatus.SelectedIndex!=0 ? ddlStatus.SelectedItem.Text : Cd.R1, Cd.R2, Cd.R3, "", Cd.BankName1, Cd.BankName2,
                                        Cd.Course1,
                                        Cd.StudentName1,
                                        Cd.Course2,
                                        Cd.StudentName2,
                                        Cd.Course3,
                                        Cd.StudentName3,
                                        Cd.CourseOther1,
                                        Cd.StudentOther1,
                                        Cd.Relation1,
                                        Cd.Relation2,
                                        Cd.Relation3,
                                        Cd.RelationOther1,
                                        Cd.StudentCommingCategoty,
                                        Cd.AreaId,
                                        Cd.PMADate.ToString(),
                                        0,
                                        ddlExamStatus.SelectedItem.Text);
                            try
                            {

                                int aa = 1;
                                var _session = obj.Sessions.Where(x => x.Sessionid == Convert.ToInt32(Session["SessionId"]));
                                var studentSession = Cd.AdmissionNo.Substring(0, 4);
                                var sessionName = _session.First().SessionName.Substring(2, 2) + _session.First().SessionName.Substring(5);
                                if (studentSession == sessionName)
                                {
                                    aa = 0;
                                }
                                obj.SP_GetDueFeePrevious(1, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Cd.AdmissionNo, Cd.AdmissionId, Convert.ToInt32(Session["UserId"]),Cd.CourseId,aa);
                            }
                            catch (Exception ex)
                            { }
                           
                            s1 = 1;
                        }
                        else
                        {
                            Globals.Message(Page, "Students already exist for this class!!");
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Please create class in session " + ddlTo.SelectedItem.Text);
                        break;
                    }
                }
            }
            try
            {
                IEnumerable<Addmision> Addmision1 = from Cons in obj.Addmisions
                                                    where Cons.CourseId == CourseId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(ddlTo.SelectedValue)
                                                    select Cons;

                foreach (Addmision Cd in Addmision1)
                {

                    obj.Sp_CreateMonthlyFees(Cd.AdmissionId, Convert.ToInt32(ddlTo.SelectedValue));
                   
                }
            }
            catch (Exception ex)
            { }
            if (s1 == 1)
            {
                Globals.Message(Page, "Student transfer successfully");
            }
            else
            {
                Globals.Message(Page, "Student not transfer successfully");
            }
        }
        catch (Exception ex)
        { }
    }
    public string GetCourseName(string CourseName)
    {
        string ActualCourseName = "";
        if (CourseName == "P NUR")
            ActualCourseName = "NURSERY";
        if (CourseName == "NURSERY")
            ActualCourseName = "LKG";
        if (CourseName == "LKG")
            ActualCourseName = "UKG";
        if (CourseName == "UKG")
            ActualCourseName = "1ST";
        else if (CourseName == "KG1")
            ActualCourseName = "KG2";
        else if (CourseName == "KG2")
            ActualCourseName = "1ST";
        else if (CourseName == "1ST")
            ActualCourseName = "2ND ";
        else if (CourseName == "2ND ")
            ActualCourseName = "3RD";
        else if (CourseName == "3RD")
            ActualCourseName = "4TH";
        else if (CourseName == "4TH")
            ActualCourseName = "5TH";
        else if (CourseName == "5TH")
            ActualCourseName = "6TH";
        else if (CourseName == "6TH")
            ActualCourseName = "7TH";
        else if (CourseName == "7TH")
            ActualCourseName = "8TH";
        else if (CourseName == "8TH")
            ActualCourseName = "9TH";
        else if (CourseName == "9TH")
            ActualCourseName = "10TH";
        else if (CourseName == "10TH")
            ActualCourseName = "11TH";
        else if (CourseName == "11TH")
            ActualCourseName = "12TH";
        else if (CourseName == "12TH")
            ActualCourseName = "12TH";
        return ActualCourseName;
    }
}