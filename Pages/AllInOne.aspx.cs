using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AllInOne : System.Web.UI.Page
{
    int LogId = 0;
    public int srno = 1;
    DataClassesDataContext obj = new DataClassesDataContext();
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
            if (!IsPostBack)
            {

                if (Session["CompanyId"] != null)
                {
                    GetdataAll();
                    getTableHeads();
                    //ddltablehead.ClearSelection();
                    //for (int i = 0; i < ddltablehead.Items.Count; i++)
                    //{
                    //    if (ddltablehead.Items[i].Text.Equals("BANK"))
                    //    {
                    //        ddltablehead.SelectedIndex = i; break;
                    //    }
                    //}
                    //ddltablehead.Enabled = false;
                    Getadata();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        catch (Exception ex) { }

    }
    private void getTableHeads()
    {
        ddltablehead.DataSource = obj.SP_GET_SINGLEVALUETABLES(0,Convert.ToInt32(Session["CompanyId"].ToString()));
        ddltablehead.DataValueField = "STID";
        ddltablehead.DataTextField = "TABLENAME";
        ddltablehead.DataBind();
        ddltablehead.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddltablehead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (role.Select.Value)
        {
            Getadata();
        }
        else Globals.Message(Page, "Not Authorized ??");
    }
    protected void btnsaveem_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (role.Insert.Value)
            {
                if (ddltablehead.SelectedIndex > 0)
                {

                    ImageButton img = (ImageButton)sender;
                    GridViewRow grow = (GridViewRow)img.NamingContainer;
                    TextBox txtval = (TextBox)grow.FindControl("txteminsertvalue");
                    TextBox txtvalue = (TextBox)grow.FindControl("txtvalue");
                    if (string.IsNullOrEmpty(txtval.Text))
                    {
                        Globals.Message(this.Page, "Please enter head...");
                        txtval.Focus();
                    }
                    else
                    {

                        if (obj.SP_SINGLEVALUEDATA(1, 0, Convert.ToInt32(ddltablehead.SelectedItem.Value), txtval.Text.ToUpper().Trim(), string.Empty, false, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["UserId"]), DateTime.Now,Convert.ToInt32(Session["CompanyId"].ToString()),0) == 0)
                        {
                            Globals.Message(this.Page, "Record Saved !!");
                            Getadata(); txtvalue.Focus();

                        }
                        else
                        {
                            Globals.Message(this.Page, "Record Not Saved !!");
                        }
                    }
                }
                else
                {
                    Globals.Message(this.Page, "Please select heading...");
                    ddltablehead.Focus();
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Record Not Saved " + epp.Message);
        }

    }
    protected void btnsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (role.Insert.Value)
            {
                if (ddltablehead.SelectedIndex > 0)
                {
                    ImageButton img = (ImageButton)sender;
                    GridViewRow grow = (GridViewRow)img.NamingContainer;
                    TextBox txtval = (TextBox)grow.FindControl("txtinsertvalue");
                    if (string.IsNullOrEmpty(txtval.Text))
                    {
                        Globals.Message(this.Page, "Please enter head...");
                        txtval.Focus();
                    }
                    else
                    {

                        if (obj.SP_SINGLEVALUEDATA(1, 0, Convert.ToInt32(ddltablehead.SelectedItem.Value), txtval.Text.ToUpper().Trim(), string.Empty, false, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["CompanyId"].ToString()), 0) == 0)
                        {
                            Globals.Message(this.Page, "Record Saved !!");
                            Getadata();
                            txtval.Focus();
                        }
                        else
                        {
                            Globals.Message(this.Page, "Record Not Saved !!");
                        }
                    }
                }
                else
                {
                    Globals.Message(this.Page, "Please select heading...");
                    ddltablehead.Focus();
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Record Not Saved " + epp.Message);
        }

    }
    protected void btnedit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                if (ddltablehead.SelectedIndex > 0)
                {

                    ImageButton img = (ImageButton)sender;
                    GridViewRow grow = (GridViewRow)img.NamingContainer;
                    Label lblvalue = (Label)grow.FindControl("lblvalue");
                    TextBox txtvalue = (TextBox)grow.FindControl("txtvalue");
                    ImageButton btnupdate = (ImageButton)grow.FindControl("btnupdate");

                    lblvalue.Visible = false;
                    txtvalue.Visible = true;
                    btnupdate.Visible = true;
                }
                else
                {
                    Globals.Message(this.Page, "Please select heading...");
                    ddltablehead.Focus();
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Record Not Deleted " + epp.Message);
        }

    }

    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (role.Delete.Value)
            {
                if (ddltablehead.SelectedIndex > 0)
                {
                    ImageButton img = (ImageButton)sender;
                    GridViewRow grow = (GridViewRow)img.NamingContainer;
                    string id = Grd.DataKeys[grow.RowIndex].Value.ToString();
                    TextBox txtvalue = (TextBox)grow.FindControl("txtvalue");
                    if (string.IsNullOrEmpty(id))
                    {
                        Globals.Message(this.Page, "Please enter head...");
                        txtvalue.Focus();
                    }
                    else
                    {

                        if (obj.SP_SINGLEVALUEDATA(3, Convert.ToInt32(id), Convert.ToInt32(ddltablehead.SelectedItem.Value), string.Empty, string.Empty, false, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["CompanyId"].ToString()), 0) == 0)
                        {
                            Globals.Message(this.Page, "Record Deleted !!");
                            Getadata();
                            txtvalue.Focus();

                        }
                        else
                        {
                            Globals.Message(this.Page, "Record Not Deleted !!");
                        }
                    }
                }
                else
                {
                    Globals.Message(this.Page, "Please select heading...");
                    ddltablehead.Focus();
                }
            }
            else Globals.Message(Page, "Not Authorized ??");
        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Record Not Deleted " + epp.Message);
        }

    }
    protected void btnupdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (role.Update.Value)
            {
                if (ddltablehead.SelectedIndex > 0)
                {
                    ImageButton img = (ImageButton)sender;
                    GridViewRow grow = (GridViewRow)img.NamingContainer;
                    string id = Grd.DataKeys[grow.RowIndex].Value.ToString();
                    TextBox txtvalue = (TextBox)grow.FindControl("txtvalue");
                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(txtvalue.Text))
                    {

                    }
                    else
                    {

                        if (obj.SP_SINGLEVALUEDATA(2, Convert.ToInt32(id), Convert.ToInt32(ddltablehead.SelectedItem.Value), txtvalue.Text.ToUpper().Trim(), string.Empty, false, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["UserId"]), DateTime.Now, Convert.ToInt32(Session["CompanyId"].ToString()), 0) == 0)
                        {
                            Globals.Message(this.Page, "Record Updated !!");
                            Getadata();
                            txtvalue.Focus();

                        }
                        else
                        {
                            Globals.Message(this.Page, "Record Not Updated !!");
                        }
                    }
                }
            }
            else Globals.Message(Page, "Not Authorized ??");

        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Record Not Updated " + epp.Message);
        }

    }


    private void Getadata()
    {
        try
        {
            if (role.Select.Value)
            {
                Grd.DataSource = obj.SP_GET_SINGLEVALUEDATA(Convert.ToInt32(ddltablehead.SelectedValue));
                Grd.DataBind();
            }
        }
        catch
        {

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTableName.Text != "")
        {
            if (AllMethods.IsSingaleValueData(txtTableName.Text.Trim(), Convert.ToInt32(Session["CompanyId"])))
            {
                Globals.Message(Page, "Already Exist");
                txtTableName.Focus();
                Getdata(txtTableName.Text.ToString().ToUpper());
            }
            else
            {
                if (obj.SP_SINGLEVALUETABLES(1, 0, txtTableName.Text.Trim().ToUpper(), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"])) == 0)
                {
                    Globals.Message(Page, "Record Saved !!");
                    Clear();
                    GetdataAll();
                    getTableHeads();
                }
                else
                {
                    Globals.Message(Page, "Input Error");
                }
            }
        }
        else
        {
            Globals.Message(Page, "Please Enter Heading");
        }
    }
    private void Getdata(string str)
    {
        try
        {
            if (!string.IsNullOrEmpty(str))
            {
                var DATA = from cons in obj.SINGLEVALUETABLEs
                           where cons.ISDELETED == false 
                           && cons.TABLENAME.Contains(str)
                           && cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                           select cons;
                GridView1.DataSource = DATA;
                GridView1.DataBind();
            }
            else
            {
                GetdataAll();
            }
        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Error : " + epp.Message);
        }
    }

    private void GetdataAll()
    {
        try
        {

            var DATA = from cons in obj.SINGLEVALUETABLEs
                       where cons.ISDELETED == false
                       && cons.CompanyId == Convert.ToInt32(Session["CompanyId"])
                       select cons;
            GridView1.DataSource = DATA;
            GridView1.DataBind();


        }
        catch (Exception epp)
        {
            Globals.Message(this.Page, "Error : " + epp.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (AllMethods.IsSingaleValueData(txtTableName.Text.Trim(), Convert.ToInt32(Session["CompanyId"])))
        {
            Globals.Message(Page, "Already Exist");
            txtTableName.Focus();
            Getdata(txtTableName.Text.ToString().ToUpper());
        }
        else
        {
            if (obj.SP_SINGLEVALUETABLES(2, Convert.ToInt32(Hiddenid.Value), txtTableName.Text.Trim().ToUpper(), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"])) == 0)
            {
                Globals.Message(Page, "Updated");
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Clear();
                GetdataAll();
                getTableHeads();
            }
            else
            {
                Globals.Message(Page, "Input Error");
            }
        }
        Getdata(txtTableName.Text.ToString());
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //if (obj.SP_SINGLEVALUETABLES(3, Convert.ToInt32(Hiddenid.Value), txtTableName.Text.Trim(),Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CompanyId"])) == 0)
        //{
        //    Globals.Message(Page, "Deleted");
        //    Clear();
        //    GetdataAll();
        //}
        //else
        //{
        //    Globals.Message(Page, "Input Error");
        //}
        Getdata(txtTableName.Text.ToString());
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtTableName.Text = string.Empty;
        txtSearch.Text = string.Empty;
    }
    protected void Clear()
    {
        txtTableName.Text = string.Empty;
        txtSearch.Text = string.Empty;
    }
    protected void btnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterTableName.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Getdata(txtSearch.Text);
    }
    protected void Grd_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Hiddenid.Value = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
        IEnumerable<SINGLEVALUETABLE> DATA = from pro in obj.SINGLEVALUETABLEs
                                             where pro.ISDELETED == false && pro.STID == Convert.ToInt32(Hiddenid.Value)
                                             select pro;
        txtTableName.Text = DATA.First().TABLENAME.ToString();
        btnSave.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;
    }
}