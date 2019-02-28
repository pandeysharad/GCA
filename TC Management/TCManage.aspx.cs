using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TC_Management_TCManage : System.Web.UI.Page
{
    public string TCbtn = " TC Create";
    public string CCbtn = " CC Create";
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    LoginRole role = new LoginRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                TCbtn = " TC Create";
                CCbtn = " CC Create";
                txtApplyDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                AutoCompleteExtender4.ContextKey = Session["SessionId"].ToString();
                AutotxtAndExtender2.ContextKey = Session["SessionId"].ToString();
                AutotxtClassExtender5.ContextKey = Session["SessionId"].ToString();
                AutotxtExaminationExtender3.ContextKey = Session["SessionId"].ToString();
                AutotxtHisHerConductwasExtender2.ContextKey = Session["SessionId"].ToString();
                AutotxtInwordsclassExtender2.ContextKey = Session["SessionId"].ToString();
                AutotxtPaidallduestillendExtender1.ContextKey = Session["SessionId"].ToString();
                AutotxtToClassExtender2.ContextKey = Session["SessionId"].ToString();
                AutotxtYearExtender2.ContextKey = Session["SessionId"].ToString();

                BindTCGrid();

                var TCM = (from Cons in obj.TcIssues
                           where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                           select Cons.TcSerialNo).Max();
                var CCM = (from Cons in obj.TcIssues
                           where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                           select Cons.CcSerialNo).Max();

                if (TCM != null && TCM != "")
                {
                    txtTcSerialNo.Text = (Convert.ToInt32(TCM) + 1).ToString();
                    chkTcSerialNo.Checked = false;
                }
                if (CCM != null && CCM != "")
                {
                    txtCCSerialNo.Text = (Convert.ToInt32(CCM) + 1).ToString();

                    chkCCSerialNo.Checked = false;
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearchDetails_Click(object sender, EventArgs e)
    {
        GetAdmissionDetailsByAddmissionNo(txtAdminNo.Text.Trim());
    }
    protected void GetAdmissionDetailsByAddmissionNo(string AdmissionNo)
    {
        //txtAdminNo.Text = AdmissionNo.Trim().ToString();
        try
        {
            if (txtAdminNo.Text != "")
            {
                IEnumerable<Addmision> Addmisions1 = from id in obj.Addmisions
                                                     where id.AdmissionNo == txtAdminNo.Text
                                                     && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                     select id;
                txtSession.Text = Addmisions1.First().Session;
                txtAdimissionNo.Text = Addmisions1.First().AdmissionNo;
                txtAdmissionDate.Text = Convert.ToDateTime(Addmisions1.First().AdmissionDate).ToString("dd/MM/yyyy");
                txtName.Text = Addmisions1.First().StudentName;
                txtFatherName.Text = Addmisions1.First().FatherName;
                txtMotherName.Text = Addmisions1.First().MotherName;
                txtReligion.Text = Addmisions1.First().Religion;
                txtCast.Text = Addmisions1.First().Category;
                txtSection.Text = Addmisions1.First().Section;
                txtContact.Text = Addmisions1.First().ContactNo;
                txtAadhar.Text = Addmisions1.First().AadharCardNo;
                txtSamagraId.Text = Addmisions1.First().SamegraId;
                txtGender.Text = Addmisions1.First().Gender;
                txtCurrentClass.Text = Addmisions1.First().CourseName;
                txtSection.Text = Addmisions1.First().Section;
                txtAdmClass.Text = Addmisions1.First().AdmittedInClass;
                txtDOB.Text = Addmisions1.First().DOB;

                IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                                where Cons.AdmissionNo == Convert.ToInt32(txtAdminNo.Text.Trim())
                                                && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                select Cons;
                if (TcIssues.Count<TcIssue>() > 0)
                {
                    txtApplyDate.Text = Convert.ToDateTime(TcIssues.First().ApplyDate).ToString("dd/MM/yyyy"); ;
                    txtSchoolLeavingDate.Text = Convert.ToDateTime(TcIssues.First().SchoolLeavingDate).ToString("dd/MM/yyyy");
                    txtPaidallduestillend.Text = TcIssues.First().PaidAllDue;
                    txtYear.Text = TcIssues.First().Year;
                    txtExamination.Text = TcIssues.First().Examination;
                    txtClass.Text = TcIssues.First().Class;
                    txtAnd.Text = TcIssues.First().AndPassed;
                    txtToClass.Text = TcIssues.First().ToClass;
                    txtInwordsclass.Text = TcIssues.First().InWordsClass;
                    txtHisHerConductwas.Text = TcIssues.First().ConductWas;
                    txtRemarks.Text = TcIssues.First().Remarks;

                    if (TcIssues.First().TcIssued == true)
                    {
                        TCbtn = " TC Update";
                    }
                    else
                    {
                        TCbtn = " TC Create";
                    }
                    if (TcIssues.First().CcIssued == true)
                    {
                        CCbtn = " CC Update";
                    }
                    else
                    {
                        CCbtn = " CC Create";
                    }

                    if (TcIssues.First().TcSerialNo == null)
                    {
                        try
                        {
                            var TCM = (from Cons in obj.TcIssues
                                       where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                       select Cons.TcSerialNo).Max();
                            if (TCM != null && TCM != "")
                            {
                                txtTcSerialNo.Text = (Convert.ToInt32(TCM) + 1).ToString();
                                chkTcSerialNo.Checked = false;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                    else
                    {
                        txtTcSerialNo.Text = TcIssues.First().TcSerialNo;
                    }
                    if (TcIssues.First().CcSerialNo == null)
                    {
                        try
                        {
                            var CCM = (from Cons in obj.TcIssues
                                       where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                       select Cons.CcSerialNo).Max();

                            if (CCM != null && CCM != "")
                            {
                                txtCCSerialNo.Text = (Convert.ToInt32(CCM) + 1).ToString();

                                chkCCSerialNo.Checked = false;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                    else
                    {
                        txtCCSerialNo.Text = TcIssues.First().CcSerialNo;
                    }

                    if (TcIssues.First().DuplicateTc == true)
                    {
                        chkDuplicateTc.Checked = true;
                    }
                    else
                    {
                        chkDuplicateTc.Checked = false;
                    }
                    if (TcIssues.First().DuplicateCc == true)
                    {
                        chkDuplicateCC.Checked = true;
                    }
                    else
                    {
                        chkDuplicateCC.Checked = false;
                    }

                }
                else
                {
                    txtApplyDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtSchoolLeavingDate.Text = "";
                    txtPaidallduestillend.Text = "";
                    txtYear.Text = "";
                    txtExamination.Text = "";
                    txtClass.Text = "";
                    txtAnd.Text = "";
                    txtToClass.Text = "";
                    txtInwordsclass.Text = "";
                    txtHisHerConductwas.Text = "";
                    TCbtn = " TC Create";
                    CCbtn = " CC Create";
                }
            }
            else
            {
                msg = "Please enter student admission number...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        {
            msg = "Adimission no does not exist...";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
        }
    }

    private void Refresh()
    {
        try
        {
            txtAdminNo.Text = "";
            txtSession.Text = "";
            txtAdimissionNo.Text = "";
            txtAdmissionDate.Text = "";
            txtName.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtReligion.Text = "";
            txtCast.Text = "";
            txtSection.Text = "";
            txtAdmClass.Text = "";
            txtAadhar.Text = "";
            txtSamagraId.Text = "";
            txtGender.Text = "";
            txtCurrentClass.Text = "";
            txtDOB.Text = "";
            txtContact.Text = "";

            txtApplyDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtSchoolLeavingDate.Text = "";
            txtPaidallduestillend.Text = "";
            txtYear.Text = "";
            txtExamination.Text = "";
            txtClass.Text = "";
            txtAnd.Text = "";
            txtToClass.Text = "";
            txtInwordsclass.Text = "";
            txtHisHerConductwas.Text = "";
            TCbtn = " TC Create";
            CCbtn = " CC Create";
            chkCCSerialNo.Checked = false;
            chkTcSerialNo.Checked = false;
            txtTcSerialNo.Enabled = false;
            txtCCSerialNo.Enabled = false;
            chkDuplicateTc.Checked = false;
            chkDuplicateCC.Checked = false;
            txtRemarks.Text = "";
            BindTCGrid();

            var TCM = (from Cons in obj.TcIssues
                       where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons.TcSerialNo).Max();
            var CCM = (from Cons in obj.TcIssues
                       where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                       select Cons.CcSerialNo).Max();

            if (TCM != null && TCM != "")
            {
                txtTcSerialNo.Text = (Convert.ToInt32(TCM) + 1).ToString();
                chkTcSerialNo.Checked = false;
            }
            else
            {
                txtTcSerialNo.Text = "";
            }
            if (CCM != null && CCM != "")
            {
                txtCCSerialNo.Text = (Convert.ToInt32(CCM) + 1).ToString();
                chkCCSerialNo.Checked = false;
            }
            else
            {
                txtCCSerialNo.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnAllFeesRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            Refresh();
        }
        catch (Exception ex)
        { }
    }

    protected void btnTcIssue_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTcSerialNo.Text != "")
            {
                if (txtAdminNo.Text == txtAdimissionNo.Text)
                {
                    IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                                    where Cons.AdmissionNo == Convert.ToInt32(txtAdminNo.Text.Trim())
                                                    && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                    select Cons;
                    IEnumerable<Addmision> Addmisions1 = from id in obj.Addmisions
                                                         where id.AdmissionNo == txtAdminNo.Text.Trim()
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                         select id;
                    if (TcIssues.Count<TcIssue>() <= 0)
                    {

                        if (obj.Sp_TcIssue(1, 0, Addmisions1.First().AdmissionId, Convert.ToInt32(Addmisions1.First().AdmissionNo), Convert.ToDateTime(txtSchoolLeavingDate.Text), txtPaidallduestillend.Text, txtExamination.Text,
                            txtClass.Text, txtAnd.Text, txtToClass.Text, txtInwordsclass.Text, txtHisHerConductwas.Text, Convert.ToDateTime(txtApplyDate.Text), false, true, false, chkDuplicateTc.Checked ? true : false, chkDuplicateCC.Checked ? true : false, txtTcSerialNo.Text, null, Convert.ToDateTime(txtSchoolLeavingDate.Text), txtRemarks.Text, "", Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), txtYear.Text) == 0)
                        {
                            var DATA1 = (from Cons in obj.TcIssues
                                         where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                         select Cons.TCId).Max();
                            Session["TCId"] = DATA1;
                            //Update Student Staus 'TC Issued'
                            try
                            {
                                Addmision objAddmision = obj.Addmisions.Single(Adm => Adm.AdmissionNo == Addmisions1.First().AdmissionNo);
                                objAddmision.R1 = "TC ISSUED";
                                obj.SubmitChanges();
                            }
                            catch (Exception ex) { }
                            Refresh();
                             //COURSE objCourse = OdContext.COURSEs.Single(course => course.course_name == "B.Tech");
                             
                            //msg = "Tc Successfully Issue....";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            string URL = "javascript:window.open('TCReport.aspx')";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                    }
                    else
                    {
                        if (obj.Sp_TcIssue(2, TcIssues.First().TCId, Addmisions1.First().AdmissionId, Convert.ToInt32(Addmisions1.First().AdmissionNo), Convert.ToDateTime(txtSchoolLeavingDate.Text), txtPaidallduestillend.Text, txtExamination.Text,
                            txtClass.Text, txtAnd.Text, txtToClass.Text, txtInwordsclass.Text, txtHisHerConductwas.Text, Convert.ToDateTime(txtApplyDate.Text), false, true, false, chkDuplicateTc.Checked ? true : false, chkDuplicateCC.Checked ? true : false, txtTcSerialNo.Text, null, Convert.ToDateTime(txtSchoolLeavingDate.Text), txtRemarks.Text, "", Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), txtYear.Text) == 0)
                        {
                            Session["TCId"] = TcIssues.First().TCId.ToString();
                            Refresh();
                            //msg = "Tc Updated....";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            string URL = "javascript:window.open('TCReport.aspx')";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                    }
                }
                else
                {
                    msg = "Please firstly search record.....";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
            else
            {
                msg = "Please enter intial TC serial.....";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnCCIssue_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCCSerialNo.Text != "")
            {
                if (txtAdminNo.Text == txtAdimissionNo.Text)
                {
                    IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                                    where Cons.AdmissionNo == Convert.ToInt32(txtAdminNo.Text.Trim())
                                                    && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                    select Cons;
                    IEnumerable<Addmision> Addmisions1 = from id in obj.Addmisions
                                                         where id.AdmissionNo == txtAdminNo.Text.Trim()
                                                         && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                         select id;
                    if (TcIssues.Count<TcIssue>() <= 0)
                    {

                        if (obj.Sp_TcIssue(1, 0, Addmisions1.First().AdmissionId, Convert.ToInt32(Addmisions1.First().AdmissionNo), Convert.ToDateTime(txtSchoolLeavingDate.Text), txtPaidallduestillend.Text, txtExamination.Text,
                            txtClass.Text, txtAnd.Text, txtToClass.Text, txtInwordsclass.Text, txtHisHerConductwas.Text, Convert.ToDateTime(txtApplyDate.Text), false, false, true, chkDuplicateTc.Checked ? true : false, chkDuplicateCC.Checked ? true : false, null, txtCCSerialNo.Text, Convert.ToDateTime(txtSchoolLeavingDate.Text), txtRemarks.Text, "", Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), txtYear.Text) == 0)
                        {
                            var DATA1 = (from Cons in obj.TcIssues
                                         where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                         select Cons.TCId).Max();
                            Session["TCId"] = DATA1;
                            Refresh();
                            //msg = "Tc Successfully Issue....";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            string URL = "javascript:window.open('CCReport.aspx')";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                    }
                    else
                    {
                        if (obj.Sp_TcIssue(3, TcIssues.First().TCId, Addmisions1.First().AdmissionId, Convert.ToInt32(Addmisions1.First().AdmissionNo), Convert.ToDateTime(txtSchoolLeavingDate.Text), txtPaidallduestillend.Text, txtExamination.Text,
                            txtClass.Text, txtAnd.Text, txtToClass.Text, txtInwordsclass.Text, txtHisHerConductwas.Text, Convert.ToDateTime(txtApplyDate.Text), false, false, true, chkDuplicateTc.Checked ? true : false, chkDuplicateCC.Checked ? true : false, null, txtCCSerialNo.Text, Convert.ToDateTime(txtSchoolLeavingDate.Text), txtRemarks.Text, "", Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), txtYear.Text) == 0)
                        {
                            Session["TCId"] = TcIssues.First().TCId.ToString();
                            Refresh();
                            //msg = "Tc Updated....";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                            string URL = "javascript:window.open('CCReport.aspx')";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", URL, true);
                        }
                    }
                }
                else
                {
                    msg = "Please firstly search record.....";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
            else
            {
                msg = "Please enter intial CC serial.....";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        { }
    }
    private void BindTCGrid()
    {
        try
        {
            var DATA1 = from t in obj.TcIssues
                        from a in obj.Addmisions
                        where a.AdmissionId == t.AdmissionId &&
                        t.Remove == false && t.CompanyId == Convert.ToInt32(Session["CompanyId"]) && t.SessionId == Convert.ToInt32(Session["SessionId"])
                        select new
                        {
                            TCId = t.TCId,
                            StudentName = a.StudentName,
                            ContactNumber = a.ContactNo,
                            FatherName = a.FatherName,
                            MotherName = a.MotherName,
                            AdmiId = t.AdmissionId,
                            AdmNo = t.AdmissionNo,
                            SchoolLeavingDate = t.SchoolLeavingDate,
                            PaidAllDue = t.PaidAllDue,
                            Examination = t.Examination,
                            Class = t.Class,
                            AndPassed = t.AndPassed,
                            ToClass = t.ToClass,
                            InWordsClass = t.InWordsClass,
                            ConductWas = t.ConductWas,
                            ApplyDate = t.ApplyDate
                        };
            GridTC.DataSource = DATA1;
            GridTC.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void GridTC_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {

            int TCId = Convert.ToInt32(GridTC.DataKeys[e.NewSelectedIndex].Value);
            IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                            where Cons.TCId == TCId
                                            && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                            select Cons;
            IEnumerable<Addmision> Addmisions1 = from id in obj.Addmisions
                                                 where id.AdmissionId == TcIssues.First().AdmissionId
                                                 && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                 select id;
            txtAdminNo.Text = Addmisions1.First().AdmissionNo;
            txtSession.Text = Addmisions1.First().Session;
            txtAdimissionNo.Text = Addmisions1.First().AdmissionNo;
            txtAdmissionDate.Text = Convert.ToDateTime(Addmisions1.First().AdmissionDate).ToString("dd/MM/yyyy");
            txtName.Text = Addmisions1.First().StudentName;
            txtFatherName.Text = Addmisions1.First().FatherName;
            txtMotherName.Text = Addmisions1.First().MotherName;
            txtReligion.Text = Addmisions1.First().Religion;
            txtCast.Text = Addmisions1.First().Category;
            txtSection.Text = Addmisions1.First().Section;
            txtContact.Text = Addmisions1.First().ContactNo;
            txtAadhar.Text = Addmisions1.First().AadharCardNo;
            txtSamagraId.Text = Addmisions1.First().SamegraId;
            txtGender.Text = Addmisions1.First().Gender;
            txtCurrentClass.Text = Addmisions1.First().CourseName;
            txtSection.Text = Addmisions1.First().Section;
            txtAdmClass.Text = Addmisions1.First().AdmittedInClass;
            txtDOB.Text = Addmisions1.First().DOB;
            txtApplyDate.Text = Convert.ToDateTime(TcIssues.First().ApplyDate).ToString("dd/MM/yyyy"); ;
            txtSchoolLeavingDate.Text = Convert.ToDateTime(TcIssues.First().SchoolLeavingDate).ToString("dd/MM/yyyy");
            txtPaidallduestillend.Text = TcIssues.First().PaidAllDue;
            txtYear.Text = TcIssues.First().Year;
            txtExamination.Text = TcIssues.First().Examination;
            txtClass.Text = TcIssues.First().Class;
            txtAnd.Text = TcIssues.First().AndPassed;
            txtToClass.Text = TcIssues.First().ToClass;
            txtInwordsclass.Text = TcIssues.First().InWordsClass;
            txtHisHerConductwas.Text = TcIssues.First().ConductWas;
            txtCCSerialNo.Text = TcIssues.First().CcSerialNo;
            txtTcSerialNo.Text = TcIssues.First().TcSerialNo;
            txtRemarks.Text = TcIssues.First().Remarks;
            if (TcIssues.First().TcIssued == true)
            {
                TCbtn = " TC Update";
            }
            else
            {
                TCbtn = " TC Create";
            }
            if (TcIssues.First().CcIssued == true)
            {
                CCbtn = " CC Update";
            }
            else
            {
                CCbtn = " CC Create";
            }
            if (TcIssues.First().TcSerialNo == null)
            {
                try
                {
                    var TCM = (from Cons in obj.TcIssues
                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons.TcSerialNo).Max();
                    if (TCM != null && TCM != "")
                    {
                        txtTcSerialNo.Text = (Convert.ToInt32(TCM) + 1).ToString();
                        chkTcSerialNo.Checked = false;
                    }
                }
                catch (Exception ex)
                { }
            }
            else
            {
                txtTcSerialNo.Text = TcIssues.First().TcSerialNo;
            }
            if (TcIssues.First().CcSerialNo == null)
            {
                try
                {
                    var CCM = (from Cons in obj.TcIssues
                               where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                               select Cons.CcSerialNo).Max();

                    if (CCM != null && CCM != "")
                    {
                        txtCCSerialNo.Text = (Convert.ToInt32(CCM) + 1).ToString();

                        chkCCSerialNo.Checked = false;
                    }
                }
                catch (Exception ex)
                { }
            }
            else
            {
                txtCCSerialNo.Text = TcIssues.First().CcSerialNo;
            }
            if (TcIssues.First().DuplicateTc == true)
            {
                chkDuplicateTc.Checked = true;
            }
            else
            {
                chkDuplicateTc.Checked = false;
            }
            if (TcIssues.First().DuplicateCc == true)
            {
                chkDuplicateCC.Checked = true;
            }
            else
            {
                chkDuplicateCC.Checked = false;
            }

        }
        catch (Exception ex)
        { }
    }
    protected void GridTC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridTC.PageIndex = e.NewPageIndex;
            BindTCGrid();
            GridTC.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void chkTcSerialNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkTcSerialNo.Checked)
            {
                txtTcSerialNo.Enabled = true;
                txtTcSerialNo.Focus();
            }
            else
            {
                txtTcSerialNo.Enabled = false;
            }
            IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                            where Cons.AdmissionNo == Convert.ToInt32(txtAdminNo.Text.Trim())
                                            && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                            select Cons;
            if (TcIssues.First().TcIssued == true)
            {
                TCbtn = " TC Update";
            }
            else
            {
                TCbtn = " TC Create";
            }
            if (TcIssues.First().CcIssued == true)
            {
                CCbtn = " CC Update";
            }
            else
            {
                CCbtn = " CC Create";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void chkCCSerialNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkCCSerialNo.Checked)
            {
                txtCCSerialNo.Enabled = true;
                txtCCSerialNo.Focus();
            }
            else
            {
                txtCCSerialNo.Enabled = false;
            }
            IEnumerable<TcIssue> TcIssues = from Cons in obj.TcIssues
                                            where Cons.AdmissionNo == Convert.ToInt32(txtAdminNo.Text.Trim())
                                            && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                            select Cons;
            if (TcIssues.First().TcIssued == true)
            {
                TCbtn = " TC Update";
            }
            else
            {
                TCbtn = " TC Create";
            }
            if (TcIssues.First().CcIssued == true)
            {
                CCbtn = " CC Update";
            }
            else
            {
                CCbtn = " CC Create";
            }
        }
        catch (Exception ex)
        { }
    }
}