using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_Top20DefaulterStudent : System.Web.UI.UserControl
{
    public int srnoTop20Defaulter = 0;
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["CompanyId"] != null)
                {
                    DataSet dsTop20DueList = AllMethods.GetDashboard(4, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                    GridTop20Defaulter.DataSource = dsTop20DueList;
                    if (GridTop20Defaulter.Rows.Count > 0)
                    {
                        GridTop20Defaulter.Columns[5].HeaderText = Session["ClassLableText"].ToString();
                        GridTop20Defaulter.Columns[6].HeaderText = Session["ClassLableText"].ToString() + " Bal.";
                    }
                    GridTop20Defaulter.DataBind();
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