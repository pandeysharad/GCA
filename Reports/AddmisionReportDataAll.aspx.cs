using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Reports_AddmisionReportDataAll : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    public string SchoolName = "";
    public int GridRowCount = 0;
    string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompanyId"] != null)
            {
                var DATA = from Cons in obj.Settings 
                           where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                           select Cons;
                SchoolName = DATA.First().SchoolName;
                try
                {
                    GridRowCount = GridCourseWiseData.Rows.Count;
                }
                catch (Exception ex) { }
                if (!IsPostBack)
                {
                    //TdSearch.Visible = false;
                    Session["ClassName"] = "ALL";
                    Session["ClassName"] = "ALL";
                    Session["ddlSection"] = "ALL";
                    Session["ddlSection"] = "ALL";
                    Session["CourseStatus"] = "ALL";
                    Session["CourseStatus"] = "ALL";
                    Session["Area"] = "ALL";
                    Session["Area"] = "ALL";
                    Session["Gender"] = "ALL";
                    Session["Gender"] = "ALL";
                    Session["Category"] = "ALL";
                    Session["Category"] = "ALL";
                    Session["Stream"] = "ALL";
                    Session["Stream"] = "ALL";
                    Session["PrevSchool"] = "ALL";
                    Session["PrevSchool"] = "ALL";
                    Session["Foccupation"] = "ALL";
                    Session["Foccupation"] = "ALL";
                    Session["Moccupation"] = "ALL";
                    Session["Moccupation"] = "ALL";
                    Session["ChildStatus"] = "ALL";
                    Session["ChildStatus"] = "ALL";
                    Session["Religion"] = "ALL";
                    Session["Religion"] = "ALL";
                    Session["BankName"] = "ALL";
                    Session["BankName"] = "ALL";
                    Session["Aadhar"] = "ALL";
                    Session["Aadhar"] = "ALL";
                    Session["EmailId"] = "ALL";
                    Session["EmailId"] = "ALL";
                    Session["Family"] = "ALL";
                    Session["Family"] = "ALL";
                    Session["Samegra"] = "ALL";
                    Session["Samegra"] = "ALL";
                    Session["txtFrom"] = "";
                    Session["txtFrom"] = "";
                    Session["txtTo"] = "";
                    Session["txtTo"] = "";
                    Session["txtExtraAge"] = "";
                    Session["txtExtraAge"] = "";
                    GetAddmisionDetails();
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        { }
    }
    protected void GetAddmisionDetails()
    {
            if (Session["UserId"] != null)
            {
                GetGrid();
            }
    }

    private void BindAllDDL()
    {
        DropDownList ddlCourseName =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlCourseName");
        BindCouseName(ddlCourseName);

        if (ddlCourseName.SelectedIndex != 0)
        {
            DropDownList ddlSection =
    (DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlSection");
            ddlSection.Items.Clear();
            BindSection(ddlCourseName);
        }
        else
        {
            DropDownList ddlSection =
   (DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlSection");
            ddlSection.Items.Clear();
            ddlSection.Items.Insert(0, new ListItem("ALL", "ALL"));
        }

        DropDownList ddlCourseSatus =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlCourseStatus");
        BindCourseStatus(ddlCourseSatus);

        DropDownList ddlArea =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlArea");
        BindAre(ddlArea);

        DropDownList ddlGender =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlGender");
        BindGender(ddlGender);

        DropDownList ddlCategory =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlCategory");
        BindCategory(ddlCategory);

        DropDownList ddlStream =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlStream");
        BindStream(ddlStream);

        DropDownList ddlPrevSchool =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlPrevSchool");
        BindPrevSchool(ddlPrevSchool);

        DropDownList ddlFoccupation =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlFoccupation");
        BindFoccupation(ddlFoccupation);

        DropDownList ddlMoccupation =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlMoccupation");
        BindMoccupation(ddlMoccupation);

        DropDownList ddlChildStatus =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlChildStatus");
        BindChildStatus(ddlChildStatus);

        DropDownList ddlReligion =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlReligion");
        BindReligion(ddlReligion);

        DropDownList ddlBankName =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlBankName");
        BindBankName(ddlBankName);

        DropDownList ddlAadhar =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlAadhar");
        BindBankName(ddlBankName);
        ddlAadhar.Items.FindByValue(Session["Aadhar"].ToString() == "" ? "NOT AVAILABLE" : Session["Aadhar"].ToString())
               .Selected = true;

        DropDownList ddlSamegra =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlSamegra");
        BindBankName(ddlBankName);
        ddlSamegra.Items.FindByValue(Session["Samegra"].ToString() == "" ? "NOT AVAILABLE" : Session["Samegra"].ToString())
               .Selected = true;

        DropDownList ddlFamily =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlFamily");
        BindBankName(ddlBankName);
        ddlFamily.Items.FindByValue(Session["Family"].ToString() == "" ? "NOT AVAILABLE" : Session["Family"].ToString())
               .Selected = true;

        DropDownList ddlEmailId =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlEmailId");
        BindBankName(ddlBankName);
        ddlEmailId.Items.FindByValue(Session["EmailId"].ToString() == "" ? "NOT AVAILABLE" : Session["EmailId"].ToString())
               .Selected = true;

        TextBox txtFrom =
        (TextBox)GridCourseWiseData.HeaderRow.FindControl("txtFrom");
        txtFrom.Text = Session["txtFrom"].ToString();


        TextBox txtTo =
        (TextBox)GridCourseWiseData.HeaderRow.FindControl("txtTo");
        txtTo.Text = Session["txtTo"].ToString();

        TextBox txtExtraAge =
       (TextBox)GridCourseWiseData.HeaderRow.FindControl("txtExtraAge");
        txtExtraAge.Text = Session["txtExtraAge"].ToString();
    }

    private void GetGrid()
    {
        try
        {
            if (ddlSelectOption.SelectedIndex == 0)
            {
                DataSet ds = AllMethods.GetAddmisionReort(Convert.ToInt32(Session["CompanyId"]), Session["ClassName"].ToString(), Session["ddlSection"].ToString(), Session["Area"].ToString(), Session["Gender"].ToString(), Session["Category"].ToString(), Session["CourseStatus"].ToString(), Session["Stream"].ToString(), Session["PrevSchool"].ToString(), Session["Foccupation"].ToString(), Session["Moccupation"].ToString(), Session["ChildStatus"].ToString(), Session["Religion"].ToString(), Session["BankName"].ToString(), Session["Aadhar"].ToString(), Session["Samegra"].ToString(), Session["Family"].ToString(), Session["EmailId"].ToString(), Session["txtFrom"].ToString() != "" ? Convert.ToDateTime(Session["txtFrom"].ToString()).ToString("yyyy-MM-dd") : "", Session["txtTo"].ToString() != "" ? Convert.ToDateTime(Session["txtTo"].ToString()).ToString("yyyy-MM-dd") : "", Session["txtExtraAge"].ToString() != "" ? Convert.ToDateTime(Session["txtExtraAge"].ToString()).ToString("dd-MM-yyyy") : Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy"));
                GridCourseWiseData.DataSource = ds;
                GridCourseWiseData.DataBind();
                BindAllDDL();
            }
            else
            {
                DataSet ds = AllMethods.GetAddmisionReortByAndividual(Convert.ToInt32(Session["CompanyId"]), Session["StudentName"].ToString(), Session["ContactNo"].ToString(), Session["AadharCardNo"].ToString(), Session["SamegraId"].ToString(), Session["FamilyId"].ToString(), Session["AdmissionNo"].ToString(), Session["BankName1"].ToString(), Session["FatherName"].ToString(), Session["MotherName"].ToString());
                GridCourseWiseData.DataSource = ds;
                GridCourseWiseData.DataBind();
            }
            GridRowCount = GridCourseWiseData.Rows.Count;
            //Session["GridRowCount"] = GridCourseWiseData.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void Print_Click(object sender, EventArgs e)
    {
        string CourseId = (sender as LinkButton).CommandArgument;
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('StudentWiseData.aspx?CourseId=" + CourseId + "','');", true);
    }

    protected void btnPrint_OnClick(object sender, EventArgs e)
    {
        try
        {
            getQuery();
            if (Session["query"].ToString() != "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('AddmisionReportDataAllByChecked.aspx','');", true);
            }
            else
            {
                msg = "Please select at least one colomn which you wants to print....";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        { }
    }


    protected void txtSearch_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            string StudentName="";
            if (txtSearch.Text != "")
            {
                try
                {
                    GetSearchValue();
                    if (txtSearch.Text.Length >= 12)
                    {
                        if (Session["StudentName"].ToString() != "")
                        {
                            StudentName = txtSearch.Text;
                            StudentName = StudentName.Substring(0, StudentName.Length - 11); ;
                            txtSearch.Text = StudentName;
                            Session["StudentName"] = StudentName;
                        }
                    }
                }
                catch (Exception ex) { }
                GetGrid();
            }
            else
            {
                txtSearch.Enabled = false;
                ddlSelectOption.SelectedIndex = 0;
                GetGrid();
            }
        }
        catch (Exception ex)
        { }
    }
    //---------------DataGrid DDL Bind----------------------------
    private void BindCouseName(DropDownList ddlCourseName)
    {
        try
        {
            ddlCourseName.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.CourseId ascending
                        select new
                        {
                            ClassName = Cons.CourseName,
                            CourseId = Cons.CourseId
                        })
                       .ToList()
                       .Distinct();
            ddlCourseName.DataSource = DATA;
            ddlCourseName.DataTextField = "ClassName";
            ddlCourseName.DataValueField = "ClassName";
            ddlCourseName.DataBind();
            ddlCourseName.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlCourseName.Items.FindByValue(Session["ClassName"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindSection(DropDownList ddlClassName)
    {
        DropDownList ddlSection =
(DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlSection");
        ddlSection.Items.Clear();
        var DATA = (from Cons in obj.Addmisions
                    where Cons.CourseName == Session["ClassName"].ToString() && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    orderby Cons.Section ascending
                    select new
                    {
                        Section = Cons.Section
                    })
               .ToList()
               .Distinct();
        ddlSection.DataSource = DATA;
        ddlSection.DataTextField = "Section";
        ddlSection.DataValueField = "Section";
        ddlSection.DataBind();
        ddlSection.Items.Insert(0, new ListItem("ALL", "ALL"));
        ddlSection.Items.FindByValue(Session["ddlSection"].ToString())
            .Selected = true;
    }
    private void BindCourseStatus(DropDownList ddlCourseSatus)
    {
        try
        {
            ddlCourseSatus.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            Status = Cons.R1
                        })
                       .ToList()
                       .Distinct();
            ddlCourseSatus.DataSource = DATA;
            ddlCourseSatus.DataTextField = "Status";
            ddlCourseSatus.DataValueField = "Status";
            ddlCourseSatus.DataBind();
            ddlCourseSatus.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlCourseSatus.Items.FindByValue(Session["CourseStatus"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindAre(DropDownList ddlArea)
    {
        try
        {
            ddlArea.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.EnrollmentNo ascending
                        select new
                        {
                            Area = Cons.EnrollmentNo
                        })
                       .ToList()
                       .Distinct();
            ddlArea.DataSource = DATA;
            ddlArea.DataTextField = "Area";
            ddlArea.DataValueField = "Area";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlArea.Items.FindByValue(Session["Area"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindGender(DropDownList ddlGender)
    {
        try
        {
            ddlGender.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            Gender = Cons.Gender
                        })
                       .ToList()
                       .Distinct();
            ddlGender.DataSource = DATA;
            ddlGender.DataTextField = "Gender";
            ddlGender.DataValueField = "Gender";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlGender.Items.FindByValue(Session["Gender"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindCategory(DropDownList ddlCategory)
    {
        try
        {
            ddlCategory.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            Category = Cons.Category
                        })
                       .ToList()
                       .Distinct();
            ddlCategory.DataSource = DATA;
            ddlCategory.DataTextField = "Category";
            ddlCategory.DataValueField = "Category";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlCategory.Items.FindByValue(Session["Category"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        { }
    }

    private void BindStream(DropDownList ddlStream)
    {
        try
        {
            ddlStream.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.Stream ascending
                        select new
                        {
                            Stream = Cons.Stream,
                        })
                       .ToList()
                       .Distinct();
            ddlStream.DataSource = DATA;
            ddlStream.DataTextField = "Stream";
            ddlStream.DataValueField = "Stream";
            ddlStream.DataBind();
            ddlStream.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlStream.Items.FindByValue(Session["Stream"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindPrevSchool(DropDownList ddlPrevSchool)
    {
        try
        {
            ddlPrevSchool.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.Status ascending
                        select new
                        {
                            Status = Cons.Status
                        })
                       .ToList()
                       .Distinct();
            ddlPrevSchool.DataSource = DATA;
            ddlPrevSchool.DataTextField = "Status";
            ddlPrevSchool.DataValueField = "Status";
            ddlPrevSchool.DataBind();
            ddlPrevSchool.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlPrevSchool.Items.FindByValue(Session["PrevSchool"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindFoccupation(DropDownList ddlFoccupation)
    {
        try
        {
            ddlFoccupation.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.Foccupation ascending
                        select new
                        {
                            Foccupation = Cons.Foccupation
                        })
                       .ToList()
                       .Distinct();
            ddlFoccupation.DataSource = DATA;
            ddlFoccupation.DataTextField = "Foccupation";
            ddlFoccupation.DataValueField = "Foccupation";
            ddlFoccupation.DataBind();
            ddlFoccupation.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlFoccupation.Items.FindByValue(Session["Foccupation"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindMoccupation(DropDownList ddlMoccupation)
    {
        try
        {
            ddlMoccupation.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.Moccupation ascending
                        select new
                        {
                            Moccupation = Cons.Moccupation
                        })
                       .ToList()
                       .Distinct();
            ddlMoccupation.DataSource = DATA;
            ddlMoccupation.DataTextField = "Moccupation";
            ddlMoccupation.DataValueField = "Moccupation";
            ddlMoccupation.DataBind();
            ddlMoccupation.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlMoccupation.Items.FindByValue(Session["Moccupation"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindChildStatus(DropDownList ddlChildStatus)
    {
        try
        {
            ddlChildStatus.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.Nationality ascending
                        select new
                        {
                            ChildStatus = Cons.Nationality
                        })
                       .ToList()
                       .Distinct();
            ddlChildStatus.DataSource = DATA;
            ddlChildStatus.DataTextField = "ChildStatus";
            ddlChildStatus.DataValueField = "ChildStatus";
            ddlChildStatus.DataBind();
            ddlChildStatus.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlChildStatus.Items.FindByValue(Session["ChildStatus"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindReligion(DropDownList ddlReligion)
    {
        try
        {
            ddlReligion.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.Nationality ascending
                        select new
                        {
                            Religion = Cons.Religion
                        })
                       .ToList()
                       .Distinct();
            ddlReligion.DataSource = DATA;
            ddlReligion.DataTextField = "Religion";
            ddlReligion.DataValueField = "Religion";
            ddlReligion.DataBind();
            ddlReligion.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlReligion.Items.FindByValue(Session["Religion"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void BindBankName(DropDownList ddlBankName)
    {
        try
        {
            ddlBankName.Items.Clear();
            var DATA = (from Cons in obj.Addmisions
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        orderby Cons.BankName1 ascending
                        select new
                        {
                            BankName = Cons.BankName1
                        })
                       .ToList()
                       .Distinct();
            ddlBankName.DataSource = DATA;
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankName";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlBankName.Items.FindByValue(Session["BankName"].ToString())
                .Selected = true;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

   //------------------Change Change Event----------------------------------------
    protected void CourseNameChanged(object sender, EventArgs e)
    {
        try
        {
            Session["ddlSection"] = "ALL";
            DropDownList ddlCourseName = (DropDownList)sender;
            Session["ClassName"] = ddlCourseName.SelectedValue;
            Session["ClassName"] = ddlCourseName.SelectedValue;
            GetGrid();
            BindAllDDL();
            DropDownList ddlSection =
    (DropDownList)GridCourseWiseData.HeaderRow.FindControl("ddlSection");
            ddlSection.SelectedIndex = 0;
            
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }


    protected void BtnSubmit_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (obj.SP_UpdatedAdmissionByAdmissionReport(Convert.ToInt32(Session["ARAdmissionId"].ToString()), txtStudentName.Text, txtContact.Text, txtFatherName.Text, txtMotherName.Text, txtParentContact.Text, txtAadharNo.Text, txtSamegraId.Text, txtFamilyId.Text, txtEmailId.Text, txtBankName.Text, txtAccountNo.Text, Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
            {
                mp1.Show();
                lblMsg.Text = "Record saved successfully";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //msg = "Record saved successfully...";
                //ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Something Went Wrong";
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            this.LogError(ex);
        }
    }
    protected void StudentName_Click(object sender, EventArgs e)
    {
        try
        {
            int AdmissionId =Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["ARAdmissionId"]= AdmissionId.ToString();
            mp1.Show();
            lblMsg.Visible = false;
            var DATA = from Cons in obj.Addmisions
                        where Cons.AdmissionId == AdmissionId && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            txtAdmissionno.Text = DATA.First().AdmissionNo;
            txtStudentName.Text = DATA.First().StudentName;
            txtContact.Text = DATA.First().ContactNo;
            txtFatherName.Text = DATA.First().FatherName;
            txtMotherName.Text = DATA.First().MotherName;
            txtParentContact.Text = DATA.First().ParentContact;
            txtBankName.Text = DATA.First().BankName1;
            txtAccountNo.Text = DATA.First().Bank1;
            txtAadharNo.Text = DATA.First().AadharCardNo;
            txtSamegraId.Text = DATA.First().SamegraId;
            txtFamilyId.Text = DATA.First().FamilyId;
            txtEmailId.Text = DATA.First().EmailId;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "window.open('StudentWiseData.aspx?CourseId=" + CourseId + "','');", true);
    }
    protected void SectionChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSection = (DropDownList)sender;
            Session["ddlSection"] = ddlSection.SelectedValue;
            Session["ddlSection"] = ddlSection.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void CourseStatusChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCourseStatus = (DropDownList)sender;

            Session["CourseStatus"] = ddlCourseStatus.SelectedValue;
            Session["CourseStatus"] = ddlCourseStatus.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void AreaChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlArea = (DropDownList)sender;

            Session["Area"] = ddlArea.SelectedValue;
            Session["Area"] = ddlArea.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void GenderChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlGender = (DropDownList)sender;

            Session["Gender"] = ddlGender.SelectedValue;
            Session["Gender"] = ddlGender.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void CategoryChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)sender;

            Session["Category"] = ddlCategory.SelectedValue;
            Session["Category"] = ddlCategory.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void StreamChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlStream = (DropDownList)sender;

            Session["Stream"] = ddlStream.SelectedValue;
            Session["Stream"] = ddlStream.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void PrevSchoolChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPrevSchool = (DropDownList)sender;

            Session["PrevSchool"] = ddlPrevSchool.SelectedValue;
            Session["PrevSchool"] = ddlPrevSchool.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void FoccupationChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlFoccupation = (DropDownList)sender;

            Session["Foccupation"] = ddlFoccupation.SelectedValue;
            Session["Foccupation"] = ddlFoccupation.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void MoccupationChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlMoccupation = (DropDownList)sender;

            Session["Moccupation"] = ddlMoccupation.SelectedValue;
            Session["Moccupation"] = ddlMoccupation.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    
    protected void ChildStatusChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlChildStatus = (DropDownList)sender;

            Session["ChildStatus"] = ddlChildStatus.SelectedValue;
            Session["ChildStatus"] = ddlChildStatus.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    
    protected void ReligionChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlReligion = (DropDownList)sender;

            Session["Religion"] = ddlReligion.SelectedValue;
            Session["Religion"] = ddlReligion.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void BankNameChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlBankName = (DropDownList)sender;

            Session["BankName"] = ddlBankName.SelectedValue;
            Session["BankName"] = ddlBankName.SelectedValue;
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void AadharChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlAadhar = (DropDownList)sender;
            if(ddlAadhar.SelectedIndex==0)
            Session["Aadhar"] ="ALL";
            else if (ddlAadhar.SelectedIndex == 1)
            Session["Aadhar"] = "AVAILABLE";
            else if (ddlAadhar.SelectedIndex == 2)
            Session["Aadhar"] = "";
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void SamegraChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSamegra = (DropDownList)sender;
            if (ddlSamegra.SelectedIndex == 0)
                Session["Samegra"] = "ALL";
            else if (ddlSamegra.SelectedIndex == 1)
                Session["Samegra"] = "AVAILABLE";
            else if (ddlSamegra.SelectedIndex == 2)
                Session["Samegra"] = "";
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void FamilyChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlFamily = (DropDownList)sender;
            if (ddlFamily.SelectedIndex == 0)
                Session["Family"] = "ALL";
            else if (ddlFamily.SelectedIndex == 1)
                Session["Family"] = "AVAILABLE";
            else if (ddlFamily.SelectedIndex == 2)
                Session["Family"] = "";
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void EmailIdChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlEmailId = (DropDownList)sender;
            if (ddlEmailId.SelectedIndex == 0)
                Session["EmailId"] = "ALL";
            else if (ddlEmailId.SelectedIndex == 1)
                Session["EmailId"] = "AVAILABLE";
            else if (ddlEmailId.SelectedIndex == 2)
                Session["EmailId"] = "";
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    //------------------------------------------------------------------------

    protected void ddlSelectOption_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSelectOption.SelectedIndex != 0)
            {
                txtSearch.Enabled = true;
                txtSearch.Text = "";
                txtSearch.Focus();
                AutoCompleteExtender4.ContextKey = ddlSelectOption.SelectedValue.ToString(); 
                GetSearchValue();
            }
            else
            {
                txtSearch.Enabled = false;
                txtSearch.Text = "";
                Response.Redirect(Request.RawUrl);
                GetGrid();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "SetPlaceHolderText", "SetPlaceHolderText();", true);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    private void GetSearchValue()
    {
        if (ddlSelectOption.SelectedIndex != 0)
        {
            Session["StudentName"] = "";
            Session["ContactNo"] = "";
            Session["AadharCardNo"] = "";
            Session["SamegraId"] = "";
            Session["FamilyId"] = "";
            Session["AdmissionNo"] = "";
            Session["BankName1"] = "";
            Session["FatherName"] = "";
            Session["MotherName"] = "";
            if (ddlSelectOption.SelectedIndex == 1)
            {
                Session["StudentName"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 2)
            {
                Session["ContactNo"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 3)
            {
                Session["AadharCardNo"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 4)
            {
                Session["SamegraId"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 5)
            {
                Session["FamilyId"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 6)
            {
                Session["AdmissionNo"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 7)
            {
                Session["BankName1"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 8)
            {
                Session["FatherName"] = txtSearch.Text;
            }
            else if (ddlSelectOption.SelectedIndex == 9)
            {
                Session["MotherName"] = txtSearch.Text;
            }
        }
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtFrom =
        (TextBox)GridCourseWiseData.HeaderRow.FindControl("txtFrom");
            if (txtFrom.Text != "")
            {
                Session["txtFrom"] = txtFrom.Text;
                Session["txtFrom"] = txtFrom.Text;
            }
            else
            {
                Session["txtFrom"] = "";
                Session["txtFrom"] = "";
            }
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void txtExtraAge_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtExtraAge =
       (TextBox)GridCourseWiseData.HeaderRow.FindControl("txtExtraAge");
            if (txtExtraAge.Text != "")
            {
                Session["txtExtraAge"] = txtExtraAge.Text;
            }
            else
            {
                Session["txtExtraAge"] ="";
            }
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtTo =
       (TextBox)GridCourseWiseData.HeaderRow.FindControl("txtTo");
            if (txtTo.Text != "")
            {
                Session["txtTo"] = txtTo.Text;
                Session["txtTo"] = txtTo.Text;
            }
            else
            {
                Session["txtTo"] = "";
                Session["txtTo"] = "";
            }
            GetGrid();
            BindAllDDL();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void getQuery()
    {
        string query = "";
        string WhereCondition = "";
        string ExtraAge = "";
        CheckBox chkAdmissionNo = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkAdmissionNo");
        CheckBox chkCourseName = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkCourseName");
        CheckBox chkSection = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkSection");
        CheckBox chkStream = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkStream");
        CheckBox chkStatus = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkStatus");
        CheckBox chkEnrollmentNo = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkEnrollmentNo");
        CheckBox chkAdmissionDate = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkAdmissionDate");
        CheckBox chkStudentName = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkStudentName");
        CheckBox chkContactNo = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkContactNo");
        CheckBox chkFatherName = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkFatherName");
        CheckBox chkFoccupation = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkFoccupation");
        CheckBox chkParentContact = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkParentContact");
        CheckBox chkMotherName = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkMotherName");
        CheckBox chkMoccupation = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkMoccupation");
        CheckBox chkChildStatus = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkChildStatus");
        CheckBox chkDOB = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkDOB");
        CheckBox chkGender = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkGender");
        CheckBox chkCategory = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkCategory");
        CheckBox chkReligion = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkReligion");
        CheckBox chkBankName = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkBankName");
        CheckBox chkAddress = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkAddress");
        CheckBox chkAadharCardNo = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkAadharCardNo");
        CheckBox chkSamegraId = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkSamegraId");
        CheckBox chkFamilyId = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkFamilyId");
        CheckBox chkEmailId = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkEmailId");
        CheckBox chkR1 = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkR1");
        CheckBox chkStudentAge = (CheckBox)GridCourseWiseData.HeaderRow.FindControl("chkStudentAge");
        if (Session["txtExtraAge"].ToString() != "")
        {
            ExtraAge = Session["txtExtraAge"].ToString();
        }
        else
        {
            ExtraAge = DateTime.Now.ToString("dd/MM/yyyy");
        }
        if (chkAdmissionNo.Checked)
        {
            query += "AdmissionNo as [Adm-No.],";
        }
        if (chkCourseName.Checked)
        {
            query += "CourseName as [Current Class],";
        }
        if (chkSection.Checked)
        {
            query += "Section as [Section],";
        }
        if (chkStream.Checked)
        {
            query += "Stream as [Stream],";
        }
        if (chkStatus.Checked)
        {
            query += "Status as [Prev. School],";
        }
        if (chkEnrollmentNo.Checked)
        {
            query += "EnrollmentNo as [Area],";
        }
        if (chkAdmissionDate.Checked)
        {
            query += "CONVERT(varchar, AdmissionDate, 105) as [AdmDate],";
        }
        if (chkStudentName.Checked)
        {
            query += "StudentName as [Student Name],";
        }
        if (chkContactNo.Checked)
        {
            query += "ContactNo as [Contact],";
        }
        if (chkFatherName.Checked)
        {
            query += "FatherName as [Father],";
        }
        if (chkFoccupation.Checked)
        {
            query += "Foccupation as [F. Occup.],";
        }
        if (chkChildStatus.Checked)
        {
            query += "Nationality as [Child Status],";
        }
        if (chkParentContact.Checked)
        {
            query += "ParentContact as [P.Mob.No.],";
        }
        if (chkMotherName.Checked)
        {
            query += "MotherName as [Mother],";
        }
        if (chkMoccupation.Checked)
        {
            query += "Moccupation as [M. Occup.],";
        }
        if (chkDOB.Checked)
        {
            query += "DOB as [DOB],";
        }

        if (chkStudentAge.Checked)
        {
            query += "(select dbo.FUN_CALCULATEAGE(CONVERT(DateTime,DOB,105),CONVERT(DateTime,'" + ExtraAge + "',105))) StudentAge,";
        }
        if (chkGender.Checked)
        {
            query += "Gender as [Gender],";
        }
        if (chkCategory.Checked)
        {
            query += "Category as [Category],";
        }
        if (chkReligion.Checked)
        {
            query += "Religion as [Religion],";
        }
        if (chkBankName.Checked)
        {
            query += "BankName1 as [Bank Name],";
        }
        if (chkAddress.Checked)
        {
            query += "Address as [Address],";
        }
        if (chkAadharCardNo.Checked)
        {
            query += "AadharCardNo as [Aadhar],";
        }
        if (chkSamegraId.Checked)
        {
            query += "SamegraId as [Samegra Id],";
        }
        if (chkFamilyId.Checked)
        {
            query += "FamilyId as [Family Id],";
        }
        if (chkEmailId.Checked)
        {
            query += "EmailId as [EmailId],";
        }
        if (chkR1.Checked)
        {
            query += "R1 as [Status],";
        }
        WhereCondition += " FROM         Addmision  where Remove=0 and CompanyId=" + Session["CompanyId"];
        if (Session["ClassName"].ToString() != "ALL")
        {
            WhereCondition += " and CourseName='" + Session["ClassName"].ToString()+"'";
        }
        if (Session["txtFrom"].ToString() != "" && Session["txtTo"].ToString() != "")
        {
            WhereCondition += " and AdmissionDate between CONVERT(datetime,'" +Convert.ToDateTime(Session["txtFrom"].ToString()).ToString("yyyy/MM/dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(Session["txtTo"].ToString()).ToString("yyyy/MM/dd") + "')";
        }
        if (Session["ddlSection"].ToString() != "ALL")
        {
            WhereCondition += " and Section='" + Session["ddlSection"].ToString() + "'";
        }
        if (Session["CourseStatus"].ToString() != "ALL")
        {
            WhereCondition += " and r1='" + Session["CourseStatus"].ToString() + "'";
        }
        if (Session["Area"].ToString() != "ALL")
        {
            WhereCondition += " and EnrollmentNo='" + Session["Area"].ToString() + "'";
        }
        if (Session["Gender"].ToString() != "ALL")
        {
            WhereCondition += " and Gender='" + Session["Gender"].ToString() + "'";
        }
        if (Session["Category"].ToString() != "ALL")
        {
            WhereCondition += " and Category='" + Session["Category"].ToString() + "'";
        }
        if (Session["Stream"].ToString() != "ALL")
        {
            WhereCondition += " and Stream='" + Session["Stream"].ToString() + "'";
        }
        if (Session["PrevSchool"].ToString() != "ALL")
        {
            WhereCondition += " and Status='" + Session["PrevSchool"].ToString() + "'";
        }
        if (Session["Foccupation"].ToString() != "ALL")
        {
            WhereCondition += " and Foccupation='" + Session["Foccupation"].ToString() + "'";
        }
        if (Session["Moccupation"].ToString() != "ALL")
        {
            WhereCondition += " and Moccupation='" + Session["Moccupation"].ToString() + "'";
        }
        if (Session["ChildStatus"].ToString() != "ALL")
        {
            WhereCondition += " and Nationality='" + Session["ChildStatus"].ToString() + "'";
        }
        if (Session["Religion"].ToString() != "ALL")
        {
            WhereCondition += " and Religion='" + Session["Religion"].ToString() + "'";
        }
        if (Session["BankName"].ToString() != "ALL")
        {
            WhereCondition += " and BankName1='" + Session["BankName"].ToString() + "'";
        }
        if (Session["Aadhar"].ToString() != "ALL")
        {
            if (Session["Aadhar"].ToString() == "AVAILABLE")
            {
                WhereCondition += " and AadharCardNo!=''";
            }
            else
            {
                WhereCondition += " and AadharCardNo=''";
            }
        }
        if (Session["EmailId"].ToString() != "ALL")
        {
            if (Session["EmailId"].ToString() == "AVAILABLE")
            {
                WhereCondition += " and EmailId!=''";
            }
            else
            {
                WhereCondition += " and EmailId=''";
            }
        }
        if (Session["Family"].ToString() != "ALL")
        {
            if (Session["Family"].ToString() == "AVAILABLE")
            {
                WhereCondition += " and FamilyId!=''";
            }
            else
            {
                WhereCondition += " and FamilyId=''";
            }
        }
        if (Session["Samegra"].ToString() != "ALL")
        {
            if (Session["Samegra"].ToString() == "AVAILABLE")
            {
                WhereCondition += " and SamegraId!=''";
            }
            else
            {
                WhereCondition += " and SamegraId=''";
            }
        }
        Session["WhereCondition"] = WhereCondition;
        Session["query"] = query;
        //query=query.Remove(query.Length - 1);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=ClassWiseReport-" + System.DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
            Response.Charset = "";
            this.EnableViewState = false;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            GridCourseWiseData.RenderControl(htw);
            //Page.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    private void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }
}