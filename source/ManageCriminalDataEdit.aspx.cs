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

public partial class ManageCriminalDataEdit : System.Web.UI.Page
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

        int mID = 0;
        if (Request.QueryString["id"].ToString() != "")
            mID = Convert.ToInt16(Request.QueryString["id"].ToString());
        lblId.InnerText = mID.ToString();

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand("Select * from CriminalMaster where CID = " + mID, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            txtFName.Text = Dr["FName"].ToString();
            txtMName.Text = Dr["MName"].ToString();
            txtLName.Text = Dr["LName"].ToString();
            txtAddress.Text = Dr["RelAddress"].ToString();
            txtMobileNo.Text = Dr["RelMobileNo"].ToString();
            txtResiNo.Text = Dr["RelResiNo"].ToString();
            txtBirthDate.Text = Dr["DOB"].ToString();
            txtSkinColor.Text = Dr["SkinColor"].ToString();
            txtHairColor.Text = Dr["HairColor"].ToString();
            txtHeight.Text = Dr["Height"].ToString();
            txtWeight.Text = Dr["Weight"].ToString();
            txtScars.Text = Dr["Scars"].ToString();
            txtPhyDeformity.Text = Dr["PhysicalDeformity"].ToString();
            if (Dr["Photo"].ToString() != "")
                imgPhoto.ImageUrl = ("photos/Dept/" + Dr["Photo"].ToString());
        }
        Dr.Close();
        Cmd.Dispose();
        if (Request.QueryString["tag"].ToString() == "view")
            btnSubmit.Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false) return;

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        int mID = Convert.ToInt16(lblId.InnerText.ToString());
        int mNewId = 0;
        if (mID == 0)
        {
            String strR = "";
            SqlCommand Cmd = new SqlCommand("Select Max(CID) from CriminalMaster", Cn);
            strR = Cmd.ExecuteScalar().ToString();
            if (strR != "")
                mNewId = Convert.ToInt16(strR);
            mNewId = mNewId + 1;
        }

        SqlDataAdapter Da = new SqlDataAdapter("Select * from CriminalMaster where CID = " + mID, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataTable Ds = new DataTable();
        DataRow r;
        Da.Fill(Ds);

        if (mID == 0)
        {
            r = Ds.NewRow();
            r["CID"] = mNewId;
            r["CreatedBy"] = Class1.sUserName();
            r["CreatedDate"] = DateTime.Now;
        }
        else
            r = Ds.Rows[0];
        r["FName"] = txtFName.Text.ToString();
        r["MName"] = txtMName.Text.ToString();
        r["LName"] = txtLName.Text.ToString();
        if (txtBirthDate.Text.ToString() != "")
            r["DOB"] = Convert.ToDateTime(txtBirthDate.Text.ToString());
        r["RelAddress"] = txtAddress.Text.ToString();
        r["RelMobileNo"] = txtMobileNo.Text.ToString();
        r["RelResiNo"] = txtResiNo.Text.ToString();
        r["SkinColor"] = txtSkinColor.Text.ToString();
        r["HairColor"] = txtHairColor.Text.ToString();
        r["Height"] = txtHeight.Text.ToString();
        r["Weight"] = txtWeight.Text.ToString();
        r["Scars"] = txtScars.Text.ToString();
        r["PhysicalDeformity"] = txtPhyDeformity.Text.ToString();
        if (Fupd.FileName.ToString() != "")
        {
            r["Photo"] = mNewId + Fupd.FileName.ToString();
            Fupd.SaveAs(Server.MapPath("~/") + "photos/Dept/" + mNewId.ToString() + Fupd.FileName.ToString());
        }

        if (mID == 0)
            Ds.Rows.Add(r);
        Da.Update(Ds);
        Da.Dispose();
        Cb.Dispose();
        Ds.Dispose();

        Response.Redirect("ManageCriminalData.aspx");
    }
}
