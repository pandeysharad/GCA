using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_UpdateSections : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public  int SrNo = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdown.FillClassList(ddlClass, Convert.ToInt32(Session["CompanyId"]));

        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedIndex > 0)
        {
            DataSet ds = AllMethods.GetStudentByClassForSessionUpdate(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlClass.SelectedValue));
            GridStudentWiseData.DataSource = ds;
            if (GridStudentWiseData.Rows.Count > 0)
            {
                GridStudentWiseData.Columns[3].HeaderText = Session["SectionLableText"].ToString();
                GridStudentWiseData.Columns[4].HeaderText = Session["SectionLableText"].ToString();
            }
            GridStudentWiseData.DataBind();
        }
        else
        {
            
            GridStudentWiseData.DataBind();
        }
    }
    protected void GridStudentWiseData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    for (int Index = 0; Index < GridStudentWiseData.Rows.Count; Index++)
        //    {
        //        int AdmissionId = Convert.ToInt32(((TextBox)GridStudentWiseData.Rows[Index].FindControl("AdmissionId")).Text);
        //        var addmisions = from Cons in obj.Addmisions
        //                         where Cons.AdmissionId == AdmissionId
        //                           && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
        //                           select Cons;
        //        if (addmisions.First().Section == "New")
        //        { }
        //        else
        //        {
        //            //DropDownList ddlSection = ((DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlSection")).SelectedItem.Text;
        //            DropDownList ddlSection = (DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlSection");
        //            ddlSection.ClearSelection();
        //            ddlSection.SelectedItem.Text = addmisions.First().Section;
        //            //foreach (ListItem li in ddlSection.Items)
        //            //{
        //            //    if (li.Text == addmisions.First().Section.ToString())
        //            //    {
        //            //        li.Selected = true;
        //            //        break;
        //            //    }
        //            //}
        //        }

        //        //if (((DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlSection")).SelectedItem.Text == "New")
        //        //{

        //        //}
        //        //else
        //        //{ 
                    
        //        //}
        //        //if (((CheckBox)GridStudentWiseData.Rows[Index].FindControl("chkOtherFee")).Checked)
        //        //{
        //        //    //OtherFee += Convert.ToDecimal(((TextBox)GridStudentWiseData.Rows[Index].FindControl("txtFees")).Text);
        //        //    //if (OtherFeeType == string.Empty)
        //        //    //{
        //        //    //    //OtherFeeType = ((TextBox)GridOtherFee.Rows[Index].FindControl("txtFeesType")).Text;
        //        //    //}
        //        //}
        //    }
        //}
        //catch (Exception)
        //{
            
        //    throw;
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            for (int Index = 0; Index < GridStudentWiseData.Rows.Count; Index++)
            {
                DropDownList ddlSection = (DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlSection");
                
                if (ddlSection.SelectedItem.Text == "New")
                { }
                else
                {
                    int AdmissionId = Convert.ToInt32(GridStudentWiseData.DataKeys[Index].Value.ToString());
                    if (obj.SP_UpdateSection(1,ddlSection.SelectedItem.Text, Convert.ToInt32(AdmissionId)) == 0)
                    { 
                    
                    }
                }
            }
            if (ddlClass.SelectedIndex > 0)
            {
                DataSet ds = AllMethods.GetStudentByClassForSessionUpdate(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlClass.SelectedValue));
                GridStudentWiseData.DataSource = ds;
                if (GridStudentWiseData.Rows.Count > 0)
                {
                    GridStudentWiseData.Columns[3].HeaderText = Session["SectionLableText"].ToString();
                    GridStudentWiseData.Columns[4].HeaderText = Session["SectionLableText"].ToString();
                }
                GridStudentWiseData.DataBind();
            }
            else
            {
                if (GridStudentWiseData.Rows.Count > 0)
                {
                    GridStudentWiseData.Columns[3].HeaderText = Session["SectionLableText"].ToString();
                    GridStudentWiseData.Columns[4].HeaderText = Session["SectionLableText"].ToString();
                }
                GridStudentWiseData.DataBind();
            }
            Globals.Message(Page, "Section Updated !!!");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}