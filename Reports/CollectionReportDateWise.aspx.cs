using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_CollectionReportDateWise : System.Web.UI.Page
{
    public string SchoolName = "";
    public int SrNo=1;
    public DateTime FD = System.DateTime.Now;
    public DateTime TD = System.DateTime.Now;
    public double totClass = 0, totTrans = 0, totOther = 0, totprev = 0, totAdm = 0, totLateFee = 0;

    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null && Session["SessionId"].ToString() != null)
        {
            var DATA = from Cons in obj.Settings
                       select Cons;
            SchoolName = DATA.First().SchoolName;
            FD = Convert.ToDateTime(Request.QueryString["FD"]);
            TD = Convert.ToDateTime(Request.QueryString["TD"]);
            GetCollectionData();
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
    protected void GetCollectionData()
    {
        try
        {
            DataSet ds = AllMethods.GetCollectionReportDateWise(1, Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(Session["CompanyId"]), FD, TD);
            GridData.DataSource = ds;
            GridData.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridData.FooterRow.Cells[0].ColumnSpan = 4;
                GridData.FooterRow.Cells[0].Text = "TOTAL";
                GridData.FooterRow.Cells[1].Text = totClass.ToString();
                GridData.FooterRow.Cells[4].Text = totTrans.ToString();
                GridData.FooterRow.Cells[7].Text = totOther.ToString();
                GridData.FooterRow.Cells[8].Text = totprev.ToString();
                GridData.FooterRow.Cells[9].Text = totAdm.ToString();
                GridData.FooterRow.Cells[10].Text = totLateFee.ToString();

                GridData.FooterRow.Cells.RemoveAt(11);
                GridData.FooterRow.Cells.RemoveAt(12);
                GridData.FooterRow.Cells[11].Visible = false;
            }
            else
            {
                Globals.Message(Page, "Record Not Found!!!");
            }
            
            //GridData.FooterRow.Cells.RemoveAt(13);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
    protected void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            totClass += Convert.ToDouble(e.Row.Cells[4].Text);
            totTrans += Convert.ToDouble(e.Row.Cells[7].Text);
            totOther += Convert.ToDouble(e.Row.Cells[10].Text);
            totprev += Convert.ToDouble(e.Row.Cells[11].Text);
            totAdm += Convert.ToDouble(e.Row.Cells[12].Text);
            totLateFee += Convert.ToDouble(e.Row.Cells[13].Text);
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
        Response.AddHeader("content-disposition", "attachment;filename=CollectionReport-" + FD.ToShortDateString() + " To " + TD.ToShortDateString() + ".xls");
        Response.Charset = "";        
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        GridData.RenderControl(htw);
        
        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}