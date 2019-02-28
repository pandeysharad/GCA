using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TC_Management_CCReport : System.Web.UI.Page
{
    public string print = "";
    public string ChiledStatusDetails = "";
    DataClassesDataContext obj = new DataClassesDataContext();
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
            print += "<tr><td height='50px' colspan='4'></td></tr>";
            print += "<tr><td align='center' colspan='4'><table id='meta1'  width='100%' cellpadding='0' cellspacing='0' >";
            print += "<tr><td style='width:100%;font-family: Lucida Bright;font-size:23px;font-weight: bold;padding-bottom:0px;' align='center'>" + Profile.First().SchoolName + "<br/><span style='padding:0px;font-size:14px;font-weight: bold;margin-top:-20px;' >Patan Road NTPC,Bineki,Jabalpur(MP) Ph.: 0761-2854022,<br/>Helpline :9009933344,9669002220</span></td></tr>";
            print += "</table></td></tr>";
            print += "<tr><td height='10px' colspan='4'></td></tr>";
            print += "<tr><td align='center' colspan='4'><table id='meta1'  width='100%' cellpadding='0' cellspacing='0' >";
            print += "<tr><td align='center' style='width:100%;'><img src='../images/Vipslogo.png' height='100px' width='130px' /></td></tr>";
            print += "</table></td></tr>";
            print += "<tr><td height='10px' colspan='4'></td></tr>";
           
            
            print += "<tr><td height='10x' colspan='4'></td></tr>";
            print += "<tr><td colspan='4'  align='center' style='width:100%;font-family: Lucida Bright;font-size:20px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center' >CHARACTER CERTIFICATE</td></tr>";
            print += "<tr><td height='4px' colspan='4'></td></tr>";
            print += "<tr><td height='10px' colspan='4'></td></tr>";
            if (TcIssues.First().DuplicateCc == true)
            {
                print += "<tr><td colspan='4'  align='center' style='width:100%;font-family: Lucida Bright;font-size:18px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center' >DUPLICATE</td></tr>";
            }
            else
            {
                print += "<tr><td height='10px' colspan='4'></td></tr>";
            }
            print += "<tr><td height='10px' colspan='4'></td></tr>";
            print += "<tr><td align='center' colspan='4'><table id='meta1'  width='100%' cellpadding='0' cellspacing='0' >";
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This is to Certify that shri / ku." + Admission.First().StudentName + "</td></tr>";
           
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>Son/Daughter of Shri" + Admission.First().FatherName + " was a bonafider</td></tr>";
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>regular.</td></tr>";
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>student of this institution from " + Convert.ToDateTime(Admission.First().AdmissionDate).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(TcIssues.First().SchoolLeavingDate).ToString("dd/MM/yyyy") + "</td></tr>";
            
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>During His/Her stay in the school  His/Her character </td></tr>";
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>was satisfactory.</td></tr>";
            print += "<tr><td height='10px' colspan='4'></td></tr>";
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>To the best of my knowledge He/She has not taken part</td></tr>";
          
            print += "<tr><td style='width:15%;'></td><td align='left' style='width:85%;font-family: Lucida Calligraphy;font-size:17px;font-weight: bold;padding-bottom:4px;'>in any subversive or anti national activity.</td></tr>";
            print += "</table></td></tr>";

            print += "<tr><td height='50px' colspan='4'></td></tr>";
            print += "<tr><td  style='width:30%;padding:0px;font-family:  Lucida Calligraphy;font-size:15px;font-weight: bold;padding-bottom:0px;' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Serial No.</td><td style='width:2%;padding:0px;font-family:  Lucida Calligraphy;font-size:15px;font-weight: bold;padding-bottom:0px;'><b>:</b></td><td style='width:68%;padding:0px;font-family: Lucida Calligraphy;font-size:15px;font-weight: bold;padding-bottom:0px;'>  " + TcIssues.First().TcSerialNo + "</td></tr>";
            print += "<tr><td  style='width:30%;padding:0px;font-family:  Lucida Calligraphy;font-size:15px;font-weight: bold;padding-bottom:0px;' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Admission No.</td><td style='width:2%;padding:0px;font-family:  Lucida Calligraphy;font-size:15px;font-weight: bold;padding-bottom:0px;'><b>:</b></td><td style='width:68%;padding:0px;font-family: Lucida Calligraphy;font-size:15px;font-weight: bold;padding-bottom:0px;'>  " + TcIssues.First().AdmissionNo + "</td></tr>";
            print += "<tr><td height='50px' colspan='4'></td></tr>";
            print += "<tr><td align='center' colspan='4'><table id='meta1'  width='100%' cellpadding='0' cellspacing='0' >";
            print += "<tr><td colspan='2' style='width:50%;font-family:Lucida Calligraphy;font-size:15px;font-weight: bold;' align='center'></td><td style='width:50%;font-family: Lucida Calligraphy;font-size:15px;font-weight: bold;' align='center'>Principal</td></tr>";
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