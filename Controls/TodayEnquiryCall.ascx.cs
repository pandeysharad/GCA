using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TodayEnquiryCall : System.Web.UI.UserControl
{
    public int srno = 0;
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["CompanyId"] != null)
                {
                    EnquiryStudentNextCall.DataSource = AllMethods.GetEnquiryStudentNextCall(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                    EnquiryStudentNextCall.DataBind();
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
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}

    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        try
        {
            for (int Index = 0; Index < EnquiryStudentNextCall.Rows.Count; Index++)
            {
                TextBox txtNextCallDate = (TextBox)EnquiryStudentNextCall.Rows[Index].FindControl("txtNextCallDate");

                int EnquiryId = Convert.ToInt32(EnquiryStudentNextCall.DataKeys[Index].Value.ToString());
                if (obj.SP_SetEnquiryNextCall(EnquiryId, Convert.ToDateTime(txtNextCallDate.Text)) == 0)
                {
                    IdSuccessMsg.Visible = true;
                }
            }
            try
            {
                EnquiryStudentNextCall.DataSource = AllMethods.GetEnquiryStudentNextCall(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                EnquiryStudentNextCall.DataBind();
            }
            catch (Exception ex)
            {
                IdErrorMsg.Visible = true;
                Globals.Message(Page, "Exception " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Globals.Message(Page, "Exception " + ex.Message);
        }
    }
    protected void btnExpotToExcel_OnClick(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=ClassWiseReport-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        EnquiryStudentNextCall.RenderControl(htw);

        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}