using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;

public class AllMethods
{
    static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DATABASEConnectionString"].ToString());
   
    public string EnquiryNo;
    public string StudentName;
    public string Address;
    public string ContactNo;
    public string EmailId;
    public string EnquiryForCourse;
    public string PreviousClass;
    public string fees;
    public string EnquiryDate;
    public string NextCallDate;
    public string Image;
    public string Remarks;
    public string Status;
    public string PCP;
    public string SerialNo;
    public string CourseName;
    public decimal Fees;


    public string From;
    public string To;
    public string KM;
    public string RPKM;
    public string TotalFees;
    public string Sessionid;
    public string SerNo;
    public string AdmissionNo;

    public string OtherFeesId;
    public string CourseId;

	public AllMethods()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int SelectAdmissionFormFees(int CompanyId)
    {
        using (SqlConnection con = new SqlConnection(Globals.connectionString))
        {
            using (SqlCommand cm = new SqlCommand(@"DECLARE @STID INT SET @STID=(SELECT top 1 STID FROM SINGLEVALUETABLES WHERE ISDELETED=0 AND TABLENAME='ADMISSION FORM FEES' and CompanyId='" + CompanyId + "') SELECT Isnull(TABLEVALUE,0)FROM SINGLEVALUEDATA WHERE STID=@STID AND ISDELETED=0 and CompanyId='" + CompanyId + "'", con))
            {
                con.Close();
                con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                    return Convert.ToInt32(dr[0]);
            }
        }
        return 0;
    }
    public static DataSet CALCULATEAGE(string DOB)
    {
        DataSet Ds = new DataSet();

        SqlCommand oCmd = new SqlCommand("CALCULATEAGE", con);
            con.Close();
             con.Open();
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@DOB",Convert.ToDateTime(DOB));
            SqlDataAdapter Da = new SqlDataAdapter(oCmd);
            Da.Fill(Ds);
            con.Close();

        return Ds;
    }

    public static AllMethods GetEnquiryData(int id,int CompanyId)
    {
        AllMethods m = new AllMethods();
        SqlCommand cmd = new SqlCommand(@"SELECT     EnquiryNo, StudentName, Address, ContactNo, EmailId, PreviousClass,PCP,EnquiryForCourse, fees, EnquiryDate, NextCallDate, Image, Remarks, Status
FROM         Enquiry WHERE EnquiryId=@EnquiryId AND Remove=0 and CompanyId=@CompanyId", con);
        cmd.Parameters.AddWithValue("@EnquiryId", id);
        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        con.Close();
        con.Open();
        SqlDataReader r = cmd.ExecuteReader();
        if (r.Read())
        {
            m.EnquiryNo = r[0].ToString();
            m.StudentName = r[1].ToString();
            m.Address = r[2].ToString();
            m.ContactNo = r[3].ToString();
            m.EmailId = r[4].ToString();
            m.PreviousClass = r[5].ToString();
            m.PCP = r[6].ToString();
            m.EnquiryForCourse = r[7].ToString();
            m.fees = r[8].ToString();
            m.EnquiryDate = r[9].ToString();
            m.NextCallDate = r[10].ToString();
            m.Image = r[11].ToString();
            m.Remarks = r[12].ToString();
            m.Status = r[13].ToString();

        }
        return m;
        con.Close();
    }
    public static AllMethods GetCourseData(int id,int CompanyId)
    {
        AllMethods m = new AllMethods();
        SqlCommand cmd = new SqlCommand(@"SELECT     SerialNo, CourseName, FirstChildFees
FROM         Course WHERE CourseId=@CourseId AND Remove=0 and CompanyId=@CompanyId", con);
        cmd.Parameters.AddWithValue("@CourseId", id);
        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        con.Close();
        con.Open();
        SqlDataReader r = cmd.ExecuteReader();
        if (r.Read())
        {
            m.SerialNo = r[0].ToString();
            m.CourseName = r[1].ToString();
            m.Fees =Convert.ToDecimal(r[2]);
        }
        return m;
        con.Close();
    }


    public static AllMethods GetTransportData(int id)
    {
        AllMethods m = new AllMethods();
        SqlCommand cmd = new SqlCommand(@"SELECT     [From], [To], KM, RPKM, TotalFees
FROM         BusTransport WHERE TransportId=@TransportId AND Remove=0", con);
        cmd.Parameters.AddWithValue("@TransportId", id);
        con.Close();
        con.Open();
        SqlDataReader r = cmd.ExecuteReader();
        if (r.Read())
        {
            m.From = r[0].ToString();
            m.To = r[1].ToString();
            m.KM = r[2].ToString();
            m.RPKM = r[3].ToString();
            m.TotalFees = r[4].ToString();
        }
        return m;
        con.Close();
    }
    public static AllMethods SelectSessionId(string SessionName)
    {
        try
        {
            AllMethods m = new AllMethods();
            SqlCommand cmd = new SqlCommand(@"SELECT     Sessionid
FROM         Session WHERE SessionName=@SessionName AND Remove=0", con);
            cmd.Parameters.AddWithValue("@SessionName", SessionName);
            con.Close();
            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                m.Sessionid = r[0].ToString();
                return m;
            }
            m.Sessionid = null;
            return null;
            con.Close();
        }
        catch (Exception ex)
        {
            return null;
            con.Close();
        }
    }

    //public static AllMethods SelectSerialNo(int CompanyId, int SessionId, DateTime AdmissionDate)
    //{
    //    try
    //    {
    //        AllMethods m = new AllMethods();
    //        SqlCommand cmd = new SqlCommand(@"SELECT ISNULL(MAX(SerialNo),0)+1 FROM Addmision WHERE Remove=0 and CompanyId="+CompanyId+"and SessionId="+SessionId+"", con);
            
    //        con.Close();
    //        con.Open();
    //        SqlDataReader r = cmd.ExecuteReader();
    //        if (r.Read())
    //        {
    //            m.SerNo = r[0].ToString();
    //            return m;
    //        }
    //        m.SerNo = null;
    //        return null;
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //        con.Close();
    //    }
    //}
    public static string SelectSerialNo(int CompanyId, int SessionId, DateTime AdmissionDate)
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();
            qry.Append("SELECT ISNULL(Max(SerialNo)+1,1) FROM         Addmision WHERE Remove=0  and   DATEPART(YEAR, AdmissionDate)=DATEPART(YEAR, @AdmissionDate) and CompanyId=" + CompanyId + " and SessionId=" + SessionId + "");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.Parameters.AddWithValue("@AdmissionDate", AdmissionDate);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }
        return count;
    }
    public static AllMethods SelectOtherFeesId(string OtherFeesType,int CourseId,int CompanyId,int SessionId)
    {
        try
        {
            AllMethods m = new AllMethods();
            SqlCommand cmd = new SqlCommand(@"SELECT     OtherFeesId
FROM         Other_Fees WHERE FeesType=@FeesType AND CourseId=@CourseId AND CompanyId=@CompanyId AND  SessionId=@SessionId AND Remove=0", con);
            cmd.Parameters.AddWithValue("@FeesType", OtherFeesType);
            cmd.Parameters.AddWithValue("@CourseId", CourseId);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            cmd.Parameters.AddWithValue("@SessionId", SessionId);
            con.Close();
            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                m.OtherFeesId = r[0].ToString();
                return m;
            }
            m.OtherFeesId = "0";
            return null;
            con.Close();
        }
        catch (Exception ex)
        {
            return null;
            con.Close();
        }
    }

    public static AllMethods SelectCourseId(string CourseName, int CompanyId)
    {
        try
        {
            AllMethods m = new AllMethods();
            SqlCommand cmd = new SqlCommand(@"SELECT     CourseId
FROM         Course WHERE CourseName=@CourseName AND Remove=0 and CompanyId=@CompanyId", con);
            cmd.Parameters.AddWithValue("@CourseName", CourseName);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            con.Close();
            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                m.CourseId = r[0].ToString();
                return m;
            }
            m.CourseId = "0";
            return null;
            con.Close();
        }
        catch (Exception ex)
        {
            return null;
            con.Close();
        }
    }
    public static DataSet EnquiryPrit(string Name,string ContactNo,string Sdate,string Edate,string PreviousSchool,string Village,int CompanyId,int SessionId,string Status)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        if (Name != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0  AND  CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@StudentName+'%'", con);
                cm.Parameters.AddWithValue("@StudentName", Name);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0 AND Status=@Status AND  CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@StudentName+'%'", con);
                cm.Parameters.AddWithValue("@StudentName", Name);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@Status", Status);
            }
        }
        else if (ContactNo != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0  AND  CompanyId=@CompanyId AND SessionId=@SessionId AND ContactNo LIKE +@ContactNo+'%'", con);
                cm.Parameters.AddWithValue("@ContactNo", ContactNo);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0 AND Status=@Status AND  CompanyId=@CompanyId AND SessionId=@SessionId AND ContactNo LIKE +@ContactNo+'%'", con);
                cm.Parameters.AddWithValue("@ContactNo", ContactNo);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@Status", Status);
            }
        }
        else if (Sdate != "" && Edate != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"SELECT     Enquiry.*
FROM         Enquiry WHERE Remove=0  AND CompanyId=@CompanyId AND SessionId=@SessionId AND CONVERT(Date,EnquiryDate) Between CONVERT(Date,@Sdate) AND CONVERT(Date,@Edate)", con);
                cm.Parameters.AddWithValue("@Sdate", Convert.ToDateTime(Sdate));
                cm.Parameters.AddWithValue("@Edate", Convert.ToDateTime(Edate));
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"SELECT     Enquiry.*
FROM         Enquiry WHERE Remove=0 AND Status=@Status AND CompanyId=@CompanyId AND SessionId=@SessionId AND CONVERT(Date,EnquiryDate) Between CONVERT(Date,@Sdate) AND CONVERT(Date,@Edate)", con);
                cm.Parameters.AddWithValue("@Sdate", Convert.ToDateTime(Sdate));
                cm.Parameters.AddWithValue("@Edate", Convert.ToDateTime(Edate));
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@Status", Status);
            }

        }
        else if (PreviousSchool != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@PreviousSchool+'%'", con);
                cm.Parameters.AddWithValue("@PreviousSchool", PreviousSchool);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0 AND Status=@Status AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@PreviousSchool+'%'", con);
                cm.Parameters.AddWithValue("@PreviousSchool", PreviousSchool);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@Status", Status);
            }
        }
        else if (Village != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0  AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Village+'%'", con);
                cm.Parameters.AddWithValue("@Village", Village);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0 AND Status=@Status AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Village+'%'", con);
                cm.Parameters.AddWithValue("@Village", Village);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@Status", Status);
            }
        }
        else
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0  AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);

            }
            else
            {
                cm = new SqlCommand(@"select * from Enquiry where Remove=0 AND Status=@Status AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@Status", Status);
            }
        }
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet AdmissionPrint(string Name, string AdmissionNo, string ContactNo, string Sdate, string Edate, int CompanyId, int SessionId,string Status)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        if (Name != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@StudentName+'%'", con);
                cm.Parameters.AddWithValue("@StudentName", Name);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {

                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@StudentName+'%'", con);
                cm.Parameters.AddWithValue("@StudentName", Name);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@R1", Status);
            }
        }
        else if (AdmissionNo != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE  Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND AdmissionNo=@AdmissionNo", con);
                cm.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND AdmissionNo=@AdmissionNo", con);
                cm.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@R1", Status);
            }
        }
        else if (ContactNo != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE  Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND CompanyId=@CompanyId AND SessionId=@SessionId AND ContactNo LIKE +@ContactNo+'%'", con);
                cm.Parameters.AddWithValue("@ContactNo", ContactNo);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND CompanyId=@CompanyId AND SessionId=@SessionId AND ContactNo LIKE +@ContactNo+'%'", con);
                cm.Parameters.AddWithValue("@ContactNo", ContactNo);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId); 
                cm.Parameters.AddWithValue("@R1", Status);
            }
        }
        else if (Sdate != "" && Edate != "")
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND CONVERT(Date,AdmissionDate) Between CONVERT(Date,@Sdate) AND CONVERT(Date,@Edate)", con);
                cm.Parameters.AddWithValue("@Sdate", Convert.ToDateTime(Sdate));
                cm.Parameters.AddWithValue("@Edate", Convert.ToDateTime(Edate));
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND CONVERT(Date,AdmissionDate) Between CONVERT(Date,@Sdate) AND CONVERT(Date,@Edate)", con);
                cm.Parameters.AddWithValue("@Sdate", Convert.ToDateTime(Sdate));
                cm.Parameters.AddWithValue("@Edate", Convert.ToDateTime(Edate));
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@R1", Status);
            }
        }
        else
        {
            if (Status == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, EnrollmentNo, AdmissionDate, StudentName, ContactNo, FatherName, MotherName, DOB, EmailId, Gender, Address, Status, R1
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
                cm.Parameters.AddWithValue("@R1", Status);
            }
        }
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet CoursePrint(string Search, int CompanyId, int SessionId, string ClassName, string CourseStatus,string Section)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        if (Search != "")
        {
            if (ClassName == "ALL" && CourseStatus == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE  Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Search+'%' OR CourseName LIKE +@Search+'%'", con);
                cm.Parameters.AddWithValue("@Search", Search);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else if (ClassName != "ALL" && CourseStatus != "ALL")
            {
                if (Section == "ALL")
                {
                    cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId And R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Search+'%' OR CourseName LIKE +@Search+'%'", con);
                    cm.Parameters.AddWithValue("@Search", Search);
                    cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                    cm.Parameters.AddWithValue("@SessionId", SessionId);
                    cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                    cm.Parameters.AddWithValue("@R1", CourseStatus);
                }
                else
                {
                    cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId And R1=@R1 AND Section=@Section AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Search+'%' OR CourseName LIKE +@Search+'%'", con);
                    cm.Parameters.AddWithValue("@Search", Search);
                    cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                    cm.Parameters.AddWithValue("@SessionId", SessionId);
                    cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                    cm.Parameters.AddWithValue("@R1", CourseStatus);
                    cm.Parameters.AddWithValue("@Section", Section);
                }
            }
            else
            {
                if (ClassName != "ALL")
                {
                    if (Section == "ALL")
                    {
                        cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId  AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Search+'%' OR CourseName LIKE +@Search+'%'", con);
                        cm.Parameters.AddWithValue("@Search", Search);
                        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cm.Parameters.AddWithValue("@SessionId", SessionId);
                        cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                    }
                    else
                    {
                        cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId AND Section=@Section AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Search+'%' OR CourseName LIKE +@Search+'%'", con);
                        cm.Parameters.AddWithValue("@Search", Search);
                        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cm.Parameters.AddWithValue("@SessionId", SessionId);
                        cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                        cm.Parameters.AddWithValue("@Section", Section);
                    }
                }
                else if (CourseStatus != "ALL")
                {
                    cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StudentName LIKE +@Search+'%' OR CourseName LIKE +@Search+'%'", con);
                    cm.Parameters.AddWithValue("@Search", Search);
                    cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                    cm.Parameters.AddWithValue("@SessionId", SessionId);
                    cm.Parameters.AddWithValue("@R1", CourseStatus);
                }
            }
        }
        else
        {
            if (ClassName == "ALL" && CourseStatus == "ALL")
            {
                cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE  Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                cm.Parameters.AddWithValue("@SessionId", SessionId);
            }
            else if (ClassName != "ALL" && CourseStatus != "ALL")
            {
                if (Section == "ALL")
                {
                    cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId And R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                    cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                    cm.Parameters.AddWithValue("@SessionId", SessionId);
                    cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                    cm.Parameters.AddWithValue("@R1", CourseStatus);
                }
                else
                {
                    cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId And R1=@R1 AND Section=@Section AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                    cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                    cm.Parameters.AddWithValue("@SessionId", SessionId);
                    cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                    cm.Parameters.AddWithValue("@R1", CourseStatus);
                    cm.Parameters.AddWithValue("@Section", Section);
                }
            }
            else
            {
                if (ClassName != "ALL")
                {
                    if (Section == "ALL")
                    {
                        cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId  AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId ", con);
                        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cm.Parameters.AddWithValue("@SessionId", SessionId);
                        cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                    }
                    else
                    {
                        cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE CourseId=@CourseId AND Section=@Section AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId ", con);
                        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cm.Parameters.AddWithValue("@SessionId", SessionId);
                        cm.Parameters.AddWithValue("@CourseId", Convert.ToInt32(ClassName));
                        cm.Parameters.AddWithValue("@Section", Section);
                    }
                }
                else if (CourseStatus != "ALL")
                {
                    cm = new SqlCommand(@"SELECT     AdmissionNo, StudentName, CourseName, CourseFees, CourseDiscountType, CourseDiscount, CourseFeesAfterDisc, CourseRemarks, ContactNo, FatherName, 
                      TotalFees, R1,Section
FROM         Addmision WHERE R1=@R1 AND Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
                    cm.Parameters.AddWithValue("@CompanyId", CompanyId);
                    cm.Parameters.AddWithValue("@SessionId", SessionId);
                    cm.Parameters.AddWithValue("@R1", CourseStatus);
                }
            }
        }
        
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SendMsgAllClasess(int CompanyId, int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT  StudentName, ContactNo, FatherName, MotherName, CourseName
FROM         Addmision where R1='ACTIVE' and Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SelectFromClassData(int CompanyId, int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select CourseId,SerialNo,CourseName,FirstChildFees,UserId ,CompanyId ,SecondChildFees,ThirdChildFees ,SessionId,R1	
	                         ,R2 ,SecChildDisType,SecChildDiscount,ThirdChildDisType,ThirdChildDiscount,TotalFirstChild,TotalSecondChild,TotalThirdChild	
	                         FROM [Course] where SessionId=@SessionId and CompanyId=@CompanyId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SelectFromCousreHeadData(int CourseId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select CourseHeadId,CourseId,Head ,Amount,UserId,CompanyId,SessionId from CourseHead
		                        where CourseId=@CourseId", con);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SelectFromOtherFeesData(int CourseId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select OtherFeesId ,CourseId ,SerialNo,FeesType,Fees,CompanyId,UserId ,SessionId ,PayType
		                        from Other_Fees where CourseId=@CourseId", con);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SelectBusTransportToTransfer(int CompanyId,int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select TransportId,[From],[To],KM,RPKM,TotalFees,UserId,CompanyId,SessionId from BusTransport
            where SessionId=@SessionId and CompanyId=@CompanyId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SendBirthdayMsg(int CompanyId, int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT  a.StudentName, a.ContactNo, a.FatherName, a.MotherName, a.CourseName,a.DOB,a.PMADate,a.AdmissionId,a.BirthdayMsgFlag,a.PMAMsgFlag,s.SchoolName
FROM         Addmision a join Setting s on a.CompanyId=s.CompanyId  where R1='ACTIVE' and a.Remove=0 and cast(SUBSTRING(a.DOB, 1, 2)as int)=DAY(getdate()) and cast(SUBSTRING(a.DOB,4, 2)as int)=Month(GETDATE()) and a.BirthdayMsgFlag=0 AND a.CompanyId=@CompanyId AND a.SessionId=@SessionId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SendParentMAMsg(int CompanyId, int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT  a.StudentName, a.ContactNo, a.FatherName, a.MotherName, a.CourseName,a.DOB,a.PMADate,a.AdmissionId,a.BirthdayMsgFlag,a.PMAMsgFlag,s.SchoolName,LEFT(a.ParentContact,10)ParentMobileNo
FROM         Addmision a join Setting s on a.CompanyId=s.CompanyId  where R1='ACTIVE' and a.Remove=0 and isnull(DAY(a.PMADate),0)=DAY(getdate()) and isnull(Month(PMADate),0)=Month(GETDATE()) and a.PMAMsgFlag=0 AND a.CompanyId=@CompanyId AND a.SessionId=@SessionId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }

    public static DataSet SendStaffBirthdayMsg(int CompanyId, int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT  st.StaffName, st.ContactNo, st.FatherName, st.MotherName,st.DOB,st.BirthdayMsgFlag,st.PMAMsgFlag,s.SchoolName,st.StaffPId
FROM         Staff st join Setting s on st.CompanyId=s.CompanyId  where st.Remove=0 and isnull(DAY(st.DOB),0)=DAY(getdate()) and isnull(Month(st.DOB),0)=Month(GETDATE()) and st.BirthdayMsgFlag=0 AND st.CompanyId=@CompanyId AND st.SessionId=@SessionId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet BindScheduleGrid(int CompanyId, int SessionId,int ExamTermId,int ExamTitleId,int CourseId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        if (ExamTermId == 0 && ExamTitleId == 0 && CourseId==0)
        {
            cm = new SqlCommand(@"SELECT     ExamTerm.ExamTerm, ExamTitle.ExamTitleName, Course.CourseName, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (SubjectNameClassWise.SubjectName) 
                      ELSE (SubjectNameClassWise.SubjectName + '+' +
                          (SELECT     SubjectName
                            FROM          SubjectNameClassWise
                            WHERE      SubjectId = ExamSchedule.AdditionalSubjectId)) END AS Subjects, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.MinimumMarks) 
                      ELSE (CAST(ExamSchedule.MinimumMarks AS varchar(10))) + ',' + (CAST(ExamSchedule.AdnMinimumMarks AS varchar(10))) END AS Minimum, 
                      CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.Maximummarks) ELSE (CAST(ExamSchedule.Maximummarks AS varchar(10))) 
                      + ',' + (CAST(ExamSchedule.Adnmaximummarks AS varchar(10))) END AS Maximum, ExamSchedule.ExamScheduleId
FROM         ExamSchedule INNER JOIN
                      ExamTerm ON ExamSchedule.ExamTermId = ExamTerm.ExamTermId INNER JOIN
                      ExamTitle ON ExamSchedule.ExamTitleId = ExamTitle.ExamTitleId INNER JOIN
                      Course ON ExamSchedule.CourseId = Course.CourseId INNER JOIN
                      SubjectNameClassWise ON ExamSchedule.SubjectId = SubjectNameClassWise.SubjectId
            where ExamSchedule.Remove=0 AND ExamSchedule.CompanyId=@CompanyId AND ExamSchedule.SessionId=@SessionId", con);
            cm.Parameters.AddWithValue("@CompanyId", CompanyId);
            cm.Parameters.AddWithValue("@SessionId", SessionId);
        }
        else if (ExamTermId != 0 && ExamTitleId == 0 && CourseId == 0)
        {
            cm = new SqlCommand(@"SELECT     ExamTerm.ExamTerm, ExamTitle.ExamTitleName, Course.CourseName, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (SubjectNameClassWise.SubjectName) 
                      ELSE (SubjectNameClassWise.SubjectName + '+' +
                          (SELECT     SubjectName
                            FROM          SubjectNameClassWise
                            WHERE      SubjectId = ExamSchedule.AdditionalSubjectId)) END AS Subjects, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.MinimumMarks) 
                      ELSE (CAST(ExamSchedule.MinimumMarks AS varchar(10))) + ',' + (CAST(ExamSchedule.AdnMinimumMarks AS varchar(10))) END AS Minimum, 
                      CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.Maximummarks) ELSE (CAST(ExamSchedule.Maximummarks AS varchar(10))) 
                      + ',' + (CAST(ExamSchedule.Adnmaximummarks AS varchar(10))) END AS Maximum, ExamSchedule.ExamScheduleId
FROM         ExamSchedule INNER JOIN
                      ExamTerm ON ExamSchedule.ExamTermId = ExamTerm.ExamTermId INNER JOIN
                      ExamTitle ON ExamSchedule.ExamTitleId = ExamTitle.ExamTitleId INNER JOIN
                      Course ON ExamSchedule.CourseId = Course.CourseId INNER JOIN
                      SubjectNameClassWise ON ExamSchedule.SubjectId = SubjectNameClassWise.SubjectId
            where ExamSchedule.ExamTermId=@ExamTermId AND ExamSchedule.Remove=0 AND ExamSchedule.CompanyId=@CompanyId AND ExamSchedule.SessionId=@SessionId", con);
            cm.Parameters.AddWithValue("@CompanyId", CompanyId);
            cm.Parameters.AddWithValue("@SessionId", SessionId);
            cm.Parameters.AddWithValue("@ExamTermId", ExamTermId);
        }
        else if (ExamTitleId != 0 && ExamTitleId != 0 && CourseId == 0)
        {
            cm = new SqlCommand(@"SELECT     ExamTerm.ExamTerm, ExamTitle.ExamTitleName, Course.CourseName, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (SubjectNameClassWise.SubjectName) 
                      ELSE (SubjectNameClassWise.SubjectName + '+' +
                          (SELECT     SubjectName
                            FROM          SubjectNameClassWise
                            WHERE      SubjectId = ExamSchedule.AdditionalSubjectId)) END AS Subjects, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.MinimumMarks) 
                      ELSE (CAST(ExamSchedule.MinimumMarks AS varchar(10))) + ',' + (CAST(ExamSchedule.AdnMinimumMarks AS varchar(10))) END AS Minimum, 
                      CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.Maximummarks) ELSE (CAST(ExamSchedule.Maximummarks AS varchar(10))) 
                      + ',' + (CAST(ExamSchedule.Adnmaximummarks AS varchar(10))) END AS Maximum, ExamSchedule.ExamScheduleId
FROM         ExamSchedule INNER JOIN
                      ExamTerm ON ExamSchedule.ExamTermId = ExamTerm.ExamTermId INNER JOIN
                      ExamTitle ON ExamSchedule.ExamTitleId = ExamTitle.ExamTitleId INNER JOIN
                      Course ON ExamSchedule.CourseId = Course.CourseId INNER JOIN
                      SubjectNameClassWise ON ExamSchedule.SubjectId = SubjectNameClassWise.SubjectId
            where ExamSchedule.ExamTermId=@ExamTermId AND ExamSchedule.ExamTitleId=@ExamTitleId AND ExamSchedule.Remove=0 AND ExamSchedule.CompanyId=@CompanyId AND ExamSchedule.SessionId=@SessionId", con);
            cm.Parameters.AddWithValue("@CompanyId", CompanyId);
            cm.Parameters.AddWithValue("@SessionId", SessionId);
            cm.Parameters.AddWithValue("@ExamTermId", ExamTermId);
            cm.Parameters.AddWithValue("@ExamTitleId", ExamTitleId);
        }
        else if (ExamTitleId != 0 && ExamTitleId != 0 && CourseId != 0)
        {
            cm = new SqlCommand(@"SELECT     ExamTerm.ExamTerm, ExamTitle.ExamTitleName, Course.CourseName, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (SubjectNameClassWise.SubjectName) 
                      ELSE (SubjectNameClassWise.SubjectName + '+' +
                          (SELECT     SubjectName
                            FROM          SubjectNameClassWise
                            WHERE      SubjectId = ExamSchedule.AdditionalSubjectId)) END AS Subjects, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.MinimumMarks) 
                      ELSE (CAST(ExamSchedule.MinimumMarks AS varchar(10))) + ',' + (CAST(ExamSchedule.AdnMinimumMarks AS varchar(10))) END AS Minimum, 
                      CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.Maximummarks) ELSE (CAST(ExamSchedule.Maximummarks AS varchar(10))) 
                      + ',' + (CAST(ExamSchedule.Adnmaximummarks AS varchar(10))) END AS Maximum, ExamSchedule.ExamScheduleId
FROM         ExamSchedule INNER JOIN
                      ExamTerm ON ExamSchedule.ExamTermId = ExamTerm.ExamTermId INNER JOIN
                      ExamTitle ON ExamSchedule.ExamTitleId = ExamTitle.ExamTitleId INNER JOIN
                      Course ON ExamSchedule.CourseId = Course.CourseId INNER JOIN
                      SubjectNameClassWise ON ExamSchedule.SubjectId = SubjectNameClassWise.SubjectId
            where ExamSchedule.ExamTermId=@ExamTermId AND ExamSchedule.ExamTitleId=@ExamTitleId AND ExamSchedule.CourseId=@CourseId AND ExamSchedule.Remove=0 AND ExamSchedule.CompanyId=@CompanyId AND ExamSchedule.SessionId=@SessionId", con);
            cm.Parameters.AddWithValue("@CompanyId", CompanyId);
            cm.Parameters.AddWithValue("@SessionId", SessionId);
            cm.Parameters.AddWithValue("@ExamTermId", ExamTermId);
            cm.Parameters.AddWithValue("@ExamTitleId", ExamTitleId);
            cm.Parameters.AddWithValue("@CourseId", CourseId);
        }
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet selectForFillMarkGrid(int CompanyId, int SessionId, int ExamTitleId, int CourseId, int ExamTermId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
            cm = new SqlCommand(@"SELECT     ExamTerm.ExamTerm, ExamTitle.ExamTitleName, Course.CourseName, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (SubjectNameClassWise.SubjectName) 
                      ELSE (SubjectNameClassWise.SubjectName + '+' +
                          (SELECT     SubjectName
                            FROM          SubjectNameClassWise
                            WHERE      SubjectId = ExamSchedule.AdditionalSubjectId)) END AS Subjects, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.MinimumMarks) 
                      ELSE (CAST(ExamSchedule.MinimumMarks AS varchar(10))) + ',' + (CAST(ExamSchedule.AdnMinimumMarks AS varchar(10))) END AS Minimum, 
                      CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.Maximummarks) ELSE (CAST(ExamSchedule.Maximummarks AS varchar(10))) 
                      + ',' + (CAST(ExamSchedule.Adnmaximummarks AS varchar(10))) END AS Maximum, ExamSchedule.ExamScheduleId
FROM         ExamSchedule INNER JOIN
                      ExamTerm ON ExamSchedule.ExamTermId = ExamTerm.ExamTermId INNER JOIN
                      ExamTitle ON ExamSchedule.ExamTitleId = ExamTitle.ExamTitleId INNER JOIN
                      Course ON ExamSchedule.CourseId = Course.CourseId INNER JOIN
                      SubjectNameClassWise ON ExamSchedule.SubjectId = SubjectNameClassWise.SubjectId
            where ExamSchedule.CourseId=@CourseId AND ExamSchedule.ExamTermId=@ExamTermId AND ExamSchedule.ExamTitleId=@ExamTitleId AND ExamSchedule.Remove=0 AND ExamSchedule.CompanyId=@CompanyId AND ExamSchedule.SessionId=@SessionId", con);
            cm.Parameters.AddWithValue("@CourseId", CourseId);
            cm.Parameters.AddWithValue("@ExamTermId", ExamTermId);
            cm.Parameters.AddWithValue("@ExamTitleId", ExamTitleId);
            cm.Parameters.AddWithValue("@CompanyId", CompanyId);
            cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet selectForFillMarkGridUpdated(int CompanyId, int SessionId,int AdmissionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT     ExamTerm.ExamTerm, ExamTitle.ExamTitleName, Course.CourseName, FillMarks.SubjectName AS Subjects, FillMarks.SubjectMark, FillMarks.AdnSubjectMarks, 
                      CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.MinimumMarks) ELSE (CAST(ExamSchedule.MinimumMarks AS varchar(10))) 
                      + ',' + (CAST(ExamSchedule.AdnMinimumMarks AS varchar(10))) END AS Minimum, CASE ExamSchedule.AdditionalSubjectId WHEN 0 THEN (ExamSchedule.Maximummarks) 
                      ELSE (CAST(ExamSchedule.Maximummarks AS varchar(10))) + ',' + (CAST(ExamSchedule.Adnmaximummarks AS varchar(10))) END AS Maximum, ExamSchedule.ExamScheduleId
FROM         FillMarks INNER JOIN
                      ExamTerm ON FillMarks.ExamTermId = ExamTerm.ExamTermId INNER JOIN
                      ExamTitle ON FillMarks.ExamTitleId = ExamTitle.ExamTitleId INNER JOIN
                      Course ON FillMarks.CourseId = Course.CourseId INNER JOIN
                      ExamSchedule ON FillMarks.ExamScheduleId = ExamSchedule.ExamScheduleId
WHERE     FillMarks.AdmissionId =@AdmissionId AND FillMarks.CompanyId=@CompanyId AND FillMarks.SessionId=@SessionId", con);
        cm.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet SendMsgAllStaff(int CompanyId, int SessionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT     StaffName, ContactNo
FROM         Staff where R1='ACTIVE' and Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;

    }
    public static DataSet SendMsgSpecificClasess(int CompanyId, int SessionId,int CourseId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT  StudentName, ContactNo, FatherName, MotherName, CourseName
FROM         Addmision where R1='ACTIVE' and Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND CourseId=@CourseId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;

    }
    public static DataSet SendMsgSpecificDepartment(int CompanyId, int SessionId, string Department)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT     StaffName, ContactNo
FROM         Staff where R1='ACTIVE' and Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND Department=@Department", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@Department", Department);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;

    }
    public static DataSet SendMsgSpecificStudent(int CompanyId, int SessionId, int AdmissionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT  StudentName, ContactNo, FatherName, MotherName, CourseName
FROM         Addmision where R1='ACTIVE' and Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND AdmissionId=@AdmissionId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;

    }
    public static void updateAdmissionAreaId(int AdmissionId,int AreaId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"update Addmision set AreaId=@AreaId where AdmissionId=@AdmissionId", con);
        cm.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        cm.Parameters.AddWithValue("@AreaId", AreaId);
        con.Close();
        con.Open();
        cm.ExecuteNonQuery();
        //con.Close();
    }
    public static DataSet SendMsgSpecificStaff(int CompanyId, int SessionId, int StaffPId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"SELECT     StaffName, ContactNo
FROM         Staff where Status='ACTIVE' and Remove=0 AND CompanyId=@CompanyId AND SessionId=@SessionId AND StaffPId=@StaffPId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@StaffPId", StaffPId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;

    }
    public static DataSet GetCourseWiseDetails(int ACID, int SessionId, int CompanyId, int CourseId, int AdmissionId, string Section)
    {
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetCourseWiseDetails", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@ACID", Convert.ToInt32(ACID));
        oCmd.Parameters.AddWithValue("@SessionId", Convert.ToInt32(SessionId));
        oCmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        oCmd.Parameters.AddWithValue("@CourseId", Convert.ToInt32(CourseId));
        oCmd.Parameters.AddWithValue("@AdmissionId", Convert.ToInt32(AdmissionId));
        oCmd.Parameters.AddWithValue("@Section", Section);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();

        return Ds;
    }
    public static DataSet GetOtherFeesByCourse(int CompanyId, int SessionId, int CourseId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select * from Other_fees where Remove=0 and CompanyId=@CompanyId and SessionId=@SessionId and CourseId=@CourseId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet GetStudentByClassForSessionUpdate(int CompanyId, int SessionId, int CourseId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select AdmissionId,StudentName,FatherName,Section,CourseName,Stream,R1,AdmissionNo from Addmision where Remove=0 and CompanyId=@CompanyId and SessionId=@SessionId and CourseId=@CourseId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static string GetRegistrationFormNo(int CompanyId)
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select Isnull(MAX(Isnull(formno,0))+1,1) from RegistrationForm where FrormRegistrationId = (select top 1 FrormRegistrationId from RegistrationForm where CompanyId='" + CompanyId + "'  order by  FrormRegistrationId desc)");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);

            //cmd.Parameters.Add(new SqlParameter("@Amt", SqlDbType.Decimal));
            //cmd.Parameters["@Amt"].Value = Amt;
            
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }

        return count;
    }
    public static DataSet GetPreviousPaidFeesDetails(int CompanyId, int SessionId, int CourseId,int AdmissionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select * from payment where Isnull(previouspaid,0) > 0 and AdmissionId=@AdmissionId and ComapanyId=@CompanyId and SessionId=@SessionId and CourseId=@CourseId and Remove=0", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet GetCollectionReportDateWise(int ACID, int SessionId, int CompanyId, DateTime FD, DateTime TD)
    {
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetCollectionReportDateWise", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@ACID", Convert.ToInt32(ACID));
        oCmd.Parameters.AddWithValue("@SessionId", Convert.ToInt32(SessionId));
        oCmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        oCmd.Parameters.AddWithValue("@FDATE", FD);
        oCmd.Parameters.AddWithValue("@TODATE", TD);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static string GetNumberOfInstallment(string AdmissionNo, int CompanyId)
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select COUNT(*) from installments where admissionid=(select AdmissionId from addmision where CompanyId=" + CompanyId + " and  AdmissionNo=@AdmissionNo)");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }

        return count;
    }
    public static DataSet GetAddmisionReort(int CompanyId, string ClassName, string Section, string Area, string Gender, string Category, string Status, string Stream, string PrevSchool, string Foccupation, string Moccupation, string ChildStatus, string Religion, string BankName, string Aadhar, string Samegra, string Family, string EmailId, string From, string To, string ExtraAge)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetAddmisionReort", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        oCmd.Parameters.AddWithValue("@Class", ClassName!="ALL" ? ClassName : null);
        oCmd.Parameters.AddWithValue("@Section", Section != "ALL" ? Section : null);
        oCmd.Parameters.AddWithValue("@Area", Area != "ALL" ? Area : null);
        oCmd.Parameters.AddWithValue("@Gender", Gender != "ALL" ? Gender : null);
        oCmd.Parameters.AddWithValue("@Category", Category != "ALL" ? Category : null);
        oCmd.Parameters.AddWithValue("@Status", Status != "ALL" ? Status : null);
        oCmd.Parameters.AddWithValue("@Stream", Stream != "ALL" ? Stream : null);
        oCmd.Parameters.AddWithValue("@PrevSchool", PrevSchool != "ALL" ? PrevSchool : null);
        oCmd.Parameters.AddWithValue("@Foccupation", Foccupation != "ALL" ? Foccupation : null);
        oCmd.Parameters.AddWithValue("@Moccupation", Moccupation != "ALL" ? Moccupation : null);
        oCmd.Parameters.AddWithValue("@ChildStatus", ChildStatus != "ALL" ? ChildStatus : null);
        oCmd.Parameters.AddWithValue("@Religion", Religion != "ALL" ? Religion : null);
        oCmd.Parameters.AddWithValue("@BankName", BankName != "ALL" ? BankName : null);
        oCmd.Parameters.AddWithValue("@Aadhar", Aadhar != "ALL" ? Aadhar : null);
        oCmd.Parameters.AddWithValue("@Samegra", Samegra != "ALL" ? Samegra : null);
        oCmd.Parameters.AddWithValue("@Family", Family != "ALL" ? Family : null);
        oCmd.Parameters.AddWithValue("@EmailId", EmailId != "ALL" ? EmailId : null);
        oCmd.Parameters.AddWithValue("@From", From != "" ?  From : null);
        oCmd.Parameters.AddWithValue("@To", To != "" ? To : null);
        oCmd.Parameters.AddWithValue("@ExtraAgeDay", ExtraAge != "" ? ExtraAge : null);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet GetAddmisionReortByAndividual(int CompanyId, string StudentName, string ContactNo, string AadharCardNo, string SamegraId, string FamilyId, string AdmissionNo, string BankName1, string FatherName, string MotherName)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetAddmisionReortByAndividaul", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        oCmd.Parameters.AddWithValue("@StudentName", StudentName != "" ? StudentName : null);
        oCmd.Parameters.AddWithValue("@ContactNo", ContactNo != "" ? ContactNo : null);
        oCmd.Parameters.AddWithValue("@AadharCardNo", AadharCardNo != "" ? AadharCardNo : null);
        oCmd.Parameters.AddWithValue("@SamegraId", SamegraId != "" ? SamegraId : null);
        oCmd.Parameters.AddWithValue("@FamilyId", FamilyId != "" ? FamilyId : null);
        oCmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo != "" ? AdmissionNo : null);
        oCmd.Parameters.AddWithValue("@BankName1", BankName1 != "" ? BankName1 : null);
        oCmd.Parameters.AddWithValue("@FatherName", FatherName != "" ? FatherName : null);
        oCmd.Parameters.AddWithValue("@MotherName", MotherName != "" ? MotherName : null);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet GetAddmisionReortByChecked(string query,int CompanyId,string WhereCondition)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetAddmisionDataByCheckBox", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@SqlQuery",query);
        oCmd.Parameters.AddWithValue("@CompanyId", CompanyId.ToString());
        oCmd.Parameters.AddWithValue("@WhereCondition", WhereCondition);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }

    public static DataSet GetSecondChildReport(int CompanyId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("SecondChildReport", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet SP_FeeDueReport(int ACID, int CompanyId, int SessionId, DateTime MonthName, int CourseId, decimal MinAmount)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("SP_FeeDueReport", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@ACID", ACID);
        oCmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(CompanyId));
        oCmd.Parameters.AddWithValue("@SessionId", Convert.ToInt32(SessionId));
        oCmd.Parameters.AddWithValue("@MonthName", Convert.ToDateTime(MonthName));
        oCmd.Parameters.AddWithValue("@CourseId", CourseId);
        oCmd.Parameters.AddWithValue("@MinAmount", MinAmount);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static string SP_CheckSMSSendOrNot(int ACID,string ReportType, string Month, DateTime YearName, int CompanyId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        string count = "";
        try
        {
            SqlCommand oCmd = new SqlCommand("SP_CheckSMSSendOrNot", con);
            con.Close();
            con.Open();
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@ACID", ACID);
            oCmd.Parameters.AddWithValue("@Month", Month);
            oCmd.Parameters.AddWithValue("@ReportType", ReportType);
            oCmd.Parameters.AddWithValue("@YearName", YearName);
            oCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            count = oCmd.ExecuteScalar().ToString().Trim();
            con.Dispose();
            con.Close();
        }
        catch { }

        return count;
    }
    public static DataSet GetUpdateFeeGrid(int ACID, string AdmissionNo, int CompanyId, int SessionId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetUpdateFeeGrid", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@ACID", ACID);
        oCmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        oCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        oCmd.Parameters.AddWithValue("@SessionId", SessionId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet GetDashboard(int ACID, int CompanyId, int SessionId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetDashboard", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@ACID", ACID);
        oCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        oCmd.Parameters.AddWithValue("@SessionId", SessionId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet GetDiscountApproval(int CompanyId, int SessionId, int Action, int AdmissionId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetDiscountApproval", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@Action", Action);
        oCmd.Parameters.AddWithValue("@AdmissionId",AdmissionId);
        oCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        oCmd.Parameters.AddWithValue("@SessionId", SessionId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet GetAllFeeDetailsInEnquiry(int CompanyId, int @CourseId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("Sp_GetAllFeeDetailsInEnquiry", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        oCmd.Parameters.AddWithValue("@CourseId", @CourseId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static DataSet GetGridCompareData(int AdmissionId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetGridCompareData", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static string GetDueDate( int CompanyId)
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select top 1 TABLEVALUE from SINGLEVALUEDATA where ISDELETED=0  and STID in (select STID from SINGLEVALUETABLES where TABLENAME='SMS DUE DATE' and CompanyId=" + CompanyId + ") order by SVID DESC");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }

        return count;
    }
    public static string ExistGridUpdateApproval(int AdmissionId)
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select  Count(*)  from GridUpdateApproval where AdmissionId=@AdmissionId and UpdateStatus='Request'");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.Parameters.AddWithValue("@AdmissionId", AdmissionId);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }
        return count;
    }
    public static string GetTodayCollectionUserWise(int SessionId, int CompanyId, int UserId)
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select ISNULL(sum(totalFees),0)totalFees from Payment p where  Remove=0 and SessionId=@SessionId and ComapanyId=@CompanyId and UserId=@UserId  and  DATEPART(day, PaymentDate)=DATEPART(DAY, GETDATE()) and  DATEPART(MONTH, PaymentDate)=DATEPART(MONTH, GETDATE()) and  DATEPART(YEAR, PaymentDate)=DATEPART(YEAR, GETDATE())");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.Parameters.AddWithValue("@SessionId", SessionId);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }
        return count;
    }
    public static string GetUserNameByid(int SessionId, int CompanyId, int PaymentId )
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select UserName from [User] where UserId = (select UserId from Payment p where  Remove=0 and SessionId=@SessionId and ComapanyId=@CompanyId and PaymentId=@PaymentId )");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.Parameters.AddWithValue("@SessionId", SessionId);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            cmd.Parameters.AddWithValue("@PaymentId", PaymentId);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch { }
        return count;
    }
    public static DataSet GetReciptBal(int ACID,int AdmissionId)
    {
        SqlConnection con = new SqlConnection(Globals.connectionString);
        DataSet Ds = new DataSet();
        SqlCommand oCmd = new SqlCommand("GetReciptBal", con);
        con.Close();
        con.Open();
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("@ACID", ACID);
        oCmd.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        SqlDataAdapter Da = new SqlDataAdapter(oCmd);
        Da.Fill(Ds);
        con.Close();
        return Ds;
    }
    public static void BackupDataBase()
    {
        using (SqlConnection oCon = new SqlConnection(Globals.connectionString))
        {
            oCon.Open();
            SqlCommand oCmd = new SqlCommand("Sp_backupDb", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.ExecuteNonQuery();
            oCmd.Dispose();
            oCon.Close();
        }
    }
    public static string DATABACEBACKUPPATH()
    {
        string count = "";
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);

            StringBuilder qry = new StringBuilder();

            qry.Append("select top 1 TABLEVALUE from SINGLEVALUEDATA where STID=(select MAX(STID) from SINGLEVALUETABLES where TABLENAME='DATA BASE BACKUP PATH') order by SVID desc");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = cmd.ExecuteScalar().ToString().Trim();
            cmd.Dispose();
            cnn.Close();
        }
        catch {  }
        return count;
    }
    public static DataSet GetOtherFeesByCourse(int CompanyId, int SessionId, int CourseId, int aa, int AdmissionId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand("GetOtherFeesByAdmissionId", con);
        con.Close();
        con.Open();
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@CourseId", CourseId);
        cm.Parameters.AddWithValue("@aa", aa);
        cm.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static bool IsSingaleValueData(string NAME, int CompanyID)
    {
        SqlConnection cnn = new SqlConnection(Globals.connectionString);

        StringBuilder qry = new StringBuilder();

        qry.Append("select COUNT(*) from SINGLEVALUETABLES where TABLENAME=@TABLENAME and ISDELETED=0 and CompanyID="+CompanyID+"");

        SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);

        cmd.Parameters.Add(new SqlParameter("@TABLENAME", SqlDbType.NVarChar, 500));
        cmd.Parameters["@TABLENAME"].Value = NAME.Trim();

        cmd.CommandType = CommandType.Text;

        cnn.Open();

        int count = Convert.ToInt32(cmd.ExecuteScalar().ToString().Trim());

        cmd.Dispose();
        cnn.Close();

        if (count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static int CheckOtherFeesHeadDeleteOrNot(string FeesType, int CourseId, int CompanyId, int SessionId)
    {
        int count = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(Globals.connectionString);
            StringBuilder qry = new StringBuilder();
            qry.Append("select Count(*) from payment where CourseId=@CourseId and SessionId=@SessionId and ComapanyId=@CompanyId	and OtherFeesType like '%'+@FeesType+'%'");
            SqlCommand cmd = new SqlCommand(qry.ToString(), cnn);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            cmd.Parameters.AddWithValue("@SessionId", SessionId);
            cmd.Parameters.AddWithValue("@CourseId", CourseId);
            cmd.Parameters.AddWithValue("@FeesType", FeesType);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            cnn.Close();
        }
        catch { }
        return count;
    }
    public static DataTable GetOtherFeesByAdmissionId(int CompanyId, int SessionId, int AdmissionId)
    {
        DataTable dt = new DataTable();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select RTRIM(LTRIM(splitdata)) As HeadName from [dbo].fnSplitString(
   (SELECT REPLACE(STUFF((SELECT '&' + upper(left(OtherFeesType,1)) + substring(OtherFeesType,2,len(OtherFeesType))
            FROM Payment where 
            --OtherFeesType like '%&%' and
             AdmissionId=@AdmissionId
            and Remove=0 and OtherFees!=0 and SessionId=@SessionId and ComapanyId=@CompanyId
            FOR XML PATH('')) ,1,1,''),'amp;','') AS OtherFeesType),'&') ", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@AdmissionId", AdmissionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(dt);
        return dt;
    }

    public static DataSet GetAllFamilyIdReport(int CompanyId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
//        cm = new SqlCommand(@"select distinct FamilyId, count(FamilyId) Counts into #temp from Addmision
//                               group by  FamilyId HAVING COUNT(*) >= 2
//
//                            --select * from #temp where Counts >= 2
//                            --select distinct FamilyId from Addmision where FamilyId!=0 and FamilyId!='' and SessionId=1 and CompanyId=1
//                            select
//                            AdmissionId
//                            ,FamilyId
//                            ,AdmissionNo
//                            ,StudentName
//                            ,CourseName
//                            ,CourseId
//                            ,AdmissionDate
//                            --,ROW_NUMBER() OVER(PARTITION BY FamilyId ORDER BY AdmissionDate ASC)AS RowNo
//                            ,CASE WHEN ROW_NUMBER() OVER(PARTITION BY FamilyId ORDER BY AdmissionDate ASC) =1 THEN 'FIRST'
//                             WHEN ROW_NUMBER() OVER(PARTITION BY FamilyId ORDER BY AdmissionDate ASC) =2 THEN 'SECAND'
//                             WHEN ROW_NUMBER() OVER(PARTITION BY FamilyId ORDER BY AdmissionDate ASC) =3 THEN 'THIRD'
//                             ELSE '-' END AS StudentType
//                            from Addmision A where FamilyId in
//                            (select FamilyId from #temp where FamilyId!=0 and FamilyId!='') and CompanyId=@CompanyId order by FamilyId,AdmissionDate ASC
//
//                            drop table #temp", con);
        cm = new SqlCommand(@"select FamilyId,CompanyId,r1 into #temp from Addmision a
                               group by FamilyId,CompanyId,r1 HAVING COUNT(*) >= 2 
                    select FamilyId,CompanyId,r1 from #temp where FamilyId!=0 and FamilyId!='' and CompanyId=@CompanyId and  r1 not in('INACTIVE','TC ISSUED')
                     drop table #temp", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet GetStudentbyFamilyId(int CompanyId,int FamilyId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select AdmissionId,StudentName,AdmissionNo,CourseName from Addmision where FamilyId=@FamilyId and CompanyId=@CompanyId and Remove=0 and r1 not in('INACTIVE','TC ISSUED')", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@FamilyId", FamilyId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataSet GetFatherbyFamilyId(int CompanyId, int FamilyId)
    {
        DataSet ds = new DataSet();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select top 1 FatherName,MotherName from Addmision where FamilyId=@FamilyId and CompanyId=@CompanyId", con);
        cm.Parameters.AddWithValue("@CompanyId", CompanyId);
        cm.Parameters.AddWithValue("@FamilyId", FamilyId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(ds);
        return ds;
    }
    public static DataTable GetPaymentReceiptNoByAdmissionId(int CompanyId, int SessionId,  int AdmissionId)
    {
        DataTable dt = new DataTable();
        SqlCommand cm = new SqlCommand();
        cm = new SqlCommand(@"select PaymentId,PaymentDate ,ReceiptNo ,PaymentType ,PreviousSession ,PreviousPaid ,AdmissionFees ,(select TableValue from SINGLEVALUEDATA where SVID=payment.LateFeeType) TABLEVALUE,LateFees ,
OtherFeesType ,OtherFees ,CourseFees ,TransportFees ,Discount ,TotalFees ,PayMonths ,DiscountType  
from payment where Admissionid=@Admissionid and ComapanyId=@ComapanyId and SessionId=@SessionId order by PaymentId asc ", con);
        cm.Parameters.AddWithValue("@ComapanyId", CompanyId);
        cm.Parameters.AddWithValue("@SessionId", SessionId);
        cm.Parameters.AddWithValue("@Admissionid", AdmissionId);
        cm.CommandType = CommandType.Text;
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cm);
        da.Fill(dt);
        return dt;
    }
}