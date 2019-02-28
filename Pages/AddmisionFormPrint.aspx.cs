using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddmisionFormPrint : System.Web.UI.Page
{
    public string print = "";
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Print();
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
            if (Session["FrormRegistrationId1"] != null)
            {
                var RegistrationForms = from Cons in obj.RegistrationForms
                                        where Cons.FrormRegistrationId == Convert.ToInt32(Session["FrormRegistrationId1"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                              select Cons;

                var Profile = from Cons in obj.Settings
                              where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                              select Cons;
                print += "<table width='100%'>";
                print += "<tr><td style='width:100%;font-family: Lucida Bright;font-size:25px;font-weight: bold;padding-bottom:0px;' colspan='4' align='center'>" + Profile.First().SchoolName + "</td></tr>";
                // print += "<tr><td colspan='4' style='border-top:thin solid black;'></td></tr>";
                print += "<tr><td height='2px' colspan='2'></td></tr>";
                print += "<tr><td colspan='4'  align='center' style='padding:0px;font-weight: bold;' >" + Profile.First().Address + "</td></tr>";
                //print += "<tr><td colspan='4'  align='center' style='padding:0px;font-weight: bold;' >Patan Road NTPC,Bineki,Jabalpur(MP) Ph.: 0761-2854022, Helpline :9009933344,9669002220</td></tr>";

                print += "<tr><td height='15px' colspan='2'></td></tr>";
                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Form No.</span><b>:</b></td><td style='width:50%;'>" + RegistrationForms.First().FormNo + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:" + Convert.ToDateTime(RegistrationForms.First().Date).ToString("dd/MM/yyyy") + "</td></tr>";

                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Student's Name</span><b>:</b></td><td style='width:50%;'>" + RegistrationForms.First().StudentName + "</td></tr>";

                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Father's Name</span><b>:</b></td><td style='width:50%;'>" + RegistrationForms.First().FatherName + "</td></tr>";


                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Contact No.</span><b>:</b></td><td style='width:50%;'>" + RegistrationForms.First().ContactNo + "</td></tr>";


                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Amount</span><b>:</b></td><td style='width:50%;'>" + RegistrationForms.First().Amount + "</td></tr>";


                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Address</span><b>:</b></td><td style='width:50%;'>" + RegistrationForms.First().Address + "</td></tr>";


                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "<tr style='font-size:20px;font-weight: bold;'><td align='center' style='width:50%;padding-left:10px;'><span style='margin-left:40px;'>Amount in word</span><b>:</b></td><td style='width:50%;'>" + ConvertNumbertoWords(Convert.ToInt32(RegistrationForms.First().Amount)) + " ONLY</td></tr>";
                print += "<tr><td height='12px' colspan='2'></td></tr>";

                print += "</table>";
            }
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
}