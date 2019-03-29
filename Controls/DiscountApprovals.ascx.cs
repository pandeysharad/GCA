using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_DiscountApprovals : System.Web.UI.UserControl
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
        GridDiscountApprovals.DataSource = AllMethods.GetDiscountApproval(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), 1, 0);
        GridDiscountApprovals.DataBind();
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