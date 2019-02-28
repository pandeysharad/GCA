using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_UpdateStream : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdown.FillClassList11th12th(ddlClass, Convert.ToInt32(Session["CompanyId"]));

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
                GridStudentWiseData.Columns[3].HeaderText = Session["StreamLableText"].ToString();
                GridStudentWiseData.Columns[4].HeaderText = Session["StreamLableText"].ToString();
            }
            GridStudentWiseData.DataBind();
        }
        else
        {
            if (GridStudentWiseData.Rows.Count > 0)
            {
                GridStudentWiseData.Columns[3].HeaderText = Session["StreamLableText"].ToString();
                GridStudentWiseData.Columns[4].HeaderText = Session["StreamLableText"].ToString();
            }
            GridStudentWiseData.DataBind();
        }
    }
    protected void GridStudentWiseData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int Index = 0; Index < GridStudentWiseData.Rows.Count; Index++)
        {
            DropDownList ddlStream = (DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlStream");
            FillDropdown.FillSTREAM(ddlStream, Convert.ToInt32(Session["CompanyId"].ToString()));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            for (int Index = 0; Index < GridStudentWiseData.Rows.Count; Index++)
            {
                DropDownList ddlStream = (DropDownList)GridStudentWiseData.Rows[Index].FindControl("ddlStream");

                if (ddlStream.SelectedItem.Text == "ALL")
                { }
                else
                {
                    int AdmissionId = Convert.ToInt32(GridStudentWiseData.DataKeys[Index].Value.ToString());
                    var _addmision = obj.Addmisions.Where(x => x.AdmissionId == AdmissionId);
                    if (obj.SP_UpdateSection(2, ddlStream.SelectedItem.Text, Convert.ToInt32(AdmissionId)) == 0)
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
                    GridStudentWiseData.Columns[3].HeaderText = Session["StreamLableText"].ToString();
                    GridStudentWiseData.Columns[4].HeaderText = Session["ClassLableText"].ToString();
                }
                GridStudentWiseData.DataBind();
            }
            else
            {
                if (GridStudentWiseData.Rows.Count > 0)
                {
                    GridStudentWiseData.Columns[3].HeaderText = Session["StreamLableText"].ToString();
                    GridStudentWiseData.Columns[4].HeaderText = Session["ClassLableText"].ToString();
                }
                GridStudentWiseData.DataBind();
            }
            Globals.Message(Page, "Stream Updated !!!");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}