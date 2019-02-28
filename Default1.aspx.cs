using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.IO.Compression;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    public static int SessionId = 0;
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session.Abandon();
                var DATA = from Cons in obj.Sessions
                             where Cons.Remove==false
                             select Cons;
                ddlSession.DataSource = DATA;
                ddlSession.DataTextField = "SessionName";
                ddlSession.DataValueField = "Sessionid";
                ddlSession.DataBind();
                ddlSession.Items.Insert(0,"Select Session");
                ddlSession.Focus();
                var sessions = from Cons in obj.Sessions
                           where Cons.Remove == false && Cons.Autoset==true
                           select Cons;
                ddlSession.ClearSelection();
                foreach (ListItem li in ddlSession.Items)
                {
                    if (li.Text == sessions.First().SessionName.ToString())
                    {
                        li.Selected = true;
                        break;
                    }
                }
                if (ddlSession.SelectedIndex != 0)
                {
                    Session["SessionId"] = sessions.First().Sessionid.ToString();
                    txtUserId.Focus();
                }
                SessionId = Convert.ToInt32(Session["SessionId"]);
                
                try
                {
                    Deletefolder();
                    AllMethods.BackupDataBase();
                }
                catch (Exception ex)
                { }
            }
        }
        catch (Exception ex)
        { }
    }
    internal void Deletefolder()
    {
        try
        {
            string date = System.DateTime.Now.ToString("yyyyMMdd");
            string path = AllMethods.DATABACEBACKUPPATH() + date + @"\";
            Directory.Delete(path, true);

        }
        catch (IOException ex)
        {
            //MessageBox.Show(ex.Message);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int sds = Convert.ToInt32(Session["SessionId"]);
        Session["SessionId"] = ddlSession.SelectedValue;
        try
        {
           
            var DATA1 = (from Cons in obj.Users
                       where Cons.UserLoingId == txtUserId.Text && Cons.Password==txtPassword.Text && Cons.Status=="Active"
                       select Cons.UserId).Count();

            if (Session["SessionId"] != null && ddlSession.SelectedIndex > 0)
            {
                if (DATA1 != 0)
                {
                    var DATA = from Cons in obj.Users
                               where Cons.UserLoingId == txtUserId.Text && Cons.Password == txtPassword.Text && Cons.Status == "Active"
                               select Cons;
                    Session["CompanyId"] = DATA.First().CompanyId;
                    Session["UserId"] = DATA.First().UserId;
                    Session["UserName"] = DATA.First().UserName;
                    Session["UserType"] = DATA.First().UserType;
                    Session["UserLoingId"] = DATA.First().UserLoingId;
                    Session["Password"] = DATA.First().Password;
                    obj.SP_SessionAutoSet(Convert.ToInt32(ddlSession.SelectedValue));
                    var D = from Cons in obj.Settings
                            where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                            select Cons;
                    Session["MsgAPI"] = D.First().MsgAPI;
                    Session["CompanyType"] = D.First().CompanyType;
                    Session["ClassLableText"] = "Class";
                    //Class/Course Lable
                    var DATACompanyIdWiseSetTexts = from x in obj.CompanyIdWiseSetTexts
                                                    where x.CompanyId == Convert.ToInt32(Session["CompanyId"]) && x.Type == "Class"
                                                    select x;
                    if (DATACompanyIdWiseSetTexts.Count() > 0)
                    {
                         Session["ClassLableText"] = DATACompanyIdWiseSetTexts.First().Text;
                    }

                    //School/College Lable
                    Session["SchoolLableText"] = "School";
                    var DATACompanyIdWiseSetTextSchool = from x in obj.CompanyIdWiseSetTexts
                                                         where x.CompanyId == Convert.ToInt32(Session["CompanyId"]) && x.Type == "School"
                                                    select x;
                    if (DATACompanyIdWiseSetTextSchool.Count() > 0)
                    {
                        Session["SchoolLableText"] = DATACompanyIdWiseSetTextSchool.First().Text;
                    }
                    //Section/Batch Lable
                    Session["SectionLableText"] = "Section";
                    var DATACompanyIdWiseSetTextSection = from x in obj.CompanyIdWiseSetTexts
                                                          where x.CompanyId == Convert.ToInt32(Session["CompanyId"]) && x.Type == "Section"
                                                         select x;
                    if (DATACompanyIdWiseSetTextSection.Count() > 0)
                    {
                        Session["SectionLableText"] = DATACompanyIdWiseSetTextSection.First().Text;
                    }
                    //Stream/Duration Lable
                    Session["StreamLableText"] = "Stream";
                    var DATACompanyIdWiseSetTextStream = from x in obj.CompanyIdWiseSetTexts
                                                         where x.CompanyId == Convert.ToInt32(Session["CompanyId"]) && x.Type == "Stream"
                                                          select x;
                    if (DATACompanyIdWiseSetTextStream.Count() > 0)
                    {
                        Session["StreamLableText"] = DATACompanyIdWiseSetTextStream.First().Text;
                    }
                    try
                    {
                        SendMsgAuto();
                    }
                    catch (Exception ex)
                    { }
                    Response.Redirect("Pages/Dashboard.aspx",false);
                }
                else
                {
                    msg = "Please enter currect userid or password...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                    txtUserId.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserId.Focus();
                }
            }
            else
            {
                msg = "Please select session...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                txtUserId.Text = string.Empty;
                txtPassword.Text = string.Empty;
                ddlSession.Focus();
            }
        }
        catch (Exception ex)
        { }
    }

    private void SendMsgAuto()
    {
        try
        {
            // Send Msg For Happy Birthday
            DataSet ds = new DataSet();
            ds = AllMethods.SendBirthdayMsg(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr[8].ToString()) != 1)
                    {
                        string msg = "Dear " + dr[0].ToString() + ",\nMay your sweet smile never fade way.\nI wish you a very happy and sweet birthday.\nGood bless you.\nRegards\n"+ dr[10].ToString().ToUpper();
                        string Mobile = dr[1].ToString();
                        if (Mobile.Length == 10)
                        {
                            SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                            obj.SP_SETMsgFlag(1, Convert.ToInt32(dr[7].ToString()), 1);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
        try
        {
            // Send Msg For Happy Marriage Anniversary
            DataSet ds = new DataSet();
            ds = AllMethods.SendParentMAMsg(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr[9].ToString()) != 1)
                    {
                        string msg = "Happy Anniversary Mr." + dr[2].ToString() + "/ Mrs." + dr[3].ToString() + ",\nWishing You Both All Of God Blessing ! \nMay The Lord Bless You All The Days Of Your Life.\nRegards\n" + dr[10].ToString().ToUpper();
                        string Mobile = dr[1].ToString();
                        if (Mobile.Length == 10)
                        {
                            SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                            obj.SP_SETMsgFlag(2, Convert.ToInt32(dr[7].ToString()), 1);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
        try
        {
            // Send staff Msg For Happy Birthday
            DataSet ds = new DataSet();
            ds = AllMethods.SendStaffBirthdayMsg(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr[5].ToString()) != 1)
                    {
                        string msg = "Dear " + dr[0].ToString() + ",\nOn your Big Day, it is my hope that\nyour academic journey will continue to be a wonderful experience for you.\nHappy birthday.\nRegards\n" + dr[7].ToString().ToUpper();
                        string Mobile = dr[1].ToString();
                        if (Mobile.Length == 10)
                        {
                            SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                            obj.SP_SETMsgFlag(3, Convert.ToInt32(dr[8].ToString()), 1);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedIndex != 0)
            {
                Session["SessionId"] = null;
                Session["SessionId"] = ddlSession.SelectedValue;
                txtUserId.Focus();
            }
            else
            {
                Session["SessionId"] = null;
            }
        }
        catch (Exception ex)
        { }
    }
}