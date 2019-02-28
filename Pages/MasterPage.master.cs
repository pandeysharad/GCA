using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class Pages_MasterPage : System.Web.UI.MasterPage
{
   
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionId"] != null)
            {
                if (IsPostBack == false)
                {
                    if (Session["CompanyId"] != null)
                    {
                        try
                        {
                            TodayCollection.Text = AllMethods.GetTodayCollectionUserWise(Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"]));
                            var DATA = from Cons in obj.Settings
                                       where Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                                       select Cons;
                            Session["MsgAPI"] = DATA.First().MsgAPI;
                            Session["SchoolName"] = DATA.First().SchoolName;
                            Session["SendSMSFlag"] = DATA.First().SendMsg;
                            Session["AdminContactNo"] = DATA.First().ContactNo;
                            CompanyName.Text = DATA.First().SchoolName;
                        }
                        catch (Exception ex)
                        { }
                        var DATA1 = from Cons in obj.Sessions
                                    where Cons.Sessionid == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        lblSessionName.Text = "SESSION: " + DATA1.First().SessionName;
                        lbUser.Text = Session["UserName"].ToString();
                        try
                        {
                            if (Session["UserType"].ToString() != "Admin")
                            {
                                ShowModule();
                            }
                            //try
                            //{
                            //    ScheduledMsgSend();
                            //}
                            //catch (Exception ex)
                            //{ }
                            try
                            {
                                UpdateAgeAuto();
                            }
                            catch (Exception ex)
                            { }
                        }
                        catch (Exception ex) { }
                    }
                    else
                    {
                        Response.Redirect("../Default.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../Default.aspx");
        }
    }
    public void UpdateAgeAuto()
    {
        try
        {
            IEnumerable<Addmision> Addmisions = from Cons in obj.Addmisions
                                                   where Cons.Remove == false 
                                                   select Cons;
            foreach (Addmision Cd in Addmisions.ToList<Addmision>())
            {
                 DataSet ds = new DataSet();
                ds = AllMethods.CALCULATEAGE(Cd.DOB);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        obj.SP_UpdateAgeAuto(1, Cd.AdmissionId, dr[0].ToString());

                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    private void ScheduledMsgSend()
    {
        try
        {
            int s = 0;
            IEnumerable<MsgSchedule> MsgSchedule = from Cons in obj.MsgSchedules
                                                   where Cons.Remove == false && Cons.MsgSent == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                   select Cons;
            foreach (MsgSchedule Cd in MsgSchedule.ToList<MsgSchedule>())
            {
                s = 0;
                DateTime SetTime, NowTime;
                NowTime = Convert.ToDateTime(string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(System.DateTime.Now.ToString("hh:mm:ss tt"))));
                SetTime = Convert.ToDateTime(string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(Convert.ToDateTime(Cd.Time).ToString("hh:mm:ss tt"))));
                if (Convert.ToDateTime(Convert.ToDateTime(Cd.Date).ToString("dd/MM/yyyy")) <= Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    if (NowTime >= SetTime)
                    {
                        if (Cd.ScheduleType == "STUDENT")
                        {
                            if (Cd.ALL != "")
                            {
                                DataSet ds = new DataSet();
                                ds = AllMethods.SendMsgAllClasess(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        s = 1;
                                        string msg = "Dear " + dr[0].ToString() + ",\n" +Cd.Msg;
                                        string Mobile = dr[1].ToString();
                                        try
                                        {
                                            SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                        }
                                        catch (Exception ex)
                                        { }
                                    }
                                }
                            }
                            else if (Cd.Specific != "")
                            {
                                string str = Cd.Specific;
                                //string str = "8602047392,9935258924,8602047392,9935258924";
                                string str1 = "";
                                int Count = 0;
                                string Actual = "";
                                Count = str.Length;
                                for (int i = 0; i <= Count; i++)
                                {
                                    if (i != Count)
                                    {
                                        str1 = str.Substring(i, 1);
                                    }
                                    if (i == Count)
                                    {
                                        ddlSpecific.Items.Add(Actual);
                                    }
                                    if (str1 != ",")
                                    {
                                        Actual = Actual + str1;
                                    }
                                    else
                                    {
                                        ddlSpecific.Items.Add(Actual);
                                        Actual = "";
                                    }
                                }
                                for (int i = 0; i < ddlSpecific.Items.Count; i++)
                                {
                                    DataSet ds = new DataSet();
                                    ds = AllMethods.SendMsgSpecificClasess(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlSpecific.Items[i].ToString()));
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            s = 1;
                                            string msg = "Dear " + dr[0].ToString() + ",\n" + Cd.Msg;
                                            string Mobile = dr[1].ToString();
                                            try
                                            {
                                                SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                            }
                                            catch (Exception ex)
                                            { }
                                        }
                                    }
                                }
                            }
                            else if (Cd.Perticular != "")
                            {
                                string str = Cd.Perticular;
                                //string str = "8602047392,9935258924,8602047392,9935258924";
                                string str1 = "";
                                int Count = 0;
                                string Actual = "";
                                Count = str.Length;
                                for (int i = 0; i <= Count; i++)
                                {
                                    if (i != Count)
                                    {
                                        str1 = str.Substring(i, 1);
                                    }
                                    if (i == Count)
                                    {
                                        ddlPerticular.Items.Add(Actual);
                                    }
                                    if (str1 != ",")
                                    {
                                        Actual = Actual + str1;
                                    }
                                    else
                                    {
                                        ddlPerticular.Items.Add(Actual);
                                        Actual = "";
                                    }
                                }
                                for (int i = 0; i < ddlPerticular.Items.Count; i++)
                                {
                                    DataSet ds = new DataSet();
                                    ds = AllMethods.SendMsgSpecificStudent(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlPerticular.Items[i].ToString()));
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            s = 1;
                                            string msg = "Dear " + dr[0].ToString() + ",\n" + Cd.Msg;
                                            string Mobile = dr[1].ToString();
                                            try
                                            {
                                                SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                            }
                                            catch (Exception ex)
                                            { }
                                        }
                                    }
                                }
                            }
                        }
                        else if (Cd.ScheduleType == "STAFF")
                        {
                            if (Cd.ALL != "")
                            {
                                DataSet ds = new DataSet();
                                ds = AllMethods.SendMsgAllStaff(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        s = 1;
                                        string msg = "Dear " + dr[0].ToString() + ",\n" + Cd.Msg;
                                        string Mobile = dr[1].ToString();
                                        try
                                        {
                                            SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                        }
                                        catch (Exception ex)
                                        { }
                                    }
                                }
                            }
                            else if (Cd.Specific != "")
                            {
                                string str = Cd.Specific;
                                //string str = "8602047392,9935258924,8602047392,9935258924";
                                string str1 = "";
                                int Count = 0;
                                string Actual = "";
                                Count = str.Length;
                                for (int i = 0; i <= Count; i++)
                                {
                                    if (i != Count)
                                    {
                                        str1 = str.Substring(i, 1);
                                    }
                                    if (i == Count)
                                    {
                                        ddlSpecific.Items.Add(Actual);
                                    }
                                    if (str1 != ",")
                                    {
                                        Actual = Actual + str1;
                                    }
                                    else
                                    {
                                        ddlSpecific.Items.Add(Actual);
                                        Actual = "";
                                    }
                                }
                                for (int i = 0; i < ddlSpecific.Items.Count; i++)
                                {
                                    DataSet ds = new DataSet();
                                    ds = AllMethods.SendMsgSpecificDepartment(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), ddlSpecific.Items[i].ToString());
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            s = 1;
                                            string msg = "Dear " + dr[0].ToString() + ",\n" + Cd.Msg;
                                            string Mobile = dr[1].ToString();
                                            try
                                            {
                                                SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                            }
                                            catch (Exception ex)
                                            { }
                                        }
                                    }
                                }
                            }
                            else if (Cd.Perticular != "")
                            {
                                string str = Cd.Perticular;
                                //string str = "8602047392,9935258924,8602047392,9935258924";
                                string str1 = "";
                                int Count = 0;
                                string Actual = "";
                                Count = str.Length;
                                for (int i = 0; i <= Count; i++)
                                {
                                    if (i != Count)
                                    {
                                        str1 = str.Substring(i, 1);
                                    }
                                    if (i == Count)
                                    {
                                        ddlPerticular.Items.Add(Actual);
                                    }
                                    if (str1 != ",")
                                    {
                                        Actual = Actual + str1;
                                    }
                                    else
                                    {
                                        ddlPerticular.Items.Add(Actual);
                                        Actual = "";
                                    }
                                }
                                for (int i = 0; i < ddlPerticular.Items.Count; i++)
                                {
                                    DataSet ds = new DataSet();
                                    ds = AllMethods.SendMsgSpecificStaff(Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]), Convert.ToInt32(ddlPerticular.Items[i].ToString()));
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            s = 1;
                                            string msg = "Dear " + dr[0].ToString() + ",\n" + Cd.Msg;
                                            string Mobile = dr[1].ToString();
                                            try
                                            {
                                                SendSMS.sendsmsapi(Mobile, msg, "", Session["MsgAPI"].ToString());
                                            }
                                            catch (Exception ex)
                                            { }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (s == 1)
                {
                    obj.Sp_MsgSchedule(4, Convert.ToInt32(Cd.MsgScheduleId), "", "", "", "", DateTime.Now, "", Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0), "");
                }
            }
        }
        catch (Exception ex)
        { }
    }
    private void ShowModule()
    {
        try
        {
            IEnumerable<LoginRole> roles1 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 1
                                            select r;
            foreach (LoginRole role in roles1.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    admincontrol.Visible = false;
                    break;
                }
                else
                {
                    admincontrol.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles2 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 2
                                            select r;
            foreach (LoginRole role in roles2.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    LiEnquiry.Visible = false;
                    break;
                }
                else
                {
                    LiEnquiry.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles3 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 3
                                            select r;
            foreach (LoginRole role in roles3.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    LiAddmision.Visible = false;
                    break;
                }
                else
                {
                    LiAddmision.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles4 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 4
                                            select r;
            foreach (LoginRole role in roles4.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    Feesmgnt.Visible = false;
                    break;
                }
                else
                {
                    Feesmgnt.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles5 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 5
                                            select r;
            foreach (LoginRole role in roles5.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    Staff.Visible = false;
                    break;
                }
                else
                {
                    Staff.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles6 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 6
                                            select r;
            foreach (LoginRole role in roles6.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    librarymgnt.Visible = false;
                    break;
                }
                else
                {
                    librarymgnt.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles7 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 7
                                            select r;
            foreach (LoginRole role in roles7.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    Inventory.Visible = false;
                    break;
                }
                else
                {
                    Inventory.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles8 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 8
                                            select r;
            foreach (LoginRole role in roles8.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    Examination.Visible = false;
                    break;
                }
                else
                {
                    Examination.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles9 = from r in obj.LoginRoles
                                            where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 9
                                            select r;
            foreach (LoginRole role in roles9.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    Result.Visible = false;
                    break;
                }
                else
                {
                    Result.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles10 = from r in obj.LoginRoles
                                             where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 10
                                             select r;
            foreach (LoginRole role in roles10.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    MessagePortal.Visible = false;
                    break;
                }
                else
                {
                    MessagePortal.Visible = true;
                }
            }
            IEnumerable<LoginRole> roles11 = from r in obj.LoginRoles
                                             where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 11
                                             select r;
            foreach (LoginRole role in roles11.ToList<LoginRole>())
            {
                if (role.Insert == false && role.Update == false && role.Delete == false && role.Select == false)
                {
                    Master.Visible = false;
                    break;
                }
                else
                {
                    Master.Visible = true;
                }
            }
        }
        catch (Exception ex) { }
    }
    protected void myLink_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");
        }
        catch (Exception ex)
        { }
    }
}
