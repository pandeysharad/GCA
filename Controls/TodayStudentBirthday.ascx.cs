using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TodayStudentBirthday : System.Web.UI.UserControl
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
                    GridViewTodayBirthday.DataSource = AllMethods.StudentBirthdayDisplay(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                    GridViewTodayBirthday.DataBind();
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
}