using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;

/// <summary>
/// Summary description for FillDropdown
/// </summary>
public class FillDropdown
{
    static DataClassesDataContext obj = new DataClassesDataContext();
    
	public FillDropdown()
	{
		
	}
    public static void FillMonth(DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl.Items.Insert(1, new ListItem("April", "4"));
        ddl.Items.Insert(2, new ListItem("May", "5"));
        ddl.Items.Insert(3, new ListItem("June", "6"));
        ddl.Items.Insert(4, new ListItem("July", "7"));
        ddl.Items.Insert(5, new ListItem("August", "8"));
        ddl.Items.Insert(6, new ListItem("September", "9"));
        ddl.Items.Insert(7, new ListItem("October", "10"));
        ddl.Items.Insert(8, new ListItem("November", "11"));
        ddl.Items.Insert(9, new ListItem("December", "12"));
        ddl.Items.Insert(10, new ListItem("January", "1"));
        ddl.Items.Insert(11, new ListItem("February", "2"));
        ddl.Items.Insert(12, new ListItem("March", "3"));
    }
    //public static void FillMonth(DropDownList ddl )
    //{
    //    var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

    //    ddl.Items.Insert(0, new ListItem("--Select--", "0"));

    //    for (int i = 0; i < months.Length - 1; i++)
    //    {
    //        ddl.Items.Add(new ListItem(months[i], (i + 1).ToString()));
    //    }

    //}
    public static void FillSessionList(DropDownList ddl)
    {
        var DATA = from Cons in obj.Sessions
                   where Cons.Remove == false
                   select Cons;
        ddl.DataSource = DATA;
        ddl.DataTextField = "SessionName";
        ddl.DataValueField = "Sessionid";
        ddl.DataBind();
        ddl.Items.Insert(0, "Select Session");
        ddl.Focus();
    }
    public static void FillStudentNameByClass(DropDownList ddl, int Courseid, int CompanyId)
    {
        using (SqlConnection conn = new SqlConnection(Globals.connectionString))
        {
            DataTable dt = new DataTable();
            using (SqlCommand cm = new SqlCommand("select AdmissionId,StudentName+'/'+AdmissionNo as StudentName from Addmision where Courseid='" + Courseid + "' and CompanyId='"+CompanyId+"' order by StudentName asc", conn))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(cm);
                cm.CommandType = CommandType.Text;
                sqlDa.Fill(dt);
                ddl.DataSource = dt;
                ddl.DataTextField = "StudentName";
                ddl.DataValueField = "AdmissionId";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--SELECT STUDENT NAME--", "0"));

            }
        }
    }
    public static void FillStudentByClassAndBySection(DropDownList ddl, int Courseid, string section, int CompanyId)
    {
        using (SqlConnection conn = new SqlConnection(Globals.connectionString))
        {
            DataTable dt = new DataTable();
            using (SqlCommand cm = new SqlCommand("select AdmissionNo,StudentName+' S/O '+FatherName as StudentName from Addmision where R1 in ('ACTIVE', 'ACTIVE RTE') and courseid='" + Courseid + "' and Section='" + section + "' and CompanyId='"+CompanyId+"' order by StudentName asc", conn))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(cm);
                cm.CommandType = CommandType.Text;
                sqlDa.Fill(dt);
                ddl.DataSource = dt;
                ddl.DataTextField = "StudentName";
                ddl.DataValueField = "AdmissionNo";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--STUDENT NAME--", "0"));

            }
        }
    }
    public static void FillSectionByClass(DropDownList ddl, int Courseid, int CompanyId)
    {
        using (SqlConnection conn = new SqlConnection(Globals.connectionString))
        {
            DataTable dt = new DataTable();
            using (SqlCommand cm = new SqlCommand("select distinct section from Addmision where courseid='" + Courseid + "' and CompanyId='" + CompanyId + "'  order by  section asc", conn))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(cm);
                cm.CommandType = CommandType.Text;
                sqlDa.Fill(dt);
                ddl.DataSource = dt;
                ddl.DataTextField = "section";
                ddl.DataValueField = "section";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--SECTION--", "0"));

            }
        }
    }
    
    public static void FillStaffType(DropDownList ddl,int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("STAFF TYPE",CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    
    public static void FillSTREAM(DropDownList ddl,int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("STREAM",CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("NA", "0"));
    }
    public static void Fill12thStream(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("12TH STREAM", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillAdmissionStatus(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("STATUS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillGraduationStream(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("GRADUATION STREAM", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillPostGraduationStream(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("POST GRADUATION STREAM", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillCast(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("CAST", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillReligion(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("RELIGION", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillRegMode(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("REGMODES", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }


    public static void FillBanks(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("BANKS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }


    public static void FillDepartments(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("DEPARTMENTS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }

    public static void FillSELFTRANSPORT(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("SELF TRANSPORT", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }

    public static void FillPUBLICTRANSPORT(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("PUBLIC TRANSPORT", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }


    public static void FillDesignations(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("DESIGNATIONS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }

    public static void FillWardCategories(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("WARD CATEGORIES", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }



    public static void FillFloors(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("FLOORS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }

    public static void FillQualifications(DropDownList ddl,int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("QUALIFICATIONS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }


    public static void FillOrganisations(DropDownList ddl,int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("ORGANISATIONS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillAreas(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("AREAS", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT AREA--", "0"));
    }



    public static void FillDistrict(DropDownList ddl, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES("DISTRICT", CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT DISTRICT--", "0"));
    }
    public static void FillClassList(DropDownList ddl, int Company)
    {
        var DATA = from Cons in obj.Courses 
                   where Cons.Remove == false 
                   && Cons.CompanyId== Company
                   select Cons;
        ddl.DataSource = DATA;
        ddl.DataTextField = "CourseName";
        ddl.DataValueField = "CourseId";
        ddl.DataBind();
        ddl.Items.Insert(0, "Select");
        ddl.Focus();
 
   }
    public static void FillSINGLEVALUEDATA(DropDownList ddl, string Head, int CompanyId)
    {
        ddl.DataSource = obj.SP_GETSINGLEVALUES(Head, CompanyId);
        ddl.DataValueField = "SVID";
        ddl.DataTextField = "VALUE";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }
    public static void FillClassList11th12th(DropDownList ddl, int CompanyId)
    {
        var DATA = from Cons in obj.Courses
                   where Cons.Remove == false && Cons.CompanyId == CompanyId && (Cons.CourseName == "11TH" || Cons.CourseName == "12TH")
                   select Cons;
        ddl.DataSource = DATA;
        ddl.DataTextField = "CourseName";
        ddl.DataValueField = "CourseId";
        ddl.DataBind();
        ddl.Items.Insert(0, "Select");
        ddl.Focus();

    }
    public static void FillCompanyList(DropDownList ddl)
    {
        var DATA = from Cons in obj.Settings
                   where Cons.SchoolName!="NETRAW"
                   select Cons;
        ddl.DataSource = DATA;
        ddl.DataTextField = "SchoolName";
        ddl.DataValueField = "CompanyId";
        ddl.DataBind();
        ddl.Items.Insert(0, "Select");
        ddl.Focus();
    }
}