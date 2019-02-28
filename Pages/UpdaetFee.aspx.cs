using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_UpdaetFee : System.Web.UI.Page
{
    public string StudentName = "", FatherName = "", ClassSection = "";
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAdminNo.Focus();
        }
    }
    protected void txtAdminNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetData();
            GetSudentInfo();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void GetData()
    {
        if (txtAdminNo.Text != string.Empty)
        {
            DataSet ds = AllMethods.GetUpdateFeeGrid(1, txtAdminNo.Text.Trim(), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
            GridMonthlyInstallments.DataSource = ds;
            GridMonthlyInstallments.DataBind();
        }
    }
    protected void UpdateFee()
    {
        if (txtAdminNo.Text != string.Empty)
        {
            var DATA = from p in  obj.Addmisions
                       where p.AdmissionNo == txtAdminNo.Text.Trim() 
                       && p.CompanyId == Convert.ToInt32(Session["CompanyId"])
                       && p.SessionId == Convert.ToInt32(Session["SessionId"])
                select p;
            int AdmissionId = Convert.ToInt32(DATA.First().AdmissionId);
            string PaymentType = DATA.First().PaymentType;
            string StudentName = DATA.First().StudentName;
            if (Convert.ToInt32(AllMethods.ExistGridUpdateApproval(AdmissionId)) == 0)
            {
                for (int Index = 0; Index < GridMonthlyInstallments.Rows.Count; Index++)
                {
                    int InstMonthlyId = Convert.ToInt32(((TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtMonthlyInstId")).Text);
                    TextBox txtCourseFees = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtCourseFees");
                    TextBox txtTransportFees = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtTransportFees");
                    TextBox txtCoursePaid = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtCoursePaid");
                    TextBox txtTransportPaid = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtTransportPaid");
                    DropDownList ddlCountries = (DropDownList)GridMonthlyInstallments.Rows[Index].FindControl("comPaymentMode");
                    //TextBox txtMonths = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtMonths");
                    TextBox txtInstallmentDate = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtInstallmentDate");
                    TextBox txtCourseBalance = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtCourseBalance");
                    TextBox txtTransportBalance = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtTransportBalance");
                    TextBox txtPayClassFees = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtPayClassFees");
                    TextBox txtPayTransportFees = (TextBox)GridMonthlyInstallments.Rows[Index].FindControl("txtPayTransportFees");
                    if (obj.SP_GridUpdateApproval(1, 0, AdmissionId, txtAdminNo.Text.Trim(), PaymentType, Convert.ToDateTime(txtInstallmentDate.Text), Convert.ToDouble(txtCourseFees.Text), Convert.ToDouble(txtTransportFees.Text), Convert.ToDouble(txtCoursePaid.Text), Convert.ToDouble(txtTransportPaid.Text), Convert.ToDouble(txtCourseBalance.Text), Convert.ToDouble(txtTransportBalance.Text), ddlCountries.SelectedItem.Text, "Request", System.DateTime.Now, InstMonthlyId.ToString(), StudentName,
                        "", Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"]),0) == 0)
                    {

                    }
                    //if (obj.SP_UpdateFeeGrid(txtAdminNo.Text.Trim(), InstMonthlyId, Convert.ToDouble(txtCourseFees.Text), Convert.ToDouble(txtTransportFees.Text), Convert.ToDateTime(txtInstallmentDate.Text), Convert.ToDouble(txtCoursePaid.Text), Convert.ToDouble(txtTransportPaid.Text), Convert.ToDouble(txtCourseBalance.Text), Convert.ToDouble(txtTransportBalance.Text), ddlCountries.SelectedItem.Text) == 0)
                    //{ }
                }    
            }
            else
            {
                Globals.Message(Page, "Already request send!!");
            }
        }
        else
        {
            Globals.Message(Page, "Please enter Addmition number!!");
        }
        GridMonthlyInstallments.DataBind();
        //GetData();
        txtAdminNo.Text = "";
        Globals.Message(Page, "request successfully sended !!");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateFee();
    }
    public void GetSudentInfo()
    {
        StudentName = ""; FatherName = ""; ClassSection = "";
        if (txtAdminNo.Text != string.Empty)
        {
            var _studentInfo = obj.Addmisions.Where(x => x.AdmissionNo == txtAdminNo.Text.Trim() 
                && x.SessionId == Convert.ToInt32(Session["SessionId"])
                && x.CompanyId == Convert.ToInt32(Session["CompanyId"]));
            StudentName = _studentInfo.First().StudentName;
            FatherName = _studentInfo.First().FatherName;
            ClassSection = _studentInfo.First().CourseName+"-"+_studentInfo.First().Section;
        }
    }
}