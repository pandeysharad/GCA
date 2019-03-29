using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_StudentStatus : System.Web.UI.UserControl
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
                    DataSet dsStudentStatus = AllMethods.GetDashboard(3, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                    GridStudentStaus.DataSource = dsStudentStatus;
                    GridStudentStaus.DataBind();
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