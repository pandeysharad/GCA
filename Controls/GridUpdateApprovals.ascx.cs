using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_GridUpdateApprovals : System.Web.UI.UserControl
{
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["CompanyId"] != null)
                {
                    if (Session["UserType"].ToString() == "Admin")
                    {
                        GetData();
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex)
        { }

    }

    private void GetData()
    {
        var _GridUpdateApprovals = from p in obj.GridUpdateApprovals
                                   where p.UpdateStatus == "Request" && p.isdel == false
                                   select new
                                   {
                                       AdmissionId = p.AdmissionId,
                                       AdmissionNo = p.AdmissionNo,
                                       R2 = p.R2
                                   };
        //var _GridUpdateApprovals = obj.GridUpdateApprovals.ToList().Distinct().Where(m => m.isdel == false && m.UpdateStatus == "Request");
        GridGridUpdateApprovals.DataSource = _GridUpdateApprovals.Distinct();
        GridGridUpdateApprovals.DataBind();
    }
    protected void btnApproved_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        int AdmissionId = Convert.ToInt32(GridGridUpdateApprovals.DataKeys[row.RowIndex].Values[0].ToString());
        var _GridUpdateApprovals = obj.GridUpdateApprovals.ToList().Where(m => m.isdel == false && m.UpdateStatus == "Request" && m.AdmissionId == AdmissionId);
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
}