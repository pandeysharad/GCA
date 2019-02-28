using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_CompareGrid : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int AdmissionId=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdmissionId = Convert.ToInt32(Request.QueryString["AdmissionId"]);
            Getdata();
        }
    }
    protected void Getdata()
    {
        //Updated Data
        var _GridUpdateApprovals = from m in obj.GridUpdateApprovals
                                   where m.isdel == false && m.UpdateStatus == "Request" && m.AdmissionId == AdmissionId
                                   select m;
        //var _GridUpdateApprovals = obj.GridUpdateApprovals.ToList().Where(m => m.isdel == false && m.UpdateStatus == "Request" && m.AdmissionId == AdmissionId);
        GridUpdateApprovals.DataSource = _GridUpdateApprovals;
        GridUpdateApprovals.DataBind();
        //Live / Current Data
        DataSet dsInstallmentData = AllMethods.GetGridCompareData(AdmissionId);
        GridLiveData.DataSource = dsInstallmentData;
        GridLiveData.DataBind();
    }
}