using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_CourseWiseReports : System.Web.UI.Page
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

                if (!IsPostBack)
                {
                    FillDropdown.FillSessionList(ddlSession);
                    GetCourseWiseDetails();
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
    protected void GetCourseWiseDetails()
    {
        if (ddlSession.SelectedIndex > 0)
        {
            DataSet ds = AllMethods.GetCourseWiseDetails(1, Convert.ToInt32(ddlSession.SelectedValue), Convert.ToInt32(Session["CompanyId"]), 0, 0, "");
            GridCourseWiseData.DataSource = ds;
            GridCourseWiseData.DataBind();
        }
        else
        {
            if (Session["UserId"] != null)
            {
                DataSet ds = AllMethods.GetCourseWiseDetails(1, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), 0, 0, "");
                GridCourseWiseData.DataSource = ds;
                GridCourseWiseData.DataBind();
            }
        }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCourseWiseDetails();
    }
    protected void Print_Click(object sender, EventArgs e)
    {
        string CourseId = (sender as LinkButton).CommandArgument;
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('StudentWiseData.aspx?CourseId=" + CourseId + "','');", true);
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
        Response.AddHeader("content-disposition", "attachment;filename=ClassWiseReport-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        GridCourseWiseData.RenderControl(htw);

        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}