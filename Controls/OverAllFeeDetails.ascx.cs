using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_OverAllFeeDetails : System.Web.UI.UserControl
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
                        DataSet ds = AllMethods.GetDashboard(1, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                        GridData.DataSource = ds;
                        GridData.DataBind();
                        var D = from Cons in obj.Settings
                                where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                                select Cons;
                        if (GridData.Rows.Count > 0)
                        {
                            if (D.First().CompanyType == "college")
                            {
                                GridData.HeaderRow.Cells[1].Text = Session["ClassLableText"].ToString() + " Fee";
                                GridData.HeaderRow.Cells[2].Text = Session["ClassLableText"].ToString() + " Paid";
                                GridData.HeaderRow.Cells[3].Text = Session["ClassLableText"].ToString() + " Disc.";
                                GridData.HeaderRow.Cells[4].Text = Session["ClassLableText"].ToString() + " Bal.";
                            }
                        }
                        DataSet dsTodayCollection = AllMethods.GetDashboard(2, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                        foreach (DataRow dr in dsTodayCollection.Tables[0].Rows)
                        {
                            lblTodayCollection.Text = dr[0].ToString();
                        }
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
}