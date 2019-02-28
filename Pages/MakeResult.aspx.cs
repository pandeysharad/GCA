using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MakeResult : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    public int SrNo = 1;
    int s = 0;
    LoginRole role = new LoginRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                if (Session["UserType"].ToString() != "Admin")
                {
                    IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 9
                                                   select r;
                    if (roles.Count<LoginRole>() > 0)
                    {
                        role = roles.First<LoginRole>();
                    }
                    else
                    {
                        role.Select = false;
                        role.Insert = false;
                        role.Delete = false;
                        role.Update = false;
                    }
                }
                else
                {
                    role.Select = true;
                    role.Insert = true;
                    role.Delete = true;
                    role.Update = true;
                }
            }
            if (IsPostBack == false)
            {
                if (Session["CompanyId"] != null)
                {
                    var DATA = from Cons in obj.Courses
                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons;
                    ddlClass.DataSource = DATA;
                    ddlClass.DataTextField = "CourseName";
                    ddlClass.DataValueField = "CourseId";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("--SELECT--", "0"));
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex) { }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
                var DATA = from Cons in obj.Addmisions
                           where Cons.CourseId==Convert.ToInt32(ddlClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                           select Cons;
                ddlSubjectName.DataSource = DATA;
                ddlSubjectName.DataTextField = "StudentName";
                ddlSubjectName.DataValueField = "AdmissionId";
                ddlSubjectName.DataBind();
                ddlSubjectName.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
        catch (Exception ex)
        { }
    }
}