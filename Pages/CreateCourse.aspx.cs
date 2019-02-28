using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq.SqlClient;
using System.Data;

public partial class Pages_CreateCourse : System.Web.UI.Page
{
    DataClassesDataContext obj = new DataClassesDataContext();
    string msg;
    int rowIndex = 0;
    public int Sno = 1;
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
                                                   where r.LoginId.Value == Convert.ToInt32(Session["UserId"]) && r.RoleId == 11
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
                    try
                    {
                        if (obj.Sp_CourseHead(5, 0, 0, "", 0, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                        {
                        }
                    }
                    catch (Exception ex) { }
                    var DATA2 = (from Cons in obj.Courses
                                 where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                 select Cons.SerialNo).Max() + 1;
                    if (DATA2 == null)
                    {
                        txtSerialNo.Text = "1";
                    }
                    else
                    {
                        txtSerialNo.Text = DATA2.ToString();
                    }
                    BindGrid1();
                    BindGrid();
                    BindddlHead();
                    if (Session["Courseid"] != null)
                    {
                        GetCourseData();
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex) { }
    }

    private void GetCourseData()
    {
        int id = Convert.ToInt32(Session["Courseid"]);
        var DATA = from Cons in obj.Courses
                   where Cons.Remove == false && Cons.CourseId == id && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                   select Cons;
        txtSerialNo.Text = DATA.First().SerialNo.ToString();
        txtCourseName.Text = DATA.First().CourseName;
        Session["txtCourseName"] = DATA.First().CourseName; ;
        txtFees.Text = DATA.First().FirstChildFees.ToString();
        if (DATA.First().SecChildDisType == "Flat")
        {
            ddlSecondDiscountType.SelectedIndex = 0;
        }
        else if (DATA.First().SecChildDisType == "Percent")
        {
            ddlSecondDiscountType.SelectedIndex = 1;
        }
        if (DATA.First().ThirdChildDisType == "Flat")
        {
            ddlThirdDiscountType.SelectedIndex = 0;
        }
        else if (DATA.First().ThirdChildDisType == "Percent")
        {
            ddlThirdDiscountType.SelectedIndex = 1;
        }
        txtSecondDiscount.Text = DATA.First().SecChildDiscount.ToString();
        txtThirdDiscount.Text = DATA.First().ThirdChildDiscount.ToString();
        txtSecondChildFees.Text = DATA.First().SecondChildFees.ToString();
        txtThirdChildFees.Text = DATA.First().ThirdChildFees.ToString();
        var DATA1 = from Cons in obj.CourseHeads
                    where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(Session["Courseid"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                    select Cons;
        Sno = 1;
        GridCourseHead.DataSource = DATA1;
        GridCourseHead.DataBind();
        BindddlHead();
    }
    private void clear()
    {
        try
        {
            var DATA = (from Cons in obj.Courses
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons.SerialNo).Max() + 1;

            if (DATA == null)
            {
                txtSerialNo.Text = "1";
            }
            else
            {
                txtSerialNo.Text = DATA.ToString();
            }
            ddlSecondDiscountType.SelectedIndex = 0;
            ddlThirdDiscountType.SelectedIndex = 0;
            txtSecondDiscount.Text = string.Empty;
            txtThirdDiscount.Text = string.Empty;
            txtSecondChildFees.Text = string.Empty;
            txtThirdChildFees.Text = string.Empty;
            txtCourseName.Text = string.Empty;
            txtFees.Text = string.Empty;
            Session["Courseid"] = null;
            Session["txtCourseName"] = null;
            GridCourseHead.EditIndex = -1;
            var DATA1 = from Cons in obj.CourseHeads
                        where Cons.Remove == false && Cons.CourseId == 0 && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            Sno = 1;
            GridCourseHead.DataSource = DATA1;
            GridCourseHead.DataBind();
            BindGrid1();
            BindGrid();

            BindddlHead();
        }
        catch (Exception ex)
        { }
    }

    private void BindddlHead()
    {
        IEnumerable<ClassHead> DATA2 = from Cons in obj.ClassHeads
                                       where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                                       select Cons;
        if (DATA2.Count<ClassHead>() > 0)
        {
            ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).DataSource = DATA2;
            ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).DataTextField = "Head";
            ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).DataBind();
            ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void BindGrid()
    {
        if (role.Select.Value)
        {
            var DATA1 = from Cons in obj.Courses
                        where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                        select Cons;
            GridCourse.DataSource = DATA1;
            GridCourse.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCourseName.Text != "")
            {
                if (Convert.ToDecimal(txtFees.Text) != 0 && Convert.ToDecimal(txtSecondChildFees.Text) != 0 && Convert.ToDecimal(txtThirdChildFees.Text) != 0)
                {
                    if (Session["Courseid"] == null)
                    {
                        if (role.Select.Value)
                        {
                            IEnumerable<Course> Courses = from id in obj.Courses
                                                          where id.CourseName == txtCourseName.Text.ToUpper() && id.Remove == false
                                                                && id.CompanyId == Convert.ToInt32(Session["CompanyId"]) && id.SessionId == Convert.ToInt32(Session["SessionId"])
                                                          select id;

                            if (Courses.Count<Course>() <= 0)
                            {
                                if (obj.Sp_Course(1,0, Convert.ToInt32(txtSerialNo.Text), txtCourseName.Text.ToUpper(), Convert.ToDecimal(txtFees.Text), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToDecimal(txtSecondChildFees.Text), Convert.ToDecimal(txtThirdChildFees.Text), Convert.ToInt32(Session["SessionId"]), "", "",
                  ddlSecondDiscountType.SelectedItem.Text, txtSecondDiscount.Text != "" ? Convert.ToDecimal(txtSecondDiscount.Text) : 0, ddlThirdDiscountType.SelectedItem.Text, txtThirdDiscount.Text != "" ? Convert.ToDecimal(txtThirdDiscount.Text) : 0, (Convert.ToDecimal(txtFees.Text) * 12), (Convert.ToDecimal(txtSecondChildFees.Text) * 12), (Convert.ToDecimal(txtThirdChildFees.Text)) * 12) == 0)
                                {
                                    var DATA = (from Cons in obj.Courses
                                                where Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                                select Cons.CourseId).Max();
                                    obj.Sp_CourseHead(4, 0, DATA != null ? Convert.ToInt32(DATA) : 0, "", 0, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"]));
                                    msg = "Record Insert Successfully!!";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                    clear();
                                }

                            }
                            else
                            {
                                msg = "This class is already exist!!";
                                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                txtCourseName.Focus();
                                clear();
                            }
                        }
                        else Globals.Message(Page, "Not Authorized ??");
                    }
                    else if (Session["Courseid"] != null)
                    {
                        if (role.Update.Value)
                        {
                            if (txtCourseName.Text == Session["txtCourseName"].ToString())
                            {
                                UpdateCourse();
                            }
                            else
                            {
                                IEnumerable<Course> comp = from c in obj.Courses
                                                           where c.CourseName == txtCourseName.Text
                                                           select c;
                                if (comp.Count<Course>() == 0)
                                {
                                    UpdateCourse();
                                }
                                else
                                {
                                    msg = "Same Class Name already exist...";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                                    txtCourseName.Text = Session["txtCourseName"].ToString();
                                    txtCourseName.Focus();
                                }
                            }
                        }
                        else Globals.Message(Page, "Not Authorized ??");

                    }
                }
                else
                {
                    msg = "Please insert head first...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                    ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).Focus();
                }
            }
            else
            {
                msg = "Please enter course name...";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                txtCourseName.Focus();
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void UpdateCourse()
    {
        if (obj.Sp_Course(2, Convert.ToInt32(Session["Courseid"]), Convert.ToInt32(txtSerialNo.Text), txtCourseName.Text.ToUpper(), Convert.ToDecimal(txtFees.Text), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToDecimal(txtSecondChildFees.Text), Convert.ToDecimal(txtThirdChildFees.Text), Convert.ToInt32(Session["SessionId"]), "", "",
             ddlSecondDiscountType.SelectedItem.Text, txtSecondDiscount.Text != "" ? Convert.ToDecimal(txtSecondDiscount.Text) : 0, ddlThirdDiscountType.SelectedItem.Text, txtThirdDiscount.Text != "" ? Convert.ToDecimal(txtThirdDiscount.Text) : 0, (Convert.ToDecimal(txtFees.Text)) * 12, (Convert.ToDecimal(txtSecondChildFees.Text)) * 12, (Convert.ToDecimal(txtThirdChildFees.Text)) * 12) == 0)
        {
            msg = "Record Updated Successfully!!";
            ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            clear();
        }
    }
    protected void GridCourse_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                int id = Convert.ToInt32(GridCourse.DataKeys[e.NewSelectedIndex].Value);
                Session["Courseid"] = GridCourse.DataKeys[e.NewSelectedIndex].Value;
                Response.Redirect(Request.RawUrl);
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
            clear();
        }
        catch (Exception ex)
        { }
    }
   

    public void CalcAmount()
    {
        try
        {
            decimal TotalAmount = 0, Amount = 0;
            for (int Index = 0; Index < GridCourseHead.Rows.Count; Index++)
            {
                try
                {
                    Amount = Convert.ToDecimal(((Label)GridCourseHead.Rows[Index].FindControl("Label4")).Text);
                }
                catch (Exception ex)
                { Amount = 0; }
                TotalAmount = TotalAmount + Amount;
            }
            txtFees.Text = TotalAmount.ToString();
            txtSecondChildFees.Text = TotalAmount.ToString();
            txtThirdChildFees.Text = TotalAmount.ToString();
        }
        catch (Exception ex)
        { }
    }
    private void BindGrid1()
    {
        var DATA = from Cons in obj.CourseHeads
                   where Cons.Remove == false && Cons.CourseId == 0 && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                   select Cons;
        
        if (GridCourseHead.Rows.Count > 0)
        {
            Sno = 1;
            GridCourseHead.DataSource = DATA;
            GridCourseHead.DataBind();
        }
        else
        {
            Sno = 1;
            GridCourseHead.DataSource = Get_EmptyDataTable();
            GridCourseHead.DataBind();
        }
        CalcAmount();
        FSChildCalc();
    }

    protected void linkinsert_OnClick(object sender, EventArgs e)
    {
      
        if (Session["Courseid"] == null)
        {
            if (role.Insert.Value)
            {
                  var DATA2 = (from Cons in obj.CourseHeads
                     where Cons.CourseId == 0 && Cons.Head == ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).SelectedItem.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                     select Cons).Count();
                  if (DATA2 == 0)
                  {
                      if (obj.Sp_CourseHead(1, 0, 0, ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).Text, Convert.ToDecimal(((TextBox)GridCourseHead.FooterRow.FindControl("txtAmount")).Text), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                      {

                          BindGrid1();
                          BindddlHead();
                          ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).Focus();
                      }
                  }
                 else Globals.Message(Page, "Already selected...");
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        else if (Session["Courseid"] != null)
        {
            if (role.Update.Value)
            {
                var DATA2 = (from Cons in obj.CourseHeads
                             where Cons.CourseId ==Convert.ToInt32(Session["Courseid"].ToString()) && Cons.Head == ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).SelectedItem.Text && Cons.Remove == false && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                             select Cons).Count();
                if (DATA2 == 0)
                {
                    if (obj.Sp_CourseHead(1, 0, Convert.ToInt32(Session["Courseid"]), ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).Text, Convert.ToDecimal(((TextBox)GridCourseHead.FooterRow.FindControl("txtAmount")).Text), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                    {
                        var DATA1 = from Cons in obj.CourseHeads
                                    where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(Session["Courseid"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        Sno = 1;
                        GridCourseHead.DataSource = DATA1;
                        GridCourseHead.DataBind();
                        CalcAmount();
                        FSChildCalc();
                        BindddlHead();
                        ((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).Focus();
                    }
                }
                else Globals.Message(Page, "Already selected...");
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
    }
    protected void LnkDelete_OnClick(object sender, EventArgs e)
    {
        if (role.Delete.Value)
        {
            string id = (sender as LinkButton).CommandArgument;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;
            if (id != "")
            {
                if (obj.Sp_CourseHead(3, Convert.ToInt32(id), 0, "", 0, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                {

                    if (Session["Courseid"] == null)
                    {
                        var DATA = from Cons in obj.CourseHeads
                                   where Cons.Remove == false && Cons.CourseId == 0 && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                   select Cons;
                        GridCourseHead.DataSource = DATA;
                        GridCourseHead.DataBind();
                        BindGrid1();
                        BindddlHead();
                    }
                    else
                    {
                        var DATA1 = from Cons in obj.CourseHeads
                                    where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(Session["Courseid"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        Sno = 1;
                        GridCourseHead.DataSource = DATA1;
                        GridCourseHead.DataBind();
                        CalcAmount();
                        FSChildCalc();
                        BindddlHead();
                        if (GridCourseHead.Rows.Count <= 0)
                        {
                            Sno = 1;
                            GridCourseHead.DataSource = Get_EmptyDataTable();
                            GridCourseHead.DataBind();
                            BindddlHead();
                        }
                    }
                }
            }
        }
        else Globals.Message(Page, "Not Authorized ??");
    }

    protected void lnkUpdate_OnClick(object sender, EventArgs e)
    {
        if (role.Update.Value)
        {
            string id = (sender as LinkButton).CommandArgument;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            rowIndex = row.RowIndex;
            if (Session["Courseid"] == null)
            {
                if (obj.Sp_CourseHead(2, Convert.ToInt32(id), 0, ((TextBox)GridCourseHead.Rows[rowIndex].FindControl("TextBox1")).Text, Convert.ToDecimal(((TextBox)GridCourseHead.Rows[rowIndex].FindControl("TextBox2")).Text), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                {
                    GridCourseHead.EditIndex = -1;
                    BindGrid1();
                    BindddlHead();
                }
            }
            else if (Session["Courseid"] != null)
            {
                if (obj.Sp_CourseHead(2, Convert.ToInt32(id), Convert.ToInt32(Session["Courseid"]), ((TextBox)GridCourseHead.Rows[rowIndex].FindControl("TextBox1")).Text, Convert.ToDecimal(((TextBox)GridCourseHead.Rows[rowIndex].FindControl("TextBox2")).Text), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["SessionId"])) == 0)
                {
                    var DATA1 = from Cons in obj.CourseHeads
                                where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(Session["Courseid"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                select Cons;
                    Sno = 1;
                    GridCourseHead.EditIndex = -1;
                    GridCourseHead.DataSource = DATA1;
                    GridCourseHead.DataBind();
                    CalcAmount();
                    FSChildCalc();
                    BindddlHead();
                }
            }
        }
        else Globals.Message(Page, "Not Authorized ??");
    }
    protected void GridCourseHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
        if (rowIndex >= 0)
        {
            if (((Label)GridCourseHead.Rows[rowIndex].FindControl("Label1")).Text != "")
            {
                if (e.CommandName == "EditRow")
                {
                    if (role.Update.Value)
                    {
                        if (Session["Courseid"] == null)
                        {
                            GridCourseHead.EditIndex = rowIndex;
                            var DATA = from Cons in obj.CourseHeads
                                       where Cons.Remove == false && Cons.CourseId == 0 && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                       select Cons;
                            GridCourseHead.DataSource = DATA;
                            GridCourseHead.DataBind();
                            BindGrid1();
                            BindddlHead();
                        }
                        else if (Session["Courseid"] != null)
                        {
                            GridCourseHead.EditIndex = rowIndex;
                            var DATA1 = from Cons in obj.CourseHeads
                                        where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(Session["Courseid"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                        select Cons;
                            Sno = 1;
                            GridCourseHead.DataSource = DATA1;
                            GridCourseHead.DataBind();
                            BindddlHead();
                        }
                    }
                    else Globals.Message(Page, "Not Authorized ??");
                }
                else if (e.CommandName == "CancleUpdate")
                {
                    if (Session["Courseid"] == null)
                    {
                        GridCourseHead.EditIndex = -1;
                        BindGrid1();
                        BindddlHead();
                    }
                    else if (Session["Courseid"] != null)
                    {
                        GridCourseHead.EditIndex = -1;
                        var DATA1 = from Cons in obj.CourseHeads
                                    where Cons.Remove == false && Cons.CourseId == Convert.ToInt32(Session["Courseid"]) && Cons.CompanyId == Convert.ToInt32(Session["CompanyId"]) && Cons.SessionId == Convert.ToInt32(Session["SessionId"])
                                    select Cons;
                        Sno = 1;
                        GridCourseHead.DataSource = DATA1;
                        GridCourseHead.DataBind();
                        CalcAmount();
                        FSChildCalc();
                        BindddlHead();
                    }
                }
            }
        }
        else Globals.Message(Page, "Already selected...");
    }
    public DataTable Get_EmptyDataTable()
    {
        DataTable dtEmpty = new DataTable();
        //Here ensure that you have added all the column available in your gridview
        dtEmpty.Columns.Add("CourseHeadId", typeof(string));
        dtEmpty.Columns.Add("Sno", typeof(string));
        dtEmpty.Columns.Add("Head", typeof(string));
        dtEmpty.Columns.Add("Amount", typeof(string));
        DataRow datatRow = dtEmpty.NewRow();

        //Inserting a new row,datatable .newrow creates a blank row
        dtEmpty.Rows.Add(datatRow);//adding row to the datatable
        return dtEmpty;
    }

    protected void ddlSecondDiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSecondDiscountType.SelectedIndex == 0)
            {
                txtSecondDiscount.Focus();
                txtSecondDiscount.Attributes["placeholder"] = "Rs.";
                txtSecondDiscount.Text = "";
                FSChildCalc();
            }
            else
            {
                txtSecondDiscount.Focus();
                txtSecondDiscount.Attributes["placeholder"] = "%";
                txtSecondDiscount.Text = "";
                FSChildCalc();
            }
        }
        catch (Exception ex)
        { }

    }
    protected void ddlThirdDiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlThirdDiscountType.SelectedIndex == 0)
            {
                txtThirdDiscount.Focus();
                txtThirdDiscount.Attributes["placeholder"] = "Rs.";
                txtThirdDiscount.Text = "";
                FSChildCalc();
            }
            else
            {
                txtThirdDiscount.Focus();
                txtThirdDiscount.Attributes["placeholder"] = "%";
                txtThirdDiscount.Text = "";
                FSChildCalc();
            }
        }
        catch (Exception ex)
        { }
    }
    public void FSChildCalc()
    {
        try
        {
            decimal SecoundAmount = 0,SecondDiscount=0,ThirdDiscount=0, ThirdAmount = 0, SecondTotalAmount = 0, ThirdTotalAmount = 0;
            try
            {
                SecoundAmount = Convert.ToDecimal(txtFees.Text);
            }
            catch (Exception ex)
            { SecoundAmount = 0; }
            try
            {
                ThirdAmount = Convert.ToDecimal(txtFees.Text);
            }
            catch (Exception ex)
            { ThirdAmount = 0; }
            try
            {
                SecondDiscount = Convert.ToDecimal(txtSecondDiscount.Text);
            }
            catch (Exception ex)
            { SecondDiscount = 0; }
            try
            {
                ThirdDiscount = Convert.ToDecimal(txtThirdDiscount.Text);
            }
            catch (Exception ex)
            { ThirdDiscount = 0; }

            if (ddlSecondDiscountType.SelectedItem.Text == "Flat" && ddlSecondDiscountType.SelectedIndex == 0)
            {
                SecondTotalAmount = SecoundAmount - SecondDiscount;
                txtSecondChildFees.Text = SecondTotalAmount.ToString();
            }
            else if (ddlSecondDiscountType.SelectedItem.Text == "Percent" && ddlSecondDiscountType.SelectedIndex == 1)
            {
                SecondTotalAmount = ((SecoundAmount * SecondDiscount) / 100);
                txtSecondChildFees.Text = (Convert.ToDecimal(txtFees.Text) - SecondTotalAmount).ToString();
            }

            if (ddlThirdDiscountType.SelectedItem.Text == "Flat" && ddlThirdDiscountType.SelectedIndex == 0)
            {
                ThirdTotalAmount = ThirdAmount - ThirdDiscount;
                txtThirdChildFees.Text = ThirdTotalAmount.ToString();
            }
            else if (ddlThirdDiscountType.SelectedItem.Text == "Percent" && ddlThirdDiscountType.SelectedIndex == 1)
            {
                ThirdTotalAmount = ((ThirdAmount * ThirdDiscount) / 100);
                txtThirdChildFees.Text = (Convert.ToDecimal(txtFees.Text) - ThirdTotalAmount).ToString();
            }
        }
        catch (Exception ex)
        {}
    }
    protected void txtSecondDiscount_TextChanged(object sender, EventArgs e)
    {
        FSChildCalc();
    }
    protected void txtThirdDiscount_TextChanged(object sender, EventArgs e)
    {
        FSChildCalc();
    }
    protected void ddlHead_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (((DropDownList)GridCourseHead.FooterRow.FindControl("ddlHead")).SelectedIndex != 0)
            {
                ((TextBox)GridCourseHead.FooterRow.FindControl("txtAmount")).Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void GridCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridCourse.PageIndex = e.NewPageIndex;
            BindGrid();
            BindddlHead();
            GridCourse.DataBind();
        }
        catch (Exception ex) { }
    }
}