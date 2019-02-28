using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq.SqlClient;

public partial class Pages_JobEquiryReport : System.Web.UI.Page
{
    public string print = "";
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
                print += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #D5F9F7;'><td>JOB-EQR-No.</td><td>EQR-DATE</td><td>NAME</td><td>CONTACT</td><td>WHATSAPP</td><td>ADDRESS</td><td>EMAIL</td><td>EXP-YEAR</td><td>EXP-MONTH</td><td>PRE-ORGANIZATION</td><td>DESIGNATION</td><td>REMARK</td><td>STATUS</td></tr>";
                if (Session["JEPdtSDate"].ToString() != "" && Session["JEPdtEDate"].ToString() != "")
                {
                    date.Visible = true;
                    StartDate = Session["JEPdtSDate"].ToString();
                    EndDate = Session["JEPdtEDate"].ToString();
                }
                if (Session["JEPStudentName"].ToString() != "")
                {
                    IEnumerable<JobEnquiry> DATA1 = from Cons in obj.JobEnquiries
                                where SqlMethods.Like(Cons.Name, "" + Session["JEPStudentName"].ToString() + "%") && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    foreach (JobEnquiry Cd in DATA1.ToList<JobEnquiry>())
                    {
                        print += "<tr><td>" + Cd.JobEnquiryNo + "</td><td>" + Convert.ToDateTime(Cd.EnquiryDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Name + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsappNo + "</td><td>" + Cd.Address + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.PreviousOrganization + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Remarks + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["JEPContactNo"].ToString() != "")
                {
                    IEnumerable<JobEnquiry> DATA1 = from Cons in obj.JobEnquiries
                                where SqlMethods.Like(Cons.ContactNo, "" + Session["JEPContactNo"].ToString() + "%") && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    foreach (JobEnquiry Cd in DATA1.ToList<JobEnquiry>())
                    {
                        print += "<tr><td>" + Cd.JobEnquiryNo + "</td><td>" + Convert.ToDateTime(Cd.EnquiryDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Name + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsappNo + "</td><td>" + Cd.Address + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.PreviousOrganization + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Remarks + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else if (Session["JEPdtSDate"].ToString() != "" && Session["JEPdtEDate"].ToString() != "")
                {
                    IEnumerable<JobEnquiry> DATA1 = from Cons in obj.JobEnquiries
                                                    where Cons.EnquiryDate >= DateTime.Parse(Session["JEPdtSDate"].ToString()) &&
                                                       Cons.EnquiryDate <= DateTime.Parse(Session["JEPdtEDate"].ToString()) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                    select Cons;
                    foreach (JobEnquiry Cd in DATA1.ToList<JobEnquiry>())
                    {
                        print += "<tr><td>" + Cd.JobEnquiryNo + "</td><td>" + Convert.ToDateTime(Cd.EnquiryDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Name + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsappNo + "</td><td>" + Cd.Address + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.PreviousOrganization + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Remarks + "</td><td>" + Cd.Status + "</td></tr>";
                    }
                }
                else
                {
                    IEnumerable<JobEnquiry> DATA1 = from Cons in obj.JobEnquiries
                                                    where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                    select Cons;
                    foreach (JobEnquiry Cd in DATA1.ToList<JobEnquiry>())
                    {
                        print += "<tr><td>" + Cd.JobEnquiryNo + "</td><td>" + Convert.ToDateTime(Cd.EnquiryDate).ToString("dd/MM/yyyy") + "</td><td>" + Cd.Name + "</td><td>" + Cd.ContactNo + "</td><td>" + Cd.WhatsappNo + "</td><td>" + Cd.Address + "</td><td>" + Cd.EmailId + "</td><td>" + Cd.ExpYear + "</td><td>" + Cd.ExpMonth + "</td><td>" + Cd.PreviousOrganization + "</td><td>" + Cd.Designation + "</td><td>" + Cd.Remarks + "</td><td>" + Cd.Status + "</td></tr>";
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