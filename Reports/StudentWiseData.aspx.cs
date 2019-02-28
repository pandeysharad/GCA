using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_StudentWiseData : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    public string SchoolName = "";
    public static string CourseName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompanyId"] != null)
            {

                var DATA = from Cons in obj.Settings
                           select Cons;
                SchoolName = DATA.First().SchoolName;

                if (!IsPostBack)
                {
                    GetStudentWiseDetails();
                    var courses = from Cons in obj.Courses
                                  where Cons.CourseId == Convert.ToInt32(Request.QueryString["CourseId"])
                               select Cons;
                    CourseName = courses.First().CourseName;
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
    protected void GetStudentWiseDetails()
    {
        if (Session["SessionId"] != null)
        {
            DataSet ds = new DataSet();
            if (ddlSection.SelectedItem.Text =="")
            {
                ds = AllMethods.GetCourseWiseDetails(2, Convert.ToInt32(Session["SessionId"]),Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Request.QueryString["CourseId"]), 0, ddlSection.SelectedItem.Text);

            }
            else
            {
                ds = AllMethods.GetCourseWiseDetails(3, Convert.ToInt32(Session["SessionId"]),Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Request.QueryString["CourseId"]), 0, ddlSection.SelectedItem.Text);
                CourseName += " - " + ddlSection.SelectedItem.Text;
            }
            GridStudentWiseData.DataSource = ds;
            GridStudentWiseData.DataBind();
            
        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStudentWiseDetails();
    }
    protected void Print_Click(object sender, EventArgs e)
    {
        string AdmissionId = (sender as LinkButton).CommandArgument;
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('StudentFeesDetails.aspx?AdmissionId=" + AdmissionId + "','');", true);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=StudentWiseReport-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        GridStudentWiseData.RenderControl(htw);

        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}