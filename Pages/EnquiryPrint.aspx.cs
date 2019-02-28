using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_EnquiryPrint : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public string print = "";
    public int SrNo = 1;
    public string SchoolName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int Sno = 0;
        string Name = "";
        string Address = "";
        string Contact = "";
        string EmailId = "";
        string Preclass="";
        string EqrFor = "";
        string Fees = "";
        string PreviousSchool = "";
        string Village = "";
        DateTime Date, NextCall;
        string Status = "";
        if (!IsPostBack)
        {
            if (Session["CompanyId"] != null)
            {
                var DATA = from Cons in obj.Settings
                           select Cons;
                SchoolName = DATA.First().SchoolName;
                DataSet ds = new DataSet();
                ds = AllMethods.EnquiryPrit(Session["EPStudentName"].ToString(), Session["EPContactNo"].ToString(), Session["EPdtSDate"].ToString(), Session["EPdtEDate"].ToString(), Session["EPPreviousSchool"].ToString(), Session["EPVillage"].ToString(), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Session["Status"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    print += "<table width='100%' style='text-align:center;font-size: 13px;' id='customers'>";
                    print += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #66CCFF;'><td>Sno</td><td>NAME</td><td>VILLAGE</td><td>ADDRESS</td><td>CONTACT</td><td>EMAIL</td><td>PRE-SCHOOL</td><td>PRE-CLASS</td><td>ENQ-FOR</td><td>FEES</td><td>DATE</td><td>NEXT-CALL</td><td>STATUS</td></tr>";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Sno = Convert.ToInt32(dr[1]);
                        Name = dr[2].ToString();
                        Address = dr[3].ToString();
                        Contact = dr[4].ToString();
                        EmailId = dr[5].ToString();
                        Preclass = dr[6].ToString();
                        EqrFor = dr[8].ToString();
                        Fees = dr[9].ToString();
                        Date = Convert.ToDateTime(dr[10]);
                        NextCall = Convert.ToDateTime(dr[11]);
                        Status = dr[14].ToString();
                        PreviousSchool = dr[19].ToString();
                        Village = dr[20].ToString();
                        if (Status == "INTERESTED")
                        {
                            print += "<tr style='background-color:#f7ff64a6;'><td>" + Sno + "</td><td>" + Name + "</td><td>" + Village + "</td><td>" + Address + "</td><td>" + Contact + "</td><td>" + EmailId + "</td><td>" + PreviousSchool + "</td><td>" + Preclass + "</td><td>" + EqrFor + "</td><td>" + Fees + "</td><td>" + Convert.ToDateTime(Date).ToShortDateString() + "</td><td>" + Convert.ToDateTime(NextCall).ToShortDateString() + "</td><td>" + Status + "</td></tr>";
                        }
                        else
                        {
                            print += "<tr><td>" + Sno + "</td><td>" + Name + "</td><td>" + Village + "</td><td>" + Address + "</td><td>" + Contact + "</td><td>" + EmailId + "</td><td>" + PreviousSchool + "</td><td>" + Preclass + "</td><td>" + EqrFor + "</td><td>" + Fees + "</td><td>" + Convert.ToDateTime(Date).ToShortDateString() + "</td><td>" + Convert.ToDateTime(NextCall).ToShortDateString() + "</td><td>" + Status + "</td></tr>";
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
           
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=EnquiryPrint-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        EP.RenderControl(htw);
        //Page.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}