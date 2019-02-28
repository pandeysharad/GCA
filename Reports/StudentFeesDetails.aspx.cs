using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_StudentFeesDetails : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    public string SchoolName = "";
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
                    GetStudentData();
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
    protected void GetStudentData()
    {
        var DATA = from s in obj.Addmisions
                   where s.Remove == false && s.AdmissionId == Convert.ToInt32(Request.QueryString["AdmissionId"].ToString())
                   select s;
        lblStudentName.Text = DATA.First().StudentName.ToString();
        lblFatherName.Text = DATA.First().FatherName.ToString();
        lblMobileNumber.Text = DATA.First().ContactNo.ToString();
        lblAdmissionNo.Text = DATA.First().AdmissionNo.ToString();
        lblVillage.Text = DATA.First().EnrollmentNo.ToString();
        lblClassSection.Text = DATA.First().CourseName + " - " + DATA.First().Section;
        lblPaymentType.Text = DATA.First().PaymentType;

        DataSet ds = AllMethods.GetCourseWiseDetails(4, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), 0,Convert.ToInt32(Request.QueryString["AdmissionId"].ToString()), "");
        GridStudentWiseData.DataSource = ds;
        GridStudentWiseData.DataBind();
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
        Response.AddHeader("content-disposition", "attachment;filename=StudentFeesReport - (" + lblStudentName.Text + "-"+ lblAdmissionNo.Text + ").xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //GridStudentWiseData.RenderControl(htw);
        Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}