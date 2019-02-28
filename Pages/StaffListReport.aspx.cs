using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq.SqlClient;

public partial class Pages_StaffListReport : System.Web.UI.Page
{
    public string print = "";
    public string print1 = "";
    public string print2 = "";
    public string StartDate = "";
    public string EndDate = "";
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CompanyId"] != null)
            {
                print += "<table width='100%' style='text-align:center;font-size: 13px;' id='customers'>";
                print += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #D5F9F7;'><td>STAFF-ID</td><td>STAFF-TYPE</td><td>JOINING-DATE</td><td>NAME</td><td>CONTACT</td><td>WHATSAPP<td>EMAIL</td><td>FATHER</td><td>MOTHER</td><td>PARENT-CONTACT</td><td>DOB</td><td>AGE</td><td>GENDER</td><td>PAN-CARD</td><td>SAMAGRA-ID</td><td>ADDRESS</td><td>STATUS</td></tr>";
                if (Session["SLPBOTH"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                                    where  Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                    select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffType + "</td><td>" + Convert.ToDateTime(Cd.JoinDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsAppNo + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.FatherName + "</td><td>" + Cd.MotherName + "</td><td>" + Cd.ParentContact + "</td><td>" + Convert.ToDateTime(Cd.DOB).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Age + "</td><td>" + Cd.Gender + "</td><td>" + Cd.PANCardNo + "</td><td>" + Cd.SamagraId + "</td><td>" + Cd.Address + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPACTIVE"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Status==Session["SLPACTIVE"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffType + "</td><td>" + Convert.ToDateTime(Cd.JoinDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsAppNo + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.FatherName + "</td><td>" + Cd.MotherName + "</td><td>" + Cd.ParentContact + "</td><td>" + Convert.ToDateTime(Cd.DOB).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Age + "</td><td>" + Cd.Gender + "</td><td>" + Cd.PANCardNo + "</td><td>" + Cd.SamagraId + "</td><td>" + Cd.Address + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPINACTIVE"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Status == Session["SLPINACTIVE"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffType + "</td><td>" + Convert.ToDateTime(Cd.JoinDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsAppNo + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.FatherName + "</td><td>" + Cd.MotherName + "</td><td>" + Cd.ParentContact + "</td><td>" + Convert.ToDateTime(Cd.DOB).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Age + "</td><td>" + Cd.Gender + "</td><td>" + Cd.PANCardNo + "</td><td>" + Cd.SamagraId + "</td><td>" + Cd.Address + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPSearchByStaffId"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.StaffId == Session["SLPSearchByStaffId"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffType + "</td><td>" + Convert.ToDateTime(Cd.JoinDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsAppNo + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.FatherName + "</td><td>" + Cd.MotherName + "</td><td>" + Cd.ParentContact + "</td><td>" + Convert.ToDateTime(Cd.DOB).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Age + "</td><td>" + Cd.Gender + "</td><td>" + Cd.PANCardNo + "</td><td>" + Cd.SamagraId + "</td><td>" + Cd.Address + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
             //-------------------------------------------------Other Info-------------------------------------------------------
                print1 += "<table width='100%' style='text-align:center;font-size: 13px;' id='customers'>";
                print1 += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #D5F9F7;'><td>STAFF-ID</td><td>NAME</td><td>EXP-YEAR</td><td>EXP-MONTH</td><td>DESIGNATION<td>QUALIFICATION</td><td>DEPARTMENT</td><td>BASIC-SALARY</td><td>ACCOUNT-NUMBER</td><td>BANK-NAME</td><td>BRANCH</td><td>IFSC-CODE</td><td>CATEGORY</td><td>RELIGION</td><td>AADHAR-CARD</td><td>NATIONALITY</td><td>STATUS</td></tr>";
                if (Session["SLPBOTH"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print1 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Qualification + "</td><td>" + Cd.Department + "</td><td>" + Cd.BasicSalary + "</td><td>" + Cd.AccountNo + "</td><td>" + Cd.bankName + "</td><td>" + Cd.Branch + "</td><td>" + Cd.IFSCCode + "</td><td>" + Cd.Category + "</td><td>" + Cd.Religion + "</td><td>" + Cd.AadharCardNo + "</td><td>" + Cd.Nationality + "</td><td>" + Cd.Status + "</td></tr>";
                    }   
                }
                else if (Session["SLPACTIVE"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Status == Session["SLPACTIVE"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print1 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Qualification + "</td><td>" + Cd.Department + "</td><td>" + Cd.BasicSalary + "</td><td>" + Cd.AccountNo + "</td><td>" + Cd.bankName + "</td><td>" + Cd.Branch + "</td><td>" + Cd.IFSCCode + "</td><td>" + Cd.Category + "</td><td>" + Cd.Religion + "</td><td>" + Cd.AadharCardNo + "</td><td>" + Cd.Nationality + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPINACTIVE"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Status == Session["SLPINACTIVE"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print1 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Qualification + "</td><td>" + Cd.Department + "</td><td>" + Cd.BasicSalary + "</td><td>" + Cd.AccountNo + "</td><td>" + Cd.bankName + "</td><td>" + Cd.Branch + "</td><td>" + Cd.IFSCCode + "</td><td>" + Cd.Category + "</td><td>" + Cd.Religion + "</td><td>" + Cd.AadharCardNo + "</td><td>" + Cd.Nationality + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPSearchByStaffId"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.StaffId == Session["SLPSearchByStaffId"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print1 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Qualification + "</td><td>" + Cd.Department + "</td><td>" + Cd.BasicSalary + "</td><td>" + Cd.AccountNo + "</td><td>" + Cd.bankName + "</td><td>" + Cd.Branch + "</td><td>" + Cd.IFSCCode + "</td><td>" + Cd.Category + "</td><td>" + Cd.Religion + "</td><td>" + Cd.AadharCardNo + "</td><td>" + Cd.Nationality + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                //-------------------------------------------------Acadmic Info-------------------------------------------------------
                print2 += "<table width='100%' style='text-align:center;font-size: 13px;' id='customers'>";
                print2 += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #D5F9F7;'><td>STAFF-ID</td><td>NAME</td><td>12TH-STREAM</td><td>12TH-SUBJECT</td><td>GRADUATION-STREAM<td>GRADUATION-SUBJECT</td><td>POST-GRADUATION-STREAM</td><td>POST-GRADUATION-SUBJECT</td><td>STATUS</td></tr>";
                if (Session["SLPBOTH"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print2 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.TwelvethStream + "</td><td>" + Cd.TwelvethSubject + "</td><td>" + Cd.GraduationStrean + "</td><td>" + Cd.GraduationSubject + "</td><td>" + Cd.PostGraduationStream + "</td><td>" + Cd.PostGraduationSubject + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPACTIVE"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Status == Session["SLPACTIVE"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print2 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.TwelvethStream + "</td><td>" + Cd.TwelvethSubject + "</td><td>" + Cd.GraduationStrean + "</td><td>" + Cd.GraduationSubject + "</td><td>" + Cd.PostGraduationStream + "</td><td>" + Cd.PostGraduationSubject + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPINACTIVE"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.Status == Session["SLPINACTIVE"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print2 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.TwelvethStream + "</td><td>" + Cd.TwelvethSubject + "</td><td>" + Cd.GraduationStrean + "</td><td>" + Cd.GraduationSubject + "</td><td>" + Cd.PostGraduationStream + "</td><td>" + Cd.PostGraduationSubject + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["SLPSearchByStaffId"].ToString() != "")
                {
                    IEnumerable<Staff> DATA1 = from Cons in obj.Staffs
                                               where Cons.StaffId == Session["SLPSearchByStaffId"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                               select Cons;
                    foreach (Staff Cd in DATA1.ToList<Staff>())
                    {
                        print2 += "<tr><td>" + Cd.StaffId + "</td><td>" + Cd.StaffName + "</td><td>" + Cd.TwelvethStream + "</td><td>" + Cd.TwelvethSubject + "</td><td>" + Cd.GraduationStrean + "</td><td>" + Cd.GraduationSubject + "</td><td>" + Cd.PostGraduationStream + "</td><td>" + Cd.PostGraduationSubject + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }

        }
    }
}