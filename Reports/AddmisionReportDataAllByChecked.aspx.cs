using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_AddmisionReportDataAllByChecked : System.Web.UI.Page
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
                           where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                           select Cons;
                SchoolName = DATA.First().SchoolName;

                if (!IsPostBack)
                {
                    GetAddmisionDetails();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Print", "javascript:window.print();", true);
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
    protected void GetAddmisionDetails()
    {
        string query = Session["query"].ToString();
        string WhereCondition = Session["WhereCondition"].ToString();
        query = query.Remove(query.Length - 1);
        if (Session["UserId"] != null)
        {
            DataSet ds = AllMethods.GetAddmisionReortByChecked(query, Convert.ToInt32(Session["CompanyId"]), WhereCondition);
            GridCourseWiseData.DataSource = ds;
            GridCourseWiseData.DataBind();
        }
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