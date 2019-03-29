using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;

public partial class Reports_ml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.Visible = true;

        //string id = txtID.Text;
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
        DataSet ds = new DataSet();
        ds = GetData();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("bramandamDataSet", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

        }


    }
    private DataSet GetData()
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(Globals.connectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        string qry = "exec SP_GetDataMonthWise";

        SqlDataAdapter da = new SqlDataAdapter();
        cmd = new SqlCommand(qry, con);
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
    }
}