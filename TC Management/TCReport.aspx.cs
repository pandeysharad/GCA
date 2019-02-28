using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TC_Management_Default : System.Web.UI.Page
{
    public string print = "";
    public string ChiledStatusDetails = "";
    DataClassesDataContext obj = new DataClassesDataContext();
    //public double ClassFee = 0, BusFee = 0, OtherFee = 0, prevbla = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
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
        if (Session["CompanyId"] != null)
        {
           
                var Profile = from Cons in obj.Settings
                              where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                              select Cons;

                IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                                where Cons.TCId == Convert.ToInt32(Session["TCId"])
                                                && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                select Cons;

                IEnumerable<Addmision> Admission = from Cons in obj.Addmisions
                                                    where Cons.AdmissionId == Convert.ToInt32(TcIssues.First().AdmissionId)
                                                    select Cons;

                print += "<table width='100%' cellpadding='0' cellspacing='0'>";
                 print += "<tr><td align='center' colspan='4'><table id='meta1'  width='100%' cellpadding='0' cellspacing='0' >";
                print += "<tr><td align='center' style='width:6%;'><img src='../images/Vipslogo.png' height='100px' width='120px' /></td><td style='width:94%;font-family: Lucida Bright;font-size:23px;font-weight: bold;padding-bottom:0px;' colspan='3' align='center'>" + Profile.First().SchoolName + "<br/><span style='padding:0px;font-size:14px;font-weight: bold;margin-top:-20px;' >Patan Road NTPC,Bineki,Jabalpur(MP) Ph.: 0761-2854022, Helpline :9009933344,9669002220</span></td></tr>";
                print += "</table></td></tr>";
                    //<td align='center' style='width:10%;'><img src='../images/Vipslogo.png' height='80px' width='100px' /></td><td style='width:90%;font-family: Lucida Bright;font-size:23px;font-weight: bold;padding-bottom:0px;' colspan='3' align='center'>" + Profile.First().SchoolName + "<br/><span style='padding:0px;font-size:14px;font-weight: bold;margin-top:-20px;' >Patan Road NTPC,Bineki,Jabalpur(MP) Ph.: 0761-2854022, Helpline :9009933344,9669002220</span></td></tr>";
                //print += "<tr><td style='width:100%;font-family: Lucida Bright;font-size:25px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center'>" + Profile.First().SchoolName + "</td></tr>";
                //print += "<tr><td style='width:100%;font-family: Lucida Bright;font-size:25px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center'>English Medium (10+2)</td></tr>";
                // print += "<tr><td colspan='4' style='border-top:thin solid black;'></td></tr>";
                //print += "<tr><td colspan='4'  align='center' style='padding:0px;font-weight: bold;' >Patan Road NTPC,Bineki,Jabalpur(MP) Ph.: 0761-2854022, Helpline :9009933344,9669002220</td></tr>";
                //print += "<tr><td colspan='4'  align='center' style='padding-bottom:0px;'><img src='../images/FEES RECEIPT.jpg' height='25px' width='150px' /></td></tr>";
                //print += "<tr><td colspan='3' style='width:75%;padding:0px' align='right'>Receipt No. " + Payment.First().ReceiptNo + " / Date<b>:</b></td><td style='width:25%;padding:0px'>  " + Convert.ToDateTime(Payment.First().PaymentDate).ToString("dd/MM/yyyy") + "</td></tr>";
                //print += "<tr><td style='width:20%;padding-left:10px;'>Student's Name<b>:</b></td><td style='width:40%;'>" + Admission.First().StudentName + " (" + Admission.First().EnrollmentNo + ")</td><td style='width:20%;'>Admission Date<b>:</b></td><td style='width:30%;'>" + Convert.ToDateTime(Admission.First().AdmissionDate).ToString("dd/MM/yyyy") + "</td></tr>";
                //print += "<tr><td style='width:20%;padding-left:10px;'>Father's Name<b>:</b></td><td style='width:40%;'>" + Admission.First().FatherName + "</td><td style='width:20%;'>Class/Section<b>:</b></td><td style='width:30%;'>" + Admission.First().CourseName + "( " + Admission.First().Section + " )</td></tr>";
                //print += "<tr><td style='width:20%;padding-left:10px;'>Child Status<b>:</b></td><td style='width:40%;'>" + Admission.First().Nationality + "</td><td style='width:20%;'>Scholar No.<b>:</b></td><td style='width:30%;'>" + Admission.First().AdmissionNo + "</td></tr>";
                print += "<tr><td height='30px' colspan='4'></td></tr>";
                print += "<tr><td colspan='4'  align='center' style='width:100%;font-family: Lucida Bright;font-size:20px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center' >TRANSFER CERTIFICATE</td></tr>";
                print += "<tr><td height='4px' colspan='4'></td></tr>";
                if (TcIssues.First().DuplicateTc == true)
                {
                    print += "<tr><td colspan='4'  align='center' style='width:100%;font-family: Lucida Bright;font-size:18px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center' >DUPLICATE</td></tr>";
                }
                else
                {
                    print += "<tr><td height='10px' colspan='4'></td></tr>";
                }
                print += "<tr><td height='10px' colspan='4'></td></tr>";
                print += "<tr><td  style='width:20%;padding:0px;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;Serial No.</td><td style='width:2%;padding:0px;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><b>:</b></td><td style='width:78%;padding:0px;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>  " + TcIssues.First().TcSerialNo + "</td></tr>";
                print += "<tr><td  style='width:20%;padding:0px;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;Admission No.</td><td style='width:2%;padding:0px;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><b>:</b></td><td style='width:78%;padding:0px;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>  " + TcIssues.First().AdmissionNo + "</td></tr>";
                print += "<tr><td height='20px' colspan='4'></td></tr>";
                print += "<tr><td align='center' colspan='4'><table id='meta1'  width='90%' cellpadding='0' cellspacing='0' >";
                //print += "<tr><th colspan='3' style='width:75%;font-weight: bold;'  align='center'>Perticulars</th><th style='width:25%;font-weight: bold;' align='center'>Amount(Rs.)</th></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>1.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Name of the pupil</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Admission.First().StudentName + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>2.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Mother's Name</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Admission.First().MotherName + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>3.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Father's Name</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Admission.First().FatherName + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>4.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Nationality</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Admission.First().Nationality + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>5.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Whether the candidate belongs to SC/ST/OBC/GENERAL</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Admission.First().Category + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>6.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Date of first admission in the school with class</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Convert.ToDateTime(Admission.First().AdmissionDate).ToString("dd/MM/yyyy") + "&nbsp;&nbsp;&nbsp;(" + Admission.First().AdmittedInClass + ")</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>7.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Date of birth according to admission register</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Convert.ToDateTime(Admission.First().DOB).ToString("dd/MM/yyyy") + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>8.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Class in which the pupil last studied</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + TcIssues.First().Class + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>9.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Last examination with result</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + TcIssues.First().Examination + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>10.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Whether qualified for promotion to the higher class,  if so to which class</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + TcIssues.First().AndPassed + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>11.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Month upto which the pupil has paid school dues</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + TcIssues.First().PaidAllDue + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>12.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>General conduct</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + TcIssues.First().ConductWas + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>13.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Date of application for certificate</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Convert.ToDateTime(TcIssues.First().ApplyDate).ToString("dd/MM/yyyy") + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>14.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Date of issue of certificate</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + Convert.ToDateTime(TcIssues.First().SchoolLeavingDate).ToString("dd/MM/yyyy") + "</td></tr>";
                print += "<tr><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>15.</td><td style='width:66%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'>Any other remarks</td><td style='width:2%;font-family: Lucida Bright;font-size:15px;font-weight: bold;'><b>:</b></td><td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='left'>" + TcIssues.First().Remarks + "</td></tr>";
                print += "</table></td></tr>";

                print += "<tr><td height='50px' colspan='4'></td></tr>";

                print += "<tr><td align='center' colspan='4'><table id='meta1'  width='100%' cellpadding='0' cellspacing='0' >";
                print += "<tr><td colspan='2' style='width:50%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='center'>Prepared By</td><td style='width:50%;font-family: Lucida Bright;font-size:15px;font-weight: bold;' align='center'>Principal</td></tr>";
                print += "</table></td></tr>";
                print += "<tr><td height='10px' colspan='4'></td></tr>";
                //print += "<tr><td colspan='2'  align='center' style='width:50%;font-family: Lucida Bright;font-size:18px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center' >Prepared By</td><td colspan='2'  align='center' style='width:50%;font-family: Lucida Bright;font-size:18px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center' >Pricipal</td></tr>";
                print += "</table>";
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
}