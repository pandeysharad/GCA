using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;


public partial class Reports_FeeDueReport : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    bool isEnableSMS = false;
    public static string Print = "";
    public int SrNo = 1;
    public string SchoolName = "";
    public double ClassFee = 0, TransportFee = 0, TotalBlance = 0, PervBla = 0;
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
                    FillDropdown.FillClassList(ddlClass, Convert.ToInt32(Session["CompanyId"]));
                    FillDropdown.FillMonth(ddlMonth);
                    Print = "";
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
    protected void SetGrid(DataSet  ds)
    {
        string ReportType = "";
        string MonthName = "";
        if (rbtDeuRpeot.Checked)
        {
            ReportType = "Yearly";
            MonthName = "Yearly";
        }
        else
        {
            ReportType = ddlReportType.SelectedItem.Text;
            MonthName = ddlMonth.SelectedItem.Text;
        }
        int dateName = Convert.ToInt32(System.DateTime.Now.Day);
        string dueDate = AllMethods.GetDueDate(Convert.ToInt32(Session["CompanyId"]));
        if (dueDate == "")
        { dueDate = "10"; }
        if (dateName <= Convert.ToInt32(dueDate))
        {
            btnSMS.Text = "Before Due Date SMS";
        }
        else
        {
            btnSMS.Text = "After Due Date SMS";
        }
        int SMSCount = Convert.ToInt32(AllMethods.SP_CheckSMSSendOrNot(1, ReportType, MonthName, System.DateTime.Now, Convert.ToInt32(Session["CompanyId"])));
        if (SMSCount == 0 && Convert.ToInt32(ddlMonth.SelectedValue) == Convert.ToInt32(System.DateTime.Now.Month))
        {
            btnSMS.Visible = true;
        }
        else
        {
            btnSMS.Visible = false;
        }
        if (ds.Tables[0].Rows.Count != null && ds.Tables[0].Rows.Count > 0)
        {
            GridDueReport.DataSource = ds;
            GridDueReport.DataBind();
            BindFooterTotal(ds);
            //var addmisionData=obj.Addmisions.Where(x => x.SessionId == Convert.ToInt32(Session["SessionId"]));
            //Double TotalAmttobecollectedoverall = 0, AmtPaidTillDate = 0, OverAllBlaAmt = 0, OverAllToBeTCllectedTillDate = 0, DueAmtTillDate = 0, OtherFee = 0, OtherFeeRec = 0, OtherFeeBla = 0, TotalBla = 0;
            //Print = "<table class='table table-striped table-bordered table-hover dataTable no-footer' cellspacing='0' rules='all' border='1' id='GridDueReport' style='width:100%;border-collapse:collapse;padding:5px;font-weight:bold'><tbody>";
            //Print += "<tr style='color:#0487B2;background-color:#EDEDED;'><th scope='col'>SN.</th><th scope='col'>Class</th><th scope='col'>ScholarNo</th><th scope='col'>Student Name</th><th scope='col'>Father Name</th><th scope='col'>Area</th><th scope='col'>ContactNo</th><th scope='col'>School Due</th><th scope='col'>Tran. Due</th><th scope='col'>Prev. Due</th><th scope='col'>Total Amt to be collected overall</th><th scope='col' style='color:#FFFFFF; background-color: Green;'>Amt Paid Till Date</th><th scope='col'>OverAll Bal Amt</th><th scope='col'>OverAll to be collected till date</th><th scope='col' style='background-color: yellow;'>Due Amt Till Date</th><th scope='col'>CM/T1/T2 Fee</th><th scope='col'>CM/T1/T2 Rec</th><th scope='col'>CM/T1/T2 Bal.</th><th scope='col'>Total Bal.</th></tr>";
            //foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            //{
            //    Double tot=Convert.ToDouble(dr[10])+Convert.ToDouble(dr[17]);
            //    if (tot >= Convert.ToInt32(string.IsNullOrWhiteSpace(txtGraterTotalAmt.Text) ? "1" : txtGraterTotalAmt.Text))
            //    {
            //        string Pervcolor = "",FontPervcolor="", T1T2CMColor = "", FontT1T2CMColor="";
            //        if (Math.Round(Convert.ToDouble(dr[10]), 0) > 0) { Pervcolor = "Red"; FontPervcolor = "#FFFFFF"; }
            //        if (Math.Round(Convert.ToDouble(dr[20]), 0) > 0) { T1T2CMColor = "Red"; FontT1T2CMColor = "#FFFFFF"; }

            //        //var _session = obj.Sessions.Where(x => x.Sessionid == Convert.ToInt32(Session["SessionId"]));
            //        //var studentSession = dr[2].ToString().Substring(0, 4);
            //        //var sessionName = _session.First().SessionName.Substring(2, 2) + _session.First().SessionName.Substring(5);
            //        //if (studentSession != sessionName)
            //        //{
            //        //    var admData=addmisionData.Where(x=>x.AdmissionNo==dr[2]);
            //        //    var cmFee = obj.Other_Fees.Where(x => x.CourseId == admData.First().CourseId
            //        //        && x.SessionId == Convert.ToInt32(Session["SessionId"])
            //        //        && x.FeesType == "CAUTION MONEY");
            //        //    var sdf = cmFee.First().Fees;
            //        //    dr[18] = Convert.ToDouble(dr[18]) - Convert.ToDouble(cmFee.First().Fees);
            //        //    dr[20] = Convert.ToDouble(dr[20]) - Convert.ToDouble(cmFee.First().Fees);
            //        //}

            //        Print += "<tr><td>" + SrNo++ + "</td><td>" + dr[1] + "</td><td>" + dr[2] + "</td><td>" + dr[3] + "</td><td>" + dr[4] + "</td><td>" + dr[5] + "</td><td>" + dr[6] + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[7]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[8]), 0) + "</td><td class='right' style='background-color:" + Pervcolor + ";color:" + FontPervcolor + "' >" + Math.Round(Convert.ToDouble(dr[10]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[13]), 0) + "</td><td  class='right' style='color:#FFFFFF; background-color: Green;'>" + Math.Round(Convert.ToDouble(dr[14]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[15]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[16]), 0) + "</td><td  class='right' style='color:red; background-color: yellow;' >" + Math.Round(Convert.ToDouble(dr[17]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[18]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[19]), 0) + "</td><td  class='right'  style='background-color:" + T1T2CMColor + ";color:" + FontT1T2CMColor + "'>" + Math.Round(Convert.ToDouble(dr[20]), 0) + "</td><td  class='right'>" + Math.Round(Convert.ToDouble(dr[17])+Convert.ToDouble(dr[20]), 0) + "</td></tr>";
            //        ClassFee += Convert.ToDouble(dr[7].ToString());
            //        TransportFee += Convert.ToDouble(dr[8].ToString());
            //        PervBla += Convert.ToDouble(dr[10].ToString());

            //        TotalAmttobecollectedoverall += Convert.ToDouble(dr[13].ToString());
            //        AmtPaidTillDate += Convert.ToDouble(dr[14].ToString());
            //        OverAllBlaAmt += Convert.ToDouble(dr[15].ToString());
            //        OverAllToBeTCllectedTillDate += Convert.ToDouble(dr[16].ToString());
            //        DueAmtTillDate += Convert.ToDouble(dr[17].ToString());
            //        OtherFee += Convert.ToDouble(dr[18].ToString());
            //        OtherFeeRec += Convert.ToDouble(dr[19].ToString());
            //        OtherFeeBla += Convert.ToDouble(dr[20].ToString());
            //        TotalBla+=Math.Round(Convert.ToDouble(dr[17]) + Convert.ToDouble(dr[20]), 0);
            //    }
            //}
            //TotalBlance = (ClassFee + TransportFee + PervBla);
            //Print += "<tr  style='text-align:Right; font-size:16px; font-style:bold;'><td  colspan='7'>TOTAL</td><td>" + ClassFee + "</td><td>" + TransportFee + "</td><td>" + PervBla + "</td><td>" + TotalAmttobecollectedoverall + "</td><td>" + AmtPaidTillDate + "</td><td>" + OverAllBlaAmt + "</td><td>" + OverAllToBeTCllectedTillDate + "</td><td>" + DueAmtTillDate + "</td><td>" + OtherFee + "</td><td>" + OtherFeeRec + "</td><td >" + OtherFeeBla + "</td><td >" + TotalBla + "</td></tr>";
            

            //Print += "</tbody></table>";
        }
        else
        {
            Print = "";
            //GridDueReport.DataBind();
            Globals.Message(Page, "Record Not Found!!!");
        }
    }
    public static string sendsmsapi(string mobileNumber, string msgtext, string msgtype)
    {
        string ucode = "text";
        if (msgtype == "Hindi")
            ucode = "unicode";

        string MSG = "http://203.129.225.68/API/WebSMS/Http/v1.0a/index.php?username=GCA-Jabalpur&password=NetrawGCA&sender=GCAjbp&to=" + mobileNumber + "&message=" + msgtext + "&reqid=1&format={json|text}&route_id=113&msgtype=" + ucode + "";
        WebClient client = new WebClient();
        client.OpenRead(MSG);
        return null;
    }
    protected void SendSMS(DataSet ds)
    {
        if (ds.Tables[0].Rows.Count != null && ds.Tables[0].Rows.Count > 0)
        {
            if (isEnableSMS == true)
            {
                var StrSessions = from Cons in obj.Sessions
                            where Cons.Sessionid == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                string SessionName = StrSessions.First().SessionName;
                SessionName = SessionName.Substring(0, SessionName.Length - 3);
                string ReportType = "";
                string MonthName = "";
                if (rbtDeuRpeot.Checked)
                {
                    ReportType = "Yearly";
                    MonthName = "Yearly";
                }
                else
                {
                    ReportType = ddlReportType.SelectedItem.Text;
                    MonthName = ddlMonth.SelectedItem.Text;
                }
                int dateName = Convert.ToInt32(System.DateTime.Now.Day);
                
                //int SMSCount = Convert.ToInt32(AllMethods.SP_CheckSMSSendOrNot(1, ReportType, MonthName, System.DateTime.Now));
                //Globals.Message(Page, SMSCount.ToString());
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToDouble(dr[9]) > 0)
                    {
                        string msg = "";
                        string dueDate = AllMethods.GetDueDate(Convert.ToInt32(Session["CompanyId"]));
                        if (dueDate == "")
                        { dueDate = "10"; }
                        if (dateName <= Convert.ToInt32(dueDate))
                        {
                            msg = "Dear " + dr[3] + " " + MonthName.Substring(0,3) + " " + SessionName + " तक की बकाया फीस " + dueDate + " " + MonthName.Substring(0,3) + " के पूर्व जमा करें";
                        }
                        else
                        {
                            //Post SMS Date ke pahale  
                            msg = "Dear " + dr[3] + " " + MonthName.Substring(0,3) + " " + SessionName + " तक की बकाया फीस जमा नहीं की गयी है कृप्या आज ही राशि का भुगतान करें";
                        }
                        string mobile = dr[6].ToString();
                        //if (mobile=="8319202155")
                        //{
                        //    sendsmsapi(mobile, msg, "Hindi"); 
                        //}
                        sendsmsapi(mobile, msg, "Hindi");
                        if (obj.SP_SMSTable(1, 0, msg, mobile, "HINDI", "ReportsFeeDueReport.aspx/GetDueFee()/SendSMS()", System.DateTime.Now, ReportType, MonthName, dr[0].ToString(), "", "", "", Convert.ToInt32(Session["CompanyId"]),Convert.ToInt32(Session["SessionId"])) == 0)
                        {

                        }
                    }
                }
                Globals.Message(Page, "Message has been successfully sent !! ");
                isEnableSMS = false;
                btnSMS.Visible = false;
            }
        }
        else
        {
            //GridDueReport.DataBind();
            Globals.Message(Page, "Record Not Found!!!");
        }
    }
    protected void GetDueFee()
    {
        if (Session["UserId"] != null)
        {
            DataSet ds = new DataSet();

            if (rbtDeuRpeot.Checked)
            {
                DateTime dateTime = System.DateTime.Now;
                //if (dateTime.Day <= 10)
                //{
                //    dateTime = dateTime.AddMonths(-1);
                //}
                string dateName1 = "28" + "/" + dateTime.Month + "/" + dateTime.Year.ToString();
                ds = AllMethods.SP_FeeDueReport(4, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToDateTime(dateName1), 0, String.IsNullOrWhiteSpace(txtGraterTotalAmt.Text) ? 1 : Convert.ToDecimal(txtGraterTotalAmt.Text));
                SetGrid(ds);
                ddlMonth.ClearSelection();
                ddlReportType.ClearSelection();
                if (isEnableSMS == true)
                {
                    SendSMS(ds);
                }
            }
            string dateName = "";
            string yearName = "";
            if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
            {
                yearName = (DateTime.Now.Year - 1).ToString();
            }
            else
            {
                yearName = (DateTime.Now.Year).ToString();
            }
            if (ddlMonth.SelectedValue == "1" || ddlMonth.SelectedValue == "2" || ddlMonth.SelectedValue == "3")
            {
                dateName = "28" + "/" + ddlMonth.SelectedValue + "/" + (Convert.ToInt32(yearName) + 1).ToString();
            }
            else
            {
                dateName = "28" + "/" + ddlMonth.SelectedValue + "/" + yearName;
            }
            if (ddlReportType.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0)
            {
                if (ddlReportType.SelectedItem.Text == "Month")
                {
                    ds = AllMethods.SP_FeeDueReport(1, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToDateTime(dateName), 0, String.IsNullOrWhiteSpace(txtGraterTotalAmt.Text) ? 1 : Convert.ToDecimal(txtGraterTotalAmt.Text));
                }
                else if (ddlReportType.SelectedItem.Text == "Installment")
                {
                    ds = AllMethods.SP_FeeDueReport(2, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToDateTime(dateName), 0, String.IsNullOrWhiteSpace(txtGraterTotalAmt.Text) ? 1 : Convert.ToDecimal(txtGraterTotalAmt.Text));
                }
                else if (ddlReportType.SelectedItem.Text == "All")
                {
                    ds = AllMethods.SP_FeeDueReport(3, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToDateTime(dateName), 0, String.IsNullOrWhiteSpace(txtGraterTotalAmt.Text) ? 1 : Convert.ToDecimal(txtGraterTotalAmt.Text));
                }
                else if (ddlReportType.SelectedItem.Text == "Class Wise" && ddlClass.SelectedIndex > 0)
                {
                    ds = AllMethods.SP_FeeDueReport(5, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToDateTime(dateName), Convert.ToInt32(ddlClass.SelectedValue), String.IsNullOrWhiteSpace(txtGraterTotalAmt.Text) ? 1 : Convert.ToDecimal(txtGraterTotalAmt.Text));
                }
                SetGrid(ds);
                if (isEnableSMS==true)
                {
                    SendSMS(ds);
                }
            }
            else if (ddlReportType.SelectedItem.Text == "Class Wise" && ddlReportType.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0)
            {
                Print = "";
            }
            
        }
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
        Response.AddHeader("content-disposition", "attachment;filename=FeeDueReport-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        Page.RenderControl(htw);
        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDueFee();
    }
    protected void GridDueReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Amt Paid Till Date
            e.Row.Cells[10].BackColor = System.Drawing.Color.Green;
            e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
            //Due Amt Till Date
            e.Row.Cells[13].BackColor = System.Drawing.Color.Yellow;
            e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
            //Total Balance
            e.Row.Cells[18].BackColor = System.Drawing.Color.Red;
            e.Row.Cells[18].ForeColor = System.Drawing.Color.White;
        }
    }
    private void BindFooterTotal(DataSet ds)
    {
        var CourseFees = ds.Tables[0].Compute("Sum(CourseFees)", string.Empty);
        GridDueReport.FooterRow.Cells[7].Text = CourseFees.ToString();
        var TransportFees = ds.Tables[0].Compute("Sum(TransportFees)", string.Empty);
        GridDueReport.FooterRow.Cells[8].Text = TransportFees.ToString();
        var CourseBalance = ds.Tables[0].Compute("Sum(CourseBalance)", string.Empty);
        GridDueReport.FooterRow.Cells[9].Text = CourseBalance.ToString();
        var TransportBalance = ds.Tables[0].Compute("Sum(TransportBalance)", string.Empty);
        GridDueReport.FooterRow.Cells[10].Text = TransportBalance.ToString();
        var PreviousBalance = ds.Tables[0].Compute("Sum(PreviousBalance)", string.Empty);
        GridDueReport.FooterRow.Cells[11].Text = PreviousBalance.ToString();
        var OverAllFee = ds.Tables[0].Compute("Sum(OverAllFee)", string.Empty);
        GridDueReport.FooterRow.Cells[12].Text = OverAllFee.ToString();
        var OverAllPaid = ds.Tables[0].Compute("Sum(OverAllPaid)", string.Empty);
        GridDueReport.FooterRow.Cells[13].Text = OverAllPaid.ToString();
        var OverAllBla = ds.Tables[0].Compute("Sum(OverAllBla)", string.Empty);
        GridDueReport.FooterRow.Cells[14].Text = OverAllBla.ToString();
        var StellBla = ds.Tables[0].Compute("Sum(StellBla)", string.Empty);
        GridDueReport.FooterRow.Cells[15].Text = StellBla.ToString();
        var StellBla1 = ds.Tables[0].Compute("Sum(StellBla1)", string.Empty);
        GridDueReport.FooterRow.Cells[16].Text = StellBla1.ToString();
        var CMT1T2 = ds.Tables[0].Compute("Sum(CMT1T2)", string.Empty);
        GridDueReport.FooterRow.Cells[17].Text = CMT1T2.ToString();
        var CMT1T2REC = ds.Tables[0].Compute("Sum(CMT1T2REC)", string.Empty);
        GridDueReport.FooterRow.Cells[18].Text = CMT1T2REC.ToString();
        var CMT1T2BLA = ds.Tables[0].Compute("Sum(CMT1T2BLA)", string.Empty);
        GridDueReport.FooterRow.Cells[19].Text = CMT1T2BLA.ToString();
        var TotBla = ds.Tables[0].Compute("Sum(TotBla)", string.Empty);
        GridDueReport.FooterRow.Cells[20].Text = TotBla.ToString();
    }
    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlReportType.SelectedItem.Text != "Class Wise" && ddlReportType.SelectedItem.Text != "" && ddlReportType.SelectedItem.Text != null)
        {
            ddlClass.Visible = false;
        }
        else if (ddlReportType.SelectedItem.Text == "Class Wise")
        {
            ddlClass.Visible = true;
            if (ddlClass.SelectedIndex == 0)
            {
                ddlClass.SelectedValue = "1";
            }

        }
        else
        {
            ddlClass.SelectedValue = "0";
        }
        GetDueFee();
    }
    protected void rbtDeuRpeot_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ShowHideFIlter();
            if (rbtDeuRpeot.Checked)
            {
                GetDueFee();
                ddlMonth.ClearSelection();
                ddlReportType.ClearSelection();
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnSMS_Click(object sender, EventArgs e)
    {
        isEnableSMS = true;
        GetDueFee();
    }
    protected void ShowHideFIlter()
    {
        if (rbtDeuRpeot.Checked)
        {
            FilterDiv.Visible = false;
            rbtDeuRpeot.Visible = true;
        }
        else
        {
            FilterDiv.Visible = true;
        }
    }
}