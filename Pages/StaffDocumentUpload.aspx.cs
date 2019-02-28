using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Pages_StaffDocumentUpload : System.Web.UI.Page
{
    string msg;
    DataClassesDataContext obj = new DataClassesDataContext();
    public int SrNo = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();

            if (Session["DocId"] != null)
            {
                var DATA1 = from Cons in obj.StaffDocs
                            where Cons.DocId == Convert.ToInt32(Session["DocId"])
                            select Cons;
                txtDocumentName.Text = DATA1.First().DocName;
                ImgDoc.ImageUrl = DATA1.First().DocType;
                Session["ImgDocName"] = DATA1.First().DocType;
            }
        }
    }

    private void BindGrid()
    {
        var DATA = from Cons in obj.StaffDocs
                   where Cons.StaffId == Convert.ToInt32(Session["StaffPId"])
                   select Cons;
        GridStudentDocs.DataSource = DATA;
        GridStudentDocs.DataBind();
    }
    protected void btnDocUpload_Click(object sender, EventArgs e)
    {
        try
        {
            //if (Session["DocId"] != null)
            //{
            //    File.Delete(Server.MapPath(Session["ImgDocName"].ToString()));
            //}
            string filename = Path.GetFileName(DocUpload.PostedFile.FileName);
            string ext = Path.GetExtension(filename);
            string DocName = "StaffId_" + Session["txtStaffId"].ToString() + "_" + txtDocumentName.Text.ToUpper() + ext;
            if (DocName != "")
            {
                if (File.Exists(Server.MapPath("~/StaffDocuments/" + DocName)) == false)
                {
                    DocUpload.SaveAs(Server.MapPath("~/StaffDocuments/" + DocName));
                    ImgDoc.ImageUrl = "~/StaffDocuments/" + DocName;
                    Session["ImgDocName"] = "~/StaffDocuments/" + DocName;
                }
                else
                {
                    msg = "A picture is alrady exists with same name..Please rename selected picture before upload";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
            else
            {
                msg = "Please select image first... ";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnDocmSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDocumentName.Text != "")
            {
                if (Session["ImgDocName"] != null)
                {
                    if (Session["DocId"] == null)
                    {
                        if (obj.SP_StaffDocs(1, 0, Convert.ToInt32(Session["StaffPId"]), txtDocumentName.Text.ToUpper(), Session["ImgDocName"].ToString(), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"])) == 0)
                        {
                            clear();
                        }
                    }
                    else
                    {
                        if (obj.SP_StaffDocs(2, Convert.ToInt32(Session["DocId"]), Convert.ToInt32(Session["StaffPId"]), txtDocumentName.Text.ToUpper(), Session["ImgDocName"].ToString(), Convert.ToInt32(Session["CompanyId"]), Convert.ToInt32(Session["UserId"])) == 0)
                        {
                            clear();
                        }
                    }
                }
                else
                {
                    msg = "Please select image first... ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
                }
            }
            else
            {
                msg = "Please enter document name... ";
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageShow", "MessageShow('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnDocmRefresh_Click(object sender, EventArgs e)
    {
        clear();
    }

    private void clear()
    {
        txtDocumentName.Text = "";
        ImgDoc.ImageUrl = null;
        Session["ImgDocName"] = null;
        Session["DocId"] = null;
        BindGrid();
    }
    protected void GridStudentDocs_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Session["DocId"] = GridStudentDocs.DataKeys[e.NewSelectedIndex].Value;
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        { }
    }
    protected void DownloadFile(object sender, EventArgs e)
    {
        string filePath = (sender as ImageButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }
    protected void Delete_click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        if (obj.SP_StaffDocs(3, Convert.ToInt32(id), Convert.ToInt32(1), txtDocumentName.Text, "", 0, 0) == 0)
        {
            clear();
        }
    }
    protected void GridStudentDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridStudentDocs.PageIndex = e.NewPageIndex;
        BindGrid();
        GridStudentDocs.DataBind();
    }
}