using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Configuration;

public partial class Pages_Dashboard : System.Web.UI.Page
{
    public int srnoTop20Defaulter = 0;
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompanyId"] != null)
            {
                Session["CompanyId"] = Session["CompanyId"].ToString();
                Session["UserName"] = Session["UserName"].ToString();
                if (Session["UserType"].ToString() == "Admin")
                {
                    GetData();
                    //Get Session Value
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    if (!Page.IsPostBack)
                    {
                        Session["sessioin"] = true;
                        Configuration con = WebConfigurationManager.OpenWebConfiguration("~/Web.config/");
                        SessionStateSection section = (SessionStateSection)con.GetSection("system.web/sessionState");
                        int timeout=(int)section.Timeout.TotalMinutes * 1000 * 60;
                        ClientScript.RegisterStartupScript(this.GetType(), "sessionAlert", "sessionExpireAlert(" + timeout + ");", true);
                    }
                }
                else {
                    UpdatePanel6.Visible = false;
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
    protected void GetData()
    {
        DataSet ds = AllMethods.GetDashboard(1, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
        GridData.DataSource = ds;
        GridData.DataBind();
        var D = from Cons in obj.Settings
                where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                select Cons;
        if (GridData.Rows.Count > 0)
        {
            if (D.First().CompanyType == "college")
            {
                GridData.HeaderRow.Cells[1].Text = Session["ClassLableText"].ToString() + " Fee";
                GridData.HeaderRow.Cells[2].Text = Session["ClassLableText"].ToString() + " Paid";
                GridData.HeaderRow.Cells[3].Text = Session["ClassLableText"].ToString() + " Disc.";
                GridData.HeaderRow.Cells[4].Text = Session["ClassLableText"].ToString() + " Bal.";
            }
        }
        //Today Collection
        DataSet dsTodayCollection = AllMethods.GetDashboard(2, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
        foreach (DataRow dr in dsTodayCollection.Tables[0].Rows)
        {
            lblTodayCollection.Text = dr[0].ToString();
        }
        //Student Staus
        DataSet dsStudentStatus = AllMethods.GetDashboard(3, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
        GridStudentStaus.DataSource = dsStudentStatus;
        GridStudentStaus.DataBind();
        //Approval Students List
        var _GridUpdateApprovals = from p in obj.GridUpdateApprovals
                                   where p.UpdateStatus == "Request" && p.isdel == false
                                   select new { AdmissionId=p.AdmissionId,
                                                AdmissionNo = p.AdmissionNo,
                                                R2=p.R2
                                   };

        if (_GridUpdateApprovals.Count() > 0)
        {
            SectionGridUpdateApprovals.Visible = true;
        }
        else
        {
            SectionGridUpdateApprovals.Visible = false;
        }
        //var _GridUpdateApprovals = obj.GridUpdateApprovals.ToList().Distinct().Where(m => m.isdel == false && m.UpdateStatus == "Request");
        GridGridUpdateApprovals.DataSource = _GridUpdateApprovals.Distinct();
        GridGridUpdateApprovals.DataBind();

        GridDiscountApprovals.DataSource = AllMethods.GetDiscountApproval(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]),1,0);
        GridDiscountApprovals.DataBind();
        if (GridDiscountApprovals.Rows.Count > 0)
        {
            SelectGridDiscountApprovals.Visible = true;
        }
        else
        {
            SelectGridDiscountApprovals.Visible = false;
        }
        //Top20 Due List
        DataSet dsTop20DueList = AllMethods.GetDashboard(4, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
        GridTop20Defaulter.DataSource = dsTop20DueList;
        if (GridTop20Defaulter.Rows.Count > 0)
        {
            GridTop20Defaulter.Columns[5].HeaderText = Session["ClassLableText"].ToString();
            GridTop20Defaulter.Columns[6].HeaderText = Session["ClassLableText"].ToString()+" Bal.";
        }
        GridTop20Defaulter.DataBind();
    }
    protected void btnApproved_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        int AdmissionId = Convert.ToInt32(GridGridUpdateApprovals.DataKeys[row.RowIndex].Values[0].ToString());
        var _GridUpdateApprovals = obj.GridUpdateApprovals.ToList().Where(m => m.isdel == false && m.UpdateStatus == "Request" && m.AdmissionId==AdmissionId);
        foreach (var item in _GridUpdateApprovals)
        {
            if (obj.SP_UpdateFeeGrid(1, item.id, AdmissionId, Convert.ToInt32(item.R1), item.ClassFees, item.TransportFees, item.Date, item.ClassPaid, item.TransportPaid, item.ClassBalance, item.TransportBalance, item.PaymentStatus, Convert.ToInt32(Session["UserId"])) == 0)
            {
            
            }
        }
        GetData();
        Globals.Message(Page, "Grid successfully update !!!");
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        int AdmissionId = Convert.ToInt32(GridGridUpdateApprovals.DataKeys[row.RowIndex].Values[0].ToString());
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('../Reports/CompareGrid.aspx?AdmissionId=" + AdmissionId + "','');", true);
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        int AdmissionId = Convert.ToInt32(GridGridUpdateApprovals.DataKeys[row.RowIndex].Values[0].ToString());
        var _GridUpdateApprovals = obj.GridUpdateApprovals.ToList().Where(m => m.isdel == false && m.UpdateStatus == "Request" && m.AdmissionId == AdmissionId);
        foreach (var item in _GridUpdateApprovals)
        {
            if (obj.SP_UpdateFeeGrid(2, item.id, AdmissionId, Convert.ToInt32(item.R1), item.ClassFees, item.TransportFees, item.Date, item.ClassPaid, item.TransportPaid, item.ClassBalance, item.TransportBalance, item.PaymentStatus, Convert.ToInt32(Session["UserId"])) == 0)
            {

            }
        }
        GetData();
        Globals.Message(Page, "Grid successfully Canceled !!!");
    }
    protected void btnDiscountApproved_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        int AdmissionId = Convert.ToInt32(GridDiscountApprovals.DataKeys[row.RowIndex].Values[0].ToString());
        obj.Sp_DiscountApproval(1, AdmissionId);
        GetData();
        Globals.Message(Page, "Discount successfully approved !!!");
    }
    protected void btnDiscountCancel_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        int AdmissionId = Convert.ToInt32(GridDiscountApprovals.DataKeys[row.RowIndex].Values[0].ToString());
        obj.Sp_DiscountApproval(2, AdmissionId);
        GetData();
        Globals.Message(Page, "Discount successfully Canceled !!!");
    }
}