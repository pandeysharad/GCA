using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CategoryReligion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void chkCategoryNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkCategoryNo.Checked)
            {
                txtCategoryNo.Enabled = true;
                txtCategoryNo.Focus();
            }
            else
            {
                txtCategoryNo.Enabled = false;
                txtCategory.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void chkReligionNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkReligionNo.Checked)
            {
                txtReligionNo.Enabled = true;
                txtReligionNo.Focus();
            }
            else
            {
                txtReligionNo.Enabled = false;
                txtReligion.Focus();
            }
        }
        catch (Exception ex)
        { }
    }
}