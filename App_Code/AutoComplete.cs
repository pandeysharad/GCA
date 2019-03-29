using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.EnterpriseServices;
using System.Configuration;
/// <summary>
/// Summary description for Autocomplate
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[System.Web.Script.Services.ScriptService]












public class AutoComplete : System.Web.Services.WebService
{

    public AutoComplete()
    {
    }



    [WebMethod]
    public string[] GetAdmNo(string prefixText,string contextKey)
    {
        string CompanyId = contextKey.Split(',')[0];
        string SessionId = contextKey.Split(',')[1];
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("select AdmissionNo from Addmision where Remove=0 AND CompanyId=@CompanyId and SessionId=@SessionId AND AdmissionNo like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(SessionId));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }

    [WebMethod]
    public string[] GetStudentName(string prefixText, string contextKey)
    {
        string CompanyId = contextKey.Split(',')[0];
        string SessionId = contextKey.Split(',')[1];
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("select StudentName from Addmision where Remove=0 AND CompanyId=@CompanyId and SessionId=@SessionId AND StudentName like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(SessionId));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }

    [WebMethod]
    public string[] GetContactNo(string prefixText, string contextKey)
    {
        string CompanyId = contextKey.Split(',')[0];
        string SessionId = contextKey.Split(',')[1];
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("select ContactNo from Addmision where Remove=0 AND CompanyId=@CompanyId and SessionId=@SessionId AND ContactNo like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(SessionId));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }

    [WebMethod]
    public string[] GetALLByOption(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();
        SqlCommand obCom = new SqlCommand();
        if (contextKey == "1")
        {
            obCom = new SqlCommand("select StudentName+' + '+admissionNo as StudentName from Addmision where Remove=0 AND StudentName like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "2")
        {
            obCom = new SqlCommand("select ContactNo from Addmision where Remove=0 AND ContactNo like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "3")
        {
            obCom = new SqlCommand("select AadharCardNo from Addmision where Remove=0 AND AadharCardNo like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "4")
        {
            obCom = new SqlCommand("select SamegraId from Addmision where Remove=0 AND SamegraId like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "5")
        {
            obCom = new SqlCommand("select FamilyId from Addmision where Remove=0 AND FamilyId like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "6")
        {
            obCom = new SqlCommand("select AdmissionNo from Addmision where Remove=0 AND AdmissionNo like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "7")
        {
            obCom = new SqlCommand("select distinct BankName1 from Addmision where Remove=0 AND BankName1 like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "8")
        {
            obCom = new SqlCommand("select FatherName from Addmision where Remove=0 AND FatherName like  '" + prefixText.Trim() + "%'", con);
        }
        else if (contextKey == "9")
        {
            obCom = new SqlCommand("select MotherName from Addmision where Remove=0 AND MotherName like  '" + prefixText.Trim() + "%'", con);
        }
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }

    [WebMethod]
    public string[] GetVillageName(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"SELECT     DISTINCT Village
FROM         Enquiry where Village like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] BloodGroup(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT BloodGroup from Addmision where BloodGroup like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] Foccupation(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT Foccupation from Addmision where Foccupation like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] Moccupation(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT Moccupation from Addmision where Moccupation like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] BankName1(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT BankName1 from Addmision where BankName1 like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] IFSC1(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT IFSC1 from Addmision where IFSC1 like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] BranchName1(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT BranchName1 from Addmision where BranchName1 like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] BankName2(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT BankName2 from Addmision where BankName2 like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] IFSC2(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT IFSC2 from Addmision where IFSC2 like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] BranchName2(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT BranchName from Addmision where BranchName like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] GetAdmVillageName(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT EnrollmentNo from Addmision where EnrollmentNo like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] GetAddress(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT Address from Addmision where Address like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] GetCourseName(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"select DISTINCT CourseName from Course where CourseName like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }
    [WebMethod]
    public string[] GetStaffId(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"SELECT     StaffId
FROM         Staff where StaffId like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }

    [WebMethod]
    public string[] GetPreviousSchool(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand(@"SELECT     PreviousSchool
FROM         Enquiry where PreviousSchool like  '" + prefixText.Trim() + "%'", con);
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();

        return items.ToArray();
    }
    [WebMethod]
    public string[] PaidAllDue(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct PaidAllDue FROM TcIssue where SessionId=@SessionId AND PaidAllDue like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] Examination(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct Examination FROM TcIssue where SessionId=@SessionId AND Examination like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] Class(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct Class FROM TcIssue where SessionId=@SessionId AND Class like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] AndPassed(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct AndPassed Class FROM TcIssue where SessionId=@SessionId AND AndPassed like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] ToClass(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct AndPassed ToClass FROM TcIssue where SessionId=@SessionId AND ToClass like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] InWordsClass(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct InWordsClass ToClass FROM TcIssue where SessionId=@SessionId AND InWordsClass like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] ConductWas(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct ConductWas ToClass FROM TcIssue where SessionId=@SessionId AND ConductWas like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
    [WebMethod]
    public string[] Year(string prefixText, string contextKey)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());

        List<string> items = new List<string>();

        SqlCommand obCom = new SqlCommand("Select Distinct Year ToClass FROM TcIssue where SessionId=@SessionId AND Year like  '" + prefixText.Trim() + "%'", con);

        obCom.Parameters.AddWithValue("@SessionId", Convert.ToInt32(contextKey));
        con.Open();
        SqlDataReader read = obCom.ExecuteReader();
        while (read.Read())
        {
            items.Add(read[0].ToString());
        }
        con.Close();


        return items.ToArray();
    }
}

