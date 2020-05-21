using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class LogMissing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (this.IsPostBack == true) return;
        lblCurDate.InnerHtml = String.Format("{0:dd MMMM, yyyy}", DateTime.Now);
        mainlogo.InnerHtml = Class1.LogoText;
        title.InnerHtml = Class1.MainHeaderText;
        // --> Checking Cookie
        HttpCookie ckType = HttpContext.Current.Request.Cookies["ckUserType"];
        String UserType = "";
        if (ckType != null)
            UserType = ckType.Value.ToString();
        linksmenu.InnerHtml = Class1.CreateMenu(UserType);
        HttpCookie ckName = HttpContext.Current.Request.Cookies["ckUserName"];
        String UserName = "";
        if (ckName != null && ckName.Value.ToString() != "")
            UserName = ckName.Value.ToString() + "." + " (" + ckType.Value.ToString() + ")";
        lblusername.InnerHtml = UserName;
        footer.InnerHtml = Class1.FooterText;
        if (Class1.sUserName() == "")
            Response.Redirect("Login.aspx");

        lblMode.InnerHtml = Request.QueryString["tag"].ToString();
        if (Request.QueryString["tag"].ToString() == "view")
            btnSubmit.Visible = false;
        lblUserId.InnerText = Request.QueryString["mid"].ToString();
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        String StrSql = "";
        lblType.InnerHtml = Request.QueryString["type"].ToString();
        if (lblType.InnerHtml.ToString() == "dept")
            StrSql = "Select * from FoundCitizenMaster where FCID = " + Convert.ToInt16(lblUserId.InnerText.ToString());
        else
            StrSql = "Select * from MissingCitizenMaster where MID = " + Convert.ToInt16(lblUserId.InnerText.ToString());

        SqlCommand Cmd = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            txtFName.Text = Dr["FName"].ToString();
            txtMName.Text = Dr["MName"].ToString();
            txtLName.Text = Dr["LName"].ToString();
            txtMobileNo.Text = Dr["MobileNo"].ToString();
            txtResiNo.Text = Dr["ResiNo"].ToString();
            txtAddress.Text = Dr["Address"].ToString();
            txtBirthDate.Text = Dr["DOB"].ToString();
            txtDetails.Text = Dr["Details"].ToString();
            if (Dr["Photo"].ToString() != "")
                imgPhoto.ImageUrl = (Server.MapPath ("~/") + "photos/Citizen/" + Dr["Photo"].ToString());
            txtSkinColor.Text = Dr["SkinColor"].ToString();
            txtHairColor.Text = Dr["HairColor"].ToString();
            txtHeight.Text = Dr["Height"].ToString();
            txtWeight.Text = Dr["Weight"].ToString();
            txtScars.Text = Dr["Scars"].ToString();
            txtPhyDeformity.Text = Dr["PhysicalDeformity"].ToString();
        }
        Dr.Close();
        Cmd.Dispose();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false) return;

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        int mId = Convert.ToInt16(lblUserId.InnerText.ToString());
        String StrSql = "";
        if (mId == 0)
        {
            String strR = "";
            if (lblType.InnerHtml.ToString() == "dept")
                StrSql = "Select max(FCID) from FoundCitizenMaster";
            else
                StrSql = "Select max(MID) from MissingCitizenMaster";
            SqlCommand Cmd9 = new SqlCommand(StrSql, Cn);
            strR = Cmd9.ExecuteScalar().ToString();
            Cmd9.Dispose();
            if (strR != "")
                mId = Convert.ToInt16(strR);
            mId = mId + 1;
        }

        if (lblType.InnerHtml.ToString() == "dept")
            StrSql = "Select * from FoundCitizenMaster where FCID = " + mId;
        else
            StrSql = "Select * from MissingCitizenMaster where MID = " + mId;

        SqlDataAdapter Da = new SqlDataAdapter(StrSql, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataTable Ds = new DataTable();
        DataRow r;
        Da.Fill(Ds);

        if (Convert.ToInt16(lblUserId.InnerText.ToString()) == 0)
        {
            r = Ds.NewRow();
            r["CreatedById"] = Class1.iUserId();
            r["CreatedBy"] = Class1.sUserName();
            r["CreatedDate"] = DateTime.Now;
            r["LastStatus"] = "New";
            r["Location"] = Class1.sUserLocation();
            if (lblType.InnerHtml.ToString() == "dept")
            {
                r["FCID"] = mId;
                r["MID"] = 0;
            }
            else
            {
                r["MID"] = mId;
                r["PID"] = 0;
            }
        }
        else
            r = Ds.Rows[0];
        r["FName"] = txtFName.Text.ToString();
        r["MName"] = txtMName.Text.ToString();
        r["LName"] = txtLName.Text.ToString();
        r["MobileNo"] = txtMobileNo.Text.ToString();
        r["ResiNo"] = txtResiNo.Text.ToString();
        r["Address"] = txtAddress.Text.ToString();
        if (txtBirthDate.Text.ToString() != "")
            r["DOB"] = Convert.ToDateTime(txtBirthDate.Text.ToString());
        r["Details"] = txtDetails.Text.ToString();
        if (Fupd.FileName.ToString() != "")
        {
            r["Photo"] = mId + Fupd.FileName.ToString();
            Fupd.SaveAs(Server.MapPath("~/") + "photos/Citizen/" + mId.ToString() + Fupd.FileName.ToString());
        }
        r["SkinColor"] = txtSkinColor.Text.ToString();
        r["HairColor"] = txtHairColor.Text.ToString();
        r["Height"] = txtHeight.Text.ToString();
        r["Weight"] = txtWeight.Text.ToString();
        r["Scars"] = txtScars.Text.ToString();
        r["PhysicalDeformity"] = txtPhyDeformity.Text.ToString();

        if (Convert.ToInt16(lblUserId.InnerText.ToString()) == 0)
            Ds.Rows.Add(r);
        Da.Update(Ds);
        Da.Dispose();
        Cb.Dispose();
        Ds.Dispose();

        if (lblType.InnerHtml.ToString() == "dept")
            Response.Redirect("ManageMissingCitizen.aspx");
        else
            Response.Redirect("ViewComplaint.aspx");
    }
}
