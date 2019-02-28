using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_AdmissionPrint : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public string print = "";
    public string StartDate = "";
    public string EndDate = "";
    public int SrNo = 1;
    public string SchoolName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string AdmNo = "";
        string EnrollNo = "";
        string StudentName = "";
        string Contact = "";
        string Father = "";
        string Mother = "";
        string DOB = "";
        string EmailId = "";
        string Gender = "";
        string Address = "";
        DateTime AdmissionDate;
        string Status = "";
        int sno=1;
        if (!IsPostBack)
        {
            if (Session["CompanyId"] != null)
            {
                var DATA = from Cons in obj.Settings
                           select Cons;
                SchoolName = DATA.First().SchoolName;
                DataSet ds = new DataSet();
                ds = AllMethods.AdmissionPrint(Session["APStudentName"].ToString(), Session["APAdminssionNo"].ToString(), Session["APContactNo"].ToString(), Session["APdtSDate"].ToString(), Session["APdtEDate"].ToString(), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Session["AdmStatus"].ToString());
                if (Session["APdtSDate"].ToString() != "" && Session["APdtEDate"].ToString() != "")
                {
                    date.Visible = true;
                    StartDate = Session["APdtSDate"].ToString();
                    EndDate = Session["APdtEDate"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    print += "<table width='100%' style='text-align:center;font-size: 13px;' id='customers'>";
                    print += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #D5F9F7;'><td>SNo</td><td>Adm-No</td><td>Adm-DATE</td><td>STUDENT NAME</td><td>CONTACT</td><td>FATHER</td><td>MOTHER</td><td>DOB</td><td>EMAIL</td><td>GENDER</td><td>VILLAGE</td><td>ADDRESS</td><td>STATUS</td></tr>";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        AdmNo = dr[0].ToString();
                        EnrollNo = dr[1].ToString();
                        AdmissionDate = Convert.ToDateTime(dr[2]);
                        StudentName = dr[3].ToString();
                        Contact = dr[4].ToString();
                        Father = dr[5].ToString();
                        Mother = dr[6].ToString();
                        DOB = dr[7].ToString();
                        EmailId = dr[8].ToString();
                        Gender = dr[9].ToString();
                        Address = dr[10].ToString();
                        Status = dr[12].ToString();
                        print += "<tr><td>" + sno + "</td><td>" + AdmNo + "</td><td>" + Convert.ToDateTime(AdmissionDate).ToShortDateString() + "</td><td>" + StudentName + "</td><td>" + Contact + "</td><td>" + Father + "</td><td>" + Mother + "</td><td>" + DOB + "</td><td>" + EmailId + "</td><td>" + Gender + "</td><td>" + EnrollNo + "</td><td>" + Address + "</td><td>" + Status + "</td></tr>";
                        sno++;
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
        Response.AddHeader("content-disposition", "attachment;filename=Addmision Data-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
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