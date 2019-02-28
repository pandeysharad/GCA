using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SubjectCreation : System.Web.UI.Page
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
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 8
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

                    GridBind();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex) { }
    }

    private void GridBind()
    {
        if (ddlClass.SelectedIndex != 0)
        {
            var DATA2 = from Cons in obj.SubjectNameClassWises
                        from C in obj.Courses
                        where C.CourseId == Cons.CourseId
                        && Cons.Remove == false && Cons.CourseId==Convert.ToInt32(ddlClass.SelectedValue)
                        select new
                        {
                            SubjectId = Cons.SubjectId,
                            CourseName = C.CourseName,
                            SubjectName = Cons.SubjectName,
                            SubjectShortName = Cons.SubjectShortName
                        };
            GridSubjects.DataSource = DATA2.Distinct();
            GridSubjects.DataBind();
        }
        else
        {
            var DATA2 = from Cons in obj.SubjectNameClassWises
                        from C in obj.Courses
                        where C.CourseId == Cons.CourseId
                        && Cons.Remove == false
                        select new
                        {
                            SubjectId = Cons.SubjectId,
                            CourseName = C.CourseName,
                            SubjectName = Cons.SubjectName,
                            SubjectShortName = Cons.SubjectShortName
                        };
            GridSubjects.DataSource = DATA2.Distinct();
            GridSubjects.DataBind();
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridBind();
            if (ddlClass.SelectedIndex != 0)
            {
                txtSubjectName.Focus();
            }

        }
        catch (Exception ex)
        { }
    }
    protected void chkShortName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkShortName.Checked)
            {
                txtSubjectShortName.Visible = true;
                txtSubjectShortName.Focus();
            }
            else
            {
                txtSubjectShortName.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["SubjectId"] == null)
            {
                IEnumerable<SubjectNameClassWise> comp = from c in obj.SubjectNameClassWises
                                                        where c.CourseId==Convert.ToInt32(ddlClass.SelectedValue) && c.SubjectName == txtSubjectName.Text
                                                        select c;
                if (comp.Count<SubjectNameClassWise>() == 0)
                {
                    if (obj.Sp_SubjectNameClassWise(1, 0, Convert.ToInt32(ddlClass.SelectedValue), txtSubjectName.Text, chkShortName.Checked ? txtSubjectShortName.Text : "", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        Globals.Message(Page, "Subject craeted successfully....");
                        Clear1();
                    }
                }
                else
                {
                    Globals.Message(Page, "Same subject name is already exist....");
                    txtSubjectName.Focus();
                }
            }
            else if (Session["SubjectId"] != null)
            {
                if (txtSubjectName.Text.ToUpper() == Session["txtSubjectName"].ToString().ToUpper())
                {
                    UpdateSubject();
                }
                else
                {
                    IEnumerable<SubjectNameClassWise> comp = from c in obj.SubjectNameClassWises
                                                             where c.SubjectName == txtSubjectName.Text && c.CourseId == Convert.ToInt32(ddlClass.SelectedValue)
                                                  select c;
                    if (comp.Count<SubjectNameClassWise>() == 0)
                    {
                        UpdateSubject();
                    }
                    else
                    {
                        Globals.Message(Page, "Same Subject already exist in this class...");
                        txtSubjectName.Text = Session["txtSubjectName"].ToString();
                        txtSubjectName.Focus();
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }

    private void UpdateSubject()
    {
        if (obj.Sp_SubjectNameClassWise(2, Convert.ToInt32(Session["SubjectId"]), Convert.ToInt32(ddlClass.SelectedValue), txtSubjectName.Text, chkShortName.Checked ? txtSubjectShortName.Text : "", Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            Globals.Message(Page, "Subject updated successfully....");
            Clear();
        }
    }

    private void Clear1()
    {
        txtSubjectName.Text = "";
        txtSubjectShortName.Text = "";
        chkShortName.Checked = false;
        txtSubjectShortName.Visible = false;
        GridBind();
        txtSubjectName.Focus();
    }
    private void Clear()
    {
        Session["SubjectId"] = null;
        txtSubjectName.Text = "";
        txtSubjectShortName.Text = "";
        chkShortName.Checked = false;
        txtSubjectShortName.Visible = false;
        var DATA = from Cons in obj.Courses
                   where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                   select Cons;
        ddlClass.DataSource = DATA;
        ddlClass.DataTextField = "CourseName";
        ddlClass.DataValueField = "CourseId";
        ddlClass.DataBind();
        ddlClass.Items.Insert(0, new ListItem("--SELECT--", "0"));
        ddlClass.SelectedIndex = 0;
        GridBind();
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch (Exception ex)
        { }
    }
    protected void GridSubjects_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Session["SubjectId"] = GridSubjects.DataKeys[e.NewSelectedIndex].Value;
            var DATA1 = from Cons in obj.SubjectNameClassWises
                        where Cons.Remove == false && Cons.SubjectId == Convert.ToInt32(Session["SubjectId"])
                        select Cons;
            ddlClass.SelectedValue = DATA1.First().CourseId.ToString();
            txtSubjectName.Text = DATA1.First().SubjectName;
            Session["txtSubjectName"] = DATA1.First().SubjectName;
            if (DATA1.First().SubjectShortName != "")
            {
                chkShortName.Checked = true;
                txtSubjectShortName.Visible = true;
                txtSubjectShortName.Text = DATA1.First().SubjectShortName;
            }
            else
            {
                chkShortName.Checked = false;
                txtSubjectShortName.Visible = false;
                txtSubjectShortName.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }
}