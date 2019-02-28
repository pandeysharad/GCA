using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ReportMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
        {
            if (rblReport.SelectedValue != string.Empty)
            {
                if (rblReport.SelectedValue == "1")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('../Reports/CollectionReportDateWise.aspx?FD=" + txtFromDate.Text + "&TD=" + txtToDate.Text + "','');", true);
                }
                else if (rblReport.SelectedValue == "2")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('../Reports/DailyCollectionReciptWise.aspx?FD=" + txtFromDate.Text + "&TD=" + txtToDate.Text + "','');", true);
                }
                else if (rblReport.SelectedValue == "3")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('../Reports/DailyCollectionReciptWiseCollColumn.aspx?FD=" + txtFromDate.Text + "&TD=" + txtToDate.Text + "','');", true);
                }
            }
            else
            {
                Globals.Message(Page, "Please Select Report!!!!");
            }
        }
        else
        {
            Globals.Message(Page, "Please Select Date!!!!");
        }
    }
}