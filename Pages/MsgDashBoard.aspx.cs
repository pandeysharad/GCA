using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Data.Linq.SqlClient;

public partial class Pages_MsgDashBoard : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    public int SrNo = 1;
    int s = 0;
    public static int msgLenght = 5;
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
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 10
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
                    txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss tt"));
                    MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                    if (dt.ToString("tt") == "AM")
                    {
                        am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                    }
                    else
                    {
                        am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                    }
                    TimeSelector2.SetTime(dt.Hour, dt.Minute, am_pm);

                    var DATA = from Cons in obj.MsgTemplates
                               where Cons.Remove == false
                               select Cons;
                    ddlMsgHeads.DataSource = DATA;
                    ddlMsgHeads.DataTextField = "MsgHead";
                    ddlMsgHeads.DataValueField = "MagTemplateId";
                    ddlMsgHeads.DataBind();
                    ddlMsgHeads.Items.Insert(0, new ListItem("--SELECT--", "0"));

                   
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex) { }
    }
    protected void ddlMsgHeads_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMsgHeads.SelectedIndex != 0)
            {
                var DATA = from Cons in obj.MsgTemplates
                           where Cons.Remove == false && Cons.MagTemplateId == Convert.ToInt32(ddlMsgHeads.SelectedValue)
                           select Cons;
                txtMsg.Text = DATA.First().Msg;
            }
            else
            {
                txtMsg.Text = string.Empty;
            }

        }
        catch (Exception ex)
        { }
    }

    protected void ddlAllClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAllClass.SelectedIndex != 0 || ddlAllClass.SelectedIndex != 1)
            {
                if (ddlAllClass.SelectedIndex == 2)
                {
                    DivEnquiryStudent.Visible = false;
                    DivChkSpecificStudent.Visible = false;
                    DivCheckBoxClasses.Visible = true;
                    var D = from Cons in obj.Courses
                            where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                    CheckBoxClasses.DataSource = D;
                    CheckBoxClasses.DataTextField = "CourseName";
                    CheckBoxClasses.DataValueField = "CourseId";
                    CheckBoxClasses.DataBind();
                }
                else if (ddlAllClass.SelectedIndex == 3)
                {
                    DivEnquiryStudent.Visible = false;
                    DivCheckBoxClasses.Visible = false;
                    DivChkSpecificStudent.Visible = true;
                    var D = from Cons in obj.Courses
                            where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                            select Cons;
                    chkSpecificStudent.DataSource = D;
                    chkSpecificStudent.DataTextField = "CourseName";
                    chkSpecificStudent.DataValueField = "CourseId";
                    chkSpecificStudent.DataBind();
                    Grid.DataSource = null;
                    Grid.DataBind();
                }
                else if (ddlAllClass.SelectedIndex == 4)
                {
                    RadioEnquiryStudent.ClearSelection();
                    DivCheckBoxClasses.Visible = false;
                    DivChkSpecificStudent.Visible = false;
                    DivEnquiryStudent.Visible = true;
                    GridEnquiryStudent.DataSource = null;
                    GridEnquiryStudent.DataBind();
                }
                else
                {
                    DivEnquiryStudent.Visible = false;
                    DivCheckBoxClasses.Visible = false;
                    DivChkSpecificStudent.Visible = false;
                }
            }
            else
            {
                DivEnquiryStudent.Visible = false;
                DivCheckBoxClasses.Visible = false;
                DivChkSpecificStudent.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void chkStudet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkStudet.Checked)
            {
                chkStaff.Checked = false;
                pnlStudent.Visible = true;
                pnlStaff.Visible = false;
            }
            else
            {
                pnlStudent.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void chkStaff_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkStaff.Checked)
            {
                pnlStaff.Visible = true;
                chkStudet.Checked = false;
                pnlStudent.Visible = false;
            }
            else
            {
                pnlStaff.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Insert.Value)
            {
                string str = Session["AdminContactNo"].ToString();
                //string str = "8602047392,9935258924,8602047392,9935258924";
                List<string> ContactList = new List<string>();
                foreach (string Contact in str.Split(','))
                    ContactList.Add(Contact);

                s = 0;
                if (ddlMsgHeads.SelectedIndex != 0 && ddlMsgType.SelectedIndex > 0)
                {
                    if (txtMsg.Text != "")
                    {
                        if (chkStudet.Checked)
                        {
                            if (ddlAllClass.SelectedIndex != 0)
                            {
                                if (ddlAllClass.SelectedIndex == 1)
                                {
                                    DataSet ds = new DataSet();
                                    ds = AllMethods.SendMsgAllClasess(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            msg =txtMsg.Text;
                                            string Mobile = dr[1].ToString();
                                            SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                            s++;
                                        }
                                    }
                                }
                                else if (ddlAllClass.SelectedIndex == 2)
                                {
                                    for (int i = 0; i < CheckBoxClasses.Items.Count; i++)
                                    {
                                        if (CheckBoxClasses.Items[i].Selected)
                                        {
                                            DataSet ds = new DataSet();
                                            ds = AllMethods.SendMsgSpecificClasess(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(CheckBoxClasses.Items[i].Value));
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in ds.Tables[0].Rows)
                                                {
                                                    msg =txtMsg.Text;
                                                    string Mobile = dr[1].ToString();
                                                    SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                                    s++;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (ddlAllClass.SelectedIndex == 3)
                                {
                                    int i = 0;
                                    foreach (DataKey d in Grid.DataKeys)
                                    {
                                        int InID = Convert.ToInt32(d.Value.ToString());
                                        if (((CheckBox)Grid.Rows[i].FindControl("ChkDelete")).Checked)
                                        {
                                            DataSet ds = new DataSet();
                                            ds = AllMethods.SendMsgSpecificStudent(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), InID);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in ds.Tables[0].Rows)
                                                {
                                                    msg =txtMsg.Text;
                                                    string Mobile = dr[1].ToString();
                                                    SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                                    s++;
                                                }
                                            }
                                        }
                                        i = i + 1;
                                    }
                                }
                                else if (ddlAllClass.SelectedIndex == 4)
                                {
                                    int i = 0;
                                    foreach (DataKey d in GridEnquiryStudent.DataKeys)
                                    {
                                        int EId = Convert.ToInt32(d.Value.ToString());
                                        if (((CheckBox)GridEnquiryStudent.Rows[i].FindControl("chkRow")).Checked)
                                        {
                                            DataSet ds = new DataSet();
                                            ds = AllMethods.SendMsgEnquiryStudent(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), EId);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in ds.Tables[0].Rows)
                                                {
                                                    msg =txtMsg.Text;
                                                    string Mobile = dr[1].ToString();
                                                    SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                                    s++;
                                                }
                                            }
                                        }
                                        i = i + 1;
                                    }
                                }
                            }
                            else
                            {
                                Globals.Message(Page, "Please select send message type....");
                            }
                            if (s > 0)
                            {
                                for (int i = 0; i < ContactList.Count(); i++)
                                {
                                    msg =txtMsg.Text;
                                    SendSMS.sendsmsapi(ContactList[i], msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                }
                                Globals.Message(Page, "Sent message successfully...");
                                ddlAllClass.SelectedIndex = 0;
                                chkStudet.Checked = false;
                                chkStudet_CheckedChanged(null, null);
                                ddlAllClass_SelectedIndexChanged(null, null);
                            }
                        }
                        else if (chkStaff.Checked)
                        {
                            if (ddlStaffAllClass.SelectedIndex != 0)
                            {
                                if (ddlStaffAllClass.SelectedIndex == 1)
                                {
                                    DataSet ds = new DataSet();
                                    ds = AllMethods.SendMsgAllStaff(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            msg = "Dear " + dr[0].ToString() + ",\n" + txtMsg.Text;
                                            string Mobile = dr[1].ToString();
                                            SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                            s++;
                                        }
                                    }
                                }
                                else if (ddlStaffAllClass.SelectedIndex == 2)
                                {
                                    for (int i = 0; i < chkDepartment.Items.Count; i++)
                                    {
                                        if (chkDepartment.Items[i].Selected)
                                        {
                                            DataSet ds = new DataSet();
                                            ds = AllMethods.SendMsgSpecificDepartment(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), chkDepartment.Items[i].Text);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in ds.Tables[0].Rows)
                                                {
                                                    msg = "Dear " + dr[0].ToString() + ",\n" + txtMsg.Text;
                                                    string Mobile = dr[1].ToString();
                                                    SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                                    s++;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (ddlStaffAllClass.SelectedIndex == 3)
                                {
                                    int i = 0;
                                    foreach (DataKey d in GridStaff.DataKeys)
                                    {
                                        int InID = Convert.ToInt32(d.Value.ToString());
                                        if (((CheckBox)GridStaff.Rows[i].FindControl("ChkDelete")).Checked)
                                        {
                                            DataSet ds = new DataSet();
                                            ds = AllMethods.SendMsgSpecificStaff(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), InID);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in ds.Tables[0].Rows)
                                                {
                                                    msg = "Dear " + dr[0].ToString() + ",\n" + txtMsg.Text;
                                                    string Mobile = dr[1].ToString();
                                                    SendSMS.sendsmsapi(Mobile, msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                                    s++;
                                                }
                                            }
                                        }
                                        i = i + 1;
                                    }
                                }
                            }
                            else
                            {
                                Globals.Message(Page, "Please select send message type....");
                            }
                            if (s > 0)
                            {
                                for (int i = 0; i < ContactList.Count(); i++)
                                {
                                    msg = "Dear Admin,\n" + txtMsg.Text;
                                    SendSMS.sendsmsapi(ContactList[i], msg, ddlMsgType.SelectedItem.Text, Session["MsgAPI"].ToString());
                                }
                                Globals.Message(Page, "Sent message successfully...");
                                ddlStaffAllClass.SelectedIndex = 0;
                                chkStaff.Checked = false;
                                chkStaff_CheckedChanged(null, null);
                                ddlStaffAllClass_SelectedIndexChanged(null, null);
                            }
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Please create template first....");
                        txtMsg.Focus();
                    }
                }
                else
                {
                    Globals.Message(Page, "Please select msg head....");
                    ddlMsgHeads.Focus();
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
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
        btnSave.Visible = true;
        btnSchedule.Visible = false;
        chkStudet.Checked = false;
        chkStaff.Checked = false;
        DivCheckBoxClasses.Visible = false;
        pnlStudent.Visible = false;
        pnlStaff.Visible = false;
        ddlAllClass.SelectedIndex = 0;
        ddlStaffAllClass.SelectedIndex = 0;
        DivCheckBoxClasses.Visible = false;
        DivchkDepartment.Visible = false;
        DivChkSpecificStudent.Visible = false;
        DivchkSpecificStaff.Visible = false;
        chkSchedule.Checked = false;

        DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss tt"));
        MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
        if (dt.ToString("tt") == "AM")
        {
            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
        }
        else
        {
            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
        }
        TimeSelector2.SetTime(dt.Hour, dt.Minute, am_pm);
    }
    protected void chkSpecificStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtsearch.Text = "";
            BindGrid();
        }
        catch (Exception ex)
        { }
    }


    private void BindGrid()
    {
        foreach (ListItem Li in chkSpecificStudent.Items)
        {
            if (Li.Selected)
            {
                if (txtsearch.Text != "")
                {
                    var DATA1 = from Cons in obj.Addmisions
                                where  Cons.CourseId == Convert.ToInt32(Li.Value) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtsearch.Text + "%") || SqlMethods.Like(Cons.AdmissionNo, "" + txtsearch.Text + "%"))
                                select Cons;
                    Grid.DataSource = DATA1;
                    Grid.DataBind();
                    break;
                }
                else
                {

                    var DATA1 = from Cons in obj.Addmisions
                                where Cons.CourseId == Convert.ToInt32(Li.Value) && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    Grid.DataSource = DATA1;
                    Grid.DataBind();
                    break;
                }
            }
        }
    }
    private void BindGridEnquiry()
    {
        foreach (ListItem Li in RadioEnquiryStudent.Items)
        {
            if (Li.Selected)
            {
                if (txtSearchEnquiry.Text != "")
                {
                    var DATA1 = from Cons in obj.Enquiries
                                where Cons.Status == Li.Value && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StudentName, "" + txtSearchEnquiry.Text + "%"))
                                select Cons;
                    GridEnquiryStudent.DataSource = DATA1;
                    GridEnquiryStudent.DataBind();
                    break;
                }
                else
                {

                    var DATA1 = from Cons in obj.Enquiries
                                where Cons.Status == Li.Value && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridEnquiryStudent.DataSource = DATA1;
                    GridEnquiryStudent.DataBind();
                    break;
                }
            }
        }
    }
    private void BindGridStaff()
    {
        foreach (ListItem Li in chkSpecificStaff.Items)
        {
            if (Li.Selected)
            {
                if (txtStaffSearch.Text != "")
                {
                    var DATA1 = from Cons in obj.Staffs
                                where Cons.Department == Li.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"]) && (SqlMethods.Like(Cons.StaffName, "" + txtStaffSearch.Text + "%") || SqlMethods.Like(Cons.StaffId, "" + txtStaffSearch.Text + "%"))
                                select Cons;
                    GridStaff.DataSource = DATA1;
                    GridStaff.DataBind();
                    break;
                }
                else
                {

                    var DATA1 = from Cons in obj.Staffs
                                where Cons.Department == Li.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    GridStaff.DataSource = DATA1;
                    GridStaff.DataBind();
                    break;
                }
            }
        }
    }
    protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid.PageIndex = e.NewPageIndex;
        BindGrid();
        Grid.DataBind();
    }
    protected void GridStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridStaff.PageIndex = e.NewPageIndex;
        BindGridEnquiry();
        GridStaff.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkSpecificStudent.SelectedIndex != -1)
            {
                BindGrid();
            }
            else
            {
                Globals.Message(Page, "Please select class first....");
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearchEnquiry_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioEnquiryStudent.SelectedIndex != -1)
            {
                BindGridEnquiry();
            }
            else
            {
                Globals.Message(Page, "Please select student status first....");
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlStaffAllClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStaffAllClass.SelectedIndex != 0 || ddlStaffAllClass.SelectedIndex != 1)
            {
                if (ddlStaffAllClass.SelectedIndex == 2)
                {
                    DivchkSpecificStaff.Visible = false;
                    DivchkDepartment.Visible = true;
                    var D = from Cons in obj.SINGLEVALUEDATAs
                            where Cons.ISDELETED==false && Cons.STID==3
                            select Cons;
                    chkDepartment.DataSource = D;
                    chkDepartment.DataTextField = "TABLEVALUE";
                    chkDepartment.DataValueField = "SVID";
                    chkDepartment.DataBind();
                }
                else if (ddlStaffAllClass.SelectedIndex == 3)
                {
                    DivchkSpecificStaff.Visible = true;
                    DivchkDepartment.Visible = false;
                    var D = from Cons in obj.SINGLEVALUEDATAs
                            where Cons.ISDELETED == false && Cons.STID == 3
                            select Cons;
                    chkSpecificStaff.DataSource = D;
                    chkSpecificStaff.DataTextField = "TABLEVALUE";
                    chkSpecificStaff.DataValueField = "SVID";
                    chkSpecificStaff.DataBind();
                    GridStaff.DataSource = null;
                    GridStaff.DataBind();
                }
                else
                {
                    DivchkSpecificStaff.Visible = false;
                    DivchkDepartment.Visible = false;
                }
            }
            else
            {
                DivchkSpecificStaff.Visible = false;
                DivchkDepartment.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void chkSpecificStaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtStaffSearch.Text = "";
            BindGridStaff();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnStaffSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridStaff();
        }
        catch (Exception ex)
        { }
    }
    protected void chkSchedule_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkSchedule.Checked)
            {
                btnSchedule.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnSchedule.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        try
        {
            if (role.Insert.Value)
            {
                string All = "", Specific = "", Perticular = "";
                int j = 0;
                if (ddlMsgHeads.SelectedIndex != 0)
                {
                    if (txtMsg.Text != "")
                    {
                        if (txtDate.Text != "")
                        {
                            if (chkStudet.Checked)
                            {
                                if (ddlAllClass.SelectedIndex != 0)
                                {
                                    if (ddlAllClass.SelectedIndex == 1)
                                    {
                                        All = ddlAllClass.SelectedItem.Text;
                                    }
                                    else if (ddlAllClass.SelectedIndex == 2)
                                    {
                                        j = 1;
                                        for (int i = 0; i < CheckBoxClasses.Items.Count; i++)
                                        {
                                            if (CheckBoxClasses.Items[i].Selected)
                                            {
                                                if (j == 1)
                                                {
                                                    Specific = CheckBoxClasses.Items[i].Value;
                                                }
                                                else
                                                {
                                                    Specific = Specific + "," + CheckBoxClasses.Items[i].Value;
                                                }
                                                j = j + 1;
                                            }
                                        }
                                    }
                                    else if (ddlAllClass.SelectedIndex == 3)
                                    {
                                        int i = 0;
                                        j = 1;
                                        foreach (DataKey d in Grid.DataKeys)
                                        {
                                            int InID = Convert.ToInt32(d.Value.ToString());
                                            if (((CheckBox)Grid.Rows[i].FindControl("ChkDelete")).Checked)
                                            {
                                                if (j == 1)
                                                {
                                                    Perticular = InID.ToString();
                                                }
                                                else
                                                {
                                                    Perticular = Perticular + "," + InID.ToString();
                                                }
                                                j = j + 1;
                                            }
                                            i = i + 1;
                                        }
                                    }
                                }
                                else
                                {
                                    Globals.Message(Page, "Please select message send type");
                                    ddlAllClass.Focus();
                                }
                            }
                            else if (chkStaff.Checked)
                            {
                                if (ddlStaffAllClass.SelectedIndex != 0)
                                {
                                    if (ddlStaffAllClass.SelectedIndex == 1)
                                    {
                                        All = ddlStaffAllClass.SelectedItem.Text;
                                    }
                                    else if (ddlStaffAllClass.SelectedIndex == 2)
                                    {
                                        j = 1;
                                        for (int i = 0; i < chkDepartment.Items.Count; i++)
                                        {
                                            if (chkDepartment.Items[i].Selected)
                                            {
                                                if (j == 1)
                                                {
                                                    Specific = chkDepartment.Items[i].Text;
                                                }
                                                else
                                                {
                                                    Specific = Specific + "," + chkDepartment.Items[i].Text;
                                                }
                                                j = j + 1;
                                            }
                                        }
                                    }
                                    else if (ddlStaffAllClass.SelectedIndex == 3)
                                    {
                                        int i = 0;
                                        j = 1;
                                        foreach (DataKey d in GridStaff.DataKeys)
                                        {
                                            int InID = Convert.ToInt32(d.Value.ToString());
                                            if (((CheckBox)GridStaff.Rows[i].FindControl("ChkDelete")).Checked)
                                            {
                                                if (j == 1)
                                                {
                                                    Perticular = InID.ToString();
                                                }
                                                else
                                                {
                                                    Perticular = Perticular + "," + InID.ToString();
                                                }
                                                j = j + 1;
                                            }
                                            i = i + 1;
                                        }
                                    }
                                }
                                else
                                {
                                    Globals.Message(Page, "Please select message send type");
                                    ddlAllClass.Focus();
                                }
                            }
                            else
                            {
                                Globals.Message(Page, "Please make a schedule first...");
                            }
                            if (chkStudet.Checked || chkStaff.Checked)
                            {
                                string time = string.Format("{0}:{1}:{2} {3}", TimeSelector2.Hour, TimeSelector2.Minute, TimeSelector2.Second, TimeSelector2.AmPm);
                                if (obj.Sp_MsgSchedule(1, 0, chkStudet.Checked ? chkStudet.Text : chkStaff.Text, All, Specific, Perticular, Convert.ToDateTime(Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy")), time, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), txtMsg.Text) == 0)
                                {
                                    Globals.Message(Page, "Message Scheduled successfully...");
                                    Clear();
                                }
                            }
                        }
                        else
                        {
                            Globals.Message(Page, "Please select/enter schedule date....");
                            txtMsg.Focus();
                        }
                    }
                    else
                    {
                        Globals.Message(Page, "Please create template first....");
                        txtMsg.Focus();
                    }
                }
                else
                {
                    Globals.Message(Page, "Please select msg head....");
                    ddlMsgHeads.Focus();
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception ex)
        { }
    }
    protected void RadioEnquiryStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtSearchEnquiry.Text = "";
            BindGridEnquiry();
        }
        catch (Exception ex)
        { }
    }

    protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkHeader = (CheckBox)GridEnquiryStudent.HeaderRow.FindControl("chkHeader");
        if (chkHeader.Checked)
        {
            foreach (GridViewRow gvrow in GridEnquiryStudent.Rows)
            {
                CheckBox chkRow = (CheckBox)gvrow.FindControl("chkRow");
                chkRow.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow gvrow in GridEnquiryStudent.Rows)
            {
                CheckBox chkRow = (CheckBox)gvrow.FindControl("chkRow");
                chkRow.Checked = false;
            }
        }
    }
    protected void chkRow_CheckedChanged(object sender, EventArgs e)
    {
        int count = 0;
        int totalRowCountGrid = GridEnquiryStudent.Rows.Count;
        CheckBox chkHeader = (CheckBox)GridEnquiryStudent.HeaderRow.FindControl("chkHeader");
        foreach (GridViewRow gvrow in GridEnquiryStudent.Rows)
        {
            CheckBox chkRow = (CheckBox)gvrow.FindControl("chkRow");
            if (chkRow.Checked)
            {
                count++;
            }
        }
        if (count == totalRowCountGrid)
        {
            chkHeader.Checked = true;
        }
        else
        {
            chkHeader.Checked = false;
        }
    }
}