using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CreateExamTitle : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    LoginRole role = new LoginRole();
    public int SrNo = 1;
    public int SrNo1 = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            if (Session["UserType"].ToString() != "Admin")
            {
                IEnumerable<LoginRole> roles = from r in obj.LoginRoles
                                               where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 4
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
        if (!IsPostBack)
        {

            if (Session["CompanyId"] != null)
            {
                var DATA1 = from Cons in obj.ExamTerms
                           where Cons.Remove == false
                           select Cons;
                GridTerms.DataSource = DATA1;
                GridTerms.DataBind();

                var DATA = from Cons in obj.ExamTerms
                           where Cons.Remove == false
                           select Cons;
                ddlSelectTerm.DataSource = DATA;
                ddlSelectTerm.DataTextField = "ExamTerm1";
                ddlSelectTerm.DataValueField = "ExamTermId";
                ddlSelectTerm.DataBind();
                ddlSelectTerm.Items.Insert(0, new ListItem("--SELECT--", "0"));


                var DATA2 = from Cons in obj.ExamTitles
                            from ET in obj.ExamTerms
                            where ET.ExamTermId == Cons.ExamTermId
                            && Cons.Remove == false
                            select new
                          {
                              ExamTitleId = Cons.ExamTitleId,
                              ExamTerm1=ET.ExamTerm1,
                              ExamTitleName=Cons.ExamTitleName
                          };
                GridTitle.DataSource = DATA2.Distinct();
                GridTitle.DataBind();
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtExamTerm.Text != "")
            {
                if (Session["ExamTermId"] == null)
                {
                     IEnumerable<ExamTerm> comp = from c in obj.ExamTerms
                                                        where c.ExamTerm1 == txtExamTerm.Text
                                                        select c;
                     if (comp.Count<ExamTerm>() == 0)
                     {
                         if (obj.Sp_ExamTerm(1, 0, txtExamTerm.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                         {
                             Globals.Message(Page, "Term created successfully....");
                             Clear();
                         }
                     }
                     else
                     {
                         Globals.Message(Page, "Term with same name is already exist...");
                         txtExamTerm.Focus();
                     }
                }
                else if (Session["ExamTermId"] != null)
                {
                    if (txtExamTerm.Text.ToUpper() == Session["txtExamTerm"].ToString().ToUpper())
                    {
                        UpdateTerm();
                    }
                    else
                    {
                        IEnumerable<ExamTerm> comp = from c in obj.ExamTerms
                                                        where c.ExamTerm1 == txtExamTerm.Text
                                                        select c;
                        if (comp.Count<ExamTerm>() == 0)
                        {
                            UpdateTerm();
                        }
                        else
                        {
                            Globals.Message(Page, "Same Term already exist...");
                            txtExamTerm.Text = Session["txtExamTerm"].ToString();
                            txtExamTerm.Focus();
                        }
                    }
                }
            }
            else
            {
                Globals.Message(Page, "Please enter term....");
                txtExamTerm.Focus();
            }
        }
        catch (Exception ex)
        { }
    }

    private void UpdateTerm()
    {
        if (obj.Sp_ExamTerm(2, Convert.ToInt32(Session["ExamTermId"]), txtExamTerm.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            Globals.Message(Page, "Term updated successfully....");
            Clear();
        }
    }

    private void Clear()
    {
        txtExamTerm.Text = "";
        txtExamTitle.Text = "";
        Session["ExamTermId"] = null;
        Session["ExamTitleId"] = null;
        var DATA1 = from Cons in obj.ExamTerms
                   where Cons.Remove == false
                   select Cons;
        GridTerms.DataSource = DATA1;
        GridTerms.DataBind();

        var DATA = from Cons in obj.ExamTerms
                   where Cons.Remove == false
                   select Cons;
        ddlSelectTerm.DataSource = DATA;
        ddlSelectTerm.DataTextField = "ExamTerm1";
        ddlSelectTerm.DataValueField = "ExamTermId";
        ddlSelectTerm.DataBind();
        ddlSelectTerm.Items.Insert(0, new ListItem("--SELECT--", "0"));
        ddlSelectTerm.SelectedIndex = 0;
        GridBind();
    }

    private void GridBind()
    {
        if (ddlSelectTerm.SelectedIndex != 0)
        {
            var DATA2 = from Cons in obj.ExamTitles
                        from ET in obj.ExamTerms
                        where ET.ExamTermId == Cons.ExamTermId
                        && Cons.Remove == false && Cons.ExamTermId == Convert.ToInt32(ddlSelectTerm.SelectedValue)
                        select new
                        {
                            ExamTitleId = Cons.ExamTitleId,
                            ExamTerm1 = ET.ExamTerm1,
                            ExamTitleName = Cons.ExamTitleName
                        };
            GridTitle.DataSource = DATA2.Distinct();
            GridTitle.DataBind();
        }
        else
        {
            var DATA2 = from Cons in obj.ExamTitles
                        from ET in obj.ExamTerms
                        where ET.ExamTermId == Cons.ExamTermId
                        && Cons.Remove == false
                        select new
                        {
                            ExamTitleId = Cons.ExamTitleId,
                            ExamTerm1 = ET.ExamTerm1,
                            ExamTitleName = Cons.ExamTitleName
                        };
            GridTitle.DataSource = DATA2.Distinct();
            GridTitle.DataBind();
        }
    }
    protected void GridTerms_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Session["ExamTermId"] = GridTerms.DataKeys[e.NewSelectedIndex].Value;
            var DATA1 = from Cons in obj.ExamTerms
                        where Cons.Remove == false && Cons.ExamTermId == Convert.ToInt32(Session["ExamTermId"])
                        select Cons;
            txtExamTerm.Text = DATA1.First().ExamTerm1;
            Session["txtExamTerm"] = DATA1.First().ExamTerm1;
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
    protected void btnSaveExamTitle_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSelectTerm.SelectedIndex != 0)
            {
                if (txtExamTitle.Text!="")
                {
                    if (Session["ExamTitleId"] == null)
                    {
                        IEnumerable<ExamTitle> comp = from c in obj.ExamTitles
                                                        where c.ExamTermId==Convert.ToInt32(ddlSelectTerm.SelectedValue) && c.ExamTitleName == txtExamTitle.Text
                                                        select c;
                        if (comp.Count<ExamTitle>() == 0)
                        {
                            if (obj.Sp_ExamTitle(1, 0, Convert.ToInt32(ddlSelectTerm.SelectedValue), txtExamTitle.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                            {
                                Globals.Message(Page, "Exam Title created successfully....");
                                Clear();
                            }
                        }
                        else
                        {
                            Globals.Message(Page, "Exam title with same name is already exist...");
                            txtExamTitle.Focus();
                        }
                    }
                    else if (Session["ExamTitleId"] != null)
                    {
                        if (txtExamTitle.Text.ToUpper() == Session["txtExamTitle"].ToString().ToUpper())
                        {
                            UpdateTitle();
                        }
                        else
                        {
                            IEnumerable<ExamTitle> comp = from c in obj.ExamTitles
                                                          where c.ExamTitleName == txtExamTitle.Text
                                                          select c;
                            if (comp.Count<ExamTitle>() == 0)
                            {
                                UpdateTitle();
                            }
                            else
                            {
                                Globals.Message(Page, "Same exam title already exist...");
                                txtExamTitle.Text = Session["ExamTitleId"].ToString();
                                txtExamTitle.Focus();
                            }
                        }
                    }
                }
                else
                {
                    Globals.Message(Page, "Please enter exam title...");
                    txtExamTitle.Focus();
                }
            }
            else
            {
                Globals.Message(Page, "Please select term...");
                ddlSelectTerm.Focus();
            }
        }
        catch (Exception ex)
        { }
    }

    private void UpdateTitle()
    {
        if (obj.Sp_ExamTitle(2, Convert.ToInt32(Session["ExamTitleId"]), Convert.ToInt32(ddlSelectTerm.SelectedValue), txtExamTitle.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
        {
            Globals.Message(Page, "Exam Title updated successfully....");
            Clear();
        }
    }
    protected void GridTitle_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Session["ExamTitleId"] = GridTitle.DataKeys[e.NewSelectedIndex].Value;
            var DATA1 = from Cons in obj.ExamTitles
                        where Cons.Remove == false && Cons.ExamTitleId == Convert.ToInt32(Session["ExamTitleId"])
                        select Cons;
            ddlSelectTerm.SelectedValue =DATA1.First().ExamTermId.ToString();
            txtExamTitle.Text = DATA1.First().ExamTitleName;
            Session["txtExamTitle"] = DATA1.First().ExamTitleName;
        }
        catch (Exception ex)
        { }
    }
    protected void btnRefExamTitle_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch (Exception ex)
        { }
    }
    protected void ddlSelectTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridBind();
            if (ddlSelectTerm.SelectedIndex != 0)
            {
                txtExamTitle.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
                ImageButton img = (ImageButton)sender;
                GridViewRow grow = (GridViewRow)img.NamingContainer;
                int ExamTermId =Convert.ToInt32(GridTerms.DataKeys[grow.RowIndex].Value);
                IEnumerable<ExamTitle> comp = from c in obj.ExamTitles
                                            where c.ExamTermId == ExamTermId
                                                        select c;
                if (comp.Count<ExamTitle>() == 0)
                {
                    if (obj.Sp_ExamTerm(3,ExamTermId, txtExamTerm.Text, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        Globals.Message(Page, "Term deleted successfully....");
                        Clear();
                    }
                }
                else
                {
                    Globals.Message(this.Page, "You are unable to delete...");
                }
        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Record Not Deleted " + epp.Message);
        }

    }
}