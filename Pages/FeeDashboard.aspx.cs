using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_FeeDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }
    protected void GetData()
    {
        DataSet ds = AllMethods.GetDashboard(1, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
        GridData.DataSource = ds;
        GridData.DataBind();
    }
}