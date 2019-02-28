using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ClassWiseCollection : System.Web.UI.Page
{

    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    public string SchoolName = "";
    public DateTime From = DateTime.Now, To = DateTime.Now;

    int CourseId;
    double FTotalClassFees = 0;
    double FTotalTransportFees = 0.0;
    double FTotalOtherFees = 0.0;
    double FAdmnFees = 0.0;
    double FLateFees = 0.0;
    double FDisc = 0.0;
    double FRegistrationFees = 0.0;
    double FPreviousPaid = 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompanyId"] != null)
            {

                var DATA = from Cons in obj.Settings
                           select Cons;
                SchoolName = DATA.First().SchoolName;
                if (!string.IsNullOrEmpty(Request.QueryString["From"]))
                {
                    From = Convert.ToDateTime(Request.QueryString["From"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["To"]))
                {
                    To = Convert.ToDateTime(Request.QueryString["To"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["CourseId"]))
                {
                    CourseId = Convert.ToInt32(Request.QueryString["CourseId"]);
                }
                if (!IsPostBack)
                {
                    FillDataPaymentSheet();
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        { }
    }
    private void FillDataPaymentSheet()
    {
        try
        {
            
            if (CourseId == 0)
            {
                var inv = from p in obj.Payments
                          from a in obj.Addmisions
                          where p.PaymentDate >= @From
                          && p.PaymentDate <= @To
                          && a.AdmissionId == p.AdmissionId
                          && a.Remove == false && p.ComapanyId == Convert.ToInt32(Session["CompanyId"])
                          orderby p.PaymentDate.Value ascending
                          select new
                          {
                              StudentName = a.StudentName,
                              ContactNumber = a.ContactNo,
                              TotalCourseFees = a.CourseFeesAfterDisc,
                              TotalTransportFees = a.TransportFeesAfterDisc,
                              AdmiId = a.AdmissionId,
                              CourseId = p.CourseId,
                              ClassName = a.CourseName,
                              Section = a.Section,
                              RollNo = a.AdmissionNo
                              //Customer = (e.Title + " " + e.Name + " " + e.LastName),
                              //ContactNumber = e.ContactNumber,
                              //EnquiryId = e.EnquiryID,
                              //InvId = i.InvId,
                              //InvoiceDate = i.InvoiceDate.Value,
                              //Amount = (i.TotalAmount.Value + i.AdditionalCharges.Value),
                              //Broker = b.BrokerName,
                              //BrokerNo = b.ContactNo,
                              //BookingAmount = i.BookingAmount.Value
                          };
                Grid.DataSource = inv.Distinct();
                Grid.DataBind();
            }
            else if (CourseId != 0)
            {
                var inv = from p in obj.Payments
                          from a in obj.Addmisions
                          where p.PaymentDate >= @From
                          && p.PaymentDate <= @To
                          && a.AdmissionId == p.AdmissionId
                          && p.CourseId==CourseId
                          && a.Remove == false && p.ComapanyId == Convert.ToInt32(Session["CompanyId"])
                          orderby p.PaymentDate.Value ascending
                          select new
                          {
                              StudentName = a.StudentName,
                              ContactNumber = a.ContactNo,
                              TotalCourseFees = a.CourseFeesAfterDisc,
                              TotalTransportFees = a.TransportFeesAfterDisc,
                              AdmiId = a.AdmissionId,
                              CourseId = p.CourseId,
                              ClassName = a.CourseName,
                              Section = a.Section,
                              RollNo = a.AdmissionNo
                              //Customer = (e.Title + " " + e.Name + " " + e.LastName),
                              //ContactNumber = e.ContactNumber,
                              //EnquiryId = e.EnquiryID,
                              //InvId = i.InvId,
                              //InvoiceDate = i.InvoiceDate.Value,
                              //Amount = (i.TotalAmount.Value + i.AdditionalCharges.Value),
                              //Broker = b.BrokerName,
                              //BrokerNo = b.ContactNo,
                              //BookingAmount = i.BookingAmount.Value
                          };
                Grid.DataSource = inv.Distinct();
                Grid.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            double TotalClassFees = 0;
            double TotalTransportFees = 0.0;
            double TotalOtherFees = 0.0;
            double AdmnFees = 0.0;
            double LateFees = 0.0;
            double Disc = 0.0;
            double RegistrationFees = 0.0;

            double PreviousPaid = 0.0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int AdmissionId = Convert.ToInt32(Grid.DataKeys[e.Row.RowIndex].Value.ToString());
                IEnumerable<Payment> install = from id in obj.Payments
                                               where id.PaymentDate >= From
                                               && id.PaymentDate <= To
                                               && id.AdmissionId == AdmissionId
                                               && id.ComapanyId == Convert.ToInt32(Session["CompanyId"])
                                               select id;
                IEnumerable<RegistrationForm> RegistrationForm = from id in obj.RegistrationForms
                                               where id.Date >= From
                                               && id.Date <= To
                                               && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) 
                                               select id;
                if (install.Count<Payment>() > 0)
                {
                    string InstallString = "<table cellspacing='0'>";

                    TotalClassFees = Convert.ToDouble(install.Sum<Payment>(s => s.CourseFees.Value));
                    TotalTransportFees = Convert.ToDouble(install.Sum<Payment>(s => s.TransportFees.Value));
                    TotalOtherFees = Convert.ToDouble(install.Sum<Payment>(s => s.OtherFees.Value));
                    AdmnFees = Convert.ToDouble(install.Sum<Payment>(s => s.AdmissionFees.Value));
                    LateFees = Convert.ToDouble(install.Sum<Payment>(s => s.LateFees.Value));
                    Disc = Convert.ToDouble(install.Sum<Payment>(s => s.Discount.Value));
                    RegistrationFees = Convert.ToDouble(RegistrationForm.Sum<RegistrationForm>(s => s.Amount.Value));
                    PreviousPaid = Convert.ToDouble(install.Sum<Payment>(s => s.PreviousPaid.Value));
                    FRegistrationFees = +RegistrationFees;
                    FTotalClassFees += TotalClassFees;
                    FTotalTransportFees += TotalTransportFees;
                    FTotalOtherFees += TotalOtherFees;
                    FAdmnFees += AdmnFees;
                    FLateFees += LateFees;
                    FDisc += Disc;
                    FPreviousPaid += PreviousPaid;
                    InstallString += "<tr><td class='installr'>" + (TotalClassFees - Disc).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (TotalTransportFees).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (TotalOtherFees + AdmnFees + LateFees + PreviousPaid).ToString("##,##,##,####.00") + "</td><td class='installr'>" + ((TotalClassFees + TotalTransportFees + TotalOtherFees + AdmnFees + LateFees + PreviousPaid) - Disc).ToString("##,##,##,####.00") + "</td></tr>";
                    InstallString += "</table>";
                    e.Row.Cells[3].Text = InstallString;
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Text = "<table><tr><td class='installr'>CLAAS FEES</td><td class='installr'>TRANSPORT FEES</td><td class='installr'>OTHERS FEES</td><td class='installr'>TOTAL+FORM FEES</td></tr></table>";
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                foreach (DataKey d in Grid.DataKeys)
                {
                    if (CourseId == 0)
                    {
                        IEnumerable<Payment> install = from id in obj.Payments
                                                       where id.PaymentDate >= From
                                                       && id.PaymentDate <= To
                                                       && id.ComapanyId == Convert.ToInt32(Session["CompanyId"]) 
                                                       select id;

                        if (install.Count<Payment>() > 0)
                        {
                            string footer = "";
                            footer += "<table>";
                            FTotalClassFees = Convert.ToDouble(install.Sum<Payment>(s => s.CourseFees.Value));
                            FTotalTransportFees = Convert.ToDouble(install.Sum<Payment>(s => s.TransportFees.Value));
                            FTotalOtherFees = Convert.ToDouble(install.Sum<Payment>(s => s.OtherFees.Value));

                            footer += "<tr><td class='installr'>" + (FTotalClassFees - FDisc).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (FTotalTransportFees).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (FTotalOtherFees + FAdmnFees + FLateFees + FPreviousPaid).ToString("##,##,##,####.00") + "</td><td class='installr'>" + ((FTotalClassFees + FTotalTransportFees + FTotalOtherFees + FAdmnFees + FLateFees + FRegistrationFees + FPreviousPaid) - FDisc).ToString("##,##,##,####.00") + "</td></tr>";
                            footer += "</table>";
                            e.Row.Cells[3].Text = footer;
                        }
                    }
                    else if (CourseId != 0)
                    {
                        string footer = "";
                        footer += "<table>";
                        footer += "<tr><td class='installr'>" + (FTotalClassFees - FDisc).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (FTotalTransportFees).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (FTotalOtherFees + FAdmnFees + FLateFees + FPreviousPaid).ToString("##,##,##,####.00") + "</td><td class='installr'>" + ((FTotalClassFees + FTotalTransportFees + FTotalOtherFees + FAdmnFees + FLateFees + FRegistrationFees + FPreviousPaid) - FDisc).ToString("##,##,##,####.00") + "</td></tr>";
                        footer += "</table>";
                        e.Row.Cells[3].Text = footer;
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlWidth_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid.Width = new Unit(double.Parse(ddlWidth.SelectedValue));
    }
}