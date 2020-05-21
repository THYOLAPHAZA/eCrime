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

public partial class UpdateStatusCitizen : System.Web.UI.Page
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

        int mId = 0;
        mId = Convert.ToInt16(Request.QueryString["mid"].ToString());
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        // Filling Citizen Data
        SqlCommand Cmd1 = new SqlCommand("Select * from FoundCitizenMaster where MID = 0 order by FName", Cn);
        SqlDataReader Dr1 = Cmd1.ExecuteReader();
        ddlCriminalList.Items.Clear();
        ListItem mLstItem1 = new ListItem("-- Select --", "");
        ddlCriminalList.Items.Add(mLstItem1);
        while (Dr1.Read())
        {
            ListItem mLstItem = new ListItem(Dr1["FName"].ToString() + " " + Dr1["LName"].ToString(), Dr1["FCID"].ToString());
            ddlCriminalList.Items.Add(mLstItem);
        }
        Dr1.Dispose();
        Cmd1.Dispose();

        lblFirLogId.InnerHtml = Request.QueryString["mid"].ToString();

        SqlCommand Cmd = new SqlCommand("Select * from MissingCitizenMaster where MID = " + mId, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            lblFName.Text = Dr["FName"].ToString();
            lblMName.Text = Dr["MName"].ToString();
            lblLName.Text = Dr["LName"].ToString();
            lblMobileNo.Text = Dr["MobileNo"].ToString();
            lblResiNo.Text = Dr["ResiNo"].ToString();
            lblAddress.Text = Dr["Address"].ToString();
            lblBirthDate.Text = Dr["DOB"].ToString();
            txtDetails.Text = Dr["Details"].ToString();
            if (Dr["Photo"].ToString() != "")
                imgPhoto.ImageUrl = ("photos/Citizen/" + Dr["Photo"].ToString());
            lblLastStatus.InnerHtml = Dr["LastStatus"].ToString();
            lblStatusUpdBy.InnerHtml = Dr["LastStatusUpdBy"].ToString();
            lblStatusUpdDate.InnerHtml = Dr["LastStatusUpdDate"].ToString();
        }
        Dr.Close();
        Cmd.Dispose();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int mFirLogId = Convert.ToInt16(lblFirLogId.InnerHtml.ToString());
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        int iPid = 0;
        if (ddlCriminalList.SelectedIndex > 0)
        {
            String strR = "";
            SqlCommand Cmd = new SqlCommand("Select max(PID) from PhysicalApperanceMaster", Cn);
            strR = Cmd.ExecuteScalar().ToString();
            if (strR != "")
                iPid = Convert.ToInt16(strR);
            iPid = iPid + 1;
            Cmd.Dispose();

            SqlDataAdapter Da1 = new SqlDataAdapter("Select * from PhysicalApperanceMaster where 1=2", Cn);
            SqlCommandBuilder Cb1 = new SqlCommandBuilder(Da1);
            DataTable Ds1 = new DataTable();
            DataRow r;
            Da1.Fill(Ds1);

            r = Ds1.NewRow();
            r["PID"] = iPid;
            r["CID"] = 0;
            r["MID"] = Convert.ToInt16(lblCriminalId.InnerHtml.ToString());
            r["SkinColor"] = txtSkinColor.Text.ToString();
            r["HairColor"] = txtHairColor.Text.ToString();
            r["Height"] = txtHeight.Text.ToString();
            r["Weight"] = txtWeight.Text.ToString();
            r["Scars"] = txtScars.Text.ToString();
            r["PhysicalDeformity"] = txtPhyDeformity.Text.ToString();
            r["AdditianlDetails"] = txtAddDetails.Text.ToString();
            if (lblPhotoName.InnerHtml.ToString() != "")
                r["Photo"] = lblPhotoName.InnerHtml.ToString();

            r["EntryBy"] = Class1.sUserName();
            r["EntryDate"] = DateTime.Now;
            Ds1.Rows.Add(r);
            Da1.Update(Ds1);
            Da1.Dispose();
            Cb1.Dispose();
            Ds1.Dispose();
        }

        SqlDataAdapter Da = new SqlDataAdapter("Select * from MissingCitizenMaster where MID = " + mFirLogId, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataTable Ds = new DataTable();
        DataRow R1;
        Da.Fill(Ds);
        R1 = Ds.Rows[0];
        R1["PID"] = iPid;
        R1["LastStatus"] = ddlFirStatus.SelectedValue.ToString();
        R1["LastStatusUpdBy"] = Class1.sUserName();
        R1["LastStatusUpdDate"] = DateTime.Now;
        Da.Update(Ds);
        Da.Dispose();
        Cb.Dispose();
        Ds.Dispose();

        SqlDataAdapter Da2 = new SqlDataAdapter("Select * from FoundCitizenMaster where FCID = " + Convert.ToInt16(lblCriminalId.InnerHtml.ToString()), Cn);
        SqlCommandBuilder Cb2 = new SqlCommandBuilder(Da2);
        DataTable Ds2 = new DataTable();
        DataRow R2;
        Da2.Fill(Ds2);
        R2 = Ds2.Rows[0];
        R2["MID"] = mFirLogId;
        R2["LastStatus"] = ddlFirStatus.SelectedValue.ToString();
        R2["LastStatusUpdBy"] = Class1.sUserName();
        R2["LastStatusUpdDate"] = DateTime.Now;
        Da2.Update(Ds2);
        Da2.Dispose();
        Cb2.Dispose();
        Ds2.Dispose();

        Response.Redirect("UpdateStatus.aspx");
    }

    protected void ddlFirStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFirStatus.SelectedValue == "Closed")
        {
            if (ddlCriminalList.SelectedIndex != 0)
            {
                lblCriminalId.InnerHtml = ddlCriminalList.SelectedValue.ToString();
                SqlConnection Cn = new SqlConnection();
                Class1.OpenConn(Cn);
                SqlCommand Cmd = new SqlCommand("Select * from FoundCitizenMaster where FCID = " + Convert.ToInt16(lblCriminalId.InnerHtml.ToString()), Cn);
                SqlDataReader Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    txtSkinColor.Text = Dr["SkinColor"].ToString();
                    txtHairColor.Text = Dr["HairColor"].ToString();
                    txtHeight.Text = Dr["Height"].ToString();
                    txtWeight.Text = Dr["Weight"].ToString();
                    txtScars.Text = Dr["Scars"].ToString();
                    txtPhyDeformity.Text = Dr["PhysicalDeformity"].ToString();
                    if (Dr["Photo"].ToString() != "")
                        imgFCPhoto.ImageUrl = ("photos/Citizen/" + Dr["Photo"].ToString());
                    lblPhotoName.InnerHtml = Dr["Photo"].ToString();
                }
                Dr.Close();
                Cmd.Dispose();
            }
            else
            {
                txtSkinColor.Text = "";
                txtHairColor.Text = "";
                txtHeight.Text = "";
                txtWeight.Text = "";
                txtScars.Text = "";
                txtPhyDeformity.Text = "";
                imgFCPhoto.ImageUrl = "~/photos/nopic.jpg";
            }
            trCloseFir.Visible = true;
        }
        else
            trCloseFir.Visible = false;
        btnSubmit.Focus();
    }
}
