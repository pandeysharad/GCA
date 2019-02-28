using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class Reports_InstallmentsDueSheet : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    public string SchoolName = "";
    public DateTime From = DateTime.Now, To = DateTime.Now;
    int CourseId;
    double TClassFess = 0, TTransportFees = 0;
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
                var inv = from i in obj.Installments
                          from a in obj.Addmisions
                          where i.InstallmentDate >= @From
                           && i.InstallmentDate <= @To
                          && a.AdmissionId == i.AdmissionId
                          && i.PaymentStatus == "BALANCE"
                          && a.R1 == "ACTIVE"
                          && a.Remove == false && i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                          orderby i.InstallmentDate.Value ascending
                          select new
                          {
                              StudentName = a.StudentName,
                              ContactNumber = a.ContactNo,
                              TotalCourseFees = a.CourseFeesAfterDisc,
                              TotalTransportFees = a.TransportFeesAfterDisc,
                              AdmiId = a.AdmissionId,
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
                var inv = from i in obj.Installments
                          from a in obj.Addmisions
                          where i.InstallmentDate >= @From
                           && i.InstallmentDate <= @To
                          && a.AdmissionId == i.AdmissionId
                           && a.CourseId == CourseId
                          && i.PaymentStatus == "BALANCE"
                          && a.R1 == "ACTIVE"
                          && a.Remove == false && i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                          orderby i.InstallmentDate.Value ascending
                          select new
                          {
                              StudentName = a.StudentName,
                              ContactNumber = a.ContactNo,
                              TotalCourseFees = a.CourseFeesAfterDisc,
                              TotalTransportFees = a.TransportFeesAfterDisc,
                              AdmiId = a.AdmissionId,
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
            //double ClassTotal = 0;
            //double TransportTotal = 0.0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int AdmisId = Convert.ToInt32(Grid.DataKeys[e.Row.RowIndex].Value.ToString());
                IEnumerable<Installment> install = from id in obj.Installments
                                                   where id.AdmissionId == AdmisId
                                                   && id.InstallmentDate >= From
                                                   && id.InstallmentDate <= To
                                                   && id.PaymentStatus == "BALANCE"
                                                   && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                   select id;

                if (install.Count<Installment>() > 0)
                {
                    string InstallString = "<table cellspacing='0'>";
                    foreach (Installment id in install)
                    {
                        TClassFess += Convert.ToDouble(id.CourseBalance.Value);
                        TTransportFees += Convert.ToDouble(id.TransportBalance.Value);
                        InstallString += "<tr><td class='installr'>" + id.InstallmentDate.Value.ToString("dd/MM/yy") + "</td><td class='installr'>" + (id.CourseBalance.Value).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (id.TransportBalance.Value).ToString("##,##,##,####.00") + "</td></tr>";
                    }
                    //if (install.Count<Installment>() > 0)
                    //{
                    //    ClassTotal += Convert.ToDouble(install.Sum<Installment>(s => s.CourseBalance.Value));
                    //    TransportTotal += Convert.ToDouble(install.Sum<Installment>(s => s.TransportBalance.Value));
                    //}
                    //InstallString += "<tr style='font-weight:bold;'><td class='installr'></td><td class='installr'>" + (ClassTotal).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (TransportTotal).ToString("##,##,##,####.00") + "</td></tr>";
                    InstallString += "</table>";
                    e.Row.Cells[6].Text = InstallString;
                }


            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[6].Text = "<table><tr><td class='installr'>DATE</td><td class='installr'>ClASS DUE</td><td class='installr'>TRANSPORT DUE</td></tr></table>";
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                double DueClassTotal = 0;
                double DueTransportTotal = 0.0;
                double bookinAmt = 0, TotalPrice = 0;
                foreach (DataKey d in Grid.DataKeys)
                {
                    int InID = Convert.ToInt32(d.Value.ToString());


                    IEnumerable<Addmision> inv = from i in obj.Addmisions
                                                 where i.AdmissionId == InID
                                                 && i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                                                 select i;
                    if (inv.Count<Addmision>() > 0)
                    {
                        bookinAmt += Convert.ToDouble(inv.Sum<Addmision>(s => s.CourseFeesAfterDisc.Value));
                        TotalPrice += Convert.ToDouble(inv.Sum<Addmision>(s => s.TransportFeesAfterDisc.Value));
                    }
                    if (CourseId == 0)
                    {
                        IEnumerable<Installment> install = from id in obj.Installments
                                                           where id.InstallmentDate >= From
                                                           && id.InstallmentDate <= To
                                                           && id.PaymentStatus == "BALANCE"
                                                           && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                           select id;

                        if (install.Count<Installment>() > 0)
                        {
                            foreach (Installment id in install)
                            {
                                if (install.Count<Installment>() > 0)
                                {
                                    DueClassTotal = Convert.ToDouble(install.Sum(s => s.CourseBalance.Value));
                                    DueTransportTotal = Convert.ToDouble(install.Sum(s => s.TransportBalance.Value));
                                }

                            }
                        }
                        string footer = "";
                        footer += "<table>";
                        footer += "<tr><td class='installr'></td><td class='installr'>" + (DueClassTotal).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (DueTransportTotal).ToString("##,##,##,####.00") + "</td></tr>";
                        footer += "</table>";

                        e.Row.Cells[6].Text = footer;
                        footer = "<table>";
                        footer += "<tr><td class='installr'>Due Amount </td></tr>";
                        footer += "</table>";
                        e.Row.Cells[3].Text = footer;
                        e.Row.Cells[4].Text = bookinAmt.ToString("##,##,##,####.00");
                        e.Row.Cells[5].Text = TotalPrice.ToString("##,##,##,####.00");
                    }
                    else if (CourseId != 0)
                    {
                        string footer = "";
                        footer += "<table>";
                        footer += "<tr><td class='installr'></td><td class='installr'>" + (TClassFess).ToString("##,##,##,####.00") + "</td><td class='installr'>" + (TTransportFees).ToString("##,##,##,####.00") + "</td></tr>";
                        footer += "</table>";

                        e.Row.Cells[6].Text = footer;
                        footer = "<table>";
                        footer += "<tr><td class='installr'>Due Amount </td></tr>";
                        footer += "</table>";
                        e.Row.Cells[3].Text = footer;
                        e.Row.Cells[4].Text = bookinAmt.ToString("##,##,##,####.00");
                        e.Row.Cells[5].Text = TotalPrice.ToString("##,##,##,####.00");
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
    protected void btnSendSms_Click(object sender, EventArgs e)
    {
        try
        {
            int i = 0,s=0;
            foreach (DataKey d in Grid.DataKeys)
            {
                int InID = Convert.ToInt32(d.Value.ToString());
                if (((CheckBox)Grid.Rows[i].FindControl("ChkDelete")).Checked)
                {
                    DataSet ds = new DataSet();
                    ds = AllMethods.SendMsgSpecificStudent(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), InID);
                    var install = from id in obj.Installments
                                                       where id.InstallmentDate >= From
                                                       && id.InstallmentDate <= To
                                                       && id.PaymentStatus == "BALANCE"
                                                       && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                       select id;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            s = 1;
                            string msg = "Hello " + dr[0].ToString() + ",\nYour next installment fees " + Convert.ToDecimal((install.First().CourseBalance + install.First().TransportBalance)).ToString("##,##,##,####.00") + " Rupees, Last date is " + Convert.ToDateTime(install.First().InstallmentDate).ToString("dd/MM/yyyy")
                                +" Please pay for avoiding late fees.\nThank You...";
                            string Mobile = dr[1].ToString();
                            try
                            {
                                SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                            }
                            catch (Exception ex)
                            { Globals.Message(Page, "Message Not send successfully Please check your internet connection..."); }
                        }
                    }
                }
                i = i + 1;
            }
            if (s == 1)
            {
                Globals.Message(Page, "Message sent successfully..."); 
            }
        }
        catch (Exception ex)
        { }
    }
}