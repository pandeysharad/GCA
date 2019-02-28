using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_DailyCollectionReciptWise : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1, SrNoCancel = 1;
    public DateTime FD = System.DateTime.Now;
    public DateTime TD = System.DateTime.Now;
    public string SchoolName = "";
    public double ClassFee = 0, TransportFee = 0, AdmFee = 0, LateFee = 0, OtherFee = 0, TotalFee = 0, Discount = 0, PervBla = 0, ClassPaid = 0, ClassBal = 0, BusPaid = 0, BusBal = 0, PervPaid = 0, PervRec = 0, TotalDue = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            if (Session["CompanyId"] != null)
            {
                var DATA = from Cons in obj.Settings
                           select Cons;
                SchoolName = DATA.First().SchoolName;
                if (!IsPostBack)
                {
                    FD = Convert.ToDateTime(Request.QueryString["FD"]);
                    TD = Convert.ToDateTime(Request.QueryString["TD"]);
                    GetCollectionData();
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        //}
        //catch (Exception ex)
        //{ }
    }
    protected void GetCollectionData()
    {
        if (Session["UserId"] != null)
        {
            DataSet ds = AllMethods.GetCollectionReportDateWise(2, Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(Session["CompanyId"]), FD, TD);
            if (ds.Tables[0].Rows.Count != null && ds.Tables[0].Rows.Count > 0)
            {
                GridCollectionReport.DataSource = ds;
                GridCollectionReport.DataBind();
                GridCollectionReport.FooterRow.Cells[0].ColumnSpan = 6;
                GridCollectionReport.FooterRow.Cells[0].Text = "TOTAL";
                GridCollectionReport.FooterRow.Cells[1].Text = PervPaid.ToString();
                GridCollectionReport.FooterRow.Cells[2].Text = PervBla.ToString();
                GridCollectionReport.FooterRow.Cells[3].Text = AdmFee.ToString();
                GridCollectionReport.FooterRow.Cells[4].Text = ClassFee.ToString();
                GridCollectionReport.FooterRow.Cells[5].Text = ClassPaid.ToString();
                GridCollectionReport.FooterRow.Cells[6].Text = ClassBal.ToString();
                GridCollectionReport.FooterRow.Cells[7].Text = TransportFee.ToString();
                GridCollectionReport.FooterRow.Cells[8].Text = BusPaid.ToString();
                GridCollectionReport.FooterRow.Cells[9].Text = BusBal.ToString();
                GridCollectionReport.FooterRow.Cells[10].Text = OtherFee.ToString();
                GridCollectionReport.FooterRow.Cells[11].Text = LateFee.ToString();
                GridCollectionReport.FooterRow.Cells[12].Text = "";
                GridCollectionReport.FooterRow.Cells[13].Text = Discount.ToString();
                GridCollectionReport.FooterRow.Cells[14].Text = TotalFee.ToString();
                GridCollectionReport.FooterRow.Cells[15].Text = TotalDue.ToString();
                GridCollectionReport.FooterRow.Cells.RemoveAt(17);
                GridCollectionReport.FooterRow.Cells.RemoveAt(16);
                GridCollectionReport.FooterRow.Cells[17].Visible = false;
                GridCollectionReport.FooterRow.Cells[16].Visible = false;

                DataSet Cancelds = AllMethods.GetCollectionReportDateWise(4, Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(Session["CompanyId"]), FD, TD);
                if (Cancelds.Tables.Count > 0)
                {
                    CancelReciepts.Visible = true;
                    GridCancel.DataSource = Cancelds;
                    GridCancel.DataBind();
                }
            }
            else
            {
                Globals.Message(Page, "Record Not Found!!!");
            }
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
        Response.AddHeader("content-disposition", "attachment;filename=FeeDueReport-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        GridCollectionReport.RenderControl(htw);
        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();

    }
    protected void GridCollectionReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PervPaid += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[6].Text) ? 0 : Convert.ToDouble(e.Row.Cells[6].Text));
            PervBla += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[7].Text) ? 0 : Convert.ToDouble(e.Row.Cells[7].Text));
            AdmFee += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[8].Text) ? 0 : Convert.ToDouble(e.Row.Cells[8].Text));
            ClassFee += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[9].Text) ? 0 : Convert.ToDouble(e.Row.Cells[9].Text));
            ClassPaid += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[10].Text) ? 0 : Convert.ToDouble(e.Row.Cells[10].Text));
            ClassBal += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[11].Text) ? 0 : Convert.ToDouble(e.Row.Cells[11].Text));
            TransportFee += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[12].Text) ? 0 : Convert.ToDouble(e.Row.Cells[12].Text));
            BusPaid += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[13].Text) ? 0 : Convert.ToDouble(e.Row.Cells[13].Text));
            BusBal += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[14].Text) ? 0 : Convert.ToDouble(e.Row.Cells[14].Text));
            OtherFee += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[15].Text) ? 0 : Convert.ToDouble(e.Row.Cells[15].Text));
            LateFee += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[16].Text) ? 0 : Convert.ToDouble(e.Row.Cells[16].Text));
            Discount += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[18].Text) ? 0 : Convert.ToDouble(e.Row.Cells[18].Text));
            TotalFee += Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[19].Text) ? 0 : Convert.ToDouble(e.Row.Cells[19].Text));
            TotalDue+= Convert.ToDouble(string.IsNullOrEmpty(e.Row.Cells[20].Text) ? 0 : Convert.ToDouble(e.Row.Cells[20].Text));
        }
    }
}