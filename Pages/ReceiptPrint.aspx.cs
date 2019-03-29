using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Pages_ReceiptPrint : System.Web.UI.Page
{
    public string print = "";
    public string ChiledStatusDetails = "";
    DataClassesDataContext obj = new DataClassesDataContext();
    public double ClassFee = 0, BusFee = 0, OtherFee = 0, prevbla = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetBal();
                Print();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Print", "javascript:window.print();", true);
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void Print()
    {

        decimal AdmFees = 0, OtherFees = 0, CourseFees = 0, TransportFees = 0, LateFees = 0, GT = 0, Discount = 0, PreviousPaid = 0;
        string NoOfInstall = "0";
        if (Session["CompanyId"] != null)
        {
            if (Session["StudentId"] != null && Session["PaymentId"] != null)
            {
                var Profile = from Cons in obj.Settings
                              where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                              select Cons;

                var Payment = from Cons in obj.Payments
                              where Cons.AdmissionId == Convert.ToInt32(Session["StudentId"]) && Cons.PaymentId == Convert.ToInt32(Session["PaymentId"])
                              select Cons;

                var Admission = from Cons in obj.Addmisions
                                where Cons.AdmissionId == Convert.ToInt32(Session["StudentId"])
                                select Cons;

                var CourseId = from Cons in obj.CourseHeads
                               where Cons.CourseId == Admission.First().CourseId
                               select Cons;
                var Course = from Cons in obj.Courses
                             where Cons.CourseId == Admission.First().CourseId
                             select Cons;

                DropDownList1.DataSource = CourseId;
                DropDownList1.DataTextField = "CourseHeadId";
                DropDownList1.DataBind();

                print += "<table width='100%' cellpadding='0' cellspacing='0'>";
                print += "<tr><td style='width:100%;font-family: Lucida Bright;font-size:25px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center'>" + Profile.First().SchoolName + "</td></tr>";
                // print += "<tr><td colspan='4' style='border-top:thin solid black;'></td></tr>";
                //print += "<tr><td colspan='4'  align='center' style='padding:0px;font-weight: bold;' >Patan Road NTPC,Bineki,Jabalpur(MP) Ph.: 0761-2854022, Helpline :9009933344,9669002220</td></tr>";
                print += "<tr><td colspan='4'  align='center' style='padding:0px;font-weight: bold;' >" + Profile.First().Address + "</td></tr>";
                print += "<tr><td colspan='4'  align='center' style='padding-bottom:0px;'><img src='../images/FEES RECEIPT.jpg' height='25px' width='150px' /></td></tr>";
                print += "<tr><td colspan='3' style='width:75%;padding:0px' align='right'>Receipt No. " + Payment.First().ReceiptNo + " / Date<b>:</b></td><td style='width:25%;padding:0px'>  " + Convert.ToDateTime(Payment.First().PaymentDate).ToString("dd/MM/yyyy") + "</td></tr>";
                print += "<tr><td style='width:20%;padding-left:10px;'>Student's Name<b>:</b></td><td style='width:40%;'>" + Admission.First().StudentName + " (" + Admission.First().EnrollmentNo + ")</td><td style='width:20%;'>Admission Date<b>:</b></td><td style='width:30%;'>" + Convert.ToDateTime(Admission.First().AdmissionDate).ToString("dd/MM/yyyy") + "</td></tr>";
                print += "<tr><td style='width:20%;padding-left:10px;'>Father's Name<b>:</b></td><td style='width:40%;'>" + Admission.First().FatherName + "</td><td style='width:20%;'>Class/Section<b>:</b></td><td style='width:30%;'>" + Admission.First().CourseName + "( " + Admission.First().Section + " )</td></tr>";
                print += "<tr><td style='width:20%;padding-left:10px;'>Child Status<b>:</b></td><td style='width:40%;'>" + Admission.First().Nationality + "</td><td style='width:20%;'>Scholar No.<b>:</b></td><td style='width:30%;'>" + Admission.First().AdmissionNo + "</td></tr>";

                IEnumerable<Addmision> Addmisions1 = from id in obj.Addmisions
                                                     where id.AdmissionId == Convert.ToInt32(Session["StudentId"])
                                                     && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                     select id;
                ChiledStatusDetails = "";
                if (Addmisions1.First().Course1 != 0 && Addmisions1.First().Course1 != null)
                {
                    ChiledStatusDetails += "<tr style='font-weight:bold; text-align:left;'><td colspan='3'>SIBLING DETAILS</td></tr>";
                    ChiledStatusDetails += "<tr style='font-weight:bold;text-transform: uppercase;font-size: 13px;'><td>Staus</td><td>Class</td><td>Stu. Name</td><td>Scholar No.</td></tr>";
                    IEnumerable<Course> courseName = from id in obj.Courses
                                                     where id.CourseId == Convert.ToInt32(Addmisions1.First().Course1)
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                     select id;
                    IEnumerable<Addmision> AddmisionsChild1 = from id in obj.Addmisions
                                                              where id.AdmissionId == Convert.ToInt32(Addmisions1.First().StudentName1)
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                              select id;
                    ChiledStatusDetails += "<tr><td>" + AddmisionsChild1.First().Nationality + "</td><td>" + courseName.First().CourseName + "</td><td>" + AddmisionsChild1.First().StudentName + "</td><td><a target='_blank' href='FeesRecieve.aspx?AdmissionNo=" + AddmisionsChild1.First().AdmissionNo + " '>" + AddmisionsChild1.First().AdmissionNo + "</a></td></tr>";
                }
                if (Addmisions1.First().Course2 != 0 && Addmisions1.First().Course2 != null)
                {

                    IEnumerable<Course> courseName = from id in obj.Courses
                                                     where id.CourseId == Convert.ToInt32(Addmisions1.First().Course2)
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                     select id;
                    IEnumerable<Addmision> AddmisionsChild1 = from id in obj.Addmisions
                                                              where id.AdmissionId == Convert.ToInt32(Addmisions1.First().StudentName2)
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                              select id;
                    ChiledStatusDetails += "<tr><td>" + AddmisionsChild1.First().Nationality + "</td><td>" + courseName.First().CourseName + "</td><td>" + AddmisionsChild1.First().StudentName + "</td><td><a target='_blank' href='FeesRecieve.aspx?AdmissionNo=" + AddmisionsChild1.First().AdmissionNo + " '>" + AddmisionsChild1.First().AdmissionNo + "</a></td></tr>";
                }
                if (Addmisions1.First().CourseOther1 != 0 && Addmisions1.First().CourseOther1 != null)
                {
                    ChiledStatusDetails += "<tr style='font-weight:bold; text-align:left;'><td colspan='3'>SIBLING DETAILS</td></tr>";
                    ChiledStatusDetails += "<tr style='font-weight:bold;text-transform: uppercase;font-size: 13px;'><td>Staus</td><td>Class</td><td>Stu. Name</td><td>Scholar No.</td></tr>";
                    IEnumerable<Course> courseName = from id in obj.Courses
                                                     where id.CourseId == Convert.ToInt32(Addmisions1.First().CourseOther1)
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                     select id;
                    IEnumerable<Addmision> AddmisionsChild1 = from id in obj.Addmisions
                                                              where id.AdmissionId == Convert.ToInt32(Addmisions1.First().StudentOther1)
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                              select id;
                    ChiledStatusDetails += "<tr><td>" + AddmisionsChild1.First().Nationality + "</td><td>" + courseName.First().CourseName + "</td><td>" + AddmisionsChild1.First().StudentName + "</td><td><a target='_blank' href='FeesRecieve.aspx?AdmissionNo=" + AddmisionsChild1.First().AdmissionNo + "  '>" + AddmisionsChild1.First().AdmissionNo + "</a></td></tr>";
                }

                if (Admission.First().PaymentType == "Installment")
                {
                    NoOfInstall = Admission.First().NoOfInstallment.ToString();
                    print += "<tr><td style='width:20%;padding-left:10px;'>Installment Type<b>:</b></td><td style='width:40%;'>" + Admission.First().PaymentType + "</td><td style='width:20%;'>No. of Installment<b>:</b></td><td style='width:30%;'>" + NoOfInstall + "</td></tr>";
                }
                else
                {
                    string Months = "";
                    NoOfInstall = "10";
                    int i = 0;
                    IEnumerable<MonthlyInstallment> MonthlyInstallments = from Cons in obj.MonthlyInstallments
                                                                          where Cons.AdmissionId == Convert.ToInt32(Convert.ToInt32(Session["StudentId"])) && Cons.CousePaid != 0
                                                                          select Cons;

                    foreach (MonthlyInstallment Cd in MonthlyInstallments)
                    {
                        i++;
                        if (i == 1)
                        {
                            if (Cd.Months == "March")
                                Months += "Mar";
                            if (Cd.Months == "April")
                                Months += "Apr";
                            if (Cd.Months == "July")
                                Months += "Jul";
                            if (Cd.Months == "August")
                                Months += "Aug";
                            if (Cd.Months == "September")
                                Months += "Sept";
                            if (Cd.Months == "October")
                                Months += "Oct";
                            if (Cd.Months == "November")
                                Months += "Nov";
                            if (Cd.Months == "December")
                                Months += "Dec";
                            if (Cd.Months == "Jan")
                                Months += "Jan";
                            if (Cd.Months == "February")
                                Months += "Feb";
                        }
                        else if (i - 1 != MonthlyInstallments.Count<MonthlyInstallment>())
                        {
                            if (Cd.Months == "March")
                                Months += ",Mar";
                            if (Cd.Months == "April")
                                Months += ",Apr";
                            if (Cd.Months == "July")
                                Months += ",Jul";
                            if (Cd.Months == "August")
                                Months += ",Aug";
                            if (Cd.Months == "September")
                                Months += ",Sept";
                            if (Cd.Months == "October")
                                Months += ",Oct";
                            if (Cd.Months == "November")
                                Months += ",Nov";
                            if (Cd.Months == "December")
                                Months += ",Dec";
                            if (Cd.Months == "January")
                                Months += ",Jan";
                            if (Cd.Months == "February")
                                Months += ",Feb";
                        }
                        else
                        {
                            if (Cd.Months == "March")
                                Months += "Mar";
                            if (Cd.Months == "April")
                                Months += "Apr";
                            if (Cd.Months == "July")
                                Months += "Jul";
                            if (Cd.Months == "August")
                                Months += "Aug";
                            if (Cd.Months == "September")
                                Months += "Sept";
                            if (Cd.Months == "October")
                                Months += "Oct";
                            if (Cd.Months == "November")
                                Months += "Nov";
                            if (Cd.Months == "December")
                                Months += "Dec";
                            if (Cd.Months == "Jan")
                                Months += "Jan";
                            if (Cd.Months == "February")
                                Months += "Feb";
                        }
                    }
                    if (MonthlyInstallments.Count<MonthlyInstallment>() == 1)
                    {
                        print += "<tr><td style='width:20%;padding-left:10px;'>Month Name<b>:</b></td><td style='width:40%;'>" + Months + "</td><td style='width:20%;'>No. of Installment<b>:</b></td><td style='width:30%;'>" + NoOfInstall + "</td></tr>";
                    }
                    else
                    {
                        print += "<tr><td style='width:20%;padding-left:10px;'>Months Name<b>:</b></td><td style='width:40%;'>" + Months + "</td><td style='width:20%;'>No. of Installment<b>:</b></td><td style='width:30%;'>" + NoOfInstall + "</td></tr>";
                    }
                }

                if (ChiledStatusDetails != string.Empty)
                {
                    print += "<tr><td colspan='4'>";
                    print += "     <table  style='margin-left: 8px;'>";

                    print += ChiledStatusDetails;
                    print += "</table></td></tr>";
                }

                print += "<tr><td align='center' colspan='4'><table id='meta'  width='100%' cellpadding='0' cellspacing='0' >";
                print += "<tr><th colspan='3' style='width:75%;font-weight: bold;'  align='center'>Perticulars</th><th style='width:25%;font-weight: bold;' align='center'>Amount(Rs.)</th></tr>";
                if (Payment.First().AdmissionFees != 0)
                {
                    print += "<tr><td colspan='3' style='width:75%;'>Adminssion Fees</td><td style='width:25%;' align='center'>" + Payment.First().AdmissionFees + "</td></tr>";
                    try
                    {
                        AdmFees = Convert.ToDecimal(Payment.First().AdmissionFees);
                    }
                    catch (Exception ex)
                    { AdmFees = 0; }
                }
                if (Payment.First().OtherFees != 0 && Payment.First().OtherFeesType != "")
                {
                    print += "<tr><td colspan='3' style='width:75%;'>" + Payment.First().OtherFeesType + "</td><td style='width:25%;' align='center'>" + Payment.First().OtherFees + "</td></tr>";
                    try
                    {
                        OtherFees = Convert.ToDecimal(Payment.First().OtherFees);
                    }
                    catch (Exception ex)
                    { OtherFees = 0; }
                }
                for (int i = 0; i < DropDownList1.Items.Count; i++)
                {
                    IEnumerable<CourseHead> CourseHead = from Cons in obj.CourseHeads
                                                         where Cons.CourseHeadId == Convert.ToInt32(DropDownList1.Items[i].ToString())
                                                         select Cons;

                    foreach (CourseHead Cd in CourseHead)
                    {
                        // print += "<tr><td colspan='3' style='width:75%;'>" + Cd.Head + "</td><td style='width:25%;' align='center'>" + Cd.Amount + "</td></tr>";
                        print += "<tr><td style='width:25%;'>" + Cd.Head + "<b>:</b></td><td style='width:20%;'>" + Cd.Amount + "</td><td style='width:50%;'>Per Month</td><td style='width:5%;' align='center'></td></tr>";
                    }
                    //print += "<tr><td style='width:30%;'>" + CourseHead.First().Head + "<b>:</b></td><td style='width:25%;'>" + CourseHead.First().Amount + "</td><td style='width:20%;'>Per Month</td><td style='width:25%;' align='center'></td></tr>";
                }
                print += "<tr><td colspan='3' style='width:75%;'>School Fees <span style='margin-left:20px;'>" + Payment.First().PayMonthClass + "</span></td><td style='width:25%;' align='center'>" + Payment.First().CourseFees + "</td></tr>";
                try
                {
                    CourseFees = Convert.ToDecimal(Payment.First().CourseFees);
                }
                catch (Exception ex)
                { CourseFees = 0; }
                if (Payment.First().TransportFees > 0)
                {
                    print += "<tr><td colspan='3' style='width:75%;'>Transport Fees <span style='margin-left:20px;'>" + Payment.First().PayMonthTransport + "</span></td><td style='width:25%;' align='center'>" + Payment.First().TransportFees + "</td></tr>";
                }
                try
                {
                    TransportFees = Convert.ToDecimal(Payment.First().TransportFees);
                }
                catch (Exception ex)
                { TransportFees = 0; }


                if (Admission.First().Nationality == "SECOND")
                {
                    print += "<tr><td style='width:20%;'>Second Child Discount<b>:</b></td><td style='width:55%;' colspan='2'>" + Course.First().SecChildDisType + " (" + Course.First().SecChildDiscount + ")" + "</td><td style='width:25%;' align='center'></td></tr>";
                }
                else if (Admission.First().Nationality == "THIRD")
                {
                    print += "<tr><td style='width:20%;'>Third Child Discount<b>:</b></td><td style='width:55%;' colspan='2'>" + Course.First().ThirdChildDisType + " (" + Course.First().ThirdChildDiscount + ")" + "</td><td style='width:25%;' align='center'></td></tr>";
                }
                if (Admission.First().Nationality == "OTHER")
                {
                    print += "<tr><td style='width:20%;'>Other Child Discount<b>:</b></td><td style='width:55%;' colspan='2'>" + Course.First().ThirdChildDisType + " (" + Course.First().ThirdChildDiscount + ")" + "</td><td style='width:25%;' align='center'></td></tr>";
                }
                if (Admission.First().CourseDiscount != 0)
                {
                    print += "<tr><td style='width:20%;'>School Fees Discount<b>:</b></td><td style='width:55%;' colspan='2'>" + Admission.First().CourseDiscountType + " (" + Admission.First().CourseDiscount + ")" + "</td><td style='width:25%;' align='center'></td></tr>";
                }
                if (Admission.First().TransportDiscount != 0)
                {
                    print += "<tr><td style='width:20%;'>Transport Fees Discount<b>:</b></td><td style='width:55%;' colspan='2'>" + Admission.First().TransportDiscountType + " (" + Admission.First().TransportDiscount + ")" + "</td><td style='width:25%;' align='center'></td></tr>";
                }
                if (Payment.First().LateFees != 0)
                {
                    print += "<tr><td colspan='3' style='width:75%;'>Miscellaneous</td><td style='width:25%;' align='center'>" + Payment.First().LateFees + "</td></tr>";
                }
                try
                {
                    LateFees = Convert.ToDecimal(Payment.First().LateFees);
                }
                catch (Exception ex)
                { LateFees = 0; }
                if (Payment.First().PreviousPaid != 0)
                {
                    print += "<tr><td colspan='3' style='width:75%;'>Previous Paid (" + Payment.First().PreviousSession + ")</td><td style='width:25%;' align='center'>" + Payment.First().PreviousPaid + "</td></tr>";
                }
                try
                {
                    PreviousPaid = Convert.ToDecimal(Payment.First().PreviousPaid);
                }
                catch (Exception ex)
                { LateFees = 0; }
                if (Payment.First().Discount != 0)
                {
                    print += "<tr><td colspan='3' style='width:75%;'>Discount(Rs.)    <span style='margin-left:20px;'>" + Payment.First().DiscountType + "</span></td><td style='width:25%;' align='center'>" + Payment.First().Discount + "</td></tr>";
                }
                try
                {
                    Discount = Convert.ToDecimal(Payment.First().Discount);
                }
                catch (Exception ex)
                { Discount = 0; }
                GT = ((AdmFees + OtherFees + CourseFees + TransportFees + LateFees + PreviousPaid) - Discount);
                string prevtext = "";
                if (prevbla > 0)
                {
                    prevtext = ", Previous Bal.: " + prevbla;
                }
                //<span style='text-align:left'>School Bal.: " + ClassFee + ", Trans. Bal.: " + BusFee + ", CM/T1/T2 : " + OtherFee + prevtext + "</span>
                print += "<tr><td colspan='3' style='width:75%;text-align:right;font-weight: bold;' ><span style='text-align:left;float:left; font-size: 11px;font-weight: normal;'>School Bal.: " + ClassFee + ", Trans. Bal.: " + BusFee + ", Other Fee Bal : " + OtherFee + prevtext + ", Total Bal. Till Date: " + (ClassFee + BusFee + OtherFee + prevbla) + "</span>Grand Total</td><td style='width:25%;' align='center'>" + GT + "</td></tr>";

                ////print += "<tr><td  style='width:15%;'></td><td style='width:35%;' ></td><td style='width:20%;'>Booking Date<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + Convert.ToDateTime(B.First().CurrentDate).ToShortDateString() + "</td></tr>";
                //// print += "<tr><td height='4px' colspan='4'></td></tr>";
                //print += "<tr><td style='width:20%;'>Parcel No.<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().ParcelNo + "</td><td  style='width:20%;'>Bus No<b>:</b>&nbsp;&nbsp;&nbsp;</td><td style='width:35%;' >" + D2.First().BusNo + "(" + D2.First().BusName + ")</td></tr>";
                //// print += "<tr><td height='4px' colspan='4'></td></tr>";
                //print += "<tr><td  style='width:20%;'>Sender Name<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().SenderName + "</td><td style='width:20%;'>Sender Mob<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().SenderContactNo + "</td></tr>";
                //print += "<tr><td style='width:20%;'>Sender Address</td><td style='width:80%;' colspan='3'>" + B.First().SenderAddress + "</td></tr>";
                //print += "<tr><td colspan='4' align='center'  style='width:100%;font-size:small;font-weight:bold;border-bottom:thin solid brown;'></td></tr>";
                //print += "<tr><td  style='width:20%;'>Receiver Name<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().ReceiverName + "</td><td  style='width:20%;'>Receiver Mob<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().ReceiverContact + "</td></tr>";
                //print += "<tr><td style='width:20%;'>Receiver Address</td><td style='width:80%;' colspan='3'>" + B.First().ReceiverAddress + "</td></tr>";
                //print += "<tr><td colspan='4' align='center'  style='width:100%;font-size:small;font-weight:bold;border-bottom:thin solid brown;'></td></tr>";
                //print += "<tr><td  style='width:20%;'>Amount<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().Amount + "</td><td  style='width:20%;'>Other Charges<b>:</b>&nbsp;&nbsp;&nbsp;</td><td  style='width:30%;'>" + B.First().OtherCharges + "&nbsp;&nbsp;&nbsp;&nbsp;Total<b>:</b>&nbsp;&nbsp;&nbsp;" + B.First().Total + "</td></tr>";
                //// print += "<tr><td height='4px' colspan='4'></td></tr>";
                //print += "<tr><td style='width:20%;'>Remarks</td><td style='width:80%;' colspan='3'>" + B.First().Remarks + "</td></tr>";
                //print += "<tr><td colspan='4' style='width:100%;font-size:small;font-weight: bold;'>Terms and Condition:-</td></tr>";
                //print += "<tr><td colspan='4' style='border:thin solid black;font-size:small;'><p style='margin:0px;''>1. Customers are bound submit proper bill or declaration with their Sales Tax No. At the time of booking other wise no claim will be paid by the agency after 7 days in any case.<br/>2. Constraband are not allowes.<br/>3. Agency will not responsible delay or loss in any type of accident.<br/>4. The luggage of goods will be lifted at owners risk only.<br/>5.Maximum liabilities are upto Rs. 500 in case of the loss of goods if the proper bills are submitted at time of booking.</p></td></tr>";
                print += "</table></td></tr>";
                print += "<tr><td align='center' colspan='4' style='Padding:0px;'><table  width='100%' cellpadding='0' cellspacing='0'>";
                print += "<tr><td style='width:20%;padding-left:10px;'>G.T. in words<b>:</b></td><td style='width:60%;' colspan='2'>" + ConvertNumbertoWords(Convert.ToInt32(GT)) + " ONLY</td><td style='width:20%;'></td></tr>";
                if (Payment.First().PaymentType == "CHEQUE")
                {
                    print += "<tr><td style='width:15%;padding-left:10px;'>Fees Type<b>:</b></td><td style='width:65%;' colspan='2'>" + Payment.First().PaymentType + "<span>  Cheque No. :</span>" + Payment.First().ChequeNo + "<span>  Cheque No. :</span>" + Convert.ToDateTime(Payment.First().ChequeDate).ToString("dd/MM/yyyy") + "</td><td style='width:20%;' align='center'></td></tr>";
                    print += "<tr><td style='width:15%;padding-left:10px;'>Remark<b>:</b></td><td style='width:65%;' colspan='2'>" + Payment.First().Remarks + "</td><td style='width:20%;' align='center'></td></tr>";
                }
                else
                {
                    print += "<tr><td style='width:15%;padding-left:10px;'>Fees Type<b>:</b></td><td style='width:65%;' colspan='2'>" + Payment.First().PaymentType + "</td><td style='width:20%;' align='center'></td></tr>";
                    print += "<tr><td style='width:15%;padding-left:10px;'>Remark<b>:</b></td><td style='width:65%;' colspan='2'>" + Payment.First().Remarks + "</td><td style='width:20%;' align='center'></td></tr>";
                }
                print += "<tr><td style='width:80%;padding-left:10px;font-size:small;font-weight: bold;' colspan='3'>Fees once paid will not be refunded except Caution Money. <span style='margin-left:20px'>(Print by: " + Session["UserName"].ToString() + "</span><span style='margin-left:20px'>Coll. by: " + AllMethods.GetUserNameByid(Convert.ToInt32(Payment.First().SessionId), Convert.ToInt32(Payment.First().ComapanyId), Convert.ToInt32(Payment.First().PaymentId)) + "</span>)</td><td style='width:20%;border-top:1px black solid;' align='center'><b>Cashier</b></td></tr>";
                print += "</table></td></tr>";
                //print += "<tr><td style='width:25%;font-weight: bold;' align='center'>Customer's Signature</td><td style='width:25%;font-weight: bold;'></td><td style='width:25%;font-weight: bold;'></td><td style='width:25%;font-weight: bold;' align='center'>Maa Rohani Travels</td></tr>";
                //print += "<tr><td height='10px' colspan='4'></td></tr>";
                print += "</table>";
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }


    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";

        if ((number / 1000000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000000) + " BILLION, ";
            number %= 1000000000;
        }

        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " CRORE, ";
            number %= 10000000;
        }

        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH, ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND, ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
    protected void GetBal()
    {
        //var DATA = from Cons in obj.Addmisions
        //           where Cons.AdmissionId == Convert.ToInt32(Session["StudentId"]) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
        //           select Cons;
        //decimal otherbalcheckinAddmisionTable = (Convert.ToDecimal(DATA.First().TotalFees) - (Convert.ToDecimal(DATA.First().CourseFeesAfterDisc)));
        DataSet ds = AllMethods.GetReciptBal(1, Convert.ToInt32(Session["StudentId"]));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ClassFee = Convert.ToDouble(dr[0]);
            BusFee = Convert.ToDouble(dr[1]);
            //OtherFee = Convert.ToDouble(dr[2]);
            prevbla = Convert.ToDouble(dr[3]);
            //OtherFee = Convert.ToDouble(otherbalcheckinAddmisionTable) - Convert.ToDouble(dr[2]);
            OtherFee = Convert.ToDouble(dr[2]);

        }
    }
}