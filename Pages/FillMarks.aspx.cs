using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FillMarks : System.Web.UI.Page
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
            var DATA1 = from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            ddlStudentName.DataSource = DATA1;
            ddlStudentName.DataTextField = "StudentName";
            ddlStudentName.DataValueField = "AdmissionId";
            ddlStudentName.DataBind();
            ddlStudentName.Items.Insert(0, new ListItem("--SELECT--", "0"));
            BindGrids();
            
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
            BindGrids();
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
        var DATA2 = from Cons in obj.ExamTitles
                    where Cons.Remove == false && Cons.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
        ddlExamTitle.DataSource = DATA2;
        ddlExamTitle.DataTextField = "ExamTitleName";
        ddlExamTitle.DataValueField = "ExamTitleId";
        ddlExamTitle.DataBind();
        ddlExamTitle.Items.Insert(0, new ListItem("--SELECT--", "0"));
        var DATA3 = from Cons in obj.Addmisions
                    where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
        ddlStudentName.DataSource = DATA3;
        ddlStudentName.DataTextField = "StudentName";
        ddlStudentName.DataValueField = "AdmissionId";
        ddlStudentName.DataBind();
        ddlStudentName.Items.Insert(0, new ListItem("--SELECT--", "0"));
        BindGrids();
    }
    private bool Isvalid()
    {
        bool Val = true;

        if (ddlClass.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select class....");
            ddlClass.Focus();
            Val = false;
        }
        else if (ddlTerms.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select exam term....");
            ddlTerms.Focus();
            Val = false;
        }
        else if (ddlExamTitle.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select exam title....");
            ddlExamTitle.Focus();
            Val = false;
        }
        else if (ddlStudentName.SelectedIndex == 0)
        {
            Globals.Message(Page, "Please select student....");
            ddlStudentName.Focus();
            Val = false;
        }
        else if (GridFillMarks.Rows.Count < 0)
        {
            Globals.Message(Page, "Please schedule exam first...");
            Val = false;
        }
        return Val;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Isvalid())
            {
                if (Session["AdmisId"] == null)
                {
                    for (int i = 0; i < GridFillMarks.Rows.Count; i++)
                    {
                        int ExamScheduleId = Convert.ToInt32(GridFillMarks.DataKeys[i].Value.ToString());
                        string SubjectName = GridFillMarks.Rows[i].Cells[0].Text;
                        TextBox txtSubjectMarks = ((TextBox)GridFillMarks.Rows[i].FindControl("txtMarks"));
                        TextBox txtAdnMarks = ((TextBox)GridFillMarks.Rows[i].FindControl("txtAdnMarks"));
                        obj.Sp_FillMarks(1,0, Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlTerms.SelectedValue), Convert.ToInt32(ddlExamTitle.SelectedValue), Convert.ToInt32(ddlStudentName.SelectedValue), ExamScheduleId, SubjectName, txtSubjectMarks.Text != "" ? Convert.ToInt32(txtSubjectMarks.Text) : 0, txtAdnMarks.Text != "" ?
                        Convert.ToInt32(txtAdnMarks.Text) : 0, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                    }
                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    ddlStudentName.DataSource = DATA1;
                    ddlStudentName.DataTextField = "StudentName";
                    ddlStudentName.DataValueField = "AdmissionId";
                    ddlStudentName.DataBind();
                    ddlStudentName.Items.Insert(0, new ListItem("--SELECT--", "0"));
                    BindGrids();
                }
                else if (Session["AdmisId"] != null)
                {
                    for(int i=0;i<ddlFillMarksId.Items.Count;i++)
                    {
                        int ExamScheduleId = Convert.ToInt32(GridFillMarks.DataKeys[i].Value.ToString());
                        string SubjectName = GridFillMarks.Rows[i].Cells[0].Text;
                        TextBox txtSubjectMarks = ((TextBox)GridFillMarks.Rows[i].FindControl("txtMarks"));
                        TextBox txtAdnMarks = ((TextBox)GridFillMarks.Rows[i].FindControl("txtAdnMarks"));
                        obj.Sp_FillMarks(2,Convert.ToInt32(ddlFillMarksId.Items[i].Value), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlTerms.SelectedValue), Convert.ToInt32(ddlExamTitle.SelectedValue), Convert.ToInt32(ddlStudentName.SelectedValue), ExamScheduleId, SubjectName, txtSubjectMarks.Text != "" ? Convert.ToInt32(txtSubjectMarks.Text) : 0, txtAdnMarks.Text != "" ?
                        Convert.ToInt32(txtAdnMarks.Text) : 0, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
 
                    }
                    BindGrids();
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlExamTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrids();
    }

    private void BindGrids()
    {
        try
        {
            GridFillMarks.DataSource = AllMethods.selectForFillMarkGrid(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlExamTitle.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlTerms.SelectedValue));
            GridFillMarks.DataBind();
        }
        catch (Exception ex)
        { }
        try
        {
            var inv = from i in obj.FillMarks
                      from c in obj.Courses
                      from ET in obj.ExamTerms
                      from ETI in obj.ExamTitles
                      from a in obj.Addmisions
                      where c.CourseId == i.CourseId
                      && ET.ExamTermId == i.ExamTermId
                      && ETI.ExamTitleId == i.ExamTitleId
                      && a.AdmissionId == i.AdmissionId
                      && i.Remove == false && i.CompanyId == Convert.ToInt32(Session["CompanyId"]) && i.SessionId == Convert.ToInt32(Session["SessionId"])
                      && i.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && i.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && i.ExamTitleId == Convert.ToInt32(ddlExamTitle.SelectedValue)
                      orderby i.AdmissionId.Value ascending
                      select new
                      {
                          StudentName = a.StudentName,
                          CourseName = c.CourseName,
                          ExamTerm1 = ET.ExamTerm1,
                          ExamTitleName = ETI.ExamTitleName,
                          AdmiId = a.AdmissionId,
                          RollNo = a.AdmissionNo,
                          ContactNumber = a.ContactNo,
                          Section = a.Section
                      };
            Gridfill.DataSource = inv.Distinct();
            Gridfill.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ExamScheduleId = Convert.ToInt32(GridFillMarks.DataKeys[e.Row.RowIndex].Value.ToString());
                var DATA1 = from Cons in obj.ExamSchedules
                            where Cons.Remove == false && Cons.ExamScheduleId == ExamScheduleId && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                if (DATA1.First().AdditionalSubjectId == 0)
                {
                    ((TextBox)e.Row.FindControl("txtAdnMarks")).Visible = false;
                }
                if (Session["AdmisId"] != null)
                {
                    var DATA2 = from Cons in obj.FillMarks
                                where Cons.AdmissionId==Convert.ToInt32(Session["AdmisId"]) && Cons.ExamScheduleId == ExamScheduleId && Cons.Remove == false  && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    TextBox txtMarks = (TextBox)e.Row.FindControl("txtMarks");
                    TextBox txtAdnMarks = (TextBox)e.Row.FindControl("txtAdnMarks");
                    txtMarks.Text = DataBinder.Eval(e.Row.DataItem, "SubjectMark").ToString();
                    txtAdnMarks.Text = DataBinder.Eval(e.Row.DataItem, "AdnSubjectMarks").ToString();
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void OnRowDataBoundGridfill(object sender, GridViewRowEventArgs e)
    {
        try
        {
            int TotalMarks = 0;
            int TotalAdnMarks = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string InstallString = "<table cellspacing='0'><tr>";
                for (int i = 0; i < GridFillMarks.Rows.Count; i++)
                {
                    int ExamScheduleId = Convert.ToInt32(GridFillMarks.DataKeys[i].Value.ToString());
                    int AdmisId = Convert.ToInt32(Gridfill.DataKeys[e.Row.RowIndex].Value.ToString());
                    IEnumerable<FillMark> DATA1 = from Cons in obj.FillMarks
                                where Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && Cons.ExamTitleId == Convert.ToInt32(ddlExamTitle.SelectedValue) &&
                                Cons.AdmissionId==AdmisId && Cons.Remove == false && Cons.ExamScheduleId == ExamScheduleId && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    InstallString += "<td class='installr'>" +(Convert.ToInt32(DATA1.First().SubjectMark) + Convert.ToInt32(DATA1.First().AdnSubjectMarks)) + "</td>";
                }
                InstallString += "</tr>";
                InstallString += "<tr>";
                for (int i = 0; i < GridFillMarks.Rows.Count; i++)
                {
                    TotalMarks = 0;
                    TotalAdnMarks = 0;
                    int ExamScheduleId = Convert.ToInt32(GridFillMarks.DataKeys[i].Value.ToString());
                    int AdmisId = Convert.ToInt32(Gridfill.DataKeys[e.Row.RowIndex].Value.ToString());
                    IEnumerable<FillMark> DATA1 = from Cons in obj.FillMarks
                                                  where Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && Cons.ExamTitleId == Convert.ToInt32(ddlExamTitle.SelectedValue) &&
                                                  Cons.AdmissionId == AdmisId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                  select Cons;
                    if (DATA1.Count<FillMark>() > 0)
                    {
                        TotalMarks = 0;
                        TotalAdnMarks = 0;
                        TotalMarks = Convert.ToInt32(DATA1.Sum(s => s.SubjectMark.Value));
                        TotalAdnMarks = Convert.ToInt32(DATA1.Sum(s => s.AdnSubjectMarks.Value));
                    }
                    if (i == 0)
                    {
                        InstallString += "<td class='installr'>Total Marks</td>";
                    }
                    else if (i + 1 == GridFillMarks.Rows.Count)
                    {
                        InstallString += "<td class='installr'>" + (Convert.ToInt32(TotalMarks) + Convert.ToInt32(TotalAdnMarks)) + "</td>";
                    }
                    else
                    {
                        InstallString += "<td class='installr'></td>";
                    }
                }
                InstallString += "</tr></table>";
                e.Row.Cells[4].Text = InstallString;
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                string InstallString = "<table cellspacing='0'><tr>";
                for (int i = 0; i < GridFillMarks.Rows.Count; i++)
                {
                    int ExamScheduleId = Convert.ToInt32(GridFillMarks.DataKeys[i].Value.ToString());
                    var DATA1 = from Cons in obj.FillMarks
                                where Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && Cons.ExamTitleId == Convert.ToInt32(ddlExamTitle.SelectedValue) &&
                                Cons.Remove == false && Cons.ExamScheduleId == ExamScheduleId && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    InstallString += "<td class='installr'>" + DATA1.First().SubjectName + "</td>";
                }
                InstallString += "</tr></table>";
                e.Row.Cells[4].Text = InstallString;
            }
        }
        catch (Exception ex) { }
    }
    protected void Gridfill_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            int AdmisId = Convert.ToInt32(Gridfill.DataKeys[e.NewSelectedIndex].Value);
            Session["AdmisId"] = AdmisId;
            var DATA = from Cons in obj.FillMarks
                       where Cons.AdmissionId == AdmisId
                       && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                       && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons;
            ddlClass.SelectedValue =DATA.First().CourseId.ToString();
            ddlTerms.SelectedValue = DATA.First().ExamTermId.ToString();
            var DATA1 = from Cons in obj.ExamTitles
                        where Cons.Remove == false && Cons.ExamTermId == Convert.ToInt32(ddlTerms.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            ddlExamTitle.DataSource = DATA1;
            ddlExamTitle.DataTextField = "ExamTitleName";
            ddlExamTitle.DataValueField = "ExamTitleId";
            ddlExamTitle.DataBind();
            ddlExamTitle.Items.Insert(0, new ListItem("--SELECT--", "0"));
            var DATA2 = from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(ddlClass.SelectedValue) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            ddlStudentName.DataSource = DATA2;
            ddlStudentName.DataTextField = "StudentName";
            ddlStudentName.DataValueField = "AdmissionId";
            ddlStudentName.DataBind();
            ddlStudentName.Items.Insert(0, new ListItem("--SELECT--", "0"));
            ddlExamTitle.SelectedValue = DATA.First().ExamTitleId.ToString();
            ddlStudentName.SelectedValue = DATA.First().AdmissionId.ToString();
            try
            {
                GridFillMarks.DataSource = AllMethods.selectForFillMarkGridUpdated(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), AdmisId);
                GridFillMarks.DataBind();
            }
            catch (Exception ex)
            { }
            var DATA3 = from Cons in obj.FillMarks
                        where Cons.AdmissionId == AdmisId
                        && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                        && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            ddlFillMarksId.DataSource = DATA3;
            ddlFillMarksId.DataTextField = "FillMarksId";
            ddlFillMarksId.DataValueField = "FillMarksId";
            ddlFillMarksId.DataBind();
        }
        catch (Exception ex)
        { }
    }
}