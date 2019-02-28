using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Reports_ChildStatusReport : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    public int SrNo1 = 1;
    public string SchoolName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompanyId"] != null)
            {

                var DATA = from Cons in obj.Settings
                           where Cons.CompanyId==Convert.ToInt32(Session["CompanyId"])
                           select Cons;
                SchoolName = DATA.First().SchoolName;

                if (!IsPostBack)
                {
                    DivFamilyWiseGrid.Visible = false;
                    SecondChildFamilyID.Checked = false;
                    DataSet ds = AllMethods.GetSecondChildReport(Convert.ToInt32(Session["CompanyId"]));
                    GridCourseWiseData.DataSource = ds;
                    GridCourseWiseData.DataBind();
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=Second_Child_Status-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        if (SecondChildFamilyID.Checked)
        {
            FamilyWiseGrid.RenderControl(htw);
        }
        else
        {
            GridCourseWiseData.RenderControl(htw);
        }

        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void SecondChildFamilyID_CheckedChanged(object sender, EventArgs e)
    {
        if (SecondChildFamilyID.Checked)
        {
            DivGridCourseWiseData.Visible = false;
            DivFamilyWiseGrid.Visible = true;
            DataSet ds = AllMethods.GetAllFamilyIdReport(Convert.ToInt32(Session["CompanyId"]));
            FamilyWiseGrid.DataSource = ds;
            FamilyWiseGrid.DataBind();
        }
        else
        {
            DivFamilyWiseGrid.Visible = false;
            DivGridCourseWiseData.Visible = true;
            DataSet ds = AllMethods.GetSecondChildReport(Convert.ToInt32(Session["CompanyId"]));
            GridCourseWiseData.DataSource = ds;
            GridCourseWiseData.DataBind();
        }
    }
    protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#2E4053',this.style.color='white'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#E8F8F5',this.style.color='Black'");
                e.Row.BackColor = Color.FromName("#E8F8F5");
                int FamilyId = Convert.ToInt32(FamilyWiseGrid.DataKeys[e.Row.RowIndex].Value.ToString());
                string InstallString = "<table cellspacing='0'>";
                DataSet ds = new DataSet();
                ds = AllMethods.GetStudentbyFamilyId(Convert.ToInt32(Session["CompanyId"]), FamilyId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        InstallString += "<tr><td class='installr'>" + dr[1].ToString() + "</td><td class='installr'>" + dr[2].ToString() + "</td><td class='installr'>" + dr[3].ToString() + "</td></tr>";
                    }
                }
                InstallString += "</table>";
                e.Row.Cells[2].Text = InstallString;

               string InstallString1 = "<table cellspacing='0'>";
               DataSet ds1 = new DataSet();
               ds1 = AllMethods.GetFatherbyFamilyId(Convert.ToInt32(Session["CompanyId"]), FamilyId);
               if (ds1.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in ds1.Tables[0].Rows)
                   {
                       InstallString1 += "<tr><td class='installr'>" + dr[0].ToString() + "</td><td class='installr'>" + dr[1].ToString() + "</td></tr>";
                   }
               }
               InstallString1 += "</table>";
               e.Row.Cells[3].Text = InstallString1;

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "<table><tr><td class='installr'>STUDENT NAME</td><td class='installr'>ADMISSION NO.</td><td class='installr'>CLASS</td></tr></table>";
                e.Row.Cells[3].Text = "<table><tr><td class='installr'>FATHER NAME</td><td class='installr'>MOTHER NAME</td></tr></table>";
            }
        }
        catch (Exception ex)
        { }
    }
}