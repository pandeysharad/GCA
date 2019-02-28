using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_CoursePrint : System.Web.UI.Page
{
    public string print = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string AdmNo = "";
        string StudentName = "";
        string CourseName = "";
        string CourseFees = "";
        string DiscountType = "";
        string Discount = "";
        string AfterDiscount = "";
        string Section = "";
        string Contact = "";
        string Father = "";
        int sno = 1;
        string TotalFess = "";
        string Status = "";
        if (!IsPostBack)
        {
            if (Session["CompanyId"] != null)
            {
                DataSet ds = new DataSet();
                ds = AllMethods.CoursePrint(Session["ASearchCourse"].ToString(), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Session["ClassName"].ToString(), Session["CourseStatus"].ToString(), Session["ddlSection"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    print += "<table width='100%' style='text-align:center;font-size: 13px;' id='customers'>";
                    print += "<tr style='padding-top: 12px; padding-bottom: 12px;font-size:14px; background-color: #D5F9F7;'><td>Sno</td><td>Adm-No</td><td>STUDENT NAME</td><td>CONTACT NO.</td><td>FATHER NAME</td><td>CLASS NAME</td><td>CLASS FEES</td><td>DISCOUNT TYPE</td><td>DISCOUNT</td><td>AFTER DISCOUNT FEES</td><td>TOTAL FEES</td><td>STATUS</td></tr>";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        AdmNo = dr[0].ToString();
                        StudentName = dr[1].ToString();
                        CourseName = dr[2].ToString();
                        CourseFees = dr[3].ToString();
                        DiscountType = dr[4].ToString();
                        Discount = dr[5].ToString();
                        AfterDiscount = dr[6].ToString();
                        Contact = dr[8].ToString();
                        Father = dr[9].ToString();
                        TotalFess = dr[10].ToString();
                        Status = dr[11].ToString();
                        Section = dr[12].ToString();
                        print += "<tr><td>" + sno + "</td><td>" + AdmNo + "</td><td>" + StudentName + "</td><td>" + Contact + "</td><td>" + Father + "</td><td>" + CourseName + "(" + Section+")" + "</td><td>" + CourseFees + "</td><td>" + DiscountType + "</td><td>" + DiscountType + "</td><td>" + AfterDiscount + "</td><td>" + TotalFess + "</td><td>" + Status + "</td></tr>";
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
}