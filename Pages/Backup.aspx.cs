using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Backup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBackUp_Click(object sender, EventArgs e)
    {
        AllMethods.BackupDataBase();
        Globals.Message(Page, "DataBase Backup Stored On Drived");
        lblmsg.BackColor = System.Drawing.Color.Red;
        lblmsg.Text = "DataBase Backup Stored On Drived";
    }
}