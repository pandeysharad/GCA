using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_StudentTranfer : System.Web.UI.Page
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
                if (Session["CompanyId"] != null)
                {
                    var DATA = from Cons in obj.Sessions
                               where Cons.Remove == false && Cons.Sessionid > Convert.ToInt32(Session["SessionId"]) 
                               select Cons;
                    ddlSession.DataSource = DATA;
                    ddlSession.DataTextField = "SessionName";
                    ddlSession.DataValueField = "Sessionid";
                    ddlSession.DataBind();
                    ddlSession.Items.Insert(0, "Select Session");
                    ddlSession.Focus();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
        }
        catch (Exception ex) { }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (role.Select.Value)
            {
                if (ddlSession.SelectedIndex != 0)
                {
                    btnSave.Visible = true;
                    btnSave.Text = "Tranfer Students To " + ddlSession.SelectedItem.Text;
                    Session["NextSessionId"] = ddlSession.SelectedValue;
                }
                else
                {
                    btnSave.Visible = false;
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
       
        System.Threading.Thread.Sleep(5000);

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string CourseName = "";
            string ActualCourseName = "";
            int a1 = 0, b = 0, s1 = 0;
            double TotalOtherFees = 0, CourseFees = 0;
            IEnumerable<Addmision> Addmision = from Cons in obj.Addmisions
                                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;

            foreach (Addmision Cd in Addmision)
            {
                CourseName = Cd.CourseName;
                ActualCourseName = GetCourseName(CourseName);
                IEnumerable<Course> Course = from Cons in obj.Courses
                                             where Cons.CourseName == ActualCourseName && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["NextSessionId"])
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
            }
            foreach (Addmision Cd in Addmision)
            {
                Addmision a = new Addmision();
                CourseName = Cd.CourseName;
                ActualCourseName = GetCourseName(CourseName);
                IEnumerable<Course> Course = from Cons in obj.Courses
                                             where Cons.CourseName == ActualCourseName && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["NextSessionId"])
                                             select Cons;
                if (a1 == 1 && b == 0)
                {
                    IEnumerable<Other_Fee> inv = from o in obj.Other_Fees
                                                 where o.CourseId == Course.First().CourseId
                                                 && o.Remove == false && o.CompanyId == Convert.ToInt32(Session["CompanyId"]) && o.SessionId == Convert.ToInt32(Session["NextSessionId"])
                                                 select o;
                    TotalOtherFees = Convert.ToDouble(inv.Sum(s => s.Fees.Value));
                    CourseFees = Convert.ToDouble(Course.First().TotalFirstChild);
                    obj.SP_Addmision(1, Course.First().CourseId, Cd.SerialNo, Cd.AdmissionNo, Cd.EnrollmentNo, Cd.AdmissionDate, Cd.Session, Cd.StudentName, Cd.ContactNo, Cd.FatherName, Cd.MotherName, Cd.ParentContact,
                               Cd.DOB, Cd.Section, Cd.EmailId, Cd.Medium, Cd.Medium, Cd.Category, Cd.Religion, Cd.Address, Cd.AadharCardNo,
                               Cd.StudentPhoto, Cd.Nationality, Cd.Status, Course.First().CourseName, Convert.ToDecimal(Course.First().TotalFirstChild), Cd.CourseDiscountType,
                                Cd.CourseDiscount, Convert.ToDecimal(Course.First().TotalFirstChild), Cd.CourseRemarks, Cd.From, Cd.To, Cd.TransportFees, Cd.TransportDiscountType,
                                Cd.TransportDiscount, Cd.TransportFeesAfterDisc, Cd.TransportRemarks, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Cd.PaymentType, Cd.NoOfInstallment,
                                Cd.Foccupation, Cd.Moccupation, Cd.SamegraId, Cd.FamilyId, Cd.Bank1, Cd.IFSC1, Cd.BranchName1, Cd.Bank2, Cd.IFSC2, Cd.BranchName, Convert.ToInt32(Session["NextSessionId"]), Cd.PreviousClass, Cd.PCP, Course.First().CourseId, Cd.NoOfChildInFamily, Cd.NoOfBrothers,
                                Cd.NoOfSisters, Cd.AnualIncome, Cd.StudentAge, Cd.BloodGroup, Cd.Height, Cd.Stream, Convert.ToDecimal(TotalOtherFees + CourseFees), Cd.AdmittedInClass, Cd.R1, Cd.R2, Cd.R3, "", Cd.BankName1, Cd.BankName2, 
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
                                "");
                    s1 = 1;
                }
                else
                {
                    Globals.Message(Page, "Please create class in session " + ddlSession.SelectedItem.Text);
                    break;
                }
            }
            try
            {
                IEnumerable<Addmision> Addmision1 = from Cons in obj.Addmisions
                                                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["NextSessionId"])
                                                    select Cons;

                foreach (Addmision Cd in Addmision1)
                {
                    obj.Sp_CreateMonthlyFees(Cd.AdmissionId, Convert.ToInt32(Session["NextSessionId"]));
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
        if (CourseName == "NUR")
            ActualCourseName = "KG1";
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