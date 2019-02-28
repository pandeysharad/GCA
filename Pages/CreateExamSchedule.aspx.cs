using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CreateExamSchedule : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
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
                    pnlAdditional.Visible = false;

                    var DATA1 = from Cons in obj.ExamTerms
                                where Cons.Remove == false && Cons.CompanuId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons;
                    ddlTerms.DataSource = DATA1;
                    ddlTerms.DataTextField = "ExamTerm1";
                    ddlTerms.DataValueField = "ExamTermId";
                    ddlTerms.DataBind();
                    ddlTerms.Items.Insert(0, new ListItem("--SELECT--", "0"));

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
        GridSchedule.DataSource = AllMethods.BindScheduleGrid(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]),Convert.ToInt32(ddlTerms.SelectedValue),ddlExamTitle.SelectedValue!="" ? Convert.ToInt32(ddlExamTitle.SelectedValue) 
            :0,ddlClass.SelectedValue!="" ? Convert.ToInt32(ddlClass.SelectedValue) : 0);
        GridSchedule.DataBind();
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {   var DATA = from Cons in obj.SubjectNameClassWises
                       where Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                           select Cons;
                ddlSubjectName.DataSource = DATA;
                ddlSubjectName.DataTextField = "SubjectName";
                ddlSubjectName.DataValueField = "SubjectId";
                ddlSubjectName.DataBind();
                ddlSubjectName.Items.Insert(0, new ListItem("--SELECT--", "0"));

                ddlAdditionalSubjectName.DataSource = DATA;
                ddlAdditionalSubjectName.DataTextField = "SubjectName";
                ddlAdditionalSubjectName.DataValueField = "SubjectId";
                ddlAdditionalSubjectName.DataBind();
                ddlAdditionalSubjectName.Items.Insert(0, new ListItem("--SELECT--", "0"));
                GridBind();
        }
        catch (Exception ex)
        { }
    }
    protected void chkAdditionalSubject_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAdditionalSubject.Checked)
            {
                pnlAdditional.Visible = true;
            }
            else
            {
                pnlAdditional.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlTerms_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var DATA1 = from Cons in obj.ExamTitles
                        where Cons.Remove == false && Cons.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            ddlExamTitle.DataSource = DATA1;
            ddlExamTitle.DataTextField = "ExamTitleName";
            ddlExamTitle.DataValueField = "ExamTitleId";
            ddlExamTitle.DataBind();
            ddlExamTitle.Items.Insert(0, new ListItem("--SELECT--", "0"));
            GridBind();
        }
        catch (Exception ex)
        { }
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

    private void Clear()
    {
        Session["ExamScheduleId"] = null;
        pnlAdditional.Visible = false;
        chkAdditionalSubject.Checked = false;
        var DATA1 = from Cons in obj.ExamTerms
                    where Cons.Remove == false && Cons.CompanuId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
        ddlTerms.DataSource = DATA1;
        ddlTerms.DataTextField = "ExamTerm1";
        ddlTerms.DataValueField = "ExamTermId";
        ddlTerms.DataBind();
        ddlTerms.Items.Insert(0, new ListItem("--SELECT--", "0"));

        var DATA = from Cons in obj.Courses
                   where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                   select Cons;
        ddlClass.DataSource = DATA;
        ddlClass.DataTextField = "CourseName";
        ddlClass.DataValueField = "CourseId";
        ddlClass.DataBind();
        ddlClass.Items.Insert(0, new ListItem("--SELECT--","0"));
        ddlTerms.SelectedIndex = 0;
        ddlClass.SelectedIndex = 0;
        ddlTerms_SelectedIndexChanged(null, null);
        ddlClass_SelectedIndexChanged(null, null);
        txtadnMaximumMarks.Text = "";
        txtadnMinimumMarks.Text = "";
        txtMaximumMarks.Text = "";
        txtMinimumMarks.Text = "";
        GridBind();
    }
    private bool isvalid()
    {
        bool val = true;
        if(ddlTerms.SelectedIndex==0)
        {
            Globals.Message(Page, "Please select exam term...");
            ddlTerms.Focus();
            val = false;
        }
        else if (ddlExamTitle.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select exam title...");
            ddlExamTitle.Focus();
            val = false;
        }
        else if (ddlClass.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select class...");
            ddlClass.Focus();
            val = false;
        }
        else if (ddlSubjectName.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select subject name...");
            ddlSubjectName.Focus();
            val = false;
        }
        else if (txtMinimumMarks.Text=="")
        {
            Globals.Message(Page, "Please enter minimun number...");
            txtMinimumMarks.Focus();
            val = false;
        }
        else if (txtMaximumMarks.Text == "")
        {
            Globals.Message(Page, "Please enter maximum number...");
            txtMaximumMarks.Focus();
            val = false;
        }
        if (chkAdditionalSubject.Checked)
        {
            if (ddlAdditionalSubjectName.SelectedIndex == 0)
            {
                Globals.Message(Page, "Please select additional subject name...");
                ddlAdditionalSubjectName.Focus();
                val = false;
            }
            else if (txtadnMinimumMarks.Text == "")
            {
                Globals.Message(Page, "Please enter additional minimun number...");
                txtadnMinimumMarks.Focus();
                val = false;
            }
            else if (txtadnMaximumMarks.Text == "")
            {
                Globals.Message(Page, "Please enter additional minimun number...");
                txtadnMaximumMarks.Focus();
                val = false;
            }
        }
        return val;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalid())
            {
                int Totalmarks = 0;
                Totalmarks = (txtMaximumMarks.Text != "" ? Convert.ToInt32(txtMaximumMarks.Text) : 0) + (txtadnMaximumMarks.Text != "" ? Convert.ToInt32(txtadnMaximumMarks.Text) : 0);
                if (Session["ExamScheduleId"] == null)
                {
                    IEnumerable<ExamSchedule> comp = from c in obj.ExamSchedules
                                                     where c.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && c.ExamTitleId == Convert.ToInt32(ddlExamTitle.SelectedValue)
                                                     && c.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && c.SubjectId == Convert.ToInt32(ddlSubjectName.SelectedValue) && c.CompanyId == Convert.ToInt32(Session["CompanyId"]) && c.SessionId == Convert.ToInt32(Session["SessionId"])
                                                     select c;
                    if (comp.Count<ExamSchedule>() == 0)
                    {
                        if (obj.Sp_ExamSchedule(1, 0, Convert.ToInt32(ddlTerms.SelectedValue), Convert.ToInt32(ddlExamTitle.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlSubjectName.SelectedValue), txtMinimumMarks.Text,
                            txtMaximumMarks.Text, Convert.ToInt32(ddlAdditionalSubjectName.SelectedValue), txtadnMinimumMarks.Text, txtadnMaximumMarks.Text,
                            Totalmarks, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                        {
                            Globals.Message(Page, "Save Successfully...");
                            GridBind();
                            pnlAdditional.Visible = false;
                            chkAdditionalSubject.Checked = false;
                            txtadnMaximumMarks.Text = "";
                            txtadnMinimumMarks.Text = "";
                            txtMaximumMarks.Text = "";
                            txtMinimumMarks.Text = "";
                            try
                            {
                                var DATA = from Cons in obj.SubjectNameClassWises
                                           where Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                           select Cons;
                                ddlSubjectName.DataSource = DATA;
                                ddlSubjectName.DataTextField = "SubjectName";
                                ddlSubjectName.DataValueField = "SubjectId";
                                ddlSubjectName.DataBind();
                                ddlSubjectName.Items.Insert(0, new ListItem("--SELECT--", "0"));

                                ddlAdditionalSubjectName.DataSource = DATA;
                                ddlAdditionalSubjectName.DataTextField = "SubjectName";
                                ddlAdditionalSubjectName.DataValueField = "SubjectId";
                                ddlAdditionalSubjectName.DataBind();
                                ddlAdditionalSubjectName.Items.Insert(0, new ListItem("--SELECT--", "0"));
                                GridBind();
                            }
                            catch (Exception ex)
                            { }

                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Subject name of that class already scheduled...");
                        ddlSubjectName.Focus();
                    }
                }
                else if (Session["ExamScheduleId"] != null)
                {
                    if (Convert.ToInt32(ddlSubjectName.SelectedValue) == Convert.ToInt32(Session["SubjectId"]))
                    {
                        ExamScheduleUpdated(Totalmarks);
                    }
                    else
                    {
                        IEnumerable<ExamSchedule> comp = from c in obj.ExamSchedules
                                                         where c.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && c.ExamTitleId == Convert.ToInt32(ddlExamTitle.SelectedValue) && c.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && c.SubjectId == Convert.ToInt32(ddlSubjectName.SelectedValue) && c.CompanyId == Convert.ToInt32(Session["CompanyId"]) && c.SessionId == Convert.ToInt32(Session["SessionId"])
                                                         select c;
                        if (comp.Count<ExamSchedule>() == 0)
                        {
                            ExamScheduleUpdated(Totalmarks);
                        }
                        else
                        {
                            Globals.Message(Page, "Same subject name already exist...");
                            ddlSubjectName.SelectedValue = Session["SubjectId"].ToString();
                            ddlSubjectName.Focus();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    private void ExamScheduleUpdated(int Totalmarks)
    {
        if (obj.Sp_ExamSchedule(2, Convert.ToInt32(Session["ExamScheduleId"]), Convert.ToInt32(ddlTerms.SelectedValue), Convert.ToInt32(ddlExamTitle.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlSubjectName.SelectedValue), txtMinimumMarks.Text,
            txtMaximumMarks.Text, Convert.ToInt32(ddlAdditionalSubjectName.SelectedValue), txtadnMinimumMarks.Text, txtadnMaximumMarks.Text,
            Totalmarks, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            Globals.Message(Page, "Updated Successfully...");
            Clear();
           
        }
    }
    protected void ddlExamTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridBind();
        }
        catch (Exception ex)
        { }

    }
    protected void GridSchedule_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Session["ExamScheduleId"] = GridSchedule.DataKeys[e.NewSelectedIndex].Value;
            var DATA1 = from Cons in obj.ExamSchedules
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        && Cons.ExamScheduleId == Convert.ToInt32(Session["ExamScheduleId"])
                        select Cons;
            ddlTerms.ClearSelection();
            var DATA2 = from Cons in obj.ExamTerms
                        where Cons.Remove == false && Cons.CompanuId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            ddlTerms.DataSource = DATA2;
            ddlTerms.DataTextField = "ExamTerm1";
            ddlTerms.DataValueField = "ExamTermId";
            ddlTerms.DataBind();
            ddlTerms.Items.Insert(0, new ListItem("--SELECT--", "0"));

            ddlClass.ClearSelection();
            var DATA = from Cons in obj.Courses
                       where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons;
            ddlClass.DataSource = DATA;
            ddlClass.DataTextField = "CourseName";
            ddlClass.DataValueField = "CourseId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--SELECT--", "0"));

            ddlTerms.SelectedValue = DATA1.First().ExamTermId.ToString();
            ddlTerms_SelectedIndexChanged(null, null);
            ddlExamTitle.SelectedValue = DATA1.First().ExamTitleId.ToString();
            ddlClass.SelectedValue = DATA1.First().CourseId.ToString();
            ddlClass_SelectedIndexChanged(null, null);
            ddlSubjectName.SelectedValue = DATA1.First().SubjectId.ToString();
            Session["SubjectId"] = DATA1.First().SubjectId.ToString();
            txtMinimumMarks.Text = DATA1.First().MinimumMarks;
            txtMaximumMarks.Text = DATA1.First().Maximummarks;
            ddlExamTitle_SelectedIndexChanged(null, null);
            if (DATA1.First().AdditionalSubjectId != 0)
            {
                chkAdditionalSubject.Checked = true;
                pnlAdditional.Visible = true;
                ddlAdditionalSubjectName.SelectedValue = DATA1.First().AdditionalSubjectId.ToString();
                txtadnMinimumMarks.Text = DATA1.First().AdnMinimumMarks;
                txtadnMaximumMarks.Text = DATA1.First().Adnmaximummarks;
            }
            else
            {
                chkAdditionalSubject.Checked = false;
                pnlAdditional.Visible = false;
                txtadnMinimumMarks.Text = "";
                txtadnMaximumMarks.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }
}